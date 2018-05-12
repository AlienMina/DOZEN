using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machelfDizzy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision!=null && collision.tag == "Enemy")
        {
            collision.gameObject.GetComponentInParent<enemyMove>().isDizz = true;
        }
    }
}
