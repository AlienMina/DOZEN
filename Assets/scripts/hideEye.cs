using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hideEye : MonoBehaviour {
    public GameCon GameCo;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameCo.isHidden)
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1f);
        }
        else
        {
            this.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0f);
        }
	}
}
