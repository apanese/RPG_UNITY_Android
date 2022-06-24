using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerState
{
    ControlWalk,
    NormalAttack,
    SkillAttack,
    Death
}
public enum AttackState
{
    Moving,
    Idle,
    Attack
}

public class PlayerAttack : MonoBehaviour
{
    public static PlayerAttack _instance;
    public PlayerState state = PlayerState.ControlWalk;
    public AttackState attack_state = AttackState.Idle;

    public string aniname_normalattack= "Attack1";
    public string aniname_skillattack = "AttackCritical";
    public string aniname_death = "Death";
    public string aniname_now;
    public string aniname_idle = "Idle";
    public string aniname_walk = "Walk";


    public float time_normalattack; 
    public float rate_normalattack = 1;
    private float timer = 0;
    public float min_distance = 5; 

    private Transform target_normalattack;
    private PlayerMove move;
    public GameObject effect;
    private bool showEffect = false;
    private PlayerStatus ps; 
    public float miss_rate = 0.25f;

    public GameObject hudtextPrefab;
    public GameObject hudtextFollow;
    private GameObject hudtextGo;
    //public GameObject hudtextparent;

    private HUDText hudtext;
    public AudioClip miss_sound;
    public GameObject body;
    private Color normal;
    public GameObject[] efxArray;
    private Dictionary<string, GameObject> efxDict = new Dictionary<string, GameObject>();

    public bool isLockingTarget = false; 
    private Skillsinfo info = null;
    private Animation animation;
    //public string aniname_death;


    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
        move = this.GetComponent<PlayerMove>();
        ps = this.GetComponent<PlayerStatus>();
        normal = body.GetComponent<Renderer>().material.color;

        //hudtextFollow = transform.Find("HUDTextFollow").gameObject;
        foreach(GameObject go in efxArray)
        {
            efxDict.Add(go.name, go);
        }
    }

    void Start()
    {
        hudtextGo = NGUITools.AddChild(HudTextParent._instance.gameObject, hudtextPrefab);
        hudtext = hudtextGo.GetComponent<HUDText>();
        UIFollowTarget followTarget = hudtextGo.GetComponent<UIFollowTarget>();
        followTarget.target = hudtextFollow.transform;
        followTarget.gameCamera = Camera.main;
        animation = this.GetComponent<Animation>();

    }

    // Update is called once per frame
    void Update()
    {
        if(isLockingTarget == false&&Input.GetMouseButtonDown(1)&&state!=PlayerState.Death)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            bool isColider = Physics.Raycast(ray, out hitInfo);
            if(isColider && hitInfo.collider.tag == Tags.Enemy)
            {
                
                target_normalattack = hitInfo.collider.transform;
                state = PlayerState.NormalAttack;
                aniname_now = aniname_normalattack;
                timer = 0;
                showEffect = false;
            }
            else
            {
                state = PlayerState.ControlWalk;
                target_normalattack = null;
            }
        }
        if(state == PlayerState.NormalAttack)
        {
            if(target_normalattack == null)
            {
                state = PlayerState.ControlWalk;
            }
            else
            {
                float distance = Vector3.Distance(transform.position, target_normalattack.position);
                if (distance <= min_distance) 
                {
                    transform.LookAt(target_normalattack.position);
                    attack_state = AttackState.Attack;
                    //if(timer == 0)
                    //{
                    //    animation.CrossFade(aniname_normalattack);
                    //}
                    timer += Time.deltaTime;
                    animation.CrossFade(aniname_now);
                    if (timer >= time_normalattack) //一次普通攻击完成
                    {
                        aniname_now = aniname_idle;
                        if (showEffect == false)
                        {
                            showEffect = true;

                            GameObject.Instantiate(effect, target_normalattack.position, Quaternion.identity);
                            target_normalattack.GetComponent<wolfbaby>().TakeDamage(GetAttack());
                        }
                        //timer = 0;
                        //GameObject.Instantiate(effect, target_normalattack.position, Quaternion.identity);
                        //target_normalattack.GetComponent<wolfbaby>().TakeDamage(GetAttack());
                    }
                    //else
                    //{
                    //    aniname_now = aniname_normalattack;
                    //}
                    if (timer >= (1f / rate_normalattack)) //rate_normalattack 多少次攻击每秒 ，倒数就是1次攻击花费的时间
                    {
                        timer = 0;
                        showEffect = false;
                        aniname_now = aniname_normalattack;
                    }
                }
                else 
                {
                    attack_state = AttackState.Moving;
                    move.SimpleMove(target_normalattack.position);
                    //animation.crossfade(aniname_walk);
                }
            }
        }
        else if (state == PlayerState.Death)
        {
            GetComponent<Animation>().CrossFade(aniname_death);
        }

        if (isLockingTarget && Input.GetMouseButtonDown(1))
        {
            //OnLockTarget();
        }
    }
    public int GetAttack()
    {
        return (int)(EquipmentUI._instance.attack + ps.attack + ps.attack_plus);
       
    }

    public void TakeDamage(int attack)
    {
        if (state == PlayerState.Death)
            return;
        float def = EquipmentUI._instance.def + ps.def + ps.def_plus;
        float temp = attack * ((200 - def) / 200);
        if (temp < 1)
        {
            temp = 1;
        }
        float value = Random.Range(0f, 1f);
        if (value < miss_rate) //Miss
        {

        }
        else
        {
            hudtext.Add("-" + temp, Color.gray, 1);
            ps.hp_remain -= (int)temp;
            StartCoroutine(ShowBodyRed());
            if(ps.hp_remain <= 0)
            {
                state = PlayerState.Death;
            }
            HeadStatusUI._instance.UpdateShow();
        }

    }
    IEnumerator ShowBodyRed()
    {
        body.GetComponent<Renderer>().material.color = Color.red;
        yield return new WaitForSeconds(1f);
        body.GetComponent<Renderer>().material.color = normal ;
    }
    private void OnDestroy()
    {
        GameObject.Destroy(hudtextGo);
    }


}
