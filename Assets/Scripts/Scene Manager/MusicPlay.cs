using UnityEngine;
using System.Collections;
using System.IO;

public class MusicPlay : MonoBehaviour {

	public string nameMusic = string.Empty;
	public string namePath  = string.Empty;

	public static GameObject[] disablesOtherButon;
	public static int lengthArrayButtons;

	private UILabel _parentsText;
	private MusicManager.MusicInfo[] _music;
	private MusicManager _musicPaused;
	private GameObject _parentGameobject;

	void Awake()
	{
		disablesOtherButon = new GameObject[5]; 
	}
	
	void Start()
	{ 	
		if(GameObject.FindGameObjectsWithTag("MusicBouton").Length >= 6)
			lengthArrayButtons = 5;
		else
			lengthArrayButtons = disablesOtherButon.Length;

		disablesOtherButon = GameObject.FindGameObjectsWithTag("MusicBouton"); 
		this.transform.GetChild(1).GetComponent<UILabel>().text = nameMusic;
		_parentGameobject = this.transform.parent.gameObject;
	}

	void playMusic()
	{
		Destroy(_parentGameobject);
		MusicManager.Instance.StartMusic(namePath);
		lengthArrayButtons--;

		for(int i = 0; i < disablesOtherButon.Length; i++)
		{
			if(MusicPlay.disablesOtherButon[i] != null)
				disablesOtherButon[i].SetActive(false);
		}
	}

	// La pause est dans TestMusicManager, aussi bizarre que cela soit, elle ne fonctionne pas ici.
}
