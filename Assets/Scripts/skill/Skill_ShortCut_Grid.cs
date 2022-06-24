using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_ShortCut_Grid : MonoBehaviour
{
    // Start is called before the first frame update
    public int key; //该格的按键key
    public int id;  //id
    GameObject skillitem;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetId(int id)
    {
        this.id = id;
        skill temp = Skillsinfo._instance.GetSkillById(id);
        Skill_Shortcut_Item skill_temp_c = this.transform.GetComponentInChildren<Skill_Shortcut_Item>();
       
        if (skill_temp_c==null)
        {
            skillitem = (GameObject)Instantiate(Resources.Load("skill_shortcut_item"),this.transform,false);
            skill_temp_c = skillitem.GetComponent<Skill_Shortcut_Item>();
        }
        if (temp != null)
        {
            skillitem.GetComponentInChildren<UISprite>().spriteName = temp.skill_icon_name;
        }
            
    }
    public void SetId() //使用多态，默认id为当前id
    {
        //this.id = id;
        skill temp = Skillsinfo._instance.GetSkillById(id);
        Skill_ScrollView_Item skill_temp_c = this.transform.GetComponentInChildren<Skill_ScrollView_Item>();

        if (skill_temp_c == null)
        {
            skillitem = (GameObject)Instantiate(Resources.Load("skillitem"), this.transform, false);
            skill_temp_c = skillitem.GetComponent<Skill_ScrollView_Item>();
        }
        if (temp != null)
        {
            skillitem.GetComponentInChildren<UISprite>().spriteName = temp.skill_icon_name;
        }

    }
    public void clear()
    {
        Destroy(this.transform.Find("skill_shortcut_item(Clone)").gameObject);
        this.id = 0;
    }
}
