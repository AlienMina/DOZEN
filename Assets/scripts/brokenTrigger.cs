using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class brokenTrigger : MonoBehaviour {

    public brokenChandelierQTE QTE;
    public GameObject UI;
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
            QTE.isThere = true;
            UI.SetActive(true);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            QTE.isThere = false;
            UI.SetActive(false);
        }
    }
}
