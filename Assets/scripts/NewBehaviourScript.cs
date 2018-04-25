using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour {

    bool isTalked = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)//碰撞触发对话的示例
    {
        if (collision.tag == "Player")//如果碰到了角色的时候
        {
            if (!isTalked)
            {
                this.gameObject.GetComponent<dialog>().startDialog();
                isTalked = true;
            }
        }
    }

    }
