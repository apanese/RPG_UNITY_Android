using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumBuyDialog : MonoBehaviour
{
    // Start is called before the first frame update
    public static NumBuyDialog _instance;
    public int id;
    public UILabel num;
    public int num_;
    public UILabel coin;
    public UILabel feedback;
    public bool ishide = false;
    public TweenPosition tween;
    private void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        num = this.transform.Find("bg/Num").GetComponent<UILabel>();
        feedback = this.transform.Find("feedback").GetComponent<UILabel>();
        tween = this.GetComponent<TweenPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnBuyBtn()
    {
        int coin_num = int.Parse(coin.text);
        int buy_num = int.Parse(num.text);
        Item info = ItemsInfo.GetItemInfoById(id);
        if (buy_num * info.Buy > coin_num) //购买所需要的金额大于已有金额
        {
            num.text = "0";
            feedback.text = "您的金币不足！";
        }
        else
        {
            num.text ="0";
            feedback.text = "购买成功";
            Inventory._instance.GetId(id, buy_num); //正式购买
            //Inventory._instance.coin_num.text = (coin_num - buy_num * info.Sell).ToString();
            int test = coin_num - buy_num * info.Sell;
            Inventory._instance.updateCoin(test);
        }
    }
    public void OnTransformState() //普通弹入弹出
    {
        ishide = !ishide;
        Vector3 from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
        Vector3 to_new = new Vector3(500, 0, 0);
        tween.from = from_new;
        tween.to = to_new;
        if (ishide)
        {
            this.gameObject.SetActive(true);
            tween.PlayForward();
        }
        else
        {
            tween.PlayReverse();
        }
    }
    public void close()
    {
        ishide = !ishide;
        Vector3 from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
        Vector3 to_new = new Vector3(500, 0, 0);
        tween.from = from_new;
        tween.to = to_new;
        if (ishide)
        {
            this.gameObject.SetActive(true);
            tween.PlayForward();
        }
        else
        {
            tween.PlayReverse();
        }
    }
}
