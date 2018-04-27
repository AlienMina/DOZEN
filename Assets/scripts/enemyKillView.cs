using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyKillView : MonoBehaviour {

    public Animator enemyanim;
    public AudioSource playerDead;
    public GameCon GameContent;
    public GameObject player;
    public GameObject dead;

    public bool isEasyEnemy;
    public float easyEnemyWait=2f;


    bool easyWaited = false;
    bool startWait = false;

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
                Debug.Log("collision easyWaited: " + easyWaited + "startWait: " + startWait);
                if (isEasyEnemy && easyWaited==false && startWait == false)//如果是简单的敌人，并且还没等待这两秒
                {
                    Debug.Log("Easy?");
                    startWait = true;
                    StartCoroutine(easyWait());
                    

                }
                else { 
                enemyanim.Play("enemySimpleAttack");
                enemyanim.gameObject.GetComponent<turnFaceEnemy>().dead = true;
                StartCoroutine(playerDied());
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
        playerDead.Play();
        yield return new WaitForSeconds(1f);
        player.SetActive(false);        
        dead.SetActive(true);
        enemyanim.gameObject.GetComponent<turnFaceEnemy>().dead = false;
    }

    IEnumerator easyWait()
    {
        yield return new WaitForSeconds(easyEnemyWait);
        easyWaited = true;
        startWait = false;
        Debug.Log("FinishWait.");
        Debug.Log("easyWaited: " + easyWaited + "startWait: " + startWait);
    }
}
