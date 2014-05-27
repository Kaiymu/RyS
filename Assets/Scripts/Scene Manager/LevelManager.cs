using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour {

    public string[] levelsName;

    private int currentSceneIndex = 0;

    IEnumerator Start()
    {
        GameManager.Instance.onRunEnd += NextLevelTime;
        SubScenes.LoadSubScene(levelsName[0]);
        yield return null;
        GameManager.Instance.StartRun();
    }

    void NextLevelTime(float t)
    {
        StartCoroutine("NextLevel");
    }

    void OnDestroy()
    {
        GameManager.Instance.onRunEnd -= NextLevelTime;
    }

    IEnumerator NextLevel()
    {
        yield return new WaitForSeconds(3.0f);
        SubScenes.UnloadSubScene(levelsName[currentSceneIndex]);
        currentSceneIndex++;
        if (currentSceneIndex >= levelsName.Length)
        {
            CleanScene.LoadBefore("CleanScene");
            yield break;
        }
        SubScenes.LoadSubScene(levelsName[currentSceneIndex]);
        yield return null;
        GameManager.Instance.StartRun();
    }

}
