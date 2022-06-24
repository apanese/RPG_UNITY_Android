using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_Shortcut_Item : UIDragDropItem
{
    public GameObject skill_shortcut_grid;
    // Start is called before the first frame update
    void Start()
    {
        skill_shortcut_grid = this.transform.parent.GetComponentInChildren<Skill_ShortCut_Grid>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected override void OnDragDropRelease(GameObject surface)
    {
        base.OnDragDropRelease(surface);
        if(surface.tag == Tags.SkillGrid)
        {
            surface.GetComponent<Skill_ShortCut_Grid>().SetId(skill_shortcut_grid.GetComponent<Skill_ShortCut_Grid>().id);
            skill_shortcut_grid.GetComponent<Skill_ShortCut_Grid>().clear(); //±æø’∏Ò«Â¡„
        }
        else if(surface.tag == Tags.SkillItem)
        {
            int new_id = surface.transform.parent.GetComponent<Skill_ShortCut_Grid>().id;
            int old_id = skill_shortcut_grid.GetComponent<Skill_ShortCut_Grid>().id;
            surface.transform.parent.GetComponent<Skill_ShortCut_Grid>().SetId(old_id);
            skill_shortcut_grid.GetComponent<Skill_ShortCut_Grid>().SetId(new_id);
            this.transform.localPosition = Vector3.zero;
        }
        else
        {
            this.transform.localPosition = Vector3.zero;
        }
    }
}
