using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTE : MonoBehaviour {

    
    public float qteTime = 1;//每个qte的反应时间
    public float qteAbleTime = 0.6f;//qte的正确按键时间
    public GameObject[] qteIcons=new GameObject[3];//三个不同的QTE按键
    public shakecamera shake;//镜头震动
    public QTEaccounts qteAccounts;//结算存放处

    public GameObject player;

    int[] qteSeries=new int[3] { 0, 0, 0 };//记录动作的序列
    
    bool qteStart=false;//qte是否开始
    float oldTime;//计时器开始时的时间
    float time;//计时器
    int num= 0;
    bool wait4finish = false;

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
        player.GetComponent<turnFaces>().pause = true;//角色动画的改变
    }
    
    void qte()
    {
        time = Time.time;//刷新时间
        if (time - oldTime >= qteTime)//如果已经超时了的情况
        {
            //这个是为了确保最后一次的动画可以正常触发，所以放在这里结算，否则直接结算会立刻顶掉最后一次QTE的震动屏幕和主角动画
            if (wait4finish)
            {
                finish();
            }
            else
            {
                fail();
            }
        }
        else//没有超时的情况，检测按键
        {
            if (Input.GetKeyUp(KeyCode.Alpha1)){
                if (time - oldTime >= qteAbleTime)//已经进入了
                {
                    player.GetComponent<turnFaces>().playAttackAnim();
                    shake.shake(2,0.2f,45);
                    qteSeries[num] = 1;
                    num++;
                    if (num > 2)//如果已经是最后一个按键
                    {
                        wait4finish = true;
                        //finish();
                        Debug.Log("wait4finish");
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
                    player.GetComponent<turnFaces>().playAttackAnim();
                    shake.shake(2, 0.2f, 45);
                    qteSeries[num] = 2;
                    num++;
                    if (num > 2)//如果已经是最后一个按键
                    {
                        wait4finish = true;
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
                    player.GetComponent<turnFaces>().playAttackAnim();
                    shake.shake(2, 0.2f, 45);
                    qteSeries[num] = 3;
                    num++;
                    if (num > 2)//如果已经是最后一个按键
                    {
                        wait4finish = true;
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
        shake.shake(10, 0.2f, 45);
        clearIcons();
        qteStart = false;
        num = 0;
        qteSeries = new int[3] { 0, 0, 0 };
        player.GetComponent<turnFaces>().pause = false;//角色动画的改变
        Debug.Log("此处应有敌人暴走");
    }

    void finish()
    {
            wait4finish = false;
            clearIcons();
            qteStart = false;
            num = 0;
            //此处应有结算过程
            Debug.Log(qteSeries[0] + "" + qteSeries[1] + "" + qteSeries[2]);
            player.GetComponent<turnFaces>().pause = false;//角色动画的改变
            accounts();
            qteSeries = new int[3] { 0, 0, 0 };
        
    }

    void clearIcons()
    {
        for (int i = 0; i < qteIcons.Length; i++)
        {
            qteIcons[i].SetActive(false);
        }
    }

    void accounts()
    {
        int qteFinalNum = qteSeries[0] * 100 + qteSeries[1] * 10 + qteSeries[2];
        if (qteFinalNum == 123)//ABC 直接杀死敌人
        {
            qteAccounts.enemyDiedImmediately();
        }
        else if (qteFinalNum == 231)
        {
            qteAccounts.enemyDizzy();
        }
        else if (qteFinalNum == 312)
        {
            qteAccounts.enemyFriendly();
        }
        else if (qteFinalNum == 132 || qteFinalNum == 213 || qteFinalNum == 321)
        {
            qteAccounts.enemyCrazy();
        }
        else
        {
            qteAccounts.enemyAngry();
        }
    }
}
