using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour {

    
    public float qteTime = 1;//每个qte的反应时间
    public float qteAbleTime = 0.6f;//qte的正确按键时间
    public GameObject[] qteIcons=new GameObject[3];//三个不同的QTE按键
    public shakecamera shake;//镜头震动
    public QTEaccounts qteAccounts;//结算存放处

    int[] qteSeries=new int[3] { 0, 0, 0 };//记录动作的序列
    
    bool qteStart=false;//qte是否开始
    float oldTime;//计时器开始时的时间
    float time;//计时器
    int num= 0;

	// Use this for initialization
	void Start () {
        //这里重置三个QTE按键，让它们不显示
        clearIcons();
	}
	
	// Update is called once per frame
	void Update () {
        if (qteStart)
        {
            qte();
        }
	}

    public void startQTE()
    {
        qteStart = true;
        oldTime = Time.time;//开始计时
        num = 0;
        qteIcons[0].SetActive(true);
    }
    
    void qte()
    {
        time = Time.time;//刷新时间
        if (time - oldTime >= qteTime)//如果已经超时了的情况
        {
            fail();
        }
        else//没有超时的情况，检测按键
        {
            if (Input.GetKeyUp(KeyCode.Alpha1)){
                if (time - oldTime >= qteAbleTime)//已经进入了
                {
                    shake.shake();
                    qteSeries[num] = 1;
                    num++;
                    if (num > 2)//如果已经是最后一个按键
                    {
                        finish();
                    }
                    else
                    {
                        //下一个QTE，并且重置时间
                        changeQTEplace();
                        Debug.Log("restart timer");
                        oldTime = Time.time;
                    }
                }
                else
                {
                    fail();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha2))
            {
                if (time - oldTime >= qteAbleTime)//已经进入了
                {
                    shake.shake();
                    qteSeries[num] = 2;
                    num++;
                    if (num > 2)//如果已经是最后一个按键
                    {
                        finish();
                    }
                    else
                    {
                        //下一个QTE，并且重置时间
                        changeQTEplace();
                        Debug.Log("restart timer");
                        oldTime = Time.time;
                    }
                }
                else
                {
                    fail();
                }
            }
            else if (Input.GetKeyUp(KeyCode.Alpha3))
            {
                if (time - oldTime >= qteAbleTime)//已经进入了
                {
                    shake.shake();
                    qteSeries[num] = 3;
                    num++;
                    if (num > 2)//如果已经是最后一个按键
                    {
                        finish();
                    }
                    else
                    {
                        //下一个QTE，并且重置时间
                        changeQTEplace();
                        Debug.Log("restart timer");
                        oldTime = Time.time;
                    }
                }
                else
                {
                    fail();
                }
            }
        }
    }

    void changeQTEplace()//改变当前活跃的QTE按键
    {
        clearIcons();
        qteIcons[num].SetActive(true);
    }
    void fail()
    {
        clearIcons();
        qteStart = false;
        num = 0;
        qteSeries = new int[3] { 0, 0, 0 };
        Debug.Log("此处应有敌人暴走");
    }

    void finish()
    {
        clearIcons();
        qteStart = false;
        num = 0;
        //此处应有结算过程
        Debug.Log(qteSeries[0] +""+ qteSeries[1] +""+ qteSeries[2]);
        Debug.Log("此处应该有结算");
        qteSeries = new int[3] { 0, 0, 0 };
    }

    void clearIcons()
    {
        for (int i = 0; i < qteIcons.Length; i++)
        {
            qteIcons[i].SetActive(false);
        }
    }
}
