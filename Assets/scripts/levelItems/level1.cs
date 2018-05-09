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

    [HideInInspector]
    public bool getAllItems;

	// Use this for initialization
	void Start () {
        Item1 = false;
        Item2 = false;
        key = false;
        Memory1 = false;
        Memory2 = false;
        getAllItems = false;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    //方便playmaker的调用

    public void getItem1()
    {
        Item1 = true;
        Debug.Log("Item1: " + Item1);
    }
    public void getItem2()
    {
        Item2 = true;
        Debug.Log("Item2: " + Item2);
    }
    public void getKey()
    {
        key = true;
    }
    public void getMemory1()
    {
        Memory1 = true;
        Debug.Log("Memory1: " + Memory1);
    }
    public void getMemory2()
    {
        Memory2 = true;
    }

    public void AllItems()
    {
        Debug.Log("Item1: " + Item1);
        Debug.Log("Item2: " + Item2);
        if (Item1 && Item2)
        {
            getAllItems = true;
        }
    }
}
