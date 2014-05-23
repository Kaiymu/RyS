using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public float runTime;

    private float currentTime = 0;
    public float CurrentTime
    {
        get { return currentTime; }
    }

    public delegate void TimeEventHandler();
    public delegate void TimeArgsEventHandler(float time);
    public event TimeEventHandler onRunBegin;
    public event TimeArgsEventHandler onRunEnd;

    private bool runIsRunning = false;

    private static GameManager instance;
    public static GameManager Instance
    {
        get { return instance; }
    }

    void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        Application.LoadLevel("test");
    }

	void Update () 
    {
        if (runIsRunning)
        {
            currentTime += Time.deltaTime;
            if (currentTime >= runTime)
            {
                if (onRunEnd != null)
                    onRunEnd(currentTime);
                runIsRunning = false;
            }
        }
	}

    public void StartRun()
    {
        if (runIsRunning) return;
        if (onRunBegin != null)
            onRunBegin();
        runIsRunning = true;
        currentTime = 0;
    }

    public void Die()
    {
        runIsRunning = false;
    }
}
