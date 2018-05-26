using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class turnFaces : MonoBehaviour {

    public GameCon gameCon;
    public Animator anim;
    public NavMeshAgent agent;
    public AudioSource audioSource;
    public GameObject mask;

    public bool pause = false;
    public bool face = true;//true--right,false--left.
    bool turnmask = false;


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (!pause)
        {

                if (agent.velocity.x < 0)
                {
                    if (gameCon.moveable)
                    {
                        anim.Play("dozenWalkLeft");
                        audioSource.volume = 1;
                        face = false;
                        turnMask();
                        //Debug.Log("left.");
                    }
                    else
                    {
                        anim.Play("dozenWaitRight");
                        audioSource.volume = 0;
                    }
                }
                else if (agent.velocity.x > 0)
                {
                    if (gameCon.moveable)
                    {
                        anim.Play("dozenWalkRight");
                        audioSource.volume = 1;
                        face = true;
                    turnMask();
                    //Debug.Log("right.");
                    }
                    else
                    {
                        anim.Play("dozenWaitRight");
                        audioSource.volume = 0;
                    }
            }
                else if (agent.velocity.x == 0)
                {
                    turnmask = false;
                    if (face)
                    {
                        anim.Play("dozenWaitRight");
                    }
                    else
                    {
                        anim.Play("dozenWaitLeft");
                    Debug.Log("waitLeft");
                    }

                    audioSource.volume = 0;
                    //Debug.Log("wait.");
                }
            
        }
    }

    void turnMask()
    {
        if (face)
        {
            mask.transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            mask.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        turnmask = true;
    }

    public void playAttackAnim()
    {
        
        if (face)
        {
            anim.Play("dozenAttackRight");
        }
        else
        {
            anim.Play("dozenAttackLeft");

        }
        
    }
}
