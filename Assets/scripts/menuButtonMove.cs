using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menuButtonMove : MonoBehaviour {

    [System.Serializable]
    public struct buttonInfo
    {
        public GameObject button;
        public Vector3 finalPlace;
    };

    public buttonInfo[] buttons;
    bool moveStart = false;
    public bool moveFinished=false;
    public float speed = 1f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (moveStart)
        {
            for(int i = 0; i < buttons.Length; i++)
            {
                float step = speed * Time.deltaTime;
                //Debug.Log("moving");
                buttons[i].button.transform.GetComponent<RectTransform>().localPosition= Vector3.MoveTowards(buttons[i].button.transform.GetComponent<RectTransform>().localPosition, buttons[i].finalPlace, step);
            }
            
            if(buttons[buttons.Length-1].button.transform.GetComponent<RectTransform>().localPosition== buttons[buttons.Length - 1].finalPlace)
            {
                moveStart = false;
                moveFinished = true;
            }
           
        }
	}

    public void moveButtons()
    {
        moveStart = true;
    }
}
