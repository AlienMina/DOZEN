using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chandelierDialogwithEnemy : MonoBehaviour {

    public dialog dialog;
    public GameObject enemy;
    public GameObject block;
    public shakecamera shake;
    public GameObject player;

    public GameObject enemy1;
    public GameObject enemy2;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dialog.finishDialog)
        {
            if(enemy.activeSelf)
            enemy.GetComponent<NavMeshAgent>().destination = player.transform.position;
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (!dialog.finishDialog)
            {
                dialog.startDialog();
                enemy.SetActive(true);
                block.SetActive(true);
                shake.shake(3, 0.5f, 45);
                enemy1.GetComponent<enemyMove>().isDizz = true;
                enemy1.transform.position = enemy1.GetComponent<enemyMove>().place1;
                enemy2.transform.position = enemy1.GetComponent<enemyMove>().place1;
                enemy2.GetComponent<enemyMove>().isDizz = true;
            }
        }
    }
}
