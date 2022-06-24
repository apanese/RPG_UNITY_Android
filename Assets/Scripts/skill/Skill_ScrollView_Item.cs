using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_ScrollView_Item :MonoBehaviour
{
    public UISprite sprite;
    public UILabel name;
    public UILabel desc;
    public UILabel skilltype;
    public UILabel spendmp;
    public int id;

    void Awake()
    {
        //base.Awake();
    }
    // Start is called before the first frame update
    void Start()
    {
       // base.Start();
        
    }

    // Update is called once per frame
    void Update()
    {
        //base.Update();
    }
    public void SetId(int id)
    {
        this.id = id;
        sprite = this.transform.Find("icon").GetComponent<UISprite>();
        name = this.transform.Find("name").GetComponent<UILabel>();
        skilltype = this.transform.Find("type").GetComponent<UILabel>();
        desc = this.transform.Find("desc").GetComponent<UILabel>();
        spendmp = this.transform.Find("cosume").GetComponent<UILabel>();
        Debug.Log(transform.name + "SetId:" + id);
        skill temp = Skillsinfo._instance.GetSkillById(id);
        name.text = temp.name;
        switch (temp.skill_type)
        {
            case global::skilltype.Buff:
                skilltype.text = "增益";
                break;
            case global::skilltype.SingleTarget:
                skilltype.text = "单体伤害";
                break;
            case global::skilltype.MultiTarget:
                skilltype.text = "多体伤害";
                break;
            case global::skilltype.Passive:
                skilltype.text = "回复";
                break;
        }
        desc.text = temp.skill_des;
        spendmp.text = temp.skillspendmp.ToString();
        sprite.spriteName = temp.skill_icon_name;

    }

    //protected override void OnDragDropRelease(GameObject surface)
    //{
    //    base.OnDragDropRelease(surface);

    //}
}
