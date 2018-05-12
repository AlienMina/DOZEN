using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyView : MonoBehaviour {

    public GameCon GameContent;

    bool chasingPlayer;
    bool isChasing;

    public float seeMachelfWait = 2f;

    float lastTime;
    float thisTime;
    int state = 2;

    // Use this for initialization
    void Start () {
        lastTime = Time.time;
    }
	
	// Update is called once per frame
	void Update () {
        //timer，当状态为开始计时时，开始计时，时间达到时，转为计时到达状态
        if (state == 0)
        {
            Debug.Log("seen machElf.");
            this.GetComponentInParent<enemyMove>().isAttracted = false;
            this.GetComponentInParent<enemyMove>().isReturn = true;
            this.GetComponentInParent<enemyMove>().attring = false;
            this.GetComponentInParent<enemyMove>().chasingVoice = false;
            this.GetComponentInParent<enemyMove>().setVoicePlace = false;
            this.GetComponentInParent<enemyMove>().StopCoroutine(this.GetComponentInParent<enemyMove>().attractedByMachelf());
            thisTime = Time.time;
            Debug.Log(thisTime);
            if (thisTime - lastTime >= seeMachelfWait)
            {
                state = 1;
            }
        }
        
        if (state == 1)
        {
            this.GetComponentInParent<enemyMove>().patrol2place1();
            state = 2;
        }
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
        else if (collision.tag == "machElf")
        {
            if (state != 0)
            {
                lastTime = Time.time;
                state = 0;
                
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
        
    }

   
}
