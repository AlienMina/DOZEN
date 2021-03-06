﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class turnFaces : MonoBehaviour {

    public GameCon gameCon;
    public Animator anim;
    public NavMeshAgent agent;
    public AudioSource audioSource;
    public GameObject mask;

    public bool pause = false;
    public bool face = true;//true--right,false--left.
    bool turnmask = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!pause)
        {

                if (agent.velocity.x < 0)
                {
                    if (gameCon.moveable)
                    {
                        anim.Play("dozenWalkLeft");
                        audioSource.volume = 1;
                        face = false;
                        turnMask();
                        //Debug.Log("left.");
                    }
                    else
                    {
                        anim.Play("dozenWaitRight");
                        audioSource.volume = 0;
                    }
                }
                else if (agent.velocity.x > 0)
                {
                    if (gameCon.moveable)
                    {
                        anim.Play("dozenWalkRight");
                        audioSource.volume = 1;
                        face = true;
                    turnMask();
                    //Debug.Log("right.");
                    }
                    else
                    {
                        anim.Play("dozenWaitRight");
                        audioSource.volume = 0;
                    }
            }
                else if (agent.velocity.x == 0)
                {
                    turnmask = false;
                    if (face)
                    {
                        anim.Play("dozenWaitRight");
                    }
                    else
                    {
                        anim.Play("dozenWaitLeft");
                    Debug.Log("waitLeft");
                    }

                    audioSource.volume = 0;
                    //Debug.Log("wait.");
                }
            
        }
    }

    void turnMask()
    {
        if (face)
        {
            mask.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            mask.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        turnmask = true;
    }

    public void playAttackAnim(int num,int place)
    {
        //num:攻击的名称 1 敲 2 拆 3 电 place：攻击的位置 1 上 2 中 3 下
        if (face)
        {
            if (num == 0 && place == 0)
            {
                anim.Play("dozenAttackRight");
            }
            else
            {
                if (num == 1)//敲
                {
                    if (place == 1)
                    {
                        anim.Play("dozenAttackRightUpQiao");
                    }
                    else if (place == 2)
                    {
                        anim.Play("dozenAttackRightMiddleQiao");
                    }
                    else
                    {
                        anim.Play("dozenAttackRightDownQiao");
                    }
                }
                else if (num == 2)//拆
                {
                    if (place == 1)
                    {
                        anim.Play("dozenAttackRightUpChai");
                    }
                    else if (place == 2)
                    {
                        anim.Play("dozenAttackRightMiddleChai");
                    }
                    else
                    {
                        anim.Play("dozenAttackRightDownChai");
                    }
                }
                else if (num == 3)
                {
                    if (place == 1)
                    {
                        anim.Play("dozenAttackRightUpDian");
                    }
                    else if (place == 2)
                    {
                        anim.Play("dozenAttackRightMiddleDian");
                    }
                    else
                    {
                        anim.Play("dozenAttackRightDownDian");
                    }
                }
            }
            
        }
        else
        {
            if (num == 0 && place == 0)
            {
                anim.Play("dozenAttackLeft");
            }
            else
            {
                if (num == 1)//敲
                {
                    if (place == 1)
                    {
                        anim.Play("dozenAttackLeftUpQiao");
                    }
                    else if (place == 2)
                    {
                        anim.Play("dozenAttackLeftMiddleQiao");
                    }
                    else
                    {
                        anim.Play("dozenAttackLeftDownQiao");
                    }
                }
                else if (num == 2)//拆
                {
                    if (place == 1)
                    {
                        anim.Play("dozenAttackLeftUpChai");
                    }
                    else if (place == 2)
                    {
                        anim.Play("dozenAttackLeftMiddleChai");
                    }
                    else
                    {
                        anim.Play("dozenAttackLeftDownChai");
                    }
                }
                else if (num == 3)
                {
                    if (place == 1)
                    {
                        anim.Play("dozenAttackLeftUpDian");
                    }
                    else if (place == 2)
                    {
                        anim.Play("dozenAttackLeftMiddleDian");
                    }
                    else
                    {
                        anim.Play("dozenAttackLeftDownDian");
                    }
                }
            }
        }
        
    }

    public void playerHitAnima(float x)
    {
        pause = true;
        if (face)//面向右侧
        {
            if (x - this.gameObject.transform.position.x < 0)//敌人在左边
            {
                anim.Play("dozenHitRightBehind");
            }
            else
            {
                anim.Play("dozenHitRightFront");
            }

        }
        else
        {
            if (x - this.gameObject.transform.position.x < 0)//敌人在右边
            {
                anim.Play("dozenHitLeftBehind");
            }
            else
            {
                anim.Play("dozenHitLeftFront");
            }
        }
        pause = false;
    }


}
