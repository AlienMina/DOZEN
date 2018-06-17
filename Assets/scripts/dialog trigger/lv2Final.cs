using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv2Final : MonoBehaviour {

    public GameObject SL1;

    public Sprite wakeUp;
    public Sprite twins1;

    public dialog dia1;
    public dialog dia2;

    public GameObject win;
    public AudioSource wins;

    bool i = false;

    bool j = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dia1.finishDialog && !i)
        {
            i = true;
            StartCoroutine(changeAgain());
        }
        else if (dia2.finishDialog)
        {
            win.SetActive(true);
            wins.Play();
            this.gameObject.SetActive(false);
        }
		
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!j)
            {
                j = true;
                SL1.GetComponent<SpriteRenderer>().sprite = wakeUp;
                chan();
            }
        }
    }
    void chan() {
        StartCoroutine(change());
    }


    IEnumerator change()
    {
        yield return new WaitForSeconds(1f);
        SL1.SetActive(false);
        this.gameObject.GetComponent<Animator>().enabled = true;
        this.gameObject.GetComponent<Animator>().Play("twinsSwitch");
        Debug.Log("switch");
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Animator>().Play("twinsA");
        dia1.startDialog();
    }

    IEnumerator changeAgain()
    {
        this.gameObject.GetComponent<Animator>().Play("twinsSwitch 0");
        yield return new WaitForSeconds(1f);
        this.gameObject.GetComponent<Animator>().Play("twinsB");
        dia2.startDialog();
    }
}
