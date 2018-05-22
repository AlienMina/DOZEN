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
        //TAB切换角色
        if (Input.GetKeyUp(KeyCode.Tab))
        {
            keyboardChangeCharacter();
        }

	}
    void keyboardChangeCharacter()
    {
        if (GameContent.isDOZEN)
        {
            GameContent.isDOZEN = false;
            audios.Play();
            this.GetComponent<Image>().sprite = controlT;
        }
        else
        {
            GameContent.isDOZEN = true;
            audios.Play();
            this.GetComponent<Image>().sprite = controlDozen;
        }
    }

    public void ChangeCharacter()
    {
        if (!GameContent.playerDied)
        {
            Debug.Log("isDozen " + GameContent.isDOZEN);
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
}
