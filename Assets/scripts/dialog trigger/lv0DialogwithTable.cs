using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv0DialogwithTable : MonoBehaviour {

    public dialog dialog;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            dialog.startDialog();
        }
    }
}
