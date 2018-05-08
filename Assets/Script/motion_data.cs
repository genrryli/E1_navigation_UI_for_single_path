using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO.Ports;
using System.Threading;
using System;

public class motion_data : MonoBehaviour {

    //串口相关参数
    public bool open_io;
    public string portname = "COM2";
    public int portspeed = 115200;
    private SerialPort ArduinoPort;

    //线程相关参数
    private Thread tport;
    private bool on_thread=false;

    //获取数据
    public bike_con bike;
    public float real_speed;
    private string _big_button;

	void Start () {
        portname = PlayerPrefs.GetString("com");
        open_io = Convert.ToBoolean(PlayerPrefs.GetInt("io"));
        ArduinoPort = new SerialPort();
        if(PlayerPrefs.GetString("com")!=""){ArduinoPort.PortName = portname;}//串口。使用电脑的22号串口
        ArduinoPort.BaudRate = portspeed;//串口。波特率是9600
        if (open_io) { ArduinoPort.Open(); }//打开串口
        on_thread = true;
        tport = new Thread(new ThreadStart( writedata));//定义线程
        tport.Start();//打开新线程
    }
	
	void FixedUpdate () {
        if(!open_io){return;}
        if (!tport.IsAlive)
        {
            tport = new Thread(new ThreadStart(writedata));//定义线程
            tport.Start();//打开新线程}
        }
        if (Time.frameCount % 120 == 0) { System.GC.Collect(); }//清理缓存      
        if (open_io) { bike.real_speed_ = real_speed; }
    }

    void writedata()//新的线程的函数、专门读取数据
    {
        while (on_thread)
        {
            string read;         
            read = ArduinoPort.ReadLine();//读取字符串
            ArduinoPort.DiscardInBuffer();//清理缓存区数据
            bike.real_angle_ = get_angle(read);
            _big_button = get_button(read);
            real_speed = get_speed(read);
            //if(real_speed>=5.0f){real_speed=5.0f;}//限制最大速度
            Debug.Log("" + read);
        }  
    }

    void OnApplicationQuit()//退出程序时所执行的函数
    {
		close_port();
    }

	public void close_port()
	{
        if(!open_io){return;}
		on_thread = false;//跳出死循环
		if (tport.IsAlive) { tport.Abort(); }//关闭线程
		ArduinoPort.Close();//关闭串口
		Debug.Log("---thread killed---port closed---");
	}


    float get_angle(string read)//将字符串转换为角度数据
    {
        float a;
        float data = float.Parse(devide_data(read,0));
        if (data > 512) { a = (data - 512) / 511 * 135; }
        else if (data < 511) { a = (data - 511) / 511 * 135; }
        else { a = 0; }
        return -a;
    }

    string get_button(string read)//将字符串转换为按钮数据
    {
        string button_event;
        button_event = devide_data(read,1);
        return button_event ;
    }

    public string big_button
    {
        get { return _big_button; }
    }

    float get_speed(string read)
    {
        float speed= float.Parse(devide_data(read, 2)); 
        return speed;
    }

    string devide_data(string data,int num)
    {
        string[] Data = data.Split(';');
        return Data[num];
    }
}
