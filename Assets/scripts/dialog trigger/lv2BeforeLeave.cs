using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2BeforeLeave : MonoBehaviour {
    public dialog dialog;
    bool i=false;
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
            if (!i)
            {
                i = true;
                dialog.startDialog();
            }
        }
    }
}
