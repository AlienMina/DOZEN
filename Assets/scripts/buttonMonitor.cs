using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonMonitor : MonoBehaviour {
    public GameCon GameContent;
    public GameObject elfAttentionButton;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GameContent.isDOZEN)
        {
            elfAttentionButton.SetActive(false);
        }
        else
        {
            elfAttentionButton.SetActive(true);
        }
	}
}
