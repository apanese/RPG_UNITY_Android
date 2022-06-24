using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentItem : MonoBehaviour
{
    // Start is called before the first frame update
    private UISprite sprite;
    public int id;
    private bool isHover = false;

    private void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isHover) //����������װ����֮�ϵ�ʱ�򣬼������Ҽ��ĵ��
        {
            if (Input.GetMouseButtonDown(1)) //����Ҽ����˵��ж�¸�װ��
            {
                EquipmentUI._instance.TakeOff(id, this.gameObject);
            }
        }
    }
    public void SetId(int id)
    {
        this.id = id;
        Item info = ItemsInfo.GetItemInfoById(id);
        SetInfo(info);
    }
    public void SetInfo(Item info)
    {
        this.id = info.id;
        sprite = this.GetComponent<UISprite>();
        sprite.spriteName = info.icon_name;
        
    }
    public void OnHover(bool isOver)
    {
        isHover = isOver;
    }
}
