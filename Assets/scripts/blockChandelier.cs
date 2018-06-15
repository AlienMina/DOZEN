using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class blockChandelier : MonoBehaviour {

    public float distance = 1f;
    public GameCon gameCon;
    Vector3 getHere;
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
        if (collision.tag == "Player" && gameCon.isElevator == false)
        {
            GameObject movePlayer = collision.GetComponentInParent<playerMove>().gameObject;
            movePlayer.GetComponent<NavMeshAgent>().isStopped = true;
            getHere = new Vector3(movePlayer.transform.position.x , movePlayer.transform.position.y+ distance, movePlayer.transform.position.z);
            movePlayer.transform.position = getHere;
            movePlayer.GetComponent<NavMeshAgent>().isStopped = false;
            movePlayer.GetComponent<NavMeshAgent>().destination = getHere;
            Debug.Log("get away QAQ!");
        }
    }
}
