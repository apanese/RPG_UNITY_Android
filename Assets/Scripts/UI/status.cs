using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class status : MonoBehaviour
{
    public static status _instance;
    private TweenPosition tween;
    private bool isShow = false;
    private UILabel attackLabel;
    private UILabel defLabel;
    private UILabel speedLabel;
    private UILabel pointRemainLabel;
    private UILabel summaryLabel;

    private GameObject attackButtonGo;
    private GameObject defButtonGo;
    private GameObject speedButtonGo;

    private PlayerStatus ps;
    private void Awake()
    {
        _instance = this;
        tween = this.GetComponent<TweenPosition>();

        attackLabel = transform.Find("attack").GetComponent<UILabel>();
        defLabel = transform.Find("def").GetComponent<UILabel>();
        speedLabel = transform.Find("speed").GetComponent<UILabel>();
        pointRemainLabel = transform.Find("remain_num").GetComponent<UILabel>();
        summaryLabel = transform.Find("summary").GetComponent<UILabel>();
        attackButtonGo = transform.Find("add_attack").gameObject;
        defButtonGo = transform.Find("add_def").gameObject;
        speedButtonGo = transform.Find("add_speed").gameObject;

    }
    // Start is called before the first frame update
    void Start()
    {
        ps = GameObject.FindGameObjectWithTag(Tags.player).GetComponent<PlayerStatus>();
    }
    public void TransformState()
    {
        if(isShow == false)
        {

        }
        else
        {

        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateShow()
    {
        attackLabel.text = ps.attack + "+" + ps.attack_plus;
        defLabel.text = ps.def + "+" + ps.def_plus;
        speedLabel.text = ps.speed + "+" + ps.speed_plus;
        pointRemainLabel.text = ps.point_remain.ToString();
        summaryLabel.text = "ÉËº¦£º" + (ps.attack + ps.attack_plus)
            + "  " + "·ÀÓù£º" + (ps.def + ps.def_plus)
            + "  " + "ËÙ¶È£º" + (ps.speed + ps.speed_plus);

        if (ps.point_remain > 0)
        {
            attackButtonGo.SetActive(true);
            defButtonGo.SetActive(true);
            speedButtonGo.SetActive(true);
        }
        else
        {
            attackButtonGo.SetActive(false);
            defButtonGo.SetActive(false);
            speedButtonGo.SetActive(false);
        }
    }
    public void OnAttackPlusClick()
    {

    }

    public void OnDefPlusClick()
    {

    }
}
