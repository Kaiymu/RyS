using UnityEngine;
using System.Collections;

public class TestMusicManager : MonoBehaviour {

    void OnGUI()
    {
        MusicManager.MusicInfo[] music = MusicManager.Instance.GetMusicList();
        if (MusicManager.Instance.AudioSource.isPlaying)
        {
            if (GUILayout.Button("Pause")) 
                MusicManager.Instance.AudioSource.Pause();
        }
        else if (MusicManager.Instance.AudioSource.clip!= null && MusicManager.Instance.AudioSource.clip.isReadyToPlay)
        {
            if (GUILayout.Button("Play")) 
                MusicManager.Instance.AudioSource.Play();
        }
        
        foreach (MusicManager.MusicInfo musicName in music)
        {
            if (GUILayout.Button(musicName.name))
                MusicManager.Instance.StartMusic(musicName.fullPath);
        }
    }
}
