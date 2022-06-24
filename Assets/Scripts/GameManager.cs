using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static GameManager _instance;
    public GameObject Inventory;
    public GameObject[] item_grids;
    public Dictionary<int, skill>.ValueCollection valuecollection;
    public GameObject Skill_Grid;
    public float width;
    public float height;
    void Start()
    {
        width = Screen.width;
        height = Screen.height;
        item_grids = Inventory.GetComponent<Inventory>().item_grids;
        //initskills();
    }

    // Update is called once per frame
    void Update()
    {
        skill temp = Skillsinfo._instance.GetSkillById(5006);
        if (Input.GetKeyDown(KeyCode.A))
        {
            AddDrug(1001, 1);
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            AddDrug(1002, 1);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            AddDrug(1003, 1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            ADDEquipment(Random.Range(2001,2023),1);
        }
    }
    public void AddDrug(int id,int num = 1)
    {
        for (int i = 0; i < item_grids.Length; i++)
        {
            Item_Grid temp_grid = item_grids[i].GetComponent<Item_Grid>();
            if (temp_grid.id == id)
            {
                temp_grid.PlusNumber(num);
                return ;
            }
        }

        for (int i = 0; i < item_grids.Length; i++)
        {
            Item_Grid temp_grid = item_grids[i].GetComponent<Item_Grid>();
            if (temp_grid.id == 0)
            {
                temp_grid.SetId(id,num);
                return ;
            }
        }

    }
    public void ADDEquipment(int id,int num = 1)
    {
        for (int i = 0; i < item_grids.Length; i++)
        {
            Item_Grid temp_grid = item_grids[i].GetComponent<Item_Grid>();
            if (temp_grid.id == id)
            {
                temp_grid.PlusNumber(num);
                return;
            }
        }

        for (int i = 0; i < item_grids.Length; i++)
        {
            Item_Grid temp_grid = item_grids[i].GetComponent<Item_Grid>();
            if (temp_grid.id == 0)
            {
                temp_grid.SetId(id, num);
                return;
            }
        }
    }

    void initskills()
    {
        valuecollection = Skillsinfo.skilldict.Values;
        foreach (skill temp in valuecollection)
        {
            GameObject test = (GameObject)Instantiate(Resources.Load("skill_grid"), Skill_Grid.transform, false);
            test.GetComponent<Skill_ScrollView_Item>().SetId(temp.id);
        }

        Skill_Grid.GetComponent<UIGrid>().repositionNow = true;
    }
}
