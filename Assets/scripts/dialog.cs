using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

[AddComponentMenu("dialog/add a Dialog Script")]
public class dialog : MonoBehaviour {

    public GameObject dialogWindow;
    public GameObject dialogText;
    public dialoTxtRead dialogTxt;

    public Sprite dozenWindow;
    public Sprite machelfTWindow;

    public float waitTimes=10f;//等待的时间

    public bool isStop = true;//是否需要角色停下，默认停下
    public NavMeshAgent playerAgent;

    int state = 2;

    float lastTime;
    float thisTime;

    [System.Serializable]
    public struct textInfo
    {
        public int dialogType;
        public int textNum;
    };

    public textInfo[] textinfo;

	// Use this for initialization
	void Start () {
        lastTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        if (state ==0)
        {
            thisTime = Time.time;
            if (thisTime - lastTime >= waitTimes)
            {
                state = 1;
            }
        }
	}

    void resetTime()
    {
        lastTime = Time.time;
    }

    public IEnumerator DialogLoop()
    {
        //让玩家立刻停下
        float oldSpeed = playerAgent.speed;
        if (isStop)
        {
            playerAgent.speed = 0;
            playerAgent.destination = playerAgent.gameObject.GetComponent<Transform>().position;
        }
        
        //这是一个循环……
        for (int i = 0; i < textinfo.Length; i++)
        {
            
            yield return StartCoroutine(loadDialog(textinfo[i].dialogType, textinfo[i].textNum));
            resetTime();//重置时间
            state = 0;
            Debug.Log("show dialog.");            
            yield return new WaitUntil(() => state == 1);
            Debug.Log("destroy dialog.");
            state = 3;
            yield return StartCoroutine(destroyDialog());
            //yield return new WaitForSeconds(0.01f);
            

        }
        //恢复速度
        playerAgent.speed = oldSpeed;

        state = 2;
    }

    /// <summary>
    /// 根据编号加载对话框和对应的文字
    /// </summary>
    public IEnumerator loadDialog(int dialogType,int textNum)
    {
        //根据dialogType决定对话框的形状 0=dozen 1=machelfT 2...后面的可以自行添加吧。
        if (dialogType == 0)
        {
            dialogWindow.gameObject.GetComponent<Image>().sprite = dozenWindow;
            
        }
        else if (dialogType == 1)
        {
            dialogWindow.gameObject.GetComponent<Image>().sprite = machelfTWindow;
        }
        /*
        else if (dialogType == 2)
        {
           //这里就自己添加吧，如果有更多的对话框需求
        }
        */

        //接下来是读text
        dialogText.gameObject.GetComponent<Text>().text = dialogTxt.dialogArrayAndroid[textNum];

        //协程走起，出特效
        dialogWindow.transform.localScale = new Vector3(1, 0.2f, 1);
        dialogText.transform.localScale = new Vector3(1, 0.2f, 1);
        yield return new WaitForSeconds(0.03f);
        dialogWindow.transform.localScale = new Vector3(1, 0.4f, 1);
        dialogText.transform.localScale = new Vector3(1, 0.4f, 1);
        yield return new WaitForSeconds(0.03f);
        dialogWindow.transform.localScale = new Vector3(1, 0.6f, 1);
        dialogText.transform.localScale = new Vector3(1, 0.6f, 1);
        yield return new WaitForSeconds(0.03f);
        dialogWindow.transform.localScale = new Vector3(1, 0.8f, 1);
        dialogText.transform.localScale = new Vector3(1, 0.8f, 1);
        yield return new WaitForSeconds(0.03f);
        dialogWindow.transform.localScale = new Vector3(1, 1, 1);
        dialogText.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.03f);

    }


    public IEnumerator destroyDialog()
    {
        //协程走起，手写消失特效
        dialogWindow.transform.localScale = new Vector3(1, 0.8f, 1);
        dialogText.transform.localScale = new Vector3(1, 0.8f, 1);
        yield return new WaitForSeconds(0.03f);
        dialogWindow.transform.localScale = new Vector3(1, 0.6f, 1);
        dialogText.transform.localScale = new Vector3(1, 0.6f, 1);
        yield return new WaitForSeconds(0.03f);
        dialogWindow.transform.localScale = new Vector3(1, 0.4f, 1);
        dialogText.transform.localScale = new Vector3(1, 0.4f, 1);
        yield return new WaitForSeconds(0.03f);
        dialogWindow.transform.localScale = new Vector3(1, 0.2f, 1);
        dialogText.transform.localScale = new Vector3(1, 0.2f, 1);
        yield return new WaitForSeconds(0.03f);
        dialogWindow.transform.localScale = new Vector3(1, 0, 1);
        dialogText.transform.localScale = new Vector3(1, 0, 1);
        yield return new WaitForSeconds(0.03f);
    }


    /// <summary>
    /// 鼠标点击时的事件，立刻终止等待
    /// </summary>
    public void desdroyImmediately()
    {
        state = 1;
    }

    /// <summary>
    /// 调用它开始对话
    /// </summary>
    public void startDialog()
    {
        StartCoroutine(DialogLoop());
    }
}



