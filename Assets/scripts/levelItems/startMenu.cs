using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class startMenu : MonoBehaviour {

    bool onLoading = false;
    public GameObject levelAudio;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void startLevel1()
    {
        if (!onLoading)
        {
            onLoading = true;
            levelAudio.SetActive(true);
            SceneManager.LoadScene("level1new", LoadSceneMode.Single);
        }
    }
    public void startLevel0()
    {
        if (!onLoading)
        {
            onLoading = true;
            levelAudio.SetActive(true);
            SceneManager.LoadScene("level0", LoadSceneMode.Single);
        }
    }

    public void startLevel2()
    {
        onLoading = true;
        levelAudio.SetActive(true);
        SceneManager.LoadScene("level2new", LoadSceneMode.Single);
    }
}
