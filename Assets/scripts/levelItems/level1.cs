using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level1 : MonoBehaviour {

    [HideInInspector]
    public bool Item1;
    [HideInInspector]
    public bool Item2;

    //[HideInInspector]
    public bool key;

    [HideInInspector]
    public bool Memory1;
    [HideInInspector]
    public bool Memory2;

	// Use this for initialization
	void Start () {
        Item1 = false;
        Item2 = false;
        key = false;
        Memory1 = false;
        Memory2 = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void getItem1()
    {
        Item1 = true;
    }
    public void getItem2()
    {
        Item2 = true;
    }
    public void getKey()
    {
        key = true;
    }
    public void getMemory1()
    {
        Memory1 = true;
    }
    public void getMemory2()
    {
        Memory2 = true;
    }
}
