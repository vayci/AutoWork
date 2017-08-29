/*
 * $邮箱：vayci2012@163.com
 * 用户： vayci
 * 日期: 2017-08-27
 * 时间: 15:39
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using AForge;
using AForge.Controls;
using AForge.Imaging;
using AForge.Video;
using System.Text;
using System.Timers;
using System.Diagnostics;
using System.Drawing.Imaging;
using Newtonsoft.Json.Linq;
using AForge.Video.DirectShow;
using System.Windows.Forms;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Configuration;

namespace AutoWork
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		
		[DllImport("user32.dll", EntryPoint = "PostMessage")]
        public static extern int PostMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);
        [DllImport("User32.dll ", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int SendMessage(IntPtr HWnd, uint Msg, int WParam, int LParam);
       
        public const int WM_SYSCOMMAND = 0x112;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const uint WM_SYSCOMMAND2 = 0x0112;
        public const uint SC_MAXIMIZE2 = 0xF030;
      
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        public static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);
        
        
        System.Windows.Forms.Timer QTimer = null;
        Boolean timerFlag =false;
		public string res;
		
		
		FilterInfoCollection videoDevices;
		VideoCaptureDevice videoSource;
		public int selectedDeviceIndex = 0;
		
		public static string apiKey = ConfigurationManager.AppSettings["apiKey"];
        public static string apiSecret = ConfigurationManager.AppSettings["apiSecret"];
        
		public MainForm()
		{
			InitializeComponent();
			if (!Directory.Exists(@""+ConfigurationManager.AppSettings["cachePath"]))  
			{   
			    Directory.CreateDirectory(@""+ConfigurationManager.AppSettings["cachePath"]);  
			} 
		}
		
		
		private void Button1Click(object sender, EventArgs e)
        {
           videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            selectedDeviceIndex = 0;
            videoSource = new VideoCaptureDevice(videoDevices[selectedDeviceIndex].MonikerString);//connect camera
            
            videoSource.VideoResolution = videoSource.VideoCapabilities[selectedDeviceIndex];
            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();  
        }
		
		private void Button2Click(object sender, EventArgs e)
        {
			faceMatching();
          
        }
		
		private void Button3Click(object sender, EventArgs e){
			if (videoSource == null){
        		MessageBox.Show("请先连接摄像头!");
        		  return;
        	}
			if(!timerFlag){
				if(QTimer==null){
					int int_base = 1000;  
					int int_time = int_base * Convert.ToInt32(ConfigurationManager.AppSettings["interval"]);
		            System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();
		            timer.Tick += new System.EventHandler(this.faceMatchingTask);
		            timer.Interval=int_time;
		            timer.Enabled = true;
		            timer.Start();
		            QTimer = timer;
				}else{
					QTimer.Start();
				}
				button3.Text = "关闭自动抓拍";
				timerFlag = true;
			}else{
				QTimer.Stop();
				button3.Text = "开启自动抓拍";
				timerFlag = false;
			}
		}
		
		private	void Button4Click(object sender, EventArgs e)
		{
			if(videoSourcePlayer1.Visible){
				videoSourcePlayer1.Visible = false;
			}else{
				videoSourcePlayer1.Visible = true;
			}
			
		}

        private void faceMatchingTask(object source, EventArgs e)
        {
            faceMatching();
        }
 
        private void faceMatching()
        {
        	if (videoSource == null){
        		MessageBox.Show("请先连接摄像头!");
        		  return;
        	}
              
            Bitmap bitmap =  new Bitmap(videoSourcePlayer1.GetCurrentVideoFrame());
            string fileName = DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss-ff") + ".jpg";
            bitmap.Save(@""+ConfigurationManager.AppSettings["cachePath"] + fileName, ImageFormat.Png);
            bitmap.Dispose();
            
            var client = new Baidu.Aip.Face.Face(apiKey,apiSecret);
            var image1 = File.ReadAllBytes(@""+ConfigurationManager.AppSettings["cachePath"] + fileName);
            var image2 = File.ReadAllBytes(@""+ConfigurationManager.AppSettings["imgPath"]);
          
            var images = new byte[][] {image1, image2};
            var result = client.FaceMatch(images);
           
            JToken  num ;
            try {
            	    num = result["result"][0];
            } catch (Exception) {
            	textBox1.Text="未检测到人脸";
            	openApplication();
            	return;
            }
          
            StringBuilder sb = new StringBuilder();
            foreach(JProperty jp in num)
			{
            	if(jp.Name=="score"){
            		if(Convert.ToDouble(jp.Value)>Convert.ToDouble(ConfigurationManager.AppSettings["threshold"])){
            		res = jp.Value.ToString();
           			 this.textBox1.Text =res;  
           			 MiniMizeAppication(ConfigurationManager.AppSettings["broswer"]);
            		}else{
            			openApplication();
            		}
            	}
			}
        	
        	
        }
        
         private void MiniMizeAppication(string processName)
        {
            Process[] processs = Process.GetProcessesByName(processName);
            if (processs != null)
            {
                foreach (Process p in processs)
                { 
                    IntPtr handle = FindWindow(null, p.MainWindowTitle);
                    //IntPtr handle = FindWindow("YodaoMainWndClass",null);
                    PostMessage(handle, WM_SYSCOMMAND, SC_MINIMIZE, 0);
                }
            }
        }
        
     	 private void openApplication()
     	 {
         	Process[] processes = Process.GetProcessesByName(ConfigurationManager.AppSettings["broswer"]);
            if (processes.Length > 0)
            {
                IntPtr handle = processes[0].MainWindowHandle;
                SendMessage(handle, WM_SYSCOMMAND2, new IntPtr(SC_MAXIMIZE2), IntPtr.Zero);	// 最大化
                SwitchToThisWindow(handle, true);	// 激活
            }
         }
         
		private void MainFormClosed(object sender, EventArgs e)
		{
			if (videoSource != null){
						MessageBoxButtons messButton = MessageBoxButtons.YesNo;
						 DialogResult dr = MessageBox.Show("是否最小化继续运行?", "退出系统", messButton);
						 
						 if (dr == DialogResult.Yes)
						 {
							Application.Exit(); 
						 }
						 else if(dr == DialogResult.No)
						{
							System.Environment.Exit(0);  
						}
			}else{
				System.Environment.Exit(0);  
			}
		}
		
	}
}
