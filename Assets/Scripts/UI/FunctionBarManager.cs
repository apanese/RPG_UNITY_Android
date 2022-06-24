using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionBarManager : MonoBehaviour
{
    public GameObject Warn; //
    public GameObject inventory;
    private TweenPosition Inventory_Tween;
    public GameObject Status;
    private TweenPosition Status_Tween;
    public GameObject Equipment;
    private TweenPosition Equipment_Tween;
    public GameObject Skill;
    private TweenPosition Skill_Tween;
    public GameObject Setting;
    private TweenPosition Setting_Tween;

    public GameObject numbuydialog;
    private bool ifopen; //�Ƿ����һ���
    // Start is called before the first frame update
    void Start()
    {
        ifopen = false;
        inventory.SetActive(true);
        numbuydialog.SetActive(true);
        NumBuyDialog._instance.coin = inventory.transform.Find("Coin_Label/Coin_Text").gameObject.GetComponent<UILabel>();
        Inventory._instance.coin_num = inventory.transform.Find("Coin_Label/Coin_Text").gameObject.GetComponent<UILabel>();
        numbuydialog.SetActive(false);
        inventory.SetActive(false);
        Status.SetActive(true);
        Status.SetActive(false);
        Equipment.SetActive(true);
        Equipment.SetActive(false);
        Skill.SetActive(true);
        Skill.SetActive(false);
        WeaponUI._instance.gameObject.SetActive(true);
        WeaponUI._instance.gameObject.SetActive(false);
        DrugShopUI._instance.gameObject.SetActive(true);
        DrugShopUI._instance.gameObject.SetActive(false);
        //Setting.SetActive(true);
        //Setting.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnMouseButtonClick_bag() //����bagҳ��ĵ���
    {
        Vector3 from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
        Vector3 to_new = new Vector3(0, 0, 0);
        if (!ifopen)
        {
            Inventory_Tween = inventory.GetComponent<TweenPosition>();
            inventory.SetActive(true);
            Inventory_Tween.from = from_new;
            Inventory_Tween.to = to_new;
            Inventory_Tween.PlayForward();
            ifopen = true;
        }
        else
        {
            Warn.GetComponent<Close>().show();
        }
    }
    public void HideBag()
    {
        ifopen = false;
        Inventory_Tween.PlayReverse();
    }
    //����statusҳ��ĵ���
    public void OnMouseButtonClick_status() //����bagҳ��ĵ���
    {
        Vector3 from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
        Vector3 to_new = new Vector3(0, 0, 0);
        if (!ifopen)
        {
            Status_Tween = Status.GetComponent<TweenPosition>();
            Status.SetActive(true);
            Status_Tween.from = from_new;
            Status_Tween.to = to_new;
            Status_Tween.PlayForward();
            ifopen = true; //������һ������
        }
        else
        {
            Warn.GetComponent<Close>().show();
        }
        
    }
    public void HideStatus()
    {
        ifopen = false;
        Status_Tween.PlayReverse();
    }
    //����equipҳ��ĵ���
    public void OnMouseButtonClick_equipment() 
    {
        Vector3 from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
        Vector3 to_new = new Vector3(0, 0, 0);
        if (!ifopen)
        {
            Equipment_Tween = Equipment.GetComponent<TweenPosition>();
            Equipment.SetActive(true);
            Equipment_Tween.from = from_new;
            Equipment_Tween.to = to_new;
            Equipment_Tween.PlayForward();
            ifopen = true; //������һ������
        }
        else {
            Warn.GetComponent<Close>().show();
        }
        
    }
    public void HideEquipment()
    {
        ifopen = false;
        Equipment_Tween.PlayReverse();
        //Debug.Log("testetstsets");
    }

    //����skillҳ��ĵ���
    public void OnMouseButtonClick_Skill()
    {
        Vector3 from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
        Vector3 to_new = new Vector3(0, 0, 0);
        if (!ifopen)
        {
            Skill_Tween = Skill.GetComponent<TweenPosition>();
            Skill.SetActive(true);
            Skill_Tween.from = from_new;
            Skill_Tween.to = to_new;
            Skill_Tween.PlayForward();
            ifopen = true; //������һ������
        }
        else
        {
            Warn.GetComponent<Close>().show();
        }

    }
    public void HideSkill()
    {
        ifopen = false;
        Skill_Tween.PlayReverse();
        //Debug.Log("testetstsets");
    }
    //����settingҳ��ĵ���
}
