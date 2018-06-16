using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brokenChandelierQTE : MonoBehaviour {
    /// <summary>
    /// 这个是拆吊灯的狂按空格的QTE
    /// </summary>
    public GameCon gameCon;
    public brokenChandelier brokenProgram;
    public Slider progressBar;//进度条
    public float qteTime = 1;
    
    float time;//QTE计时用
    float oldTime;//QTE计时用

    public float final = 1;//最终要达到的数值
    public bool isThere;//主角是否处于范围内

    public GameObject hint;//QTE狂按空格的提示
    public GameObject enemy;//需要消失的敌人
    public GameObject block;

    bool startQTE=false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startQTE)
        {
            QTE();
        }
	}

    public void StartQTE()
    {
        startQTE = true;
        oldTime = Time.time;//开始计时
        progressBar.gameObject.SetActive(true);
        hint.SetActive(true);
    }

    void QTE()
    {
        time = Time.time;
        if(time - oldTime >= qteTime)//如果超时了
        {
            finish();
        }
        else
        {
            //在没超时的情况下
            //达到了最终目标的分数
            if (progressBar.value == final)
            {
                clear();
            }
            else
            {
                if (isThere)//主角在范围内的时候
                {
                    //否则，如果按下了空格键
                    if (Input.GetKeyUp(KeyCode.Space))
                    {
                        progressBar.value += 0.04f;
                        Debug.Log(progressBar.value);
                        oldTime = Time.time;//按下空格时刷新最新时间
                        brokenProgram.shakeCamera.shake(3, 0.2f, 45);
                    }
                }
            }
        }
    }

    void finish()
    {
        startQTE = false;
        if (progressBar.value >= 0.2)
        {
            progressBar.value -= 0.2f;
        }
        else
        {
            progressBar.value = 0;
        }
        progressBar.gameObject.SetActive(false);
        hint.SetActive(false);
        
    }
    void clear()
    {
        startQTE = false;
        progressBar.gameObject.SetActive(false);
        hint.SetActive(false);
        brokenProgram.startBroken();
        enemy.SetActive(false);
        block.SetActive(false);
        gameCon.enemyStop = false;
    }
}
