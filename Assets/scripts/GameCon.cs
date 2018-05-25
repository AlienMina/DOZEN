﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.AI;
using UnityEngine.UI;
//这个是用来记全局变量和公共事件的，默认挂在Main Camera上
public class GameCon : MonoBehaviour {

    public bool isDOZEN = true;//现在是否控制的是主角，是的时候控制主角，否的时候是小精灵
    public bool isHidden = false;//主角是否进行了藏匿，默认是没有
    public AudioSource hideAudio;
    public bool isKillButton = false;
    public bool showKillButton = false;
    public bool playerDied = false;

    public bool isElevator = false;//是否在升降梯上
    public bool moveable = true;//是否可以播放走路的动画

    public int playerHealth = 6;
    public Slider blood;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (isKillButton)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().isStopped = true;

        }
        else
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<NavMeshAgent>().isStopped=false;
        }

        blood.value = playerHealth;
        
	}


    /// <summary>
    /// 这套……应该是控制头顶按钮显隐的
    /// </summary>
    public void showButton()
    {
        Debug.Log("showKillButton");
        showKillButton = true;
    }
    public void hideButton()
    {
        Debug.Log("hideKillButton.");
        showKillButton = false;
    }

    /// <summary>
    /// 这套应该是控制人物击杀时强制静止一小下的。
    /// </summary>
    public void killButton()
    {
        isKillButton = true;
    }

    public void stopKillButton()
    {
        isKillButton = false;
    }
    public void DozenHide()
    {
        hideAudio.Play();
        isHidden = true;
    }
    public void DozenLeaveHidden()
    {
        hideAudio.Play();
        isHidden = false;
        
    }
    public void Exit()
    {
        Application.Quit();
    }
    public void back2Menu()
    {
        SceneManager.LoadScene("start", LoadSceneMode.Single);
    }

    public void RestartLevel()
    {
        string restartScene= SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(restartScene, LoadSceneMode.Single);
    }
}
