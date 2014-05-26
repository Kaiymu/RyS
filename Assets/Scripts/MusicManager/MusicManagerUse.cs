using UnityEngine;
using System.Collections;

public class MusicManagerUse : MonoBehaviour {

	private float _lengthMusic = 0;
	private AudioSource AudioSourceMusic;

	void Start()
	{
		MusicManager.MusicInfo[] music = MusicManager.Instance.GetMusicList();
		AudioSourceMusic = MusicManager.Instance.AudioSource;
	}

    void OnGUI()
    {
	
		if (AudioSourceMusic.isPlaying)
        {
            if (PauseGame.pause) 
				AudioSourceMusic.Pause();
        }
		else if (AudioSourceMusic.clip!= null && AudioSourceMusic.clip.isReadyToPlay)
        {
			if (!PauseGame.pause)
			{
				AudioSourceMusic.Play();
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
