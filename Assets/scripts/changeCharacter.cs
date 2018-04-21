using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeCharacter : MonoBehaviour {
    public GameCon GameContent;
    public AudioSource audios;

    public Sprite controlDozen;
    public Sprite controlT;
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
            audios.Play();
            this.GetComponent<Image>().sprite = controlT;
        }
        else
        {
            GameContent.isDOZEN = true;
            Debug.Log("isDozen " + GameContent.isDOZEN);
            audios.Play();
            this.GetComponent<Image>().sprite = controlDozen;
        }
    }
}
