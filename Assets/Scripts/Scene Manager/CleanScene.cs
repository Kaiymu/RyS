using UnityEngine;
using System.Collections;

public class CleanScene : MonoBehaviour {

    private static string nextSceneName;

    public static void LoadBefore(string next)
    {
        nextSceneName = next;
        Application.LoadLevel("CleanScene");
    }

    void Start()
    {
        Resources.UnloadUnusedAssets();
        Application.LoadLevel(nextSceneName);
    }
	
}
