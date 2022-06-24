//-------------------------------------------------
//            NGUI: Next-Gen UI kit
// Copyright © 2011-2018 Tasharen Entertainment Inc
//-------------------------------------------------

using UnityEngine;

/// <summary>
/// Tween the object's position.
/// </summary>

[AddComponentMenu("NGUI/Tween/Tween Position")]
public class TweenPosition : UITweener
{
	public Vector3 from;
	public Vector3 to;

	[HideInInspector]
	public bool worldSpace = false;

	Transform mTrans;
	UIRect mRect;
	public UIWidget uiwidget;
	Vector3 from_new;
	Vector3 to_new;
	public Transform cachedTransform { get { if (mTrans == null) mTrans = transform; return mTrans; } }

	[System.Obsolete("Use 'value' instead")]
	public Vector3 position { get { return this.value; } set { this.value = value; } }

	/// <summary>
	/// Tween's current value.
	/// </summary>

	public Vector3 value
	{
		get
		{
			return worldSpace ? cachedTransform.position : cachedTransform.localPosition;
		}
		set
		{
			if (mRect == null || !mRect.isAnchored || worldSpace)
			{
				if (worldSpace) cachedTransform.position = value;
				else cachedTransform.localPosition = value;
			}
			else
			{
				value -= cachedTransform.localPosition;
				NGUIMath.MoveRect(mRect, value.x, value.y);
			}
		}
	}

	void Awake () { 
		mRect = GetComponent<UIRect>();
		/*Debug.Log(this.name+" width:"+this.transform.GetComponent<UIWidget>().width+"  "+ "height:"+this.transform.GetComponent<UIWidget>().height);*/
		from_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
		to_new = new Vector3(0, 0, 0);
		//to_new = new Vector3(Screen.width / 2 + this.transform.GetComponent<UIWidget>().width, 0, 0);
	}

	/// <summary>
	/// Tween the value.
	/// </summary>

	protected override void OnUpdate (float factor, bool isFinished) { value = from * (1f - factor) + to * factor; }

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenPosition Begin (GameObject go, float duration, Vector3 pos)
	{
		TweenPosition comp = UITweener.Begin<TweenPosition>(go, duration);
        comp.from = comp.value;
        comp.to = pos;

  //      comp.from = from_new;
		//comp.to = pos;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	/// <summary>
	/// Start the tweening operation.
	/// </summary>

	static public TweenPosition Begin (GameObject go, float duration, Vector3 pos, bool worldSpace)
	{
		TweenPosition comp = UITweener.Begin<TweenPosition>(go, duration);
		comp.worldSpace = worldSpace;
		comp.from = comp.value;
		comp.to = pos;

		if (duration <= 0f)
		{
			comp.Sample(1f, true);
			comp.enabled = false;
		}
		return comp;
	}

	[ContextMenu("Set 'From' to current value")]
	public override void SetStartToCurrentValue () { from = value;from = from_new; }

	[ContextMenu("Set 'To' to current value")]
	public override void SetEndToCurrentValue () { to = value;to = to_new; }

	[ContextMenu("Assume value of 'From'")]
	void SetCurrentValueToStart () { value = from; from = from_new; }

	[ContextMenu("Assume value of 'To'")]
	void SetCurrentValueToEnd () { value = to; to = to_new; }
}
