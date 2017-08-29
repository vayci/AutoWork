/*
 * $邮箱：zhwei@grgbanking.com
 * 用户： zhwei
 * 日期: 2017-08-27
 * 时间: 15:39
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace AutoWork
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private AForge.Controls.VideoSourcePlayer videoSourcePlayer1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button button4;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.videoSourcePlayer1 = new AForge.Controls.VideoSourcePlayer();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.button3 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.button4 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// videoSourcePlayer1
			// 
			this.videoSourcePlayer1.Location = new System.Drawing.Point(12, 12);
			this.videoSourcePlayer1.Name = "videoSourcePlayer1";
			this.videoSourcePlayer1.Size = new System.Drawing.Size(476, 367);
			this.videoSourcePlayer1.TabIndex = 0;
			this.videoSourcePlayer1.Text = "videoSourcePlayer1";
			this.videoSourcePlayer1.VideoSource = null;
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(19, 441);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(93, 23);
			this.button1.TabIndex = 1;
			this.button1.Text = "连接至摄像头";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(219, 441);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(93, 23);
			this.button2.TabIndex = 2;
			this.button2.Text = "手动人脸抓拍";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.Button2Click);
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(384, 441);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(93, 23);
			this.button3.TabIndex = 3;
			this.button3.Text = "开启自动抓拍";
			this.button3.UseVisualStyleBackColor = true;
			this.button3.Click += new System.EventHandler(this.Button3Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(114, 391);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(207, 21);
			this.textBox1.TabIndex = 4;
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(12, 395);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 5;
			this.label1.Text = "当前检测相似度:";
			// 
			// button4
			// 
			this.button4.Location = new System.Drawing.Point(372, 390);
			this.button4.Name = "button4";
			this.button4.Size = new System.Drawing.Size(116, 23);
			this.button4.TabIndex = 6;
			this.button4.Text = "开启/关闭 预览";
			this.button4.UseVisualStyleBackColor = true;
			this.button4.Click += new System.EventHandler(this.Button4Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(500, 489);
			this.Controls.Add(this.button4);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.videoSourcePlayer1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "AutoWork By Red";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
