using UnityEngine;
using System.Collections;

public class MusicManagerUse : MonoBehaviour {

	private float _lengthMusic = 0;

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
			{
                MusicManager.Instance.AudioSource.Play();
			}
        }
    }

	void displayUI()
	{	
		for(int i = 0; i < MusicPlay.disablesOtherButon.Length; i++)
		{
			MusicPlay.disablesOtherButon[i].SetActive(true);
		}
	}

}
