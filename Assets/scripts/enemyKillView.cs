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
                enemyanim.Play("enemySimpleAttack");
                enemyanim.gameObject.GetComponent<turnFaceEnemy>().dead = true;
                StartCoroutine(playerDied());
            }
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
}
