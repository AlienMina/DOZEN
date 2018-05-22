using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class elevator : MonoBehaviour
{

    public GameCon gameCon;//公共开关的调用
    public GameObject elevatorAnim;//升降梯
    public GameObject player;


    public GameObject upperPoint;//电梯上方的目标点
    public GameObject upperEnd;//在上方时的下电梯的位置
    public GameObject lowerPoint;//电梯下方的目标点
    public GameObject lowerEnd;//在下层时的下电梯的位置

    int elevatorPlace = 1;//电梯的位置，默认是在上面。0-下方，1-上方
    public float between = 1;//计算用的间距

    bool isDown = false;
    bool isUp = false;

    bool elevatorMoving = false;//电梯是否在移动
    bool readyToLeaveElevator = false;//是否已经要离开电梯

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (isDown)
        {
            elevatorDownUpdate();
        }
        if (isUp)
        {
            elevatorUpUpdate();
        }
    }
    /// <summary>
    /// 电梯下行
    /// </summary>
    public void setElevatorDown()
    {
        //已经上电梯了，点击也点不走了
        gameCon.isElevator = true;
        isDown = true;
        //elevatorAnim.transform.position = upperPoint.transform.position;
       Debug.Log(Mathf.Abs(player.GetComponent<NavMeshAgent>().remainingDistance));
        //走到平台上
        player.GetComponent<NavMeshAgent>().destination = upperPoint.transform.position;

    }
    void elevatorDownUpdate()
    {
        //如果正在准备离开
        if (readyToLeaveElevator)
        {
            player.GetComponent<NavMeshAgent>().destination = lowerEnd.transform.position;
            //如果已经到达了目标点
            if (Mathf.Abs(player.transform.position.x - lowerEnd.transform.position.x) < between)
            {
                gameCon.isElevator = false;
                isDown = false;
                readyToLeaveElevator = false;
                Debug.Log("finish elevator");
            }
        }
        else if (!gameCon.moveable)//如果人物不能播放动画
        {
            player.GetComponent<NavMeshAgent>().destination = lowerPoint.transform.position;
            //移动电梯……
            elevatorAnim.transform.position = player.transform.position;
           
            //如果已经到达了目标点
            if (Mathf.Abs(player.transform.position.y - lowerPoint.transform.position.y) < between)
            {
                Debug.Log("moveable: " + gameCon.moveable);
                gameCon.moveable = true;
                Debug.Log("moveable: " + gameCon.moveable);
                readyToLeaveElevator = true;
            }
        }
        else
        {
            if (Mathf.Abs(player.transform.position.x - upperPoint.transform.position.x) < between)
            //if (Mathf.Abs(player.GetComponent<NavMeshAgent>().remainingDistance) < between)
            {
                //禁止播放移动动画
                gameCon.moveable = false;
                Debug.Log("moveable false");
                isDown = true;
            }
        }
    }

    public void setElevatorUp()
    {
        //已经上电梯了，点击也点不走了
        gameCon.isElevator = true;
        isUp = true;
        //elevatorAnim.transform.position = lowerPoint.transform.position;
      // Debug.Log(Mathf.Abs(player.GetComponent<NavMeshAgent>().remainingDistance));
        //走到平台上
        player.GetComponent<NavMeshAgent>().destination = lowerPoint.transform.position;

    }

    void elevatorUpUpdate()
    {
        //如果正在准备离开
        if (readyToLeaveElevator)
        {
            player.GetComponent<NavMeshAgent>().destination = upperEnd.transform.position;
            //如果已经到达了目标点
            if (Mathf.Abs(player.transform.position.x - upperEnd.transform.position.x) < between)
            {
                gameCon.isElevator = false;
                isUp = false;
                readyToLeaveElevator = false;
                Debug.Log("finish elevator");
            }
        }
        else if (!gameCon.moveable)//如果人物不能播放动画
        {
            player.GetComponent<NavMeshAgent>().destination = upperPoint.transform.position;
            //移动电梯……
            elevatorAnim.transform.position = player.transform.position;
            //如果已经到达了目标点
            if (Mathf.Abs(player.transform.position.y - upperPoint.transform.position.y) < between)
            {
                Debug.Log("moveable: " + gameCon.moveable);
                gameCon.moveable = true;
                Debug.Log("moveable: " + gameCon.moveable);
                readyToLeaveElevator = true;
            }
        }
        else
        {
            if (Mathf.Abs(player.transform.position.x - lowerPoint.transform.position.x) < between)
            //if (Mathf.Abs(player.GetComponent<NavMeshAgent>().remainingDistance) < between)
            {
                //禁止播放移动动画
                gameCon.moveable = false;
                Debug.Log("moveable false");
                isUp = true;
            }
        }
    }
}
