using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class typewriterInScene : MonoBehaviour {

    public typewriterTotal typewriter;

    public GameObject typewriterBig;//窗口
    public GameObject trueTypeWriter;//需要被隐藏的
    public GameObject fakeTypeWriter;//显示的假的
    public dialog dialog1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (typewriter.finishTypeWriter)
        {
            typewriterBig.SetActive(false);
            fakeTypeWriter.SetActive(true);
            dialog1.startDialog();
            trueTypeWriter.SetActive(false);
        }
	}
}
