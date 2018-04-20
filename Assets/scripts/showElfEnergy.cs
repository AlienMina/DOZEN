using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class showElfEnergy : MonoBehaviour {
    Text text;
    public GameObject ener;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        this.gameObject.GetComponent<Text>().text = ener.GetComponent<machelfEnergy>().energy.ToString() ;
	}
}
