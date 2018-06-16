using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class start : MonoBehaviour {

    public Image logo;
    public GameObject Dozen;
    public GameObject Title;
    public GameObject tap;
    public GameObject background;
    public GameObject words;

	// Use this for initialization
	void Start () {
        showLogo();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void showLogo()
    {
        StartCoroutine(logoChange());
    }
    IEnumerator logoChange()
    {
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.1f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.3f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.7f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.9f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 1);
        yield return new WaitForSeconds(1);
        logo.color = new Color(1, 1, 1, 0.9f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.7f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.3f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0.1f);
        yield return new WaitForSeconds(0.1f);
        logo.color = new Color(1, 1, 1, 0);
        yield return new WaitForSeconds(0.1f);
        logo.gameObject.SetActive(false);
        StartCoroutine(showDozen());
    }

    IEnumerator showDozen()
    {
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.9f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        StartCoroutine(showTitle());
        
    }
    IEnumerator showTitle()
    {
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.9f);
        yield return new WaitForSeconds(0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        showTap();
    }

    public void showTap()
    {
        tap.SetActive(true);
    }
    public void hideandShow()
    {
        StartCoroutine(hideDozenshowBackground());
    }

    IEnumerator hideDozenshowBackground()
    {
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.9f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.9f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.4f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.6f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.3f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.7f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.2f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.8f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0.1f);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 0.9f);
        yield return new WaitForSeconds(0.1f);
        Dozen.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        Title.GetComponent<Image>().color = new Color(1, 1, 1, 0);
        background.GetComponent<Image>().color = new Color(1, 1, 1, 1);
        words.SetActive(true);
    }
}
