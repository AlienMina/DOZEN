using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class wire : MonoBehaviour {

    public GameObject died;
    Collider2D colli;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        colli = collision;
        if (collision.tag == "Player")
        {
            StartCoroutine(killPlayer());
        }
        else if (collision.tag == "machElf")
        {
            StartCoroutine(breakMachelf());
        }
        else if (collision.tag == "Enemy")
        {
            StartCoroutine(killEnemy());
        }
    }

    IEnumerator killPlayer()
    {
        this.GetComponent<AudioSource>().Play();
        colli.gameObject.GetComponentInParent<turnFaces>().pause = true;
        colli.gameObject.GetComponentInParent<AudioSource>().Stop();
        colli.gameObject.GetComponentInParent<NavMeshAgent>().ResetPath();
        if (colli.gameObject.GetComponentInParent<turnFaces>().face)
        {
            colli.gameObject.GetComponent<Animator>().Play("dozenDiedRight");
        }
        else
        {
            colli.gameObject.GetComponent<Animator>().Play("dozenDiedLeft");
        }       
        yield return new WaitForSeconds(1f);
        died.SetActive(true);
        this.gameObject.SetActive(false);       
    }

    IEnumerator breakMachelf()
    {
        this.GetComponent<AudioSource>().Play();
        yield return new WaitForSeconds(0.2f);
        colli.gameObject.GetComponentInParent<machelfEnergy>().energy = 0;
        this.gameObject.SetActive(false);
    }

    IEnumerator killEnemy()
    {
        this.GetComponent<AudioSource>().Play();
        colli.gameObject.GetComponent<turnFaceEnemy>().dead = true;
        colli.gameObject.GetComponentInParent<NavMeshAgent>().speed=0;
        Debug.Log(colli.gameObject.GetComponentInParent<NavMeshAgent>());
        colli.gameObject.GetComponent<Animator>().Play("enemySimpleDied");
        yield return new WaitForSeconds(1f);
        this.gameObject.SetActive(false);
        colli.gameObject.SetActive(false);
    }
}
