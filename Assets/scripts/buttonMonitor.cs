using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMonitor : MonoBehaviour {
    public GameCon GameContent;
    public GameObject[] elfAttentionButton;

    bool isSet = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        /*
		if (GameContent.isDOZEN)
        {
            for(int i = 0; i < elfAttentionButton.Length; i++)
            {
                elfAttentionButton[i].SetActive(false);
                
            }
            isSet = false;
            
        }
        */
        //else
        //{
            if (!isSet)
            {
                for (int i = 0; i < elfAttentionButton.Length; i++)
                {
                    elfAttentionButton[i].SetActive(true);
                }
                isSet = true;
            }
        //}
	}
}
