using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.AI;
using UnityEngine.EventSystems;


public class playerMove : MonoBehaviour {

    public static playerMove Instance = new playerMove();

    Vector3 screenPosition;
    Vector3 mousePositionOnScreen;
    Vector3 mousePositionInWorld;
    Vector2 mouseXY;
    Vector3 mousePoint;


    [HideInInspector]
    public bool playerDead = false;

    public GameCon GameContent;

    private NavMeshAgent agent;
    private Vector3 test;
    //public float zAxis=0;

    Vector3 playerPosition;
    public float StepDistance=1f;
    public GameObject machElf;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        Debug.Log("awake");
    }

    public void Update()
    {
        /*
        if (Input.GetMouseButtonDown(0)&&!playerDead)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 1000))
            {
                if (GameContent.isDOZEN)
                {
                    //Debug.Log(hit.point);
                    test.x = hit.point.x;
                    test.y = hit.point.y;
                    //test.z = hit.point.z;//测试
                    test.z = this.transform.position.z;
#if UNITY_EDITOR
                    if (EventSystem.current.IsPointerOverGameObject())
                    {
                    Debug.Log("point on UI");
                    }

#elif UNITY_STANDALONE_WIN
                     if (EventSystem.current.IsPointerOverGameObject())
                    {
                    Debug.Log("point on UI");
                    }
#elif UNITY_ANDROID
                    
                   if (playerMove.Instance.IsPointerOverUIObject(Input.GetTouch(0).position))
                   {
                       Debug.Log("方法二： 点击在UI 上");
                   }
                   
#endif
                    else
                    {
                    //Debug.Log(test);
                        if (GameContent.isHidden)
                        {
                            GameContent.DozenLeaveHidden();//当主角移动的时候，解除隐藏
                        }
                    //agent.Resume();
                    //agent.enabled = true;
                    //agent.setS
                    //agent.velocity = new Vector3(0, 0, 0);
                    StartCoroutine(wait());
                    agent.destination = test;
                        
                    }
                    
                }

            }
        }*/
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(0.01f);
    }

    public void hideMove(Vector3 hideHere)//走到隐藏点
    {
        Vector3 i;
        i.x = hideHere.x;
        i.y = hideHere.y;
        i.z = this.transform.position.z;
        //agent.Resume();
        agent.enabled = true;
        agent.destination = i;
        Debug.Log("hide place " + i);
        Debug.Log("hide.");
    }

    public void stopImmiediately()
    {
        //agent.destination = this.transform.position;
        //agent.Stop();
        agent.enabled = false;
    }

    public bool IsPointerOverUIObject(Vector2 screenPosition)
    {
        //实例化点击事件
        PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
        //将点击位置的屏幕坐标赋值给点击事件
        eventDataCurrentPosition.position = new Vector2(screenPosition.x, screenPosition.y);

        List<RaycastResult> results = new List<RaycastResult>();
        //向点击处发射射线
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);

        return results.Count > 0;
    }

    public void moveRight()
    {
        if (GameContent.isHidden)
        {
            GameContent.DozenLeaveHidden();//当主角移动的时候，解除隐藏
        }
        moveElf();
        getPlayerPosition();
        Vector3 rightPosition = new Vector3(playerPosition.x+StepDistance, playerPosition.y, playerPosition.z);
        agent.destination = rightPosition;
    }

    public void moveLeft()
    {
        if (GameContent.isHidden)
        {
            GameContent.DozenLeaveHidden();//当主角移动的时候，解除隐藏
        }
        moveElf();
        getPlayerPosition();
        Vector3 leftPosition = new Vector3(playerPosition.x - StepDistance, playerPosition.y, playerPosition.z);
        agent.destination = leftPosition;
    }

    public void moveUp()
    {
        if (GameContent.isHidden)
        {
            GameContent.DozenLeaveHidden();//当主角移动的时候，解除隐藏
        }
        moveElf();
        agent.destination = new Vector3(agent.destination.x, agent.destination.y + StepDistance, agent.destination.z);
    }

    public void moveDown()
    {
        if (GameContent.isHidden)
        {
            GameContent.DozenLeaveHidden();//当主角移动的时候，解除隐藏
        }
        moveElf();
        agent.destination = new Vector3(agent.destination.x, agent.destination.y - StepDistance, agent.destination.z);
    }

    public void getPlayerPosition()
    {
        playerPosition = this.gameObject.transform.position;
    }

    public void moveElf()
    {
        machElf.GetComponent<NavMeshAgent>().speed = 20;
        machElf.GetComponent<NavMeshAgent>().destination = new Vector3(playerPosition.x, playerPosition.y + 20, playerPosition.z + 10);
    }
}
