using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMove : MonoBehaviour {

    public GameCon GameContent;

    Vector3 place1;
    public GameObject place2;
    Vector3 enemyPlace;
    public float between = 0.05f;


    bool chasingVoice = false;//追声音
    bool chasingPlayer = false;//追主角

    private NavMeshAgent agent;
    bool isPlace1;
    // Use this for initialization
    void Start () {
        place1 = this.GetComponent<Transform>().position;//敌人的起始点
        agent = GetComponent<NavMeshAgent>();
        isPlace1 = true;
        agent.enabled = true;
    }
	
	// Update is called once per frame
	void Update () {
        //enemyPlace = this.GetComponent<Transform>().position;
        //if (!chasingPlayer && !chasingVoice)
            //StartCoroutine(patrol());
	}

    public void patrol2place2()
    {
        agent.destination = place2.transform.position;
    }

    public void patrol2place1()
    {
        agent.destination = place1;
    }
    
    IEnumerator patrol() {       
        if (isPlace1)
            agent.destination = place2.transform.position;
        else
            agent.destination = place1;
        if(agent.remainingDistance <= agent.stoppingDistance + between)
        {
          yield return new WaitForSeconds(5);
            if (isPlace1)
            {
                isPlace1 = false;
                Debug.Log("is Place1 false.");
            }
            else
            {
                isPlace1 = true;
                Debug.Log("is Place1 true.");
            }
        }

    }



        
        
       
       

    
}
