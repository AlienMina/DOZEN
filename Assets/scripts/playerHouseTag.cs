using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHouseTag : MonoBehaviour {

    public string playerHouseName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "houseTag")
        {
            playerHouseName = collision.gameObject.name;
        }
    }
}
