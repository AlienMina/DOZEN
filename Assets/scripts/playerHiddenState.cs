using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerHiddenState : MonoBehaviour {

    public GameCon GameContent;
    SpriteRenderer r;
    // Use this for initialization
    void Start () {
        r = gameObject.GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
        if (GameContent.isHidden)
        {
            r.color = new Color(1f, 1f, 1f, 0.5f);
        }
        else
        {
            r.color = new Color(1f, 1f, 1f, 1f);
        }
	}
}
