using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{
    public AudioClip bgm;
    public bool destroyOnLoad = false;

    private static MusicPlayer instance = null;
    public static MusicPlayer Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
            if (!destroyOnLoad)
                DontDestroyOnLoad(this.gameObject);
        }

        gameObject.AddComponent<AudioSource>();
        GetComponent<AudioSource>().clip = bgm;
        GetComponent<AudioSource>().loop = true;
        GetComponent<AudioSource>().volume = 0.5f;
        GetComponent<AudioSource>().Play();
    }

    public static void stopMusic()
    {
        Destroy(Instance.gameObject);
        instance = null;
    }
}