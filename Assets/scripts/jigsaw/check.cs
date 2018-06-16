using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class check : MonoBehaviour {

    public GameCon gameCon;

    public jigsawTotal jigsaw;

    public GameObject jigsawBig;//大的拼图
    public GameObject jigsawChest;//保险箱
    public GameObject emptyButton;//空的挡屏幕的按钮
    public AudioSource showAudio;//账单出现的音效
    public GameObject bill;//账单的大图
    public dialog dialog1;//第一段对话

    bool i = false;
    bool j = false;

    float oldTime;
    float time;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (jigsaw.finishJigsaw&& !i) //如果拼图已经完成了，并且一套流程没有跑完
        {
            if (!j)
            {
                oldTime = Time.time;
                j = true;
            }
            showCheckandWhy();
        }

        if (dialog1.finishDialog)
        {
            bill.SetActive(false);
            emptyButton.SetActive(false);
            gameCon.haveBill = true;
            this.gameObject.SetActive(false);
        }
	}

    void showCheckandWhy()
    {
        emptyButton.SetActive(true);
        jigsawBig.SetActive(false);
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
        showAudio.Play();
        time = Time.time;
        if (time - oldTime >= 1.5f)
        {           
            jigsawChest.SetActive(false);
            
            bill.SetActive(true);
            dialog1.startDialog();
            i = true; 
        }        
    }
}
