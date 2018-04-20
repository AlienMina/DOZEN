using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machelfEnergy : MonoBehaviour {

    public int energy = 5;
    public GameObject attr;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void energyDown()
    {
        energy--;
    }
    public void energyUp()
    {
        if(energy<5)
        energy++;
    }

    public void noEnergy()
    {
        energy = 0;
    }

    public void machAtta()
    {
        StartCoroutine(machelfAttraction());
    }

    IEnumerator machelfAttraction()
    {
        //在有能量的情况下
        if (energy > 0)
        {
            energy--;
            this.GetComponent<AudioSource>().Play();
            attr.SetActive(true);
            yield return new WaitForSeconds(0.1f);
            attr.SetActive(false);

        }
    }
}
