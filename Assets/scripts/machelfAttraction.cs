using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machelfAttraction : MonoBehaviour {

    public GameObject machelfAgent;
    public Vector3 dir = new Vector3(0, 90, 0);
    Vector3 pos;
    RaycastHit hitPos;
    Ray ray;
    Vector3 testPos;

	// Use this for initialization
	void Start () {
        
        testPos.z = -11.12f;
        
	}
	
	// Update is called once per frame
	void Update () {
        
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (collision!=null&&collision.tag == "Enemy")
            {
                getEnemyDestination();
                if (pos != null)
                {
                    collision.gameObject.GetComponentInParent<enemyMove>().attractedPlace = pos;
                    Debug.Log("attraction place: "+pos);
                    collision.gameObject.GetComponentInParent<enemyMove>().isAttracted = true;
                }
                
            }
    }

    void getEnemyDestination()
    {
        testPos.x = machelfAgent.transform.position.x;
        testPos.y = machelfAgent.transform.position.y;
        ray = new Ray(testPos, dir);
        
        Debug.Log(machelfAgent.transform.position+"  "+testPos+"  "+dir+"   "+ray);
        if (Physics.Raycast(ray,out hitPos, 10000f))
        {
            
            if (hitPos.transform.tag=="ground")
            {
                Debug.Log(hitPos.transform.name);
                pos = hitPos.point;
                Debug.Log("pos: " + pos);
            }
        }
    }



}
