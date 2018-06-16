using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class moveTest1 : MonoBehaviour {

    public GameObject player;
    public GameObject waypoint;

    public float speed = 100;
    bool move = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (move)
        {
            player.GetComponent<NavMeshAgent>().enabled = false;
            player.transform.position = Vector3.MoveTowards(player.transform.position, waypoint.transform.position, speed * Time.deltaTime);
            if (player.transform.position == waypoint.transform.position)
            {
                move = false;
                player.GetComponent<NavMeshAgent>().enabled = true;
            }
        }
	}

    public void startMove()
    {
        move = true;
    }
}
