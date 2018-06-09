using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class turnFaceT : MonoBehaviour {

    public Animator anim;
    public NavMeshAgent agent;
    public AudioSource audioSource;
    public machelfEnergy energy;
    public float machelfSound=0.5f;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        if (energy.energy == 0)
        {
            anim.Play("TlowEnergy");
        }
        else
        {
            anim.Play("TsimpleMove");
        }

        if (agent.velocity.x == 0)
        {
            audioSource.volume = 0;
        }
        else
        {
            audioSource.volume = machelfSound;
        }
    }
}
