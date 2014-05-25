using UnityEngine;
using System.Collections;
using System.IO;

public class MusicPlay : MonoBehaviour {

	public string nameMusic = string.Empty;
	public string namePath  = string.Empty;

	private UILabel _parentsText;
	private MusicManager.MusicInfo[] _music;
	private int _i = 0;
	
	void Start()
	{
		this.transform.GetChild(1).GetComponent<UILabel>().text = nameMusic;
	}

	void playMusic()
	{
		MusicManager.Instance.StartMusic(namePath);
		_parentsText = this.transform.GetChild(1).GetComponent<UILabel>();
	}
}
