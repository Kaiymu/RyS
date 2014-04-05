using UnityEngine;
using System.Collections;

public class TimeLabel : MonoBehaviour 
{
    public GUISkin skin;
    public Rect rect;

    private bool isRunning = false;

    void OnStart() { isRunning = true; }
    void OnEnd(float time) { isRunning = false; }

    void Awake()
    {
        GameManager.Instance.onRunBegin += OnStart;
        GameManager.Instance.onRunEnd += OnEnd;
    }

    void OnGUI()
    {
        if (skin) GUI.skin = skin;
        if (isRunning)
            GUI.Label(rect, GameManager.Instance.CurrentTime.ToString("0.0"));
        else
            GUI.Label(rect, "Wait");
    }
	
}
