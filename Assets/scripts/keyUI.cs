using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class keyUI : MonoBehaviour {

    public level1 lv1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (lv1.key)
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        }
        else
        {
            this.gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        }
	}
}
