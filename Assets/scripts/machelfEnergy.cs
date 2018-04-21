using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class machelfEnergy : MonoBehaviour {

    public int energy = 5;
    public GameObject attr;

    public int whenHide;
    public bool isEnergyPoint;

    public machelfEnergy whoseEnergy;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isEnergyPoint)
        {
            hideEnergyPoint();
        }
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
    /// <summary>
    /// 这是给噪音能量点显隐用的
    /// </summary>
    public void hideEnergyPoint()
    {
        if (whoseEnergy.energy <= whenHide)
        {
            this.gameObject.SetActive(false);
            Debug.Log(this.name);
        }
    }
}
