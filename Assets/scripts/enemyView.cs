using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyView : MonoBehaviour {

    public GameCon GameContent;
    bool chasingPlayer;
    bool isChasing;
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
            if (!GameContent.isHidden)
            {
                chasingPlayer = true;
                isChasing = true;
                this.GetComponentInParent<enemyMove>().chasingPlayer = chasingPlayer;
                this.GetComponentInParent<enemyMove>().isChasing = isChasing;
                Debug.Log(this.GetComponentInParent<enemyMove>().chasingPlayer);
                //Time.timeScale = 0;
            }
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            isChasing = false;
            this.GetComponentInParent<enemyMove>().isChasing = isChasing;
            Debug.Log(this.GetComponentInParent<enemyMove>().isChasing + " is not chasing?");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "machElf")
        {
            Debug.Log("seen machElf.");
            this.GetComponentInParent<enemyMove>().isAttracted = false;
            this.GetComponentInParent<enemyMove>().StopCoroutine(this.GetComponentInParent<enemyMove>().attractedByMachelf());
            this.GetComponentInParent<enemyMove>().patrol2place1();

        }
    }
}
