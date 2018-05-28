using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerBloodSlider : MonoBehaviour {

    public GameCon gameCon;
    public Slider blood;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        blood.value = gameCon.playerHealth;
	}
}
