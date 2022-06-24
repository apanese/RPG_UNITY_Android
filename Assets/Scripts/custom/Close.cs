using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Close : MonoBehaviour //这个脚本专门用于展示和隐藏按钮
{
    
    // Start is called before the first frame update
    private TweenPosition tween;
    void Start()
    {
        tween = this.GetComponent<TweenPosition>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void show()
    {
        Vector3 from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
        Vector3 to_new = new Vector3(0, 0, 0);
        tween = this.GetComponent<TweenPosition>();
        tween.from = from_new;
        tween.to = to_new;
        tween.timeScale = 1;
        this.gameObject.SetActive(true);
        tween.PlayForward();
    }
    public void hide()
    {
        tween = this.GetComponent<TweenPosition>();
        tween.PlayReverse();
    }
}
