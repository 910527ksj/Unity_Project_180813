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

    public GameObject lobbyPopUp;


    void Start()
    {

    }


    void Update()
    {
        if(losePopUpCheck.activeSelf == true)
        {
            StartCoroutine("PlayerDiePause");
            //Invoke("TimeScaleStop", 1.5f);
        }
    }


    //-------------------------------------------------- 인보크 , 코루틴 이용 시간 정지 -------------------------------------------------- //
    IEnumerator PlayerDiePause() // 코루틴을 이용한 시간 정지
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
        if (losePopUpCheck.activeSelf == false && lobbyPopUp.activeSelf == false)
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
    }

    public void BgmReStart()
    {
        bgmStopSprite.SetActive(false);
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
        if (pauseSprite.activeSelf == true && losePopUpCheck.activeSelf == false)
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
    }

    public void LobbyExitCancel()
    {
        lobbyPopUp.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
