using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuRolling : MonoBehaviour {

    float mouseY;
    public float round;
    bool mousedown;
    bool roll;
    float z;
    public float speed = 1;

    Quaternion rotations = new Quaternion();

    float tSpeed ;

    public float rotateAngle = 51.42f;

    // Use this for initialization
    void Start () {
        round = this.gameObject.transform.GetComponent<RectTransform>().localRotation.z;
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            mouseY=Input.GetAxisRaw("Mouse Y")*10f;
            Debug.Log(mouseY);
            if (mouseY <= 0)
            {
                mousedown = true;
            }
            else
            {
                mousedown = false;
            }

        }




    }

    public void rolling()
    {

        if (mousedown)
        {
            round += rotateAngle;
        }
        else
        {
            round -= rotateAngle;
        }
        Debug.Log("rolling");
        //roll = true;
        tSpeed = this.gameObject.transform.GetComponent<RectTransform>().localRotation.z + round;
        this.gameObject.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, tSpeed);
    }

    public void rotate()
    {
        float fMouseX = Input.GetAxis("Mouse X");
        float fMouseY = Input.GetAxis("Mouse Y");
        this.gameObject.transform.GetComponent<RectTransform>().transform.Rotate(new Vector3(0, 0, -1), fMouseY * speed, Space.World);
        Debug.Log("rotate?");
        //this.gameObject.transform.GetComponent<RectTransform>().transform.Rotate(Vector3.up, fMouseY * speed, Space.World);
    }
}
