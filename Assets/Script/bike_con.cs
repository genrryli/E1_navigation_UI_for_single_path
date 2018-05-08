using UnityEngine;
using System.Collections;

public class bike_con : MonoBehaviour {

    public float turning_scale;
    public float riding_scale=200;
    public GameObject bike_head;
    public GameObject head_direction;
    public Transform r_center;

    private float real_speed;
    private float real_angle;
    private int _reversal = 1;
    private Rigidbody rigid;
    private Transform start_t;
    private bool io;

    // Use this for initialization
    void Start()
    {
        rigid = GetComponent<Rigidbody>();
        start_t = gameObject.transform;
        real_speed = 0;
        io = gameObject.GetComponent<motion_data>().open_io;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //龙头固定角度偏转
        Vector3 angle_dif = new Vector3(0, real_angle, 0) - bike_head.transform.localEulerAngles;
        bike_head.transform.RotateAround(r_center.position, r_center.up, angle_dif.y);
        Vector3 angle_dif_2 = new Vector3(0, real_angle, 0) - head_direction.transform.localEulerAngles;
        head_direction.transform.Rotate(0, angle_dif.y, 0);

        if (game_manager.gm.gamestate == game_manager.game_state.playing|| game_manager.gm.gamestate == game_manager.game_state.warm_up) { motion(); }
    }

    void Update()
    {
        if (!io&& (game_manager.gm.gamestate == game_manager.game_state.playing|| game_manager.gm.gamestate == game_manager.game_state.warm_up))
        {
            float y = Input.GetAxis("Vertical");
            float x = Input.GetAxis("Horizontal");
            real_speed = 5 * y;
            real_angle = 60 * x;
        }
    }

    void motion()
    {
        //车体前进，以及前进速度
        gameObject.transform.Translate(0,0,1 * real_speed * riding_scale / 50);

        //车体转向，及转向速度
        float rotate_speed = real_angle * turning_scale * real_speed;
        if (real_speed > 0) { transform.Rotate(Vector3.up * rotate_speed * _reversal); }
    }

    public float real_speed_
    {
        get { return real_speed; }
        set { real_speed = value; }
    }

    public int reversal
    {
        get { return _reversal; }
        set { _reversal = value; }
    }

    public float real_angle_
    {
        get { return real_angle; }
        set { real_angle = value; }
    }

}
