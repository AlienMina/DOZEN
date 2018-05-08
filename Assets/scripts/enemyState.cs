using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState : MonoBehaviour {

    public enemyMove enemymove;
    public GameCon gameCon;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!gameCon.showKillButton)//在没有显示击杀的情况下
        {
            if (enemymove.dizzy)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                this.gameObject.GetComponent<Animator>().Play("enemyStateDizzy");
            }
            else if (enemymove.chasingPlayer)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                this.gameObject.GetComponent<Animator>().Play("enemyStateWarning");

            }
            else if (enemymove.attring || enemymove.isAttracted || enemymove.chasingVoice)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                if (enemymove.gameObject.GetComponentInChildren<turnFaceEnemy>().gameObject.transform.rotation.z == 180)
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);
                    Debug.Log("rotationset");
                }
                else
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
                    Debug.Log("rotationset.");
                }
                this.gameObject.GetComponent<Animator>().Play("enemyStateConfused");
            }
            else
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }
        }
        else
        {
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
	}
}
