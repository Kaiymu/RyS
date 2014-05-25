using UnityEngine;
using System.Collections;

public class TestMusicManager : MonoBehaviour {


    void OnGUI()
    {
        MusicManager.MusicInfo[] music = MusicManager.Instance.GetMusicList();
        if (MusicManager.Instance.AudioSource.isPlaying)
        {
            if (PauseGame.pause) 
                MusicManager.Instance.AudioSource.Pause();
        }
        else if (MusicManager.Instance.AudioSource.clip!= null && MusicManager.Instance.AudioSource.clip.isReadyToPlay)
        {
			if (!PauseGame.pause) 
                MusicManager.Instance.AudioSource.Play();
        }
        
    }
}
