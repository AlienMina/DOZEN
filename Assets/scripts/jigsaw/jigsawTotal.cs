using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class jigsawTotal : MonoBehaviour {
    /*
     * 这里是拼图的总控位置，每一块小拼图都只负责在点击的时候传一个自身位置进来执行一次判断
     */
    // Use this for initialization

    public int[] jigsawNum = new int[9];//存储拼图的编号
    public Button[] jigsawPieces=new Button[9];//拼图的物体储存，按顺序放进去
    public int emptyPlace = 9;//默认9号拼图是空的

    [HideInInspector] public bool finishJigsaw;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    /// <summary>
    /// 判断这块拼图的四个方向上是否有变化
    /// </summary>
    public void placeJudgement(int moveNum)
    {
        int placeNumber=getPlace(moveNum);
        //检查这个位置的上下左右是否有是空白的拼图
        //左侧一块
        if (placeNumber-1>=0 && jigsawNum[placeNumber - 1] == emptyPlace)
        {
            //地图地块的移动
            Debug.Log(jigsawPieces[jigsawNum[placeNumber - 1]].transform.position);
            Vector3 place = jigsawPieces[jigsawNum[placeNumber - 1]].transform.position;
            jigsawPieces[jigsawNum[placeNumber - 1]].transform.position = jigsawPieces[jigsawNum[placeNumber]].transform.position;
            jigsawPieces[jigsawNum[placeNumber]].transform.position = place;

            //左右交换编号
            jigsawNum[placeNumber] = jigsawNum[placeNumber - 1];
            jigsawNum[placeNumber - 1] = moveNum;         

            
        }
        //右侧一块
        else if (placeNumber+1<9 && jigsawNum[placeNumber + 1] == emptyPlace)
        {
            //地图地块的移动
            Debug.Log(jigsawPieces[jigsawNum[placeNumber + 1]].transform.position);
            Vector3 place = jigsawPieces[jigsawNum[placeNumber + 1]].transform.position;
            jigsawPieces[jigsawNum[placeNumber + 1]].transform.position = jigsawPieces[jigsawNum[placeNumber]].transform.position;
            jigsawPieces[jigsawNum[placeNumber]].transform.position = place;

            //左右交换编号
            jigsawNum[placeNumber] = jigsawNum[placeNumber + 1];
            jigsawNum[placeNumber + 1] = moveNum;
        }
        //上方一块
        else if (placeNumber-3>=0 && jigsawNum[placeNumber - 3] == emptyPlace)
        {
            //地图地块的移动
            Debug.Log(jigsawPieces[jigsawNum[placeNumber - 3]].transform.position);
            Vector3 place = jigsawPieces[jigsawNum[placeNumber - 3]].transform.position;
            jigsawPieces[jigsawNum[placeNumber - 3]].transform.position = jigsawPieces[jigsawNum[placeNumber]].transform.position;
            jigsawPieces[jigsawNum[placeNumber]].transform.position = place;

            //上下交换编号
            jigsawNum[placeNumber] = jigsawNum[placeNumber - 3];
            jigsawNum[placeNumber - 3] = moveNum;
        }
        //下方一块
        else if (placeNumber+3<9 && jigsawNum[placeNumber + 3] == emptyPlace)
        {
            //地图地块的移动
            Debug.Log(jigsawPieces[jigsawNum[placeNumber + 3]].transform.position);
            Vector3 place = jigsawPieces[jigsawNum[placeNumber + 3]].transform.position;
            jigsawPieces[jigsawNum[placeNumber + 3]].transform.position = jigsawPieces[jigsawNum[placeNumber]].transform.position;
            jigsawPieces[jigsawNum[placeNumber]].transform.position = place;

            //上下交换编号
            jigsawNum[placeNumber] = jigsawNum[placeNumber + 3];
            jigsawNum[placeNumber + 3] = moveNum;
        }
        checkIfFinish();
    }

    /// <summary>
    /// 根据传进来的小图片的标号来判断小图片的位置序号
    /// </summary>
    public int getPlace(int num)
    {
        int i = 0;
        for(i = 0; i < jigsawNum.Length; i++)
        {
            if (jigsawNum[i] == num)
            {
                break;
            }

        }
        return i;
    }

    void checkIfFinish()
    {
        int finalNum = 0;
        for(int i = 0; i < jigsawNum.Length; i++)
        {
            if (jigsawNum[i] == i)
                finalNum++;
        }
        if (finalNum == 9)
        {
            Debug.Log("finish jigsaw.");
            //在这里存放拼好以后的事件
            finishJigsaw = true;
        }
    }
}
