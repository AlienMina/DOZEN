using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class dialogtrigger : MonoBehaviour {
    public level1 level1Items;

    public dialog Dialog;

    public NavMeshAgent agent;


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
            Dialog.startDialog();
            this.gameObject.SetActive(false);
        }
    }
    }
