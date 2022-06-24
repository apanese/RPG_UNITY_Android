using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HeroType
{
    Swordman,
    Magician
}

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public HeroType heroType;
    public static PlayerStatus _instance;
    public int level = 1;   //记录角色的属性和金币数量
    public int hp = 100; //hp最大生命值
    public int mp = 100;
    public float hp_remain = 100; //当前生命值
    public float mp_remain = 100;
    public float exp = 0; //当前已经获得的经验
    public int coin = 0;
    public int experience;
    public string player_name;
    public skillrole role;
    public int attack = 20;
    public int attack_plus = 0;
    public int def =20;
    public int def_plus = 0;
    public int speed = 20;
    public int speed_plus = 0;
    public int point_remain = 0;

    public UILabel attack_;
    public UILabel attack_plus_;
    public UILabel def_;
    public UILabel def_plus_;
    public UILabel speed_;
    public UILabel speed_plus_;
    public UILabel point_remain_;


    void Awake()
    {
        heroType = HeroType.Magician;
        _instance = this;
        player_name = PlayerPrefs.GetString("name");
    }
    private void Start()
    {
        GetExp(0);
    }
    public void GetExp(int exp)
    {
        this.exp += exp;
        int total_exp = 100 + level * 30;
        while(this.exp >= total_exp)
        {
            //TODO升级
            this.level++;
            this.exp -= total_exp;
            total_exp = 100 + level * 30;
            //增加可用点数
            point_remain += 3;
            UpdateShow();
        }
        ExpBar._instance.SetValue(this.exp / total_exp);
    }

    public bool TakeMP(int count)
    {
        if(mp_remain >= count)
        {
            mp_remain -= count;
            HeadStatusUI._instance.UpdateShow();
            return true;
        }
        else
        {
            return false;
        }
    }

    public void GetDrug(int hp,int mp) //获得治疗
    {
        hp_remain += hp;
        mp_remain += mp;
        if (hp_remain > this.hp)
        {
            hp_remain = this.hp;
        }
        if (mp_remain > this.mp)
        {
            mp_remain = this.mp;
        }
        HeadStatusUI._instance.UpdateShow();
    }
    public void UpdateShow()
    {
        attack_.text = attack.ToString();
        attack_plus_.text = EquipmentUI._instance.attack.ToString();
        def_.text = def.ToString();
        def_plus_.text = EquipmentUI._instance.def.ToString();
        speed_.text = speed.ToString();
        speed_plus_.text = EquipmentUI._instance.speed.ToString();
        point_remain_.text = point_remain.ToString();
    }


}
