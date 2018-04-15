using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// 用来进行相邻房间的判断，并且负责开关的打开
/// </summary>
public class houseController : MonoBehaviour
{
    public GameCon GameContent;
    public GameObject[] houseBetweens;
    public bool hearPlayer = false;//这个房间内是否听到了主角，默认都是没有的


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameContent.isHidden)
        {
            if (houseBetweens.Length > 0)
            {
                for (int i = 0; i < houseBetweens.Length; i++)
                {
                    houseBetweens[i].GetComponent<houseController>().hearPlayer = false;
                    //Debug.Log("I don't hear you any more!" + houseBetweens[i].name);
                }
            }
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        //这里需要加东西
        if (!GameContent.isHidden)
        {
            if (collision.tag == "Player")
            {
                if (houseBetweens.Length > 0)
                {
                    for (int i = 0; i < houseBetweens.Length; i++)
                    {
                        houseBetweens[i].GetComponent<houseController>().hearPlayer = true;
                        //Debug.Log("I hear you!" + houseBetweens[i].name);
                    }
                }
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (houseBetweens.Length > 0)
            {
                for(int i = 0; i < houseBetweens.Length; i++)
                {
                    houseBetweens[i].GetComponent<houseController>().hearPlayer = false;
                    //Debug.Log("I don't hear you any more!" + houseBetweens[i].name);
                }
            }
        }
    }
}
