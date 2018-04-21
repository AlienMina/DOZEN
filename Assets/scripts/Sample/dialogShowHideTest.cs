using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogShowHideTest : MonoBehaviour {

    public GameObject dialog;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showDia()
    {
        StartCoroutine(showDialog());
    }

    public void hideDia()
    {
        StartCoroutine(hideDialog());
    }

    public IEnumerator showDialog()
    {
        dialog.transform.localScale = new Vector3(1, 0.2f, 1);
        yield return new WaitForSeconds(0.03f);
        dialog.transform.localScale = new Vector3(1, 0.4f, 1);
        yield return new WaitForSeconds(0.03f);
        dialog.transform.localScale = new Vector3(1, 0.6f, 1);
        yield return new WaitForSeconds(0.03f);
        dialog.transform.localScale = new Vector3(1, 0.8f, 1);
        yield return new WaitForSeconds(0.03f);
        dialog.transform.localScale = new Vector3(1, 1, 1);
        yield return new WaitForSeconds(0.03f);
    }

    public IEnumerator hideDialog()
    {
        
        dialog.transform.localScale = new Vector3(1, 0.8f, 1);
        yield return new WaitForSeconds(0.03f);
        dialog.transform.localScale = new Vector3(1, 0.6f, 1);
        yield return new WaitForSeconds(0.03f);
        dialog.transform.localScale = new Vector3(1, 0.4f, 1);
        yield return new WaitForSeconds(0.03f);
        dialog.transform.localScale = new Vector3(1, 0.2f, 1);
        yield return new WaitForSeconds(0.03f);
        dialog.transform.localScale = new Vector3(1, 0f, 1);
        yield return new WaitForSeconds(0.03f);
    }
}
