using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startDialoginLv0 : MonoBehaviour {

    public dialog dialog;
    public GameObject teaching;
    bool i = false;

    float oldTime;
    float time;
	// Use this for initialization
	void Start () {
        oldTime = Time.time;
        i = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (!i)
        {            
            time = Time.time;
            if (time - oldTime >= 1.5f)
            {
                dialog.startDialog();
                i = true;
            }
        }
        if (dialog.finishDialog)
        {
            teaching.SetActive(true);
            this.gameObject.SetActive(false);
        }
	}

   
}
