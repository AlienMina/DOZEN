﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jigsawInScene : MonoBehaviour {

    public jigsawChest chest;
    public AudioSource audio;
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
            if (chest.chestSeen)
            {
                chest.havePiece = true;
                audio.Play();
                this.gameObject.SetActive(false);
            }
        }
    }
}
