using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevatorTest : MonoBehaviour {

    public float speed = 5f;
    public GameObject plane;
    public GameObject player;
    public GameObject waypoint;

    bool isElevator = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isElevator)
        {
            plane.transform.position = Vector3.MoveTowards(plane.transform.position, waypoint.transform.position, speed * Time.deltaTime);
            player.transform.position = plane.transform.position;
        }
    }


}
