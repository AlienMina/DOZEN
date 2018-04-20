using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class dialoTxtRead : MonoBehaviour {

    //文本中每行的内容
    ArrayList dialogArray;
    //皮肤资源，这里用于显示中文
    // public GUISkin skin;

    public Text textShown;

    public int diaNum;

    FileInfo t;


    //使用流的形式读取
    StreamReader sr = null;

    public TextAsset dialogText;

    public string dialogPath;
    public string dialogName;


    // Use this for initialization
    void Start () {
        dialogArray = LoadFile();
        Debug.Log(dialogArray);

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public ArrayList LoadFile()
    {
        
        try
        {
            sr  = File.OpenText("Assets/" + dialogPath + "/" + dialogName);
        }
        catch (Exception e)
        {
            //路径与名称未找到文件则直接返回空
            return null;
        }

        string line;
        ArrayList arrlist = new ArrayList();
        while ((line = sr.ReadLine()) != null)
        {
            //一行一行的读取
            //将每一行的内容存入数组链表容器中
            arrlist.Add(line);
        }
        //关闭流
        sr.Close();
        //销毁流
        sr.Dispose();
        //将数组链表容器返回
        return arrlist;
    }

    public void readSomething()
    {
        
        textShown.text = dialogArray[diaNum].ToString();
    }

    public void nextWord()
    {
        diaNum++;
    }
}
