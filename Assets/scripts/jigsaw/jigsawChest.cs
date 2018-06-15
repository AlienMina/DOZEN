using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jigsawChest : MonoBehaviour {

    public GameObject ui;
    public GameObject lostPiece;
    public dialog dia;

    [HideInInspector] public bool havePiece = false;
    [HideInInspector] public bool chestSeen = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!chestSeen)//如果是第一次遇见箱子
            {
                chestSeen = true;
                dia.startDialog();
            }
            else
            {
                if (havePiece)
                {
                    lostPiece.SetActive(true);
                    ui.SetActive(true);
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "player")
        {
            ui.SetActive(false);
        }
    }
}
