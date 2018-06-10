using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jigsawPiece : MonoBehaviour {

    public jigsawTotal jigsaw;
    public int myNum;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void moveMe()
    {
        jigsaw.placeJudgement(myNum);
    }
}
