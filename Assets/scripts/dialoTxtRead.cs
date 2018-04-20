using UnityEngine;
using System.Collections;
using System.IO;
using System.Collections.Generic;
using System;
using UnityEngine.UI;

public class dialoTxtRead : MonoBehaviour {


    
    public enum saveMode
    {PC, Android };
    public saveMode savemode = saveMode.PC;
    public int dialogNumInAndroid=999;

    //文本中每行的内容
    ArrayList dialogArray;
    string[] dialogArrayAndroid;
    public Text textShown;

    public int diaNum;

    FileInfo t;


    //使用流的形式读取
    StreamReader sr = null;

    string androidDialog;

    public TextAsset dialogText;

    public string dialogPath;
    public string dialogName;


    // Use this for initialization
    void Start () {
        if(savemode == saveMode.PC)
        {
            dialogArray = LoadFile();
        }
        else if (savemode == saveMode.Android)
        {
            dialogArrayAndroid = androidLoadfile();
        }
        Debug.Log(dialogArray);
        Debug.Log(androidRead());
        //Debug.Log(Application.streamingAssetsPath);
        //textShown.text = dialogArray[0].ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public ArrayList LoadFile()
    {
        try
        {  
                sr = File.OpenText(Application.streamingAssetsPath + "/" + dialogPath + dialogName);
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

    public string[] androidLoadfile()
    {        
        androidDialog = androidRead();
        string[] dialog = androidDialog.Split(new string[] { "\r\n" }, StringSplitOptions.None);
        Debug.Log(dialog);
        return dialog;
    }


    public void readSomething()
    {
        if (savemode == saveMode.PC)
        {
            textShown.text = dialogArray[diaNum].ToString();
        }
        else if (savemode == saveMode.Android)
        {
            textShown.text = dialogArrayAndroid[diaNum] ;
        }
        
    }

    public void nextWord()
    {
        diaNum++;
    }

    public string androidRead()
    {
        WWW www = new WWW(Application.streamingAssetsPath + "/" + dialogPath + dialogName);
        while (!www.isDone) { }
        return www.text;
    }
}
