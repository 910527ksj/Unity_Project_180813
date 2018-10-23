using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnScript : MonoBehaviour {



    public GameObject pauseLabel;
    public GameObject reStartSprite;
    public GameObject pauseSprite;



    void Start()
    {

    }


    void Update()
    {
        
    }


    public void Pause()
    {
        Time.timeScale = 0.0f;
        pauseLabel.SetActive(true);
        reStartSprite.SetActive(true);
        pauseSprite.SetActive(false);
    }
    public void ReStart()
    {
        Time.timeScale = 1.0f;
        pauseLabel.SetActive(false);
        reStartSprite.SetActive(false);
        pauseSprite.SetActive(true);
    }
}
