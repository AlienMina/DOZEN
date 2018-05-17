using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveTest : MonoBehaviour {

    public bool isup = false;
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

        }
    }

    public void isUp()
    {
        isup = true;
        Debug.Log("isup");
    }
    public void isNotUp()
    {
        isup = false;
        Debug.Log("isnotup");
    }
}
