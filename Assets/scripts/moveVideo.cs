using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveVideo : MonoBehaviour {

    public AudioSource audioS;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (this.GetComponent<Rigidbody>().velocity.z != 0)
        {
            audioS.Play();
        }
        else
        {
            audioS.Stop();
        }
	}
}
