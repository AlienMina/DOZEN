using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class menu : MonoBehaviour {

    public GameCon gameCon;//要用到停止敌人和检测是否拿到了账单
    public GameObject[] menuList;//每一页内容
    public GameObject[] buttonList;//三个标签
    public Sprite[] longButton;//长的标签
    public Sprite[] shortButton;//短的标签

    public Image changeAlphaImage;
    public Text changeAlphaText;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickButton(int num)
    {
        gameCon.enemyStop = true;//停止敌人
        //所有标签回到短状态，所有页面消失
        for(int i = 0; i < buttonList.Length; i++)
        {
            buttonList[i].GetComponent<Image>().sprite = shortButton[i];
        }
        for(int j = 0; j < menuList.Length; j++)
        {
            menuList[j].SetActive(false);
        }
        //指定标签变长，指定页面出现
        buttonList[num].GetComponent<Image>().sprite = longButton[num];
        menuList[num].SetActive(true);

        //检查菜单
        if (gameCon.haveBill)
        {
            changeAlphaImage.color = new Color(1, 1, 1, 1);
            changeAlphaText.color = new Color(0.2f, 0.2f, 0.2f, 1);
        }
    }

    public void enemyMoveAgain()
    {
        gameCon.enemyStop = false;
        gameCon.fuckActiveSelf = false;
    }

    public void enemyStop()
    {
        gameCon.enemyStop = true;
        gameCon.fuckActiveSelf = true;
    }
    public void showBill(GameObject bill)
    {
        if (changeAlphaImage.color.a != 0)
        {
            bill.SetActive(true);
        }
    }
}
