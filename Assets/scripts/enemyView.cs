using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyView : MonoBehaviour {

    public GameCon GameContent;

    enemyMove enemymove;

    bool chasingPlayer;
    bool isChasing;

    public float seeMachelfWait = 2f;

    float lastTime;
    float thisTime;
    int state = 2;

    // Use this for initialization
    void Start () {
        lastTime = Time.time;//这里好像有问题，应该改掉
        enemymove = this.GetComponentInParent<enemyMove>();
    }
	
	// Update is called once per frame
	void Update () {
        #region oldCode
        /*
        //timer，当状态为开始计时时，开始计时，时间达到时，转为计时到达状态
        if (state == 0)
        {
            Debug.Log("seen machElf.");
            enemymove.isAttracted = false;
            enemymove.isReturn = true;
            enemymove.attring = false;
            enemymove.chasingVoice = false;
            enemymove.setVoicePlace = false;
            enemymove.StopCoroutine(this.GetComponentInParent<enemyMove>().attractedByMachelf());
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
        }*/
        #endregion
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!GameContent.isHidden)
            {
                #region oldCode
                /*
                chasingPlayer = true;
                isChasing = true;
                this.GetComponentInParent<enemyMove>().chasingPlayer = chasingPlayer;
                this.GetComponentInParent<enemyMove>().isChasing = isChasing;
                Debug.Log(this.GetComponentInParent<enemyMove>().chasingPlayer);
                //Time.timeScale = 0;
                */
                #endregion
                //打开追主角开关
                enemymove.chasingPlayer = true;
            }
        }
        else if (collision.tag == "machElf")
        {
            #region oldCode
            /*
            if (state != 0)
            {
                lastTime = Time.time;
                state = 0;
                
            }
            */
            #endregion
            //关掉小精灵的开关总是没错的……
            enemymove.isAttracted = false;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!GameContent.isHidden)
            {
                #region oldCode
                /*
                isChasing = false;
                this.GetComponentInParent<enemyMove>().isChasing = isChasing;
                Debug.Log(this.GetComponentInParent<enemyMove>().isChasing + " is not chasing?");*/
                #endregion
                //关掉追主角的开关，打开计时器的开关
                enemymove.chasingPlayer = false;
                enemymove.chasingTimer = true;
                enemymove.oldTime = Time.time;
            }
        }
    }


   
}
