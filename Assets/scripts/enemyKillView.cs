using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyKillView : MonoBehaviour {

    public AudioSource playerDead;
    public GameCon GameContent;
    public GameObject player;
    public GameObject dead;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameContent.isHidden)
        {
            if (collision.tag == "Player")
            {
                player.SetActive(false);
                playerDead.Play();
                dead.SetActive(true);
            }
        }
    }
}
