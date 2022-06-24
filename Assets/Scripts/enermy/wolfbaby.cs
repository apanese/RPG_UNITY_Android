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
    public float miss_rate = 0.2f; //miss��
    public float hp = 100.0f;
    public GameObject body; //�������帳ֵ2
    public Color normal; //����ԭ����ɫ
    public Transform target;
    public AudioClip miss_sound;
    //public int hp;
    public GameObject hudtextFollow; //body�µ�hudtext������
    private GameObject hudtextGo;
    public GameObject hudtextPrefab;

    public HUDText hudtext;
    private UIFollowTarget followTarget; //��ȡfollowTarget�Ľű�
    private IEnumerator showbodyred;
    public float attackmindistance ;
    public float attackmaxdistance ;
    public float realdistance;
    public float animtime_normal_attack; //����������������ʱ��
    public float animtime_crazy_attack; //����������������ʱ��
    public float animtime_death; //������������ʱ��
    public string aniname_attack_now; //ר�������洢attack״̬�Ｘ����ͬ�Ķ���״̬��normalattack��crazyattack,idle
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

        hudtextGo = NGUITools.AddChild(HudTextParent._instance.gameObject, hudtextPrefab);  //ÿ��һ��Ԥ���ְ�������ΪhudtextGo������Ʒ��parentΪUIRoot�µ�HudTextParent
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
            if (aniname_now != WolfBabyDeath) //ʹtimer��0
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
            if (aniname_now == WolfBabyWalk)  //Ѳ��
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



    //1.ǰ���Ŷ���
    //2.�ֲ��Ŷ���
    //3.timer����״̬�������
    //4.
    void changestateinusually() //Ѳ�ߴ���
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
        if (value < miss_rate) //missЧ��
        {
            hudtext.Add("Miss", Color.gray, 1);
        }
        else  //����Ч��
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
        
        if (target != null) //���Ŀ�겻Ϊ��
        {
            realdistance = Vector3.Distance(target.position, this.transform.position); //��ȡ���ߵľ���
            if(realdistance < attackmindistance) //�Ҿ���С�ڹ�������
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




