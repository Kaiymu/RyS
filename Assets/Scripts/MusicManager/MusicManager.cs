using UnityEngine;
using System.Collections;
using System.IO;

public class MusicManager : MonoBehaviour {

	private string path = Application.dataPath + "/../Music/";
	private float posY;
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
				posY -= 0.3f;
				GameObject o = Instantiate(_boutonMusic, new Vector3(1.5f, posY, 0f), Quaternion.identity) as GameObject;
				o.GetComponentInChildren<MusicPlay>().nameMusic = musicName.name;
				o.GetComponentInChildren<MusicPlay>().namePath  = musicName.fullPath;
			}
			else return;
		}
	}

    public struct MusicInfo
    {
        public string name;
        public string fullPath;
    }

    private static MusicManager mInstance;
	private static MusicManager test;
    public static MusicManager Instance
    {
        get
        {
            if (mInstance == null)
            {
                AudioListener audioListener = GameObject.FindObjectOfType<AudioListener>();

                if (audioListener == null)
                {
                    GameObject o = new GameObject("MusicManager");
                    audioListener = o.AddComponent<AudioListener>();
                }
				// Attache automatiquement le script. OH GOD
               	 	mInstance = audioListener.gameObject.AddComponent<MusicManager>();

                mInstance.mAudioSource = audioListener.gameObject.GetComponent<AudioSource>();
                if (mInstance.mAudioSource == null)
                    mInstance.mAudioSource = audioListener.gameObject.AddComponent<AudioSource>();
            }
            return mInstance;
        }
    }

    private AudioSource mAudioSource;
    public AudioSource AudioSource
    {
        get { return this.mAudioSource; }
    }

    public MusicInfo[] GetMusicList()
	{
        System.Collections.Generic.List<MusicInfo> musicInfo = new System.Collections.Generic.List<MusicInfo>();
        string[] fullPath = System.IO.Directory.GetFiles(this.path, "*.ogg", System.IO.SearchOption.TopDirectoryOnly);

        foreach (string path in fullPath)
        {
            MusicInfo info = new MusicInfo();
            info.fullPath = path;
            info.name = path.Substring(path.LastIndexOf('/')+1, path.LastIndexOf('.') - path.LastIndexOf('/') - 1);
            musicInfo.Add(info);
        }
        return musicInfo.ToArray();
    }

    public void StartMusic(string path)
    {
        StartCoroutine(OpenAndPlay(path));
    }

    private IEnumerator OpenAndPlay(string path)
    {
        WWW www = new WWW("file://" + path);
        this.AudioSource.clip = www.GetAudioClip(false, true);
        while (this.AudioSource.clip.isReadyToPlay == false) yield return null;
        this.AudioSource.Play();

    }
}
