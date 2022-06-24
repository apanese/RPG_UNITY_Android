using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolfbaby : MonoBehaviour
{
    public State state = State.walk;
    public CharacterController characterController;
    public float speed;
    public Animation animation;
    public float timer = 0;
    public float time = 1;
    public string aniname_now;
    public string WolfBabyWalk;
    public string WolfBabyAttack1 ;
    public string WolfBabyAttack2  ;
    public string WolfBabyDeath ;
    public string WolfBabyIdle;
    public string WolfBabyTakeDamage1;
    public string WolfBabyTakeDamage2;
    public string WolfBabyAttackCritical;
    public float miss_rate = 0.2f; //miss率
    public float hp = 100.0f;
    public GameObject body; //敌人身体赋值2
    public Color normal; //敌人原先颜色
    public Transform target;
    public AudioClip miss_sound;
    //public int hp;
    public GameObject hudtextFollow; //body下的hudtext空物体
    private GameObject hudtextGo;
    public GameObject hudtextPrefab;

    public HUDText hudtext;
    private UIFollowTarget followTarget; //获取followTarget的脚本
    private IEnumerator showbodyred;
    public float attackmindistance ;
    public float attackmaxdistance ;
    public float realdistance;
    public float animtime_normal_attack; //正常攻击动画播放时间
    public float animtime_crazy_attack; //正常攻击动画播放时间
    public float animtime_death; //死亡动画播放时间
    public string aniname_attack_now; //专门用来存储attack状态里几个不同的动画状态：normalattack，crazyattack,idle
    public WolfSpawn spawn;
    public int attack = 10;
    public int attack_rate = 1;

    // Start is called before the first frame update
    void Start()
    {
        aniname_now = WolfBabyIdle;
        characterController = GetComponent<CharacterController>();
        animation = GetComponent<Animation>();
        normal = body.GetComponent<Renderer>().material.color;

        hudtextGo = NGUITools.AddChild(HudTextParent._instance.gameObject, hudtextPrefab);  //每增一个预制字把它命名为hudtextGo，该物品的parent为UIRoot下的HudTextParent
        hudtext = hudtextGo.GetComponent<HUDText>();
        followTarget = hudtextGo.GetComponent<UIFollowTarget>();
        followTarget.target = hudtextFollow.transform;
        followTarget.gameCamera = Camera.main;
        attackmindistance = 1.3f;
        attackmaxdistance = 10;
        speed = 1;
        animtime_normal_attack = 0.833f;
        hp = 100f;
        //animtime_death = 0.833f;
    }

    // Update is called once per frame
    void Update()
    {
       
        teststate();
        //if (Input.GetKeyDown(KeyCode.Escape))
        //{
        //    TakeDamage(10);
        //    //teststate();
        //}

    }
    private void FixedUpdate()
    {
        
    }
    private void LateUpdate()
    {
        //characterController.SimpleMove(transform.forward * speed);
        //animation.Play(WolfBabyWalk);
    }
    void teststate()
    {
        if (state == State.attack1)
        {
            ///aniname_now = WolfBabyAttack1;
            AutoAttack();
        }
        //else if (state == State.attack2)
        //{
        //    //aniname_now = WolfBabyAttack2;
        //    animation.CrossFade("WolfBaby-Attack2");
        //}
        else if (state == State.death)
        {
            if (aniname_now != WolfBabyDeath) //使timer归0
            {
                timer = 0;
                aniname_now = WolfBabyDeath;
            }
            //aniname_now = WolfBabyDeath;
            animation.CrossFade(aniname_now);
            timer += Time.deltaTime;
            if(timer>animtime_death)
            {
                Destroy(this.gameObject);
                timer = 0;
            }
        }
        else
        {
            
            animation.CrossFade(aniname_now);
            if (aniname_now == WolfBabyWalk)  //巡逻
            {
                characterController.SimpleMove(transform.forward * speed);

            }
            timer += Time.deltaTime;
            if (timer > time)
            {
                timer = 0;
                RandomState();
            }
        }
    }
    void RandomState()
    {
        int value = Random.Range(0, 2);
        if (value == 0)
        {
            aniname_now = WolfBabyIdle;
        }
        else
        {
            if (aniname_now != WolfBabyWalk)
            {
                transform.Rotate(transform.up * Random.Range(0, 360));
            }
            aniname_now = WolfBabyWalk;
        }
    }



    //1.前播放动画
    //2.现播放动画
    //3.timer代表状态持续多久
    //4.
    void changestateinusually() //巡逻代码
    {
        if (state == State.walk)
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {
                state = State.idle;
                timer = 0;
            }
        }
        else if (state == State.idle)
        {
            timer += Time.deltaTime;
            if (timer >= time)
            {

            }
        }
    }
    public void TakeDamage(int attack)
    {
        if (state == State.death) return;
        target = GameObject.FindGameObjectWithTag(Tags.player).transform;
        state = State.attack1;
        float value = Random.Range(0f, 1f);
        showbodyred = ShowBodyRed();
        if (value < miss_rate) //miss效果
        {
            hudtext.Add("Miss", Color.gray, 1);
        }
        else  //打中效果
        {
            this.hp -= attack;
            hudtext.Add(attack.ToString(), Color.red, 1);
            StartCoroutine(showbodyred);
            if (this.hp <= 0)
            {
                state = State.death;
            }
        }
    }


    private IEnumerator ShowBodyRed()
    {
        body.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1f);
        body.GetComponent<Renderer>().material.color = normal;
    }

    void AutoAttack()
    {
        
        if (target != null) //如果目标不为空
        {
            realdistance = Vector3.Distance(target.position, this.transform.position); //获取两者的距离
            if(realdistance < attackmindistance) //且距离小于攻击距离
            {
                transform.LookAt(target);
                animation.CrossFade(aniname_attack_now);
                timer += Time.deltaTime;
                
                if (aniname_attack_now == WolfBabyAttack1)
                {
                    if(timer> animtime_normal_attack)
                    {
                        target.GetComponent<PlayerAttack>().TakeDamage(attack);
                        aniname_attack_now = WolfBabyIdle;
                    }
                }else if(aniname_attack_now == WolfBabyAttack2)
                {
                    if (timer > animtime_crazy_attack)
                    {
                        target.GetComponent<PlayerAttack>().TakeDamage(2*attack);
                        aniname_attack_now = WolfBabyIdle;
                    }
                }
                if (timer > (1f / attack_rate))
                {
                    timer = 0;
                    RandomAttack();
                }

                
            }
            else if (realdistance > attackmaxdistance)
            {
                target = null;
                state = State.idle;
                return;
            }
            else
            {
                transform.LookAt(target);
                characterController.SimpleMove(transform.forward * speed);
                animation.CrossFade(WolfBabyWalk);
            }
        }
        else
        {

        }
    }
    void RandomAttack()
    {
        float value = Random.Range(0, 5);
        if(value > 1)
        {
            aniname_attack_now = WolfBabyAttack1;
        }
        else
        {
            aniname_attack_now = WolfBabyAttack2;
        }
    }
    public void OnMouseOver()
    {
        //CursorManager._instance.setlock_target();
        CursorManager._instance.setattack();
    }
    public void OnMouseExit()
    {
        CursorManager._instance.setnormal();
    }
}

public enum State
{
    idle,
    walk,
    attack1,
    attack2,
    death,
    demage
}




