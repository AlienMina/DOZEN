using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class finalDia1withCamera : MonoBehaviour {

    public Camera MainCamera;
    public cameraFollowing cameraFollow;

    [SerializeField] float speed = 5;
    bool startMove=false;
    bool finishMove = false;
    bool dialogShown = false;

    public dialog dialog1;
    public GameObject player;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startMove && !finishMove)
        {
            Debug.Log("startMove");
            MainCamera.transform.position = Vector3.MoveTowards(MainCamera.transform.position, new Vector3(346, 49,-200), speed * Time.deltaTime);
            if (MainCamera.transform.position.x == 346)
            {
                finishMove = true;
            }
        }
        if (finishMove && !dialogShown)
        {
            dialog1.startDialog();
            dialogShown = true;
            
        }
        if (dialog1.finishDialog)
        {
            cameraFollow.enabled = true;
            this.gameObject.SetActive(false);
        }
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.GetComponent<NavMeshAgent>().destination = player.transform.position;
            //暂时结束镜头跟随
            cameraFollow.enabled = false;
            startMove = true;
            Debug.Log("startMove: " + startMove);
        }
    }


}
