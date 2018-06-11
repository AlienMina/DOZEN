using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class qteIconPress : MonoBehaviour {

    public int keyNum = 1;
    KeyCode code;
	// Use this for initialization
	void Start () {
        if (keyNum == 1)
        {
            code = KeyCode.Alpha1;
        }
        else if (keyNum == 2)
        {
            code = KeyCode.Alpha2;
        }
        else if (keyNum == 3)
        {
            code = KeyCode.Alpha3;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(code))
        {
            Debug.Log("pressed.");
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
	}
}
