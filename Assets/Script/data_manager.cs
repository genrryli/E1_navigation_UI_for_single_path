using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.IO;
using System;
using System.Text;
using UnityStandardAssets.ImageEffects;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class data_manager : MonoBehaviour
{
    [Header("基础信息")]
    public GameObject sporter;
    public string ID;   
    public string mode;
    public string count;
    public InputField inputID;
    public Dropdown input_mode;
    public Dropdown input_count;
    public Button confirm;
    public Text show_id;
    public Text show_mode;

    [Header("导航模式")]
    public GameObject navi_band;
    public GameObject mini_map;
    public GameObject clue_icon;

    [Header("发现场景物体的准确率")]
    public Text find_obj_rating;
    public GameObject ui_quiz1;
    public GameObject ui_quiz2;
    public GameObject view_pot;
    public Transform obj_location;
    public Text[] t_option;
    public GameObject[] special_obj;
    private GameObject new_obj;
    private int random_num=0;
    private int correct_num = 0;
    private int find_num = 0;
    //private float correct_rate = 0;
    private bool ui_on = false;

    [Header("时间、距离、效率")]
    public Text distance;
    public Text time;
    private float S = 0;
    private float Sn = 0;
    private float timer2 = 0;
    private Vector3 start_location;
    private float time_loger = 0;
    private float time_log_now;

    [Header("碰撞次数和位置")]
    public Text coli_times;
    public Text coli_position;
    public Text block_coli_times;
    public Text block_coli_position;
    private int coli_n=0;
    private int block_coli_n = 0;
    private ArrayList posi;
    private ArrayList block_posi;


    // Use this for initialization
    void Start()
    {
        if (sporter!=null) { start_location = sporter.transform.position; }    
        posi = new ArrayList();
        block_posi = new ArrayList();
        if (game_manager.gm.gamestate == game_manager.game_state.outset) { PlayerPrefs.DeleteAll(); }
        
    }

    // Update is called once per frame
    void Update()
    {
        ID = PlayerPrefs.GetString("_id");
        mode = PlayerPrefs.GetString("_mode");
        count = PlayerPrefs.GetString("_count");
        if (game_manager.gm.gamestate == game_manager.game_state.ready) { select_mode(); }
        if (game_manager.gm.gamestate == game_manager.game_state.outset) { basic_data(); return; }

        if (game_manager.gm.gamestate == game_manager.game_state.playing)
        {
            show_id.text = ID;
            show_mode.text = mode;
            time.text = time_data().ToString();
            distance.text = distance_data().ToString();
            coli_times.text = coli_n.ToString();
            if (coli_n >= 1) { coli_position.text = posi[coli_n - 1].ToString(); }
            block_coli_times.text = block_coli_n.ToString();
            if (block_coli_n >= 1) { block_coli_position.text = block_posi[block_coli_n - 1].ToString(); }
            find_obj_rating.text = ((float)correct_num / 3).ToString();
        }

        if (game_manager.gm.gamestate == game_manager.game_state.quiz&&!ui_on)
        {
            open_ui_quiz();
            ui_on = true;
        }

        if (game_manager.gm.gamestate == game_manager.game_state.finish)
        {
            Write("C:\\Users\\user\\Desktop\\"+ID+"-"+mode+"-"+count+".txt");
            Application.CaptureScreenshot("C:\\Users\\user\\Desktop\\"+ID+"-"+mode+"-"+count+".png");
        }

    }

    //-------------------------------------------------------------------------输入基础信息
    void basic_data()
    {
        string[] modelist = { "没有选择模式", "无导航", "寻路光带","小地图","提示图标" };
        string[] countlist = { "没有选择次数", "预测试","第一次测试", "第二次测试" };
        PlayerPrefs.SetString("_id", inputID.text);
        PlayerPrefs.SetString("_mode", modelist[input_mode.value]);
        PlayerPrefs.SetString("_count", countlist[input_count.value]);
        if (inputID == null || input_mode.value == 0 || input_count.value == 0) { confirm.interactable = false; } else { confirm.interactable = true; }
    }

    //-------------------------------------------------------------------------选择模式
    void select_mode()
    {
        navi_band.SetActive(false);
        mini_map.SetActive(false);
        clue_icon.SetActive(false);
        if (count == "预测试") { return; }
        if (mode == "寻路光带") { navi_band.SetActive(true); }
        else if (mode == "小地图") { mini_map.SetActive(true); }
        else if (mode == "提示图标") { clue_icon.SetActive(true); }
    }

    //-------------------------------------------------------------------------距离和时间
    float distance_data()
    {
        if (game_manager.gm.gamestate != game_manager.game_state.playing) { return Sn; }
        Vector3 late_location = sporter.transform.position;//更新位置
        timer2 += Time.deltaTime;
        if (timer2 >= 0.1f)
        {
            S = Vector3.Distance(start_location, late_location);//计算距离
            Sn = Sn + S;
            start_location = late_location;
            timer2 = 0;
        }
        return Sn;
    }


    public float time_data()
    {
        time_loger += Time.deltaTime;
        if (game_manager.gm.gamestate == game_manager.game_state.playing)
        {
            time_log_now = time_loger;
        }
        else { time_log_now = time_log_now; time_loger = 0; }

        return time_log_now;
    }

    //--------------------------------------------------------------------------碰撞检测
    public void coli_times_data(string obj)
    {
        if(obj=="wall") coli_n++;
        if (obj == "block") block_coli_n++;
    }

    public void coli_posi_data(Vector3 read)
    {
        posi.Add(read);
        GameObject.Find("managers").GetComponent<show_coli_posi>().show_p(read,"wall");
    }

    public void block_coli_posi_data(Vector3 read)
    {
        block_posi.Add(read);
        GameObject.Find("managers").GetComponent<show_coli_posi>().show_p(read,"block");
    }

    //--------------------------------------------------------------------------准确率
    void open_ui_quiz()
    {
        Destroy(new_obj, 0.01f);
        if (random_num >= special_obj.Length) {view_pot.SetActive(false); ui_quiz1.SetActive(false);ui_quiz2.SetActive(false); game_manager.gm.gamestate = game_manager.game_state.finish; return; }
        view_pot.SetActive(true);
        ui_quiz1.SetActive(true);
        ui_quiz2.SetActive(false);
        new_obj = Instantiate(special_obj[random_num], obj_location.position, special_obj[random_num].transform.rotation) as GameObject;
        new_obj.transform.FindChild("Canvas").gameObject.SetActive(false);
        int random_button = UnityEngine.Random.Range(0, 4);
        string num = special_obj[random_num].transform.FindChild("Canvas").FindChild("Text").GetComponent<Text>().text;
        for(int i = 0; i <= 3; i++)
        {
            t_option[i].text = "" + (int.Parse(num) - (random_button - i));
        }       
    }

    public void quest(bool yes)
    {
        if (yes)
        {
            find_num++;
            ui_quiz1.SetActive(false);
            ui_quiz2.SetActive(true);
        }
        else { random_num++; open_ui_quiz();}
    }

    public void quest(int data)
    {       
        string num = special_obj[random_num].transform.FindChild("Canvas").FindChild("Text").GetComponent<Text>().text;
        if (data == int.Parse(num)) { correct_num++; }
        random_num++;
        open_ui_quiz();
    }



    //---------------------------------------------------------------------------写出数据
    public void Write(string path)
    {
        FileStream fs = new FileStream(path, FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        //开始写入
        sw.WriteLine("ID---------------" + ID);
        sw.WriteLine("mode-------------" + mode);
        sw.WriteLine("time-------------"+time_data().ToString());
        sw.WriteLine("distance---------" + distance_data().ToString());
        sw.WriteLine("collide_wall-----"+coli_n.ToString());
        sw.WriteLine("collide_block----" + block_coli_n.ToString());
        sw.WriteLine("find_number------" + find_num.ToString());
        sw.WriteLine("correct_number---" + correct_num.ToString());
        sw.WriteLine("correct_rate-----" + ((float)correct_num / 3).ToString());
        sw.WriteLine("coli_wall--------");
        for (int i = 0; i <= coli_n - 1; i++)
        {
            sw.Write(posi[i].ToString());
        }
        sw.WriteLine();
        sw.WriteLine("coli_block--------");
        for (int i = 0; i <= block_coli_n - 1; i++)
        {
            sw.Write(block_posi[i].ToString());
        }
        //清空缓冲区
        sw.Flush();
        //关闭流
        sw.Close();
        fs.Close();
      
    }
}