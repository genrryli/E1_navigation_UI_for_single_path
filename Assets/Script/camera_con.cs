using UnityEngine;
using System.Collections;

public class camera_con : MonoBehaviour {

    public float rotate_speed = 20;
    //public GameObject rotate_target;

    private Camera myCamera;
    private float mouse_x;

    // Use this for initialization
    void Start () {
        myCamera = GetComponentInChildren<Camera>();
        mouse_x = myCamera.transform.eulerAngles.x;
	}
	
	// Update is called once per frame
	void Update () {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        float r = Input.GetAxisRaw("Mouse X");
        float u = Input.GetAxisRaw("Mouse Y");

        rotate_camera_x(r);
        rotate_camera_y(u);
        //rotate_at();

    }

    void rotate_camera_x(float r)
    {
        transform.Rotate(Vector3.up, r * rotate_speed);
    }

    void rotate_camera_y(float u)
    {
        mouse_x -= u * rotate_speed;           //计算当前摄像机的旋转角度
        myCamera.transform.localEulerAngles = new Vector3(mouse_x, 0.0f, 0.0f);	//设置摄像机的旋转角度
    }

    //void rotate_at()
    //{
    //    if (Input.GetKey(KeyCode.Q))
    //    {
    //        transform.RotateAround(rotate_target.transform.position, rotate_target.transform.up, rotate_speed * Time.deltaTime);
    //    }

    //    if (Input.GetKey(KeyCode.E))
    //        transform.RotateAround(rotate_target.transform.position, rotate_target.transform.up, -rotate_speed * Time.deltaTime);
    //}
}
