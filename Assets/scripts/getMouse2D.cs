using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getMouse2D : MonoBehaviour {
    Vector3 screenPosition;
    Vector3 mousePositionOnScreen;
    Vector3 mousePositionInWorld;
    Vector2 mouseXY;
    PlayMakerFSM fsm;

    private void Start()
    {
        fsm = GameObject.Find("SceneFSMs").GetComponent<PlayMakerFSM>();
    }

    void Update()
    {
        //screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        //mousePositionOnScreen = Input.mousePosition;
        //mousePositionOnScreen.z = screenPosition.z;
        //mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

        //if (Input.GetMouseButtonDown(0))
        //{
        //    Debug.Log(mousePositionInWorld);
        //    //Instantiate(Soldier, mousePositionInWorld, Quaternion.identity);

        //}

    }

    public void getMouse() {

        screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        mousePositionOnScreen = Input.mousePosition;
        mousePositionOnScreen.z = screenPosition.z;
        mousePositionInWorld = Camera.main.ScreenToWorldPoint(mousePositionOnScreen);

        mouseXY.x = mousePositionInWorld.x;
        mouseXY.y = mousePositionInWorld.y;
        //fsm.FsmVariables.GetFsmFloat("mouseX").Value = mouseXY.x;
        //fsm.FsmVariables.GetFsmFloat("mouseY").Value = mouseXY.y;
        fsm.FsmVariables.GetFsmVector3("touchPosition").Value = mousePositionInWorld;
    }
}
