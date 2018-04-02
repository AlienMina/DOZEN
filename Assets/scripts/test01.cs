using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test01 : MonoBehaviour
{
    private Transform Cam_transform;
    private Vector3 Cam_pos0;
    public float smoothTime = 0.5F;
    private Vector3 velocity = Vector3.zero;


    public float cameraMoveSpeed = 5f;//移动速度
//public GameObject Camera;

    private float tempSpeed;//阻尼速度

    Vector2 first;    //记录鼠标点击的初始位置  
    Vector2 second;   //记录鼠标移动时的位置  
    bool dragging = false;   //标记是否鼠标在滑动 

    public void firstPos()
    {
        Cam_transform=Camera.main.transform;
        Cam_pos0 = Cam_transform.position;  //保存摄像机初始坐标  
        first = Event.current.mousePosition; //记录鼠标按下的位置 
    }


    public void secondPos()
    {
        
        dragging = true;
        //second = new Vector2();
        //Event e = Event.current;
        //Debug.Log(e);
        second = Input.mousePosition;//记录鼠标拖动的位置 
        //Debug.Log(Event.current.mousePosition);
        Debug.Log(second);
        Vector2 slideDirection = second - first;
        Debug.Log(slideDirection);

        Cam_transform.position = Vector3.SmoothDamp(Cam_transform.position, slideDirection, ref velocity, smoothTime);  //平滑移动摄像机
    }


}
