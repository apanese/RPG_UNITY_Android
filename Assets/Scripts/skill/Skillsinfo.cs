using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skillsinfo : MonoBehaviour
{
    public static Skillsinfo _instance;
    public TextAsset infos;  //skillsinfo���ı�
    public static Dictionary<int,skill> skilldict =new Dictionary<int,skill>();
    public Dictionary<int, skill>.ValueCollection valuecollection;
    public GameObject Skill_Grid;
    // Start is called before the first frame update
    void Start()
    {
        _instance = this;
        initskillsinfo();
    }

    // Update is called once per frame
    void Update()
    {
        //skill[] m = skilldict.Values.toarray();
        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    valuecollection = skilldict.Values;
        //    foreach (skill temp in valuecollection)
        //    {
        //        GameObject test = (GameObject)Instantiate(Resources.Load("skill_grid"), Skill_Grid.transform, false);
        //       test.GetComponent<Skill_ScrollView_Item>().SetId(temp.id);
        //    }

        //    Skill_Grid.GetComponent<UIGrid>().repositionNow = true;
        //    //Skill_Grid.GetComponent<UIGrid>().onReposition();
        //}
        
    }
    void initskillsinfo() //��txt�ļ���ȡ���м�����Ϣ
    {

        string text = infos.text;
        string[] texts = text.Split('\n');
        //skill temp = new skill();
        for (int i = 0; i < texts.Length; i++)
        {
            skill temp = new skill();
            string[] temp_texts = texts[i].Split(',');
            switch (temp_texts[10])
            {
                case "Swordman":
                    temp.role = skillrole.Swordman;
                    break;
                case "Magician":
                    temp.role = skillrole.Magician;
                    break;
            }
            if (temp.role==PlayerStatus._instance.role) //���role��֮ǰ���õ�����Ӧ��
            {
                temp.id = int.Parse(temp_texts[0]);
                temp.name = temp_texts[1];
                temp.skill_icon_name = temp_texts[2];
                temp.skill_des = temp_texts[3];
                switch (temp_texts[4])
                {
                    case "Buff":
                        temp.skill_type = skilltype.Buff;
                        break;
                    case "SingleTarget":
                        temp.skill_type = skilltype.SingleTarget;
                        break;
                    case "MultiTarget":
                        temp.skill_type = skilltype.MultiTarget;
                        break;
                    case "Passive":
                        temp.skill_type = skilltype.Passive;
                        break;
                }
                switch (temp_texts[5])
                {
                    case "Attack":
                        temp.skillproperty = skillproperty.Attack;
                        break;
                    case "Def":
                        temp.skillproperty = skillproperty.Def;
                        break;
                    case "Speed":
                        temp.skillproperty = skillproperty.Speed;
                        break;
                    case "AttackSpeed":
                        temp.skillproperty = skillproperty.AttackSpeed;
                        break;
                    case "HP":
                        temp.skillproperty = skillproperty.HP;
                        break;
                    case "MP":
                        temp.skillproperty = skillproperty.MP;
                        break;

                }
                temp.skillstrength = int.Parse(temp_texts[6]);
                temp.skillworktime = int.Parse(temp_texts[7]);
                temp.skillspendmp = int.Parse(temp_texts[8]);
                temp.skillouttime = int.Parse(temp_texts[9]);
                switch (temp_texts[10])
                {
                    case "Swordman":
                        temp.role = skillrole.Swordman;
                        break;
                    case "Magician":
                        temp.role = skillrole.Magician;
                        break;
                }
                temp.skillconditionlevel = int.Parse(temp_texts[11]);
                switch (temp_texts[12])
                {
                    case "Self":
                        temp.face = skillface.Self;
                        break;
                    case "Enemy":
                        temp.face = skillface.Enemy;
                        break;

                }
                temp.skilldistance = float.Parse(temp_texts[13]);
                skilldict.Add(temp.id, temp);
            }
            
        }

        /*-----------------�Ѽ��ܶ���grid����----------------------*/
        valuecollection = skilldict.Values;
        foreach (skill temp in valuecollection)
        {
            GameObject test = (GameObject)Instantiate(Resources.Load("skill_scrollview_item"), Skill_Grid.transform, false);
            test.GetComponent<Skill_ScrollView_Item>().SetId(temp.id);
        }

        Skill_Grid.GetComponent<UIGrid>().repositionNow = true;
        //Skill_Grid.GetComponent<UIGrid>().onReposition();

    }

    public skill GetSkillById(int id)
    {
        skill tempskill = new skill();  
        skilldict.TryGetValue(id, out tempskill);
        return tempskill;
    }

}

public class skill {
    public int id;
    public string name;
    public string skill_icon_name;
    public string skill_des;
    public skilltype skill_type; //���ּ������ԣ�
    public skillproperty skillproperty;
    public int skillstrength; //����ֵ
    public int skillworktime; //����ʱ��
    public int skillspendmp; //����ħ��ֵ
    public int skillouttime;//��ȴʱ��
    public skillrole role;
    public int skillconditionlevel;
    public skillface face;
    public float skilldistance;
}

public enum skillface
{
    Self,
    Enemy
}

public enum skilltype { //��������
    Buff, //�����ٶȡ������˺�����������
    SingleTarget, //�����˺�
    MultiTarget, //�����˺�
    Passive //HP��MP�ظ�
}

public enum skillproperty  //��������
{
    Attack,
    Def,
    Speed,
    AttackSpeed,
    HP,
    MP
}


public enum skillrole //�ʺϽ�ɫ
{
    Swordman,
    Magician

}
