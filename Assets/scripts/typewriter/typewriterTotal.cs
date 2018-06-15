using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class typewriterTotal : MonoBehaviour {

    public int keyword;//正确的密码
    public GameObject emptyButton;//防止误触的空按钮

    public Image greenLight;//绿灯，对错灯，可能会变红
    public Image yellowLight;//黄灯，删除灯
    public Sprite redLightPic;//红灯的图片
    public Sprite greenLightPic;//绿灯的图片

    public GameObject gear;//齿轮
    public GameObject head;//刷头
    public GameObject paperTape;//纸带
    public Image roller;//滚轮
    public Sprite roller1;
    public Sprite roller2;

    public Sprite[] numSprites;//这里是打在纸带上的数字的样本
    public Image[] paperTapeNums;//这里是数字上的四个纸带

    Vector3 paperStartPosition;//纸带的初始位置
    float recordHelper = 1000;//帮助记录纸带数字的计量值
    int paperNumber = 0;//纸带上的数字的记录

    [HideInInspector] public bool finishTypeWriter = false;

	// Use this for initialization
	void Start () {
        paperStartPosition = paperTape.transform.position;//记录纸带的初始位置
        Init();
	}
	
    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        paperTape.transform.position = paperStartPosition;
        paperNumber = 0;//归零记录数字
        recordHelper = 1000;//辅助值回归初始
        for(int i = 0; i < paperTapeNums.Length; i++)//消除所有的纸带数字
        {
            paperTapeNums[i].color = new Color(1, 1, 1, 0);
        }
        greenLight.color = new Color(1, 1, 1, 0);
        StartCoroutine(yellowLightShine());
        emptyButton.SetActive(false);

    }
    IEnumerator yellowLightShine()
    {
        yellowLight.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(0.1f);
        yellowLight.color = new Color(1, 1, 1, 0);
    }
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 外部按键的时候引用的
    /// </summary>
    /// <param name="num"></param>
    public void pressButton(int num)
    {
        recordNumber(num);//记录数字
        StartCoroutine(typeAnima(num));//显示数字        
        
    }

    /// <summary>
    /// 记录数字
    /// </summary>
    void recordNumber(int num)
    {
        paperNumber += (int)(num * recordHelper);
        recordHelper /= 10;
    }

    /// <summary>
    /// 打字的动画整个过程
    /// </summary>
    IEnumerator typeAnima(int num)
    {
        emptyButton.SetActive(true);
        head.transform.position = new Vector3(head.transform.position.x, head.transform.position.y + 45, head.transform.position.z);
        roller.sprite = roller2;
        gear.transform.Rotate(new Vector3(0,0,40));        
        yield return new WaitForSeconds(0.3f);
        setNum(num);
        head.transform.position = new Vector3(head.transform.position.x, head.transform.position.y - 45, head.transform.position.z);
        roller.sprite = roller1;
        gear.transform.Rotate(new Vector3(0, 0, 40));
        emptyButton.SetActive(false);
        checkIfFinish();
    }

    /// <summary>
    /// 显示数字和移动纸带
    /// </summary>
    void setNum(int num)
    {
        if (recordHelper == 100)//第一次打印
        {
            paperTapeNums[0].sprite = numSprites[num];
            paperTapeNums[0].color = new Color(1, 1, 1, 1);
        }
        else if (recordHelper == 10)//第二次
        {
            paperTapeNums[1].sprite = numSprites[num];
            paperTapeNums[1].color = new Color(1, 1, 1, 1);
        }
        else if (recordHelper == 1)//第三次
        {
            paperTapeNums[2].sprite = numSprites[num];
            paperTapeNums[2].color = new Color(1, 1, 1, 1);
        }
        else//最后一次
        {
            Debug.Log(recordHelper);
            paperTapeNums[3].sprite = numSprites[num];
            paperTapeNums[3].color = new Color(1, 1, 1, 1);
        }
        if(recordHelper>=0.1)
            paperTape.transform.position = new Vector3(paperTape.transform.position.x - 45, paperTape.transform.position.y, paperTape.transform.position.z);

    }

    void checkIfFinish()
    {
        if (recordHelper < 1)//如果已经是最后一次了
        {
            if (paperNumber == keyword)//如果密码正确
            {
                //亮绿灯，执行后面的操作
                greenLight.sprite = greenLightPic;
                greenLight.color = new Color(1, 1, 1, 1);
                finishTypeWriter = true;
            }
            else
            {
                //亮红灯，并且不允许继续按键
                greenLight.sprite = redLightPic;
                greenLight.color = new Color(1, 1, 1, 1);
                emptyButton.SetActive(true);
            }
        }
    }
}
