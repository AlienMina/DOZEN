using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teachingQTE : MonoBehaviour {

    public GameObject teaching;

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

                teaching.SetActive(true);
               
                this.gameObject.SetActive(false);

        }
    }
}
