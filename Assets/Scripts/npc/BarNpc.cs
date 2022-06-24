using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarNpc : NPC
{
    public TweenPosition questTween;
    void OnMouseOver() //当鼠标位于这个collider之上的时候，会在每一帧调用这个方法。
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
      //任务系统 任务对话框上的按钮点击事件的处理
    public void OnCloseButtonClick()
    {
        Debug.Log("in close");
        HideQuest();
    }

}
