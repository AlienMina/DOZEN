using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class enemyBloodSlider : MonoBehaviour {
    public enemyStatus status;
    public Slider blood;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        blood.value = status.enemyBlood;
	}
}
