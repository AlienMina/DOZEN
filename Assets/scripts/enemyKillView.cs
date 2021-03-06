﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyKillView : MonoBehaviour {

    public GameCon gameCon;
    public Animator enemyanim;
    public AudioSource playerDead;
    public GameCon GameContent;
    public GameObject player;
    public GameObject dead;

    public bool isEasyEnemy;
    public float easyEnemyWait=2f;

    public bool isLaserEnemy;
    public GameObject laser;


    bool easyWaited = false;
    bool startWait = false;

    public bool stopLaser;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameCon.playerHealth <= 0)
        {
            StartCoroutine(playerDied());
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!GameContent.isHidden)
        {
            
            if (collision.tag == "Player")
            {
                Debug.Log("collision easyWaited: " + easyWaited + "startWait: " + startWait);
                if (isEasyEnemy && easyWaited==false && startWait == false)//如果是简单的敌人，并且还没等待这两秒
                {
                    Debug.Log("Easy?");
                    startWait = true;
                    StartCoroutine(easyWait());
                    

                }
                else {
                    if (isLaserEnemy)
                    {
                        stopLaser = true;
                        laser.SetActive(true);
                        enemyanim.Play("enemySimpleAttack");
                        enemyanim.gameObject.GetComponent<turnFaceEnemy>().pause = true;
                        //StartCoroutine(playerDied());
                        StartCoroutine(hitPlayer());
                    }
                    else
                    {
                enemyanim.Play("enemySimpleAttack");
                enemyanim.gameObject.GetComponent<turnFaceEnemy>().pause = true;
                        //StartCoroutine(playerDied());
                        StartCoroutine(hitPlayer());
                    }

                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && isEasyEnemy)
        {
            easyWaited = false;//如果是简单的敌人，那么在主角离开范围的时候，默认就没这两秒的事情了
        }
    }

    IEnumerator playerDied()
    {
        //GameObject player = GameObject.FindWithTag("Player");
        player.GetComponent<playerMove>().playerDead = true;
        player.GetComponent<turnFaces>().pause = true;
        player.GetComponent<AudioSource>().Stop();
        player.GetComponent<NavMeshAgent>().ResetPath();
        if (player.GetComponent<turnFaces>().face)
        {
            player.GetComponentInChildren<Animator>().Play("dozenKilledRight");
        }
        else
        {
            player.GetComponentInChildren<Animator>().Play("dozenKilledLeft");
        }
        if (!gameCon.playerDied)
        {
            playerDead.Play();
        }
        gameCon.playerDied = true;
        yield return new WaitForSeconds(1.5f);
        //player.SetActive(false);        
        dead.SetActive(true);
        enemyanim.gameObject.GetComponent<turnFaceEnemy>().pause = false;
        stopLaser = false;
    }

    IEnumerator hitPlayer()
    {
        gameCon.playerHealth -= 1;
        player.GetComponent<playerMove>().playerDead = true;
        player.GetComponent<NavMeshAgent>().ResetPath();
        player.GetComponent<turnFaces>().pause = true;
        player.GetComponent<turnFaces>().playerHitAnima(getEnemyX());        
        yield return new WaitForSeconds(1.5f);
        player.GetComponent<turnFaces>().pause = false;
        player.GetComponent<playerMove>().playerDead = false;
        enemyanim.gameObject.GetComponent<turnFaceEnemy>().pause = false;
    }

    IEnumerator easyWait()
    {
        yield return new WaitForSeconds(easyEnemyWait);
        easyWaited = true;
        startWait = false;
        Debug.Log("FinishWait.");
        Debug.Log("easyWaited: " + easyWaited + "startWait: " + startWait);
    }

    /*
    void playerHitAnima()
    {
        if (player.GetComponent<turnFaces>().face)//面向右侧
        {
            if (getEnemyX() - player.transform.position.x < 0)//敌人在左边
            {
                player.GetComponentInChildren<Animator>().Play("dozenKilledRight");
                //player.GetComponentInChildren<Animator>().Play("dozenHitRightBehind");
            }
            else
            {
                player.GetComponentInChildren<Animator>().Play("dozenKilledRight");
                //player.GetComponentInChildren<Animator>().Play("dozenHitRightFront");
            }
          
        }
        else
        {
            if (getEnemyX() - player.transform.position.x < 0)//敌人在右边
            {
                player.GetComponentInChildren<Animator>().Play("dozenKilledRight");
                //player.GetComponentInChildren<Animator>().Play("dozenHitLeftBehind");
            }
            else
            {
                player.GetComponentInChildren<Animator>().Play("dozenKilledRight");
                //player.GetComponentInChildren<Animator>().Play("dozenHitLeftFront");
            }
        }
    }
    */
    float getEnemyX()
    {
        float x = enemyanim.gameObject.GetComponentInParent<enemyMove>().gameObject.transform.position.x;
        Debug.Log("this is enemy x: " + x);
        return x;
    }
}
