using UnityEngine;
using System.Collections;
using System.IO;

public class MusicPlay : MonoBehaviour {

	public string nameMusic = string.Empty;
	public string namePath  = string.Empty;

	private UILabel _parentsText;
	private MusicManager.MusicInfo[] _music;
	private MusicManager _musicPaused;
	
	void Start()
	{
		_musicPaused = MusicManager.Instance;
		this.transform.GetChild(1).GetComponent<UILabel>().text = nameMusic;
	}

	void playMusic()
	{
		MusicManager.Instance.StartMusic(namePath);
	}

	// La pause est dans TestMusicManager, aussi bizarre que cela soit, elle ne fonctionne pas ici.
}
