using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class levelTeaching : MonoBehaviour {
    public int teaching = 0;

    public dialog teaching1;
    public dialog teaching2;
    public dialog teaching3;
    public dialog teaching4;
    public GameObject menu;

    public SpriteRenderer blackScreenSprite;
    public GameObject enemyMove;
    public GameObject wayPoint;
    public GameObject[] need2Show1;
    public GameObject[] need2Show2;
    public GameObject[] need2Hide;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (teaching == 0)
        {
            teaching1.startDialog();
            teaching = 1;
        }
        else if (teaching == 2)
        {
            teaching2.startDialog();
            teaching = 3;
        }
        else if (teaching == 4)
        {
            teaching3.startDialog();
            teaching = 5;
        }

	}

    public IEnumerator chagingScene1()
    {
        StartCoroutine(blackScreen());
        yield return new WaitForSeconds(0.2f);
        for(int i = 0; i < need2Show1.Length; i++)
        {
            need2Show1[i].SetActive(true);
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(blackScreenFade());
        yield return new WaitForSeconds(0.2f);
        teaching = 2;
    }

    public IEnumerator chagingScene2()
    {
        StartCoroutine(blackScreen());
        yield return new WaitForSeconds(0.2f);
        for (int i = 0; i < need2Show2.Length; i++)
        {
            need2Show2[i].SetActive(true);
        }
        for (int i = 0; i < need2Hide.Length; i++)
        {
            need2Hide[i].SetActive(false);
        }
        yield return new WaitForSeconds(0.2f);
        StartCoroutine(blackScreenFade());
        yield return new WaitForSeconds(0.2f);
        enemyMove.GetComponent<NavMeshAgent>().destination = wayPoint.transform.position;
        teaching = 4;

    }
    public IEnumerator chagingScene3()
    {
        StartCoroutine(blackScreen());
        yield return new WaitForSeconds(0.2f);
        teaching4.startDialog();
        menu.SetActive(true);

    }

    IEnumerator blackScreen()
    {
        blackScreenSprite.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 0.6f);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 0.7f);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 0.8f);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 0.9f);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 1f);
    }

    IEnumerator blackScreenFade()
    {
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 1f);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 0.9f);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 0.8f);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 0.7f);
        yield return new WaitForSeconds(0.02f);
        blackScreenSprite.color = new Color(0, 0, 0, 0.6f);
        blackScreenSprite.gameObject.SetActive(false);
    }

    public void menuTurning()
    {
        SceneManager.LoadScene("start");
    }
}
