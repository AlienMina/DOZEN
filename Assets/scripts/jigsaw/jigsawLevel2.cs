using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jigsawLevel2 : MonoBehaviour {

    public GameObject core;
    public GameObject block;
    public jigsawTotal jigsaw;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (jigsaw.finishJigsaw)
        {
            core.SetActive(true);
            block.SetActive(false);
            this.gameObject.SetActive(false);
        }
	}
}
