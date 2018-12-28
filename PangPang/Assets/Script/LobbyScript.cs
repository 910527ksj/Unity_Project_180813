using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyScript : MonoBehaviour {

    static LobbyScript _instance;
    public static LobbyScript Instance()
    {
        return _instance;
    }

    public GameObject lobbyUI;

    void Start() 
    {
        if (_instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
        _instance = this;

        DontDestroyOnLoad(this);

        UIChagner();

    }

    // Update is called once per frame
    void Update ()
    {
        UIChagner();

    }

    public void UIChagner()
    {
        string loadedSceneName = Application.loadedLevelName;
        Debug.Log("loadedSceneName  :::  " + loadedSceneName);
        switch (loadedSceneName)
        {
            case "Lobby":
                Debug.Log("Lobby");
                lobbyUI.SetActive(true);
                break;
            case "Stage_01":
                Debug.Log("Lobby x");                
                lobbyUI.SetActive(false);
                break;
            case "Title":
                Debug.Log("Lobby x");
                lobbyUI.SetActive(false);
                break;
        }
    }
}
