using UnityEngine;
using System.Collections;
using System.IO;

public class MusicManager : MonoBehaviour {

	private string path = Application.dataPath + "/../Music/";

    public struct MusicInfo
    {
        public string name;
        public string fullPath;
    }

    private static MusicManager mInstance;
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
