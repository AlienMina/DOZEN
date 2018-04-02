using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeCharacter : MonoBehaviour {
    public GameCon GameContent;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeCharacter()
    {
        Debug.Log("isDozen "+GameContent.isDOZEN);
        if (GameContent.isDOZEN)
        {
            GameContent.isDOZEN = false;
            Debug.Log("isDozen " + GameContent.isDOZEN);
        }
        else
        {
            GameContent.isDOZEN = true;
            Debug.Log("isDozen " + GameContent.isDOZEN);
        }
    }
}
