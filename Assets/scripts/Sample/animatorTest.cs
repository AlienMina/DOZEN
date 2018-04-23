using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class animatorTest : MonoBehaviour {

    public Animator anim;
    public NavMeshAgent agent;
    public Rigidbody rigid;
    // Use this for initialization


	void Start () {
        //anim.SetInteger("state", 2);
	}
	
	// Update is called once per frame
	void Update () {
        if (agent.velocity.x < 0)
        {
            anim.Play("dozenWalkLeft");
            Debug.Log("left.");
        }
        else if (agent.velocity.x > 0)
        {
            anim.Play("dozenWalkRight");
            Debug.Log("right.");
        }
        else if (agent.velocity.x == 0)
        {
            anim.Play("dozenWaitRight");
            Debug.Log("wait.");
        }
       

        //Debug.Log(rigid.velocity);
        //Debug.Log(agent.velocity);
        
    }
}
