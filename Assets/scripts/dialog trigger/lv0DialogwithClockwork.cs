using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lv0DialogwithClockwork : MonoBehaviour {

    public dialog dialog;
    public GameObject tapIcon;
    public GameObject block;
    public GameObject oldBlock;
    public shakecamera shake;
    public GameObject teaching1;
    public GameObject teaching2;
    public GameObject teaching3;
    public GameObject enemy;
    public GameObject anotherEnemy;//懒得写成[]了
    public GameObject nextDialog;
    public AudioSource enemySound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (dialog.finishDialog)
        {
            teaching2.SetActive(true);
            teaching3.SetActive(true);
            this.gameObject.SetActive(false);
        }
	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            block.SetActive(true);
            tapIcon.SetActive(true);
            teaching1.SetActive(true);

        }
    }

    public void destroyBlock()
    {
        block.SetActive(false);
        oldBlock.SetActive(false);
    }

    public void dialogandShaking()
    {
        shake.shake(3, 0.5f, 45);
        enemy.SetActive(true);
        anotherEnemy.SetActive(true);
        dialog.startDialog();
        enemySound.Play();
        nextDialog.SetActive(true);
    }
}
