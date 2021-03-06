﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraFollowing : MonoBehaviour
{
    public Transform player;
    public Transform machelf;
    public GameCon GameContent;

    public float adjustHeight = 5f;

    public float smoothRate = 0.5f;

    private Transform thisTransform;
    private Vector2 velocity;

    bool haveBeenWait;
    float lastTime;
    float thisTime;

    // Use this for initialization  
    void Start()
    {
        lastTime = Time.time;
        thisTransform = transform;
        velocity = new Vector2(0.5f, 0.5f);
    }

    // Update is called once per frame  
    void Update()
    {

        if (haveBeenWait)
        {
            Vector2 newPos2D = Vector2.zero;
            //Mathf.SmoothDamp平滑阻尼，这个函数用于描述随着时间的推移逐渐改变一个值到期望值，这里用于随着时间的推移（0.5秒）让摄像机跟着角色的移动而移动  

            //角色判断
            if (GameContent.isDOZEN)
            {
                newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, player.position.x, ref velocity.x, smoothRate);
                newPos2D.y = Mathf.SmoothDamp(thisTransform.position.y, player.position.y + adjustHeight, ref velocity.y, smoothRate);
            }
            else
            {
                newPos2D.x = Mathf.SmoothDamp(thisTransform.position.x, machelf.position.x, ref velocity.x, smoothRate);
                newPos2D.y = Mathf.SmoothDamp(thisTransform.position.y, machelf.position.y, ref velocity.y, smoothRate);
            }


            Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);
            //Vector3.Slerp 球形插值，通过t数值在from和to之间插值。返回的向量的长度将被插值到from到to的长度之间。time.time此帧开始的时间（只读）。这是以秒计算到游戏开始的时间。也就是说，从游戏开始到到现在所用的时间。  
            transform.position = Vector3.Slerp(transform.position, newPos, Time.time);
        }
        else
        {
            thisTime = Time.time;
            if (thisTime - lastTime >= 1.5f)
            {
                haveBeenWait = true;
            }
        }

    }
}
