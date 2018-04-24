using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class turnFaceEnemy : MonoBehaviour
{

    public Animator anim;
    public NavMeshAgent agent;
    // Use this for initialization
    public bool dead = false;
    bool face=true ;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!dead)
        {
            if (agent.velocity.x < 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 0, 0);
                anim.Play("enemySimpleWalk");
            }
            else if (agent.velocity.x > 0)
            {
                this.transform.rotation = Quaternion.Euler(0, 180, 0);
                anim.Play("enemySimpleWalk");
            }
        }
    }

    public void setdead()
    {
        dead = true;
        
    }
}
