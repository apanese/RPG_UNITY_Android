using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNpc : NPC
{
    public TweenPosition questTween;
    void OnMouseOver() //�����λ�����collider֮�ϵ�ʱ�򣬻���ÿһ֡�������������
    {
        CursorManager._instance.settalk();
        //Debug.Log("public TweenPosition questTween;");
        if (Input.GetMouseButtonDown(0))
        {
            ShowQuest();
        }
    }
    void ShowQuest()
    {
        questTween.gameObject.SetActive(true);
        questTween.PlayForward();
    }
    void HideQuest()
    {
        //questTween.gameObject.SetActive(false);
        questTween.PlayReverse();
    }
      //����ϵͳ ����Ի����ϵİ�ť����¼��Ĵ���
    public void OnCloseButtonClick()
    {
        Debug.Log("in close");
        HideQuest();
    }

}
