using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opacity : MonoBehaviour
{
    public dialog Dialog;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "machElf")
        {
			GetComponent<SpriteRenderer>().enabled = true;
            Dialog.startDialog();
            GetComponent<BoxCollider2D>().enabled = false;
        }
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(2);
        this.gameObject.SetActive(false);
    }
}