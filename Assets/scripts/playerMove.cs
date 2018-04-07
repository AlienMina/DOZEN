﻿using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class playerMove : MonoBehaviour {

    Vector3 screenPosition;
    Vector3 mousePositionOnScreen;
    Vector3 mousePositionInWorld;
    Vector2 mouseXY;
    Vector3 mousePoint;

    public GameCon GameContent;

    private NavMeshAgent agent;
    private Vector3 test;
    //public float zAxis=0;

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
                if (GameContent.isDOZEN)
                {
                    Debug.Log(hit.point);
                    test.x = hit.point.x;
                    test.y = hit.point.y;
                    test.z = hit.point.z;//测试
                    //test.z = this.transform.position.z;
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                        Debug.Log("point on UI");
                    }
                    else
                    {
                        Debug.Log(test);
                        if (GameContent.isHidden)
                        {
                            GameContent.isHidden = false;//当主角移动的时候，解除隐藏
                        }
                        //agent.Resume();
                        agent.enabled = true;
                        agent.destination = test;
                    }
                    
                }

            }
        }
    }

    public void hideMove(Vector3 hideHere)//走到隐藏点
    {
        Vector3 i;
        i.x = hideHere.x;
        i.y = hideHere.y;
        i.z = this.transform.position.z;
        //agent.Resume();
        agent.enabled = true;
        agent.destination = i;
        Debug.Log("hide place " + i);
        Debug.Log("hide.");
    }

    public void stopImmiediately()
    {
        //agent.destination = this.transform.position;
        //agent.Stop();
        agent.enabled = false;
    }
}
