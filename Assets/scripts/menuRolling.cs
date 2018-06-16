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

    public GameObject rollings;//转圈的东西

    Quaternion rotations = new Quaternion();

    float tSpeed ;

    public float rotateAngle = 51.42f;

    public GameObject[] words;//不同的文字
    int wordnum;

    // Use this for initialization
    void Start () {
        round = this.gameObject.transform.GetComponent<RectTransform>().localRotation.z;
        wordnum =0;
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
            wordnum++;
        }
        else
        {
            round -= rotateAngle;
            wordnum--;
        }
        Debug.Log("rolling");
        //roll = true;
        tSpeed = this.gameObject.transform.GetComponent<RectTransform>().localRotation.z + round;

        rollings.transform.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, tSpeed);
        checkWord();
    }

    public void rotate()
    {
        float fMouseX = Input.GetAxis("Mouse X");
        float fMouseY = Input.GetAxis("Mouse Y");
        rollings.transform.GetComponent<RectTransform>().transform.Rotate(new Vector3(0, 0, -1), fMouseY * speed, Space.World);
        Debug.Log("rotate?");
        //this.gameObject.transform.GetComponent<RectTransform>().transform.Rotate(Vector3.up, fMouseY * speed, Space.World);
    }

    public void checkWord()
    {
        for(int i = 0; i < words.Length; i++)
        {
            words[i].SetActive(false);
        }
        if (wordnum > 6)
        {
            wordnum = 0;
        }
        else if(wordnum<0)
        {
            wordnum = 6;
        }
        if (wordnum < 2)
        {
            words[wordnum].SetActive(true);
        }
        else
        {
            words[2].SetActive(true);
        }
    }
}
