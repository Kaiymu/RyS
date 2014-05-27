using UnityEngine;
using System.Collections;

public static class SubScenes : object
{
    public static void LoadSubScene(string name)
    {
        Application.LoadLevelAdditive(name);
    }

    public static void UnloadSubScene(string name)
    {
        GameObject root = GameObject.Find(name);
        if (root)
            GameObject.Destroy(root);
    }
}