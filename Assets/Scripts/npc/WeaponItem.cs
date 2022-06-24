using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour
{

    public UISprite icon;
    public UILabel name;
    public UILabel effect;
    public UILabel sell;
    public int id;
    public void Awake()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBuyButton() //���
    {
        NumBuyDialog._instance.id = id;
        NumBuyDialog._instance.OnTransformState();
        Debug.Log(id);
    }
    public void setid(int id)
    {
        icon = this.transform.Find("icon").GetComponent<UISprite>();
        name = this.transform.Find("name").GetComponent<UILabel>();
        effect = this.transform.Find("effect").GetComponent<UILabel>();
        sell = this.transform.Find("sell").GetComponent<UILabel>();
        this.id = id;
        Item info = ItemsInfo.GetItemInfoById(id);
        if(info.type == ObjectType.Equip) //װ��
        {
            icon.spriteName = info.icon_name;
            sell.text = info.Buy.ToString();
            name.text = info.name;
            if (info.attack != 0)
            {
                effect.text = "+" + info.attack.ToString() + "������";
            }
            else if (info.def != 0)
            {
                effect.text = "+" + info.def.ToString() + "������";
            }
            else
            {
                effect.text = "+" + info.speed.ToString() + "�ٶ�";
            }
        }
        else if(info.type == ObjectType.Drug) //ҩƷ
        {
            icon.spriteName = info.icon_name;
            sell.text = info.Buy.ToString();
            name.text = info.name;
            if (info.HpGain != 0)
            {
                effect.text = "+" + info.HpGain.ToString() + "HP";
            }
            else if (info.MpGain != 0)
            {
                effect.text = "+" + info.MpGain.ToString() + "MP";
            }
            else
            {
                
            }

        }
        
        //effect.text = info.


    }
}
