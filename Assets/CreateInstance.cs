using UnityEngine;
using System.Collections;

public class CreateInstance : MonoBehaviour {

	private float posY = -0.2f;
	private Object _boutonMusic;

	void Start()
	{
		MusicManager.MusicInfo[] music = MusicManager.Instance.GetMusicList();
		
		_boutonMusic = Resources.Load("Label");
		foreach (MusicManager.MusicInfo musicName in music)
		{	
			//MusicManager.Instance.StartMusic(musicName.fullPath);
			if(_boutonMusic != null)
			{
				posY -= 0.20f;
				GameObject o = Instantiate(_boutonMusic, new Vector3(2.2f, posY, 0f), Quaternion.identity) as GameObject;
				o.GetComponentInChildren<MusicPlay>().nameMusic = musicName.name;
				o.GetComponentInChildren<MusicPlay>().namePath  = musicName.fullPath;
			}
			else return;
		}
	}
}
