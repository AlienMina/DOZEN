using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class lockedDoor : MonoBehaviour {
    public level1 level1Items;

    public dialog lockedDialog1;
    public dialog lockedDialog2;

    public NavMeshAgent agent;

    public GameObject wayPoint;

    bool lockedDialog=false;
    bool openDoor = false;

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
            Debug.Log(level1Items.key);
            agent.destination = wayPoint.transform.position;
            if (!lockedDialog)
            {
                lockedDialog1.startDialog();
                lockedDialog = true;
                agent.destination = wayPoint.transform.position;
            }
            else if (level1Items.key&& !openDoor)
            {
                Debug.Log("start dialog2");
                lockedDialog2.startDialog();
                openDoor = true;
            }
            else if (openDoor)
            {
                this.gameObject.SetActive(false);
            }


        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (openDoor)
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                agent.destination = wayPoint.transform.position;
            }
        }
    }
}
