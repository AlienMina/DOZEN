using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class jump : MonoBehaviour {

    public GameObject playerAgent;
    public GameObject player;//这个是主角的动画
    public GameObject waypoint1;
    public GameObject waypoint2;

    public float speed = 100;

    bool startJump = false;
    bool startJump2 = false;

    bool jump1Finish = false;
    bool jump2Finish = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (startJump)
        {
            playerAgent.transform.position = Vector3.MoveTowards(playerAgent.transform.position, waypoint1.transform.position, speed*0.6f * Time.deltaTime);
            if (playerAgent.transform.position == waypoint1.transform.position)
            {
                startJump = false;
                jump1Finish = true;

            }
        }
        
        else if (jump1Finish)
        {
            jump2();
        }
        else if (startJump2)
        {
            playerAgent.GetComponent<NavMeshAgent>().enabled = false;//关掉自动寻路
            playerAgent.transform.position = Vector3.MoveTowards(playerAgent.transform.position, waypoint2.transform.position, speed * Time.deltaTime);
            if (playerAgent.transform.position == waypoint2.transform.position)
            {
                startJump2 = false;
                jump2Finish = true;
            }
        }
        else if (jump2Finish)
        {
            StartCoroutine(jump3());
        }
	}

    public void playerJump()
    {
        playerAgent.GetComponent<NavMeshAgent>().enabled = false;//关掉自动寻路
        playerAgent.GetComponent<turnFaces>().pause = true;//角色动画的改变
        player.GetComponent<Animator>().Play("dozenJumpRight1");
        startJump = true;
    }
    
    void jump2()
    {
        player.GetComponent<Animator>().Play("dozenJumpRight2");
        //playerAgent.transform.position = Vector3.MoveTowards(player.transform.position, waypoint2.transform.position, speed * Time.deltaTime);
        jump1Finish = false;
        startJump2 = true;
    }

    IEnumerator jump3()
    {
        player.GetComponent<Animator>().Play("dozenJumpRight3");
        yield return new WaitForSeconds(0.8f);
        jump2Finish = false;
        playerAgent.GetComponent<NavMeshAgent>().enabled = true;//关掉自动寻路
        playerAgent.GetComponent<turnFaces>().pause = false;//角色动画的改变
    }
}
