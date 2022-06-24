using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorManager : MonoBehaviour
{
    // Start is called before the first frame update
    public static CursorManager _instance;
    public Texture2D cursor_normal;
    public Texture2D cursor_talk;
    public Texture2D cursor_attack;
    public Texture2D cursor_pick;
    public Texture2D lock_target;
    private Vector2 hotpos = Vector2.zero;
    private CursorMode mode = CursorMode.Auto;
    private void Start()
    {
        _instance = this;
    }
    public void setnormal()
    {
        Cursor.SetCursor(cursor_normal, hotpos, mode);
    }
    public void settalk()
    {
        Cursor.SetCursor(cursor_talk, hotpos, mode);
    }
    public void setattack()
    {
        Cursor.SetCursor(cursor_attack, hotpos, mode);
    }
    public void setpick()
    {
        Cursor.SetCursor(cursor_pick, hotpos, mode);
    }
    public void setlock_target()
    {
        Cursor.SetCursor(lock_target, hotpos, mode);
    }
}
