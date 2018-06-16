using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv0DialogwithT : MonoBehaviour {

    public dialog dialog;
    public GameObject t;
    public GameObject teachingT;
    public GameObject enemy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dialog.finishDialog)
        {
            teachingT.SetActive(true);
            this.gameObject.SetActive(false);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="Player"&& enemy==null)
        {
            t.SetActive(true);
            dialog.startDialog();
        }
    }
}
