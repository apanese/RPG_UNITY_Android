using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class skill_icon : UIDragDropItem
{
    private int skillid;
    int id;
    // Start is called before the first frame update
    void Start()
    {
        base.Start();
    }

    // Update is called once per frame
    void Update()
    {
        base.Update();
    }

    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface.tag == Tags.SkillItem)
        {
            surface.transform.parent.GetComponentInChildren<Skill_ShortCut_Grid>().SetId(skillid);
        }
        else if(surface.tag == Tags.SkillGrid)
        {
            surface.GetComponent<Skill_ShortCut_Grid>().SetId(skillid);
        }

    }
    protected override void OnDragDropStart()//在克隆的icon上调用的
    {
        base.OnDragDropStart();
        skillid = transform.parent.GetComponent<Skill_ScrollView_Item>().id;
        transform.parent = transform.root;
        this.GetComponent<UISprite>().depth = 40;

    }
}
