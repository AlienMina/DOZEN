using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyMove : MonoBehaviour {

    [Header("全局的一些东西")]
    public GameCon GameContent;
    //GameObject houseTag;//这个是敌人检测到的自己所在的地块
    

    [Space(10)]
    [Header("巡逻的两个点")]
    public Vector3 place1;//巡逻的初始点
    public GameObject place2;//巡逻的终点，请拖一个Object

    [Space(10)]
    [Header("追主角相关")]
    public AudioSource audios;//追主角时的声音
    public GameObject alert;//追逐时的红色动画
    //public GameObject enemyAnima;
    //Vector3 enemyPlace;
    public GameObject gameplayer;//追逐玩家时的玩家位置    
    public float chasingTime = 3f;//追逐时敌人的追逐时间
    [HideInInspector] public bool chasingTimer = false;//追逐用的timer
    [HideInInspector] public float oldTime=0;//追逐时计时器的起始时间
    

    [Space(10)]
    public float between = 0.1f;//被小精灵吸引时的距离判断

    [HideInInspector]
    public bool chasingVoice = false;//追声音
    [HideInInspector]
    public bool chasingPlayer = false;//追主角
    [HideInInspector]
    public bool isChasing = false;//正在追……用于chasingPlayer内部的判断
    [HideInInspector]
    public bool isAttracted = false;//追小精灵
    


    private NavMeshAgent agent;//寻路用的

    Vector3 voicePlace;
    Vector3 playerPlace;
    [HideInInspector]
    public Vector3 attractedPlace;//追逐小精灵时候的定位点
    [HideInInspector]
    public bool attring = false;//追逐的单独判断，这个公共是为了进行状态动画的结算，不涉及其它

    public bool setVoicePlace = false;//追声音的时候，用于判定是否定位，如果已经做了定位，打开它，当走到声源位置或者中间就撞到了主角，关闭它
    [HideInInspector]
   public  bool attractedSet = false;//用于小精灵吸引内部的判断


    float oldSpeed;
    float newSpeed;//敌人追击速度的调整

    [HideInInspector]
    public bool isDizz;//是否有被小精灵眩晕
    [HideInInspector]
    public bool dizzy = false;//正在进行眩晕结算吗，这个公共是为了进行状态动画的结算，不涉及其它

    public float dizzyTime=3;
    public GameObject view;

    [HideInInspector]
    public bool isReturn = false;//这个是为了进行状态动画而设置的，只有在它打开的时候才清空头顶的状态

    

    public float elfSoundWait = 5f;

    float speedBeforeStop;

    bool isReturning = false;


    //这里是一组给enemyState用的

    [HideInInspector] public bool enemyDizzy = false;
    [HideInInspector] public bool enemyChasing = false;
    [HideInInspector] public bool enemyHeard = false;
    [HideInInspector] public bool nothingOnHead = true;


    // Use this for initialization
    void Start () {
        place1 = this.GetComponent<Transform>().position;//敌人巡逻的起始点
        agent = GetComponent<NavMeshAgent>();//寻路的设置
        agent.enabled = true;
        oldSpeed = agent.speed;
        newSpeed = oldSpeed * 1.2f;
        isDizz = false;
        if (alert != null)
        {
            alert.SetActive(false);
        }
        speedBeforeStop = this.gameObject.GetComponent<NavMeshAgent>().speed;
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameContent.enemyStop)
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = speedBeforeStop;
            speedBeforeStop = this.gameObject.GetComponent<NavMeshAgent>().speed;
            
        }
        else
        {
            this.gameObject.GetComponent<NavMeshAgent>().speed = 0;
        }
        #region oldCode
        //enemyPlace = this.GetComponent<Transform>().position;
        //if (!chasingPlayer && !chasingVoice)
        //StartCoroutine(patrol());
        //enemyAnima.GetComponent<houseController>().hearPlayer
        //if (enemyAnima != null)
        //{
        // houseTag = enemyAnima.GetComponent<getHouseTag>().houseBetween;
        //}
        //Debug.Log(houseTag);
        #endregion
        //优先进行判断，追主角优先度>小精灵声音>追主角声音>巡逻，当没有追玩家也没有追声音的时候，进行检测【同时由playmaker进行巡逻】
        //优先进行判断：当敌人被小精灵闪光晕眩了，这个优先级高于其他一切。

        //----------上面的都是扯蛋了
        //晕眩保留，去除掉追主角声音的部分
        /*
         晕眩的部分暂且不考虑，然后要把后面的一些判断的地方加上state图标的调整……
         还是给一组特定的布尔值让它去判断吧
         */
        if (isDizz)//如果眩晕了的操作
        {
            chasingPlayer = false;
            isAttracted = false;
            chasingVoice = false;
            isChasing = false;
            setVoicePlace = false;
            Debug.Log("Dizzy.");
            dizzy = true;
            isDizz = false;
            StartCoroutine(Dizzy());
            //下面是头顶状态相关的东西
            enemyDizzy = true;
            enemyChasing = false;
            enemyHeard = false;
            nothingOnHead = false;
        }
        #region wrongArea
        /*这里的逻辑应该是有问题的……需要修改
        if (agent.destination == place1)//当主角开始准备回自己初始点的时候……这里好像得改改，和巡逻逻辑有冲突
        {
            audios.gameObject.SetActive(false);
            alert.SetActive(false);
            chasingPlayer = false;
            Debug.Log("stop chasing alert?");
            //下面是头顶状态相关的东西
            nothingOnHead = true;
            enemyDizzy = false;
            enemyChasing = false;
            enemyHeard = false;
        }
        */
        #endregion
        if (chasingTimer)
        {
            ChasingTimer();
            //下面是头顶状态相关的东西
            enemyChasing = true;
            enemyHeard = false;
            nothingOnHead = false;
        }
        else if (chasingPlayer)//如果是在追玩家，这个地方应该是放出叹号的
        {
            //打开声音和警报
            audios.gameObject.SetActive(true);
            alert.SetActive(true);
            //追主角
            ChasingPlayer();
            //下面是头顶状态相关的东西
            enemyChasing = true;
            enemyHeard = false;
            nothingOnHead = false;

        }
        else if (isAttracted)//小精灵的声音优先级大于主角的声音    ---这里应该是听到声音放出问号了
        {

            if (!attring)
            {
                agent.destination = attractedPlace;
                StartCoroutine(attractedByMachelf());
                //下面是头顶状态相关的东西
                nothingOnHead = false;
                enemyHeard = true;
            }

        }
        else//在这里要清空头顶上的标志
        {
            if (place2 != null)
            {
                Patrol();
                //下面是头顶状态相关的东西
                enemyChasing = false;
                enemyHeard = false;
                enemyDizzy = false;
                nothingOnHead = true;
            }
        }
        #region oldCode
        /*这里也不需要了，注掉吧……
        else if(chasingVoice){
            //StartCoroutine(ChasingVoice());
            //ChasingVoice();
        }
        
        else if (houseTag!=null && houseTag.GetComponent<houseController>().hearPlayer)
        {
            //Debug.Log("chaseVoice=true");
            //chasingVoice = true;//当地块上可以听到player的时候，开启追逐声源效果
            //houseTag.GetComponent<houseController>().hearPlayer = false;
        }*/
        #endregion
    }

    #region trash
    //获取当前的地块--这里应该是获取下面挂载的动画小朋友的碰撞

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.tag == "houseTag")
    //    {
    //        houseTag = collision.GetComponent<GameObject>();
    //        Debug.Log("setHouseTag");
    //    }
    //}
    #endregion

    public void Patrol()
    {

        Debug.Log("Patrol.");
        if (!isReturning)
        {
            patrol2place2();
            if (Mathf.Abs(this.gameObject.transform.position.x - place2.transform.position.x) < 0.1f)
            {
                isReturning = true;
            }
        }
        else
        {
            patrol2place1();
            if (Mathf.Abs(this.gameObject.transform.position.x - place1.x) < 0.1f)
            {
                isReturning = false;
            }
        }
        
    }

    //这两个是（原计划用于）playmaker用的移动，现在被改成了普通巡逻用
    public void patrol2place2()
    {
        if (place2 != null)
            agent.destination = place2.transform.position;
        else
            Debug.Log("noPlace2");
    }

    public void patrol2place1()
    {
        agent.destination = place1;
    }
    
    //追逐玩家
    void ChasingPlayer()
    {
        if (!GameContent.isHidden)//在主角没有藏起来的状态下
        {
            //关闭其他的状态
            isAttracted = false;

            //向主角的位置移动
            playerPlace = gameplayer.GetComponent<Transform>().position;
            agent.speed = newSpeed;//调整速度
            agent.destination = playerPlace;//向主角移动

            #region oldCode
            /*
            //停止追声音的行为
            chasingVoice = false;
            setVoicePlace = false;

            playerPlace = gameplayer.GetComponent<Transform>().position;
            
            //检测主角的位置
            if (!isChasing)//主角已经不在视野范围内了
            {
                //这里需要改，改成计时
                //不在视野范围内，如果没有打开计时器开关，打开它，并且记录下当前的时间
                if (!chasingTimer)
                {
                    Debug.Log("OpenChasingTimer");
                    oldTime = Time.time;
                    chasingTimer = true;
                }
                else
                {
                    //如果时间已经超过了
                    Debug.Log("oldTime:"+oldTime + "timeNow:"+Time.time + "chasingTime:"+chasingTime);
                    if (Time.time - oldTime > chasingTime)
                    {
                       
                        chasingTimer = false;
                        oldTime = 0;

                        audios.gameObject.SetActive(false);
                        chasingPlayer = false;
                        agent.speed = oldSpeed;
                        alert.SetActive(false);
                        isReturn = true;
                        agent.destination = place1;//返回初始地点

                        //下面是头顶状态相关的东西
                        enemyChasing = false;
                        enemyHeard = false;
                        enemyDizzy = false;
                        nothingOnHead = true;
                    }
                }
                

                
                string enemyHouseName = houseTag.name;
                string playerHouseName = gameplayer.GetComponentInChildren<playerHouseTag>().playerHouseName;
                //Debug.Log("enemyHouseName " + enemyHouseName + " playerHouseName " + playerHouseName);
                if (enemyHouseName != playerHouseName)//敌人和主角不在同一房间
                {
                    audios.gameObject.SetActive(false);
                    chasingPlayer = false;
                    agent.speed = oldSpeed;
                    alert.SetActive(false);
                    isReturn = true;
                    agent.destination = place1;//返回初始地点
                }
                
            }
            else
            {
                chasingTimer = false;//进入视野范围，关闭计时器

                agent.speed = newSpeed;
                agent.destination = playerPlace;
            }
            */
            #endregion
        }
        else
        {
            //这里需要调整，有一些东西需要关掉，有一些不需要
            audios.gameObject.SetActive(false);
            chasingPlayer = false;
            chasingVoice = false;
            setVoicePlace = false;
            agent.speed = oldSpeed;
            alert.SetActive(false);
            isReturn = true;
            agent.destination = place1;

            //下面是头顶状态相关的东西
            enemyChasing = false;
            enemyHeard = false;
            enemyDizzy = false;
            nothingOnHead = true;
        }

    }

    //离开主角视野之后的持续追击部分
    void ChasingTimer()
    {
        if (!GameContent.isHidden)
        {
                //如果时间已经超过了，就扭头回去，否则继续追
            //Debug.Log("oldTime:" + oldTime + "timeNow:" + Time.time + "chasingTime:" + chasingTime);
            if (Time.time - oldTime > chasingTime)
            {
                //Debug.Log(Time.time - oldTime + "return.");
                chasingTimer = false;
                oldTime = 0;

                audios.gameObject.SetActive(false);
                chasingPlayer = false;
                agent.speed = oldSpeed;
                alert.SetActive(false);
                isReturn = true;
                agent.destination = place1;//返回初始地点

                    //下面是头顶状态相关的东西
                enemyChasing = false;
                enemyHeard = false;
                enemyDizzy = false;
                nothingOnHead = true;
            }
            else
            {
                //向主角的位置移动
                playerPlace = gameplayer.GetComponent<Transform>().position;
                agent.speed = newSpeed;//调整速度
                agent.destination = playerPlace;//向主角移动
            }
            
        }
        else
        {
            chasingTimer = false;
            oldTime = 0;

            audios.gameObject.SetActive(false);
            chasingPlayer = false;
            agent.speed = oldSpeed;
            alert.SetActive(false);
            isReturn = true;
            agent.destination = place1;//返回初始地点

            //下面是头顶状态相关的东西
            enemyChasing = false;
            enemyHeard = false;
            enemyDizzy = false;
            nothingOnHead = true;
        }

    }

    //前往声源【废弃
    IEnumerator ChasingVoice()
    {
        //不想改代码了，直接注掉……
        yield return new WaitForSeconds(0.01f);
        #region oldCode
        /*
        if (!setVoicePlace)
        {
            //如果还没有设置声源点，那么设置为当前主角的位置
            voicePlace=gameplayer.GetComponent<Transform>().position;
            agent.destination = voicePlace;
            setVoicePlace = true;
            Debug.Log("chasing voice start");
        }
        else //如果已经设置了声源点的情况
        {
            //判断是否已经到达【只判断平面上的情况
            if (voicePlace.x - this.GetComponent<Transform>().position.x <= between &&voicePlace.y-this.GetComponent<Transform>().position.y<=between)
            {
                Debug.Log(houseTag);
                setVoicePlace = false;
                chasingVoice = false;
                

                isReturn = true;
                agent.destination = place1;
                Debug.Log("chasing finished.");
            }
        }
        */
        #endregion
    }

    //被小精灵吸引
    public IEnumerator attractedByMachelf()
    {
        yield return new WaitForSeconds(1f);
        //Debug.Log("wait.");
        if (Mathf.Abs(agent.remainingDistance) < between)
        {
            attring = true;
                Debug.Log(agent.remainingDistance);
                yield return new WaitForSeconds(elfSoundWait);
                Debug.Log("wati fininshed.");
            //Debug.Log(this.GetComponent<Transform>().position);
            isAttracted = false;
            isReturn = true;
            agent.destination = place1;
            //下面是头顶状态相关的东西
            enemyChasing = false;
            enemyHeard = false;
            enemyDizzy = false;
            nothingOnHead = true;

            attring = false;
        }
        #region trash
        //}
        /*
        if (!attractedSet)
        {
            //如果还没有设置小精灵的位置
            attractedPlace = GameObject.Find("MachElfT-10").GetComponent<Transform>().position;
            agent.destination = attractedPlace;
            attractedSet = true;
            Debug.Log("attracted Place: " + attractedPlace+this.name);
        }
        else//如果已经设置了声源点
        {
            //截取一段时间内的敌人的位置
            Vector3 enemPlace = this.GetComponent<Transform>().position;
            yield return new WaitForSeconds(2);
            Vector3 enemplace2 = this.GetComponent<Transform>().position;

            //如果已经到了声源点
            if (enemPlace.x-enemplace2.x<=between&&enemPlace.y-enemplace2.y<=between)
                /*aattractedPlace.x - this.GetComponent<Transform>().position.x <= 5 && attractedPlace.y - this.GetComponent<Transform>().position.y <= 5
            {
                
                Debug.Log("this.place " + this.GetComponent<Transform>().position);
                attractedSet = false;
                isAttracted = false;
                yield return new WaitForSeconds(1);
                agent.destination = place1;                
                Debug.Log("finish being attracted");
                //停顿1s后，结束吸引状态，返回原处
            }
        } */
        #endregion
    }

    #region trash
    //IEnumerator patrol() {       
    //    if (isPlace1)
    //        agent.destination = place2.transform.position;
    //    else
    //        agent.destination = place1;
    //    if(agent.remainingDistance <= agent.stoppingDistance + between)
    //    {
    //      yield return new WaitForSeconds(5);
    //        if (isPlace1)
    //        {
    //            isPlace1 = false;
    //            Debug.Log("is Place1 false.");
    //        }
    //        else
    //        {
    //            isPlace1 = true;
    //            Debug.Log("is Place1 true.");
    //        }
    //    }

    //}
    #endregion

    public void stopMove()
    {
        agent.speed=0;
    }

    /// <summary>
    /// 敌人被晕眩的时候
    /// </summary>
    /// <returns></returns>
    IEnumerator Dizzy()
    {
        if (dizzy)
        {
            float oldSpeed = agent.speed;
            view.SetActive(false);
            agent.speed = 0;
            yield return new WaitForSeconds(dizzyTime);
            //Debug.Log(oldSpeed);
            agent.speed = oldSpeed;
            // Debug.Log(agent.speed);
            isReturn = true;
            agent.destination = place1;
            //下面是头顶状态相关的东西
            enemyChasing = false;
            enemyHeard = false;
            enemyDizzy = false;
            nothingOnHead = true;

            view.SetActive(true);
            dizzy = false;
        }
    }




}
