using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getHouseTag : MonoBehaviour
{
   public GameObject houseBetween;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "houseTag")
        {
            houseBetween= collision.gameObject;

        }

    }
}
