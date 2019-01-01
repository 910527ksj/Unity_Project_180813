using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySceneBtnScript : MonoBehaviour {



    public GameObject pauseLabel;
    public GameObject pauseReStartSprite;
    public GameObject pauseSprite;

    public GameObject bgmStopSprite;
    public GameObject playSoundStopSprite;

    public GameObject losePopUpCheck;
    public GameObject winPopUpCheck;

    public GameObject lobbyPopUp;

    public GameObject readyLabel;

    public List<GameObject> enemySpawn = new List<GameObject>();
    public GameObject enemyBlue;
    public GameObject enemyRed;
    public GameObject enemyBlack;
    public GameObject enemyWhite;

    IEnumerator ReadyMessage()
    {
        readyLabel.SetActive(true);
        Debug.Log("준비");
        if(Application.loadedLevelName == "Stage_01")
        { 
            readyLabel.GetComponent<UILabel>().text = "STAGE 1";
        }
        if (Application.loadedLevelName == "Stage_02")
        {
            readyLabel.GetComponent<UILabel>().text = "STAGE 2";
        }
        if (Application.loadedLevelName == "Stage_03")
        {
            readyLabel.GetComponent<UILabel>().text = "STAGE 3";
        }
        if (Application.loadedLevelName == "Stage_04")
        {
            readyLabel.GetComponent<UILabel>().text = "STAGE 4";
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("시작");
        readyLabel.GetComponent<UILabel>().text = "시작 !";
        yield return new WaitForSeconds(0.5f);
        readyLabel.SetActive(false);
        if (Application.loadedLevelName == "Stage_01")
        {
            Instantiate(enemyBlue, enemySpawn[0].transform.position, enemySpawn[0].transform.rotation);
        }
        if(Application.loadedLevelName == "Stage_02")
        {
            Instantiate(enemyRed, enemySpawn[0].transform.position, enemySpawn[0].transform.rotation);
            Instantiate(enemyRed, enemySpawn[1].transform.position, enemySpawn[1].transform.rotation);
        }
        if (Application.loadedLevelName == "Stage_03")
        {
            Instantiate(enemyBlack, enemySpawn[0].transform.position, enemySpawn[0].transform.rotation);
            Instantiate(enemyBlack, enemySpawn[1].transform.position, enemySpawn[1].transform.rotation);
        }
        if (Application.loadedLevelName == "Stage_04")
        {
            Instantiate(enemyWhite, enemySpawn[0].transform.position, enemySpawn[0].transform.rotation);
            Instantiate(enemyWhite, enemySpawn[1].transform.position, enemySpawn[1].transform.rotation);
            Instantiate(enemyWhite, enemySpawn[2].transform.position, enemySpawn[2].transform.rotation);
        }
    }

    void Start()
    {
        StartCoroutine("ReadyMessage");
        LobbyScript.Instance().UIChagner();
    }


    void Update()
    {
        if (losePopUpCheck.activeSelf == true || winPopUpCheck.activeSelf == true)
        {
            StartCoroutine("PlayerPause");
            //Invoke("TimeScaleStop", 1.5f);
        }
        //if (bgmStopSprite.activeSelf == true) // AudioManagerScript.Instance().bgm.volume = 0; 으로 해야는 이유는 오디오 매니저가 파괴 안되고 따라오기 때문
        //{
        //    Debug.Log("bgm음소거");
        //    AudioManagerScript.Instance().bgm.volume = 0;
        //}
        //if (bgmStopSprite.activeSelf == false)
        //{
        //    Debug.Log("bgm오픈");
        //    AudioManagerScript.Instance().bgm.volume = 0.5f;
        //}
    }


    //-------------------------------------------------- 인보크 , 코루틴 이용 시간 정지 -------------------------------------------------- //
    IEnumerator PlayerPause() // 코루틴을 이용한 시간 정지
    {
        yield return new WaitForSeconds(1.5f);
        Time.timeScale = 0.0f;
    }

    void TimeScaleStop() // 인보크를 이용한 시간 정지
    {
        Time.timeScale = 0f;
    }
    //-------------------------------------------------- 인보크 , 코루틴 이용 시간 정지 -------------------------------------------------- //



    public void Pause()
    {
        if (winPopUpCheck.activeSelf == false && losePopUpCheck.activeSelf == false && lobbyPopUp.activeSelf == false)
        {
            Time.timeScale = 0.0f;
            pauseLabel.SetActive(true);
            pauseReStartSprite.SetActive(true);
            pauseSprite.SetActive(false);
        }
    }

    public void PauseReStart()
    {
        Time.timeScale = 1.0f;
        pauseLabel.SetActive(false);
        pauseReStartSprite.SetActive(false);
        pauseSprite.SetActive(true);
    }
   

    public void BgmStop()
    {        
       bgmStopSprite.SetActive(true);
        if (bgmStopSprite.activeSelf == true) // AudioManagerScript.Instance().bgm.volume = 0; 으로 해야는 이유는 오디오 매니저가 파괴 안되고 따라오기 때문
        {
            Debug.Log("bgm음소거");
            AudioManagerScript.Instance().bgm.enabled = false;
        }
    }

    public void BgmReStart()
    {
        bgmStopSprite.SetActive(false);
        if (bgmStopSprite.activeSelf == false)
        {
            Debug.Log("bgm오픈");
            AudioManagerScript.Instance().bgm.enabled = true;
        }
    }



    public void PlaySoundStop()
    {
        playSoundStopSprite.SetActive(true);
    }

    public void PlaySoundReStart()
    {
        playSoundStopSprite.SetActive(false);
    }


    public void LobbyPopUp()
    {
        if (pauseSprite.activeSelf == true && winPopUpCheck.activeSelf == false && losePopUpCheck.activeSelf == false)
        {
            if (lobbyPopUp.activeSelf == false)
            {
                lobbyPopUp.SetActive(true);
                Time.timeScale = 0.0f;
            }
            else if (lobbyPopUp.activeSelf == true)
            {
                lobbyPopUp.SetActive(false);
                Time.timeScale = 1.0f;
            }
        }
    }

    public void LobbyExitClick()
    {
        Application.LoadLevel("Lobby");
        Time.timeScale = 1.0f;
        AudioManagerScript.Instance().bgm.enabled = true;
        LobbyScript.Instance().UIChagner();
    }

    public void LobbyExitCancel()
    {
        lobbyPopUp.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void ExitLobby()
    {
        Application.LoadLevel("Lobby");
        Time.timeScale = 1.0f;
        AudioManagerScript.Instance().bgm.enabled = true;
        LobbyScript.Instance().UIChagner();
    }

    public void ReStart()
    {
        if (Application.loadedLevelName == "Stage_01")
        {
            Application.LoadLevel("Stage_01");
            Time.timeScale = 1.0f;
            AudioManagerScript.Instance().bgm.enabled = true;
        }
        if (Application.loadedLevelName == "Stage_02")
        {
            Application.LoadLevel("Stage_02");
            Time.timeScale = 1.0f;
            AudioManagerScript.Instance().bgm.enabled = true;
        }
        if (Application.loadedLevelName == "Stage_03")
        {
            Application.LoadLevel("Stage_03");
            Time.timeScale = 1.0f;
            AudioManagerScript.Instance().bgm.enabled = true;
        }
        if (Application.loadedLevelName == "Stage_04")
        {
            Application.LoadLevel("Stage_04");
            Time.timeScale = 1.0f;
            AudioManagerScript.Instance().bgm.enabled = true;
        }
    }

    public void NextStage()
    {
        if(Application.loadedLevelName == "Stage_01")
        {
            Application.LoadLevel("Stage_02");
            Time.timeScale = 1.0f;
            AudioManagerScript.Instance().bgm.enabled = true;
        }
        if (Application.loadedLevelName == "Stage_02")
        {
            Application.LoadLevel("Stage_03");
            Time.timeScale = 1.0f;
            AudioManagerScript.Instance().bgm.enabled = true;
        }
        if (Application.loadedLevelName == "Stage_03")
        {
            Application.LoadLevel("Stage_04");
            Time.timeScale = 1.0f;
            AudioManagerScript.Instance().bgm.enabled = true;
        }
    }


}
