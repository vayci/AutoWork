# AutoWork
通过人脸识别，自动最小化或最大化某个程序。<br>
算法使用百度人脸比对API

配置文件app.conf 编译后为AutoWork.exe.config

		<add key="broswer" value="notepad++"/> 
            关闭程序的进程名称，可通过任务管理器查看
    
		<add key="interval" value="5"/> 
            抓拍时间间隔，单位秒(s)，由于调用百度人脸对比API会耗时2~3秒，建议设置3秒以上
    
		<add key="threshold" value="70"/> 
            人脸比对阈值，高于此阈值将触发最小化或最大化程序
    
		<add key="imgPath" value="C:\temp\1.jpg"/> 
            比对目标照片路径
    
		<add key="cachePath" value="C:\temp\cache\"/> 
            摄像头抓拍照片存储路径
    
		<add key="apiKey" value="hmkG2UIjblnlp53uA5UBsSSD"/> 
            百度人脸识别api Key 
    
		<add key="apiSecret" value="N8vdWhT9vsNqyOX9fcmvGIem2MXmz9aK"/> 
            百度人脸识别api Secret

仅支持本地摄像头，暂不支持网络摄像头<br>

<a href="http://ai.baidu.com/tech/face">获取百度api key和secret </a>
-----------------------------------------------------------------------------------------------------------------------------------
# AutoWork
auto minimize or maximize the window by face recognition.<br>
algorithm support by Baidu face recognition API.

 configuration file named 'app.conf' , after compile named 'AutoWork.exe.config'.

		<add key="broswer" value="notepad++"/> 
           this process you want to minimize it's window. you can get the name from	taskmanager.
    
		<add key="interval" value="5"/> 
           camera interval(s)，invoke API of Baidu will cost 2~3s，recommended settings is more than 3s.
    
		<add key="threshold" value="70"/> 
            threshold of face matching ， similarity over this value will trigger minimize or maximize event.
    
		<add key="imgPath" value="C:\temp\1.jpg"/> 
            the target face photo path.
    
		<add key="cachePath" value="C:\temp\cache\"/> 
            Snap photos path.
    
		<add key="apiKey" value="hmkG2UIjblnlp53uA5UBsSSD"/> 
            Baidu face recognition api Key 
    
		<add key="apiSecret" value="N8vdWhT9vsNqyOX9fcmvGIem2MXmz9aK"/> 
            Baidu face recognition api Secret

only support local camera , don't support IPC now.<br>

<a href="http://ai.baidu.com/tech/face">Get Baidu face recognition key and secret</a>
