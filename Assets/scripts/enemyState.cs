using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyState : MonoBehaviour {

    public enemyMove enemymove;
    public GameCon gameCon;

   [HideInInspector] public bool qteState;
	// Use this for initialization
	void Start () {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
    }
	
	// Update is called once per frame
	void Update () {
        if (!gameCon.showKillButton)//在没有显示击杀的情况下
        {
            if (enemymove.enemyDizzy)
            {
                enemymove.isReturn = false;
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                this.gameObject.GetComponent<Animator>().Play("enemyStateDizzy");
            }
            else if (enemymove.enemyChasing)
            {
                enemymove.isReturn = false;
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                this.gameObject.GetComponent<Animator>().Play("enemyStateWarning");

            }
            else if (enemymove.enemyHeard)
            {
                enemymove.isReturn = false;
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                if (enemymove.gameObject.GetComponentInChildren<turnFaceEnemy>().gameObject.transform.rotation.z == 180)
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(0, 180, 0);

                }
                else
                {
                    this.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);

                }
                this.gameObject.GetComponent<Animator>().Play("enemyStateConfused");
            }
            else if(enemymove.nothingOnHead && !qteState)
            {
                this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            }
        }
        else
        {
            clearState();
            this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
        }
	}

    public void clearState()
    {
        enemymove.enemyHeard = false;
        enemymove.enemyDizzy = false;
        enemymove.enemyChasing = false;
        enemymove.nothingOnHead = true;
    }

    public void resetColor()
    {
        this.gameObject.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
