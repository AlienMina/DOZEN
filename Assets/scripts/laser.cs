using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour {

    public GameObject laserObject;//激光本体
    public float laserRemaining=3;//激光持续时间
    public float laserRest = 2;//激光间隔时间

    bool isLaser = false;

    public GameObject enemyKillView;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!isLaser&&enemyKillView.GetComponent<enemyKillView>().stopLaser==false)
        {
            StartCoroutine(laserLoop());
        }
	}

    IEnumerator laserLoop()
    {
        isLaser = true;
        yield return new WaitForSeconds(laserRest);
        laserObject.SetActive(true);
        yield return new WaitForSeconds(laserRemaining);
        laserObject.SetActive(false);
        isLaser = false;

    }
}
