﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class playerMove : MonoBehaviour {

    Vector3 screenPosition;
    Vector3 mousePositionOnScreen;
    Vector3 mousePositionInWorld;
    Vector2 mouseXY;
    Vector3 mousePoint;

    private NavMeshAgent agent;
    private Vector3 test;
    public float zAxis=0;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("awake");
    }

    public void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //Debug.Log("get mouse down");
            //screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            //mousePositionOnScreen = Input.mousePosition;
            //mousePositionOnScreen.z = screenPosition.z;
            //mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

            //mousePoint.x = mousePositionInWorld.x;
            //mousePoint.y = mousePositionInWorld.y;
            //mousePoint.z = zAxis;
            ////agent.destination = mousePoint;
            //agent.SetDestination(mousePoint);
            //Debug.Log(agent.destination);
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                Debug.Log(hit.point);
                test.x = hit.point.x;
                test.y = hit.point.y;
                test.z = zAxis;
                agent.destination = test;
                
            }
        }
    }
}
