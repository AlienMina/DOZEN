using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machelfEnergy : MonoBehaviour {

    public int energy = 5;
    public GameObject attr;
    public GameObject dizzy;

    public int powerState = 0;//小精灵的能力种类，默认为0，是吸引。 1-晕眩 2-排斥
    [HideInInspector]
    public int whenHide;

    public bool isEnergyPoint;

    public machelfEnergy whoseEnergy;

    public int changeStateEnergyInit = 2;//切换状态时状态初始自带的能量点数

    int oldEnergy=0;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //这个是挂在每个小眼睛上的时候的判断，因为大的图标没戳这个，不会引起这个判断……
        if (isEnergyPoint)
        {
            hideEnergyPoint();
        }
        //在不是小眼睛的情况下（也就是它是大眼睛呗！），要进行能量的检测，来决定技能变化的问题
        else
        {
            if (energy == 0)
            {
                clearEnergy();
            }
        }
	}

    public void energyDown()
    {
        energy--;
    }
    public void energyUp()
    {
        if(energy<5)
        energy++;
    }

    public void noEnergy()
    {
        energy = 0;
    }

    /// <summary>
    /// 这里是点击按键之后连接到的位置……把状态判断放到这里
    /// </summary>
    public void machAtta()
    {
        //此处应该是有状态检测
        checkState();       
    }

    /// <summary>
    /// 吸引
    /// </summary>
    /// <returns></returns>
    IEnumerator machelfAttraction()
    {
        //在有能量的情况下
        if (energy > 0)
        {
            energy--;
            this.GetComponent<AudioSource>().Play();
            attr.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            attr.SetActive(false);

        }
    }

    /// <summary>
    /// 晕眩
    /// </summary>
    IEnumerator machelfDizzy()
    {
        if (energy > 0)
        {
            energy--;
            dizzy.SetActive(true);
            this.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(0.1f);
            dizzy.SetActive(false);


        }
    }

    /// <summary>
    /// 这是给噪音能量点显隐用的
    /// </summary>
    public void hideEnergyPoint()
    {
        if (whoseEnergy.energy <= whenHide)
        {
            this.gameObject.SetActive(false);
            Debug.Log(this.name);
        }
    }


    /// <summary>
    /// 状态检测，然后运行相对应状态的小精灵行动
    /// </summary>
    void checkState()
    {
        if (powerState == 0)//默认动作：吸引
        {
           StartCoroutine(machelfAttraction());
        }
        else if (powerState == 1)//眩晕
        {
            StartCoroutine(machelfDizzy());
        }
        else if (powerState == 2)//排斥
        {
            //此处放置排斥
        }
    }

    void changeState(int changeStateNum)
    {
        if (powerState == 0)
        {
            oldEnergy = energy;//当目前的状态是吸引的时候，存储能量
        }
        powerState = changeStateNum;//切换状态
        energy = changeStateEnergyInit;//更新能量点数
        changeUISprite();//改变图标的UI--未完成

    }

    void changeUISprite()//改变UI，清零按键的显示和消失
    {

    }

    /// <summary>
    /// 能量清空时，更改状态的判断
    /// </summary>
    void clearEnergy()
    {
        if (powerState != 0)//在不是吸引的时候
        {
            powerState = 0;//切换吸引状态
            energy = oldEnergy;//更新能量的数量
            oldEnergy = 0;//以防万一，清空一下存储的能量
            changeUISprite();//此处应有图标更新
        }
    }

}
