using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManagerScript : MonoBehaviour {

    static AudioManagerScript _instance;
    public static AudioManagerScript Instance()
    {
        return _instance;
    }

    public AudioSource bgm;


    void Start () // 씬 넘어가도 배경음악 유지 
    {
       if(_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;
        DontDestroyOnLoad(this);
    }
	

	void Update ()
    {
		
	}
}
