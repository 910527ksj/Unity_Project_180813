using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySceneBtnScript : MonoBehaviour {

    static LobbySceneBtnScript _instance;
    public static LobbySceneBtnScript Instance()
    {
        return _instance;
    }

    public UISlider _bgmSlider;
    public UISlider bgmSlider
    {
        get
        {
            return _bgmSlider;
        }
        set
        {
            _bgmSlider = value;
            if(_bgmSlider.value >= 0)
            {
                Debug.Log("bgm저장");
                SaveBgm();
            }
        }
    }

    public UILabel haveGold;
    public UILabel haveGem;
    public UILabel havePotion;

    public UILabel checkGem;
    public UILabel checkMoney;
    public List<GameObject> chkGemEa;
    public GameObject chkGemResult = null;
    public List<GameObject> chkMoney;
    public GameObject chkMoneyResult = null;

    public int _myGold;
    public int _myGem;
    public int _myPotion;

    public int myGold // get,set을 프로퍼티라 함 . 로드는 되고 세이브 안될시 호출값 확인할것. ex)_myGold가 아닌 myGold로 호출되서 계산 되야함
    {
        get
        {
            return _myGold;
        }
        set
        {
            _myGold = value;
            if (_myGold >= 0)
            {
                SaveGold ();
            }
        }
    }

    public int myGem
    {
        get
        {           
            return _myGem;
        }
        set
        {            
            _myGem = value;
            if (_myGem >= 0)
            {               
                SaveGem();
            }
        }
    }

    public int myPotion
    {
        get
        {
            return _myPotion;
        }
        set
        {
            _myPotion = value;
            if (_myPotion >= 0)
            {
                SavePotion();
            }
        }
    }

    public GameObject gameExitPopUp;

    public GameObject buyGoldPopUp;

    public GameObject buyGemPopUp;
    public GameObject buyGemCheckPopUp;

    public GameObject buyShopPopUp;

    public GameObject potionGoldCheck;
    public GameObject potionGemCheck;
    public GameObject weaponGoldCheck;
    public GameObject weaponGemCheck;
    public GameObject hpGoldCheck;
    public GameObject hpGemCheck;
    public GameObject warringLabel;

    public GameObject settingPopUp;

    public GameObject rankPopUp;

    public GameObject playerInformationPopUp;

    public UILabel nowBasicDamage;
    public UILabel beforeBasicDamage;
    public UILabel afterBasicDamage;
    public int _basicDamage = 1;
    public int basicDamage
    {
        get
        {
            return _basicDamage;
        }
        set
        {
            _basicDamage = value;
            if(_basicDamage > 0 )
            {
                SaveDamage();
            }
        }
    }

    public UILabel nowHp;
    public UILabel beforeHp;
    public UILabel afterHp;
    public int _playerMaxHp = 5;
    public int playerMaxHp
    {
        get
        {
            return _playerMaxHp;
        }
        set
        {
            _playerMaxHp = value;
            if(_playerMaxHp > 0)
            {
                SaveHp();
            }
        }
    }

    public GameObject gameStartPopUp;


    /* ---------------미완성 스코어 보드 --------------------*/
    public UILabel bestScoreLabel; 
    public UILabel secondScoreLabel;
    public UILabel thirdScoreLabel;
    public int _bestScore;
    public int _secondScore;
    public int _thirdScore;
    int _myScore;

    public int bestScore
    {
        get
        {
            return _bestScore;
        }
    }

    public int secondScore
    {
        get
        {
            return _secondScore;
        }
    }

    public int thirdScore
    {
        get
        {
            return _thirdScore;
        }
    }

    public int myScore
    {
        get
        {
            return _myScore;
        }
        set
        {
            _myScore = value;
            if (_myScore >= _bestScore)
            {
                _thirdScore = _secondScore;
                _secondScore = _bestScore;
                _bestScore = _myScore;
                SaveBestScore();
            }
            else
            if (_myScore > _secondScore)
            {
                _thirdScore = _secondScore;
                _secondScore = _myScore;
                SaveSecondScore();
            }
            else
            if (_myScore > _thirdScore )
            {
                Debug.Log("3등 저장하기");
                _thirdScore = _myScore;
                SaveThirdScore();
            }

        }
    }
    /* ---------------미완성 스코어 보드 --------------------*/

    public GameObject wattingUpdateLabel;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }

        LoadBgm();

        LoadGem();
        LoadGold();
        LoadPotion();

        LoadDamage();
        LoadHp();

        LoadBestScore();
        LoadSecondScore();
        LoadThirdScore();
    }

    void Start ()
    {

    }
	
	
	void Update ()
    {
        if (_myGold >= 0)
        {
            SaveGold();
        }
        if (_myGem >= 0)
        {
            SaveGem();
        }
        if (_myPotion >= 0)
        {
            SavePotion();
        }
        if (_basicDamage > 0)
        {
            SaveDamage();
        }
        if (_playerMaxHp > 0)
        {
            SaveHp();
        }

        haveGem.text = myGem.ToString();
        haveGold.text = myGold.ToString();
        havePotion.text = myPotion.ToString();

        nowBasicDamage.text = basicDamage.ToString();
        beforeBasicDamage.text = basicDamage.ToString();
        int afterDam;
        afterDam = basicDamage + 1;
        afterBasicDamage.text = afterDam.ToString();

        nowHp.text = playerMaxHp.ToString();
        beforeHp.text = playerMaxHp.ToString();
        int afterPlayerHp;
        afterPlayerHp = playerMaxHp + 1;
        afterHp.text = afterPlayerHp.ToString();

        bestScoreLabel.text = bestScore.ToString();
        secondScoreLabel.text = secondScore.ToString();
        thirdScoreLabel.text = thirdScore.ToString();
 
    
        if(buyGemCheckPopUp.activeSelf == true)
        {
            BuyGemResult();
        }

    }


    public void BgmVolume()
    {
        AudioManagerScript.Instance().bgm.volume = bgmSlider.value;
    }

    void SaveBgm()
    {
        Debug.Log("bgm저장 함수");
        PlayerPrefs.SetFloat("BGM", _bgmSlider.value);
    }
    void LoadBgm()
    {
        _bgmSlider.value = PlayerPrefs.GetFloat("BGM", _bgmSlider.value);
    }

    void BuyGemResult()
    {
        checkGem.text = chkGemResult.GetComponent<UILabel>().text;
        checkMoney.text = chkMoneyResult.GetComponent<UILabel>().text;
    }

    void SaveGold()
    {
        PlayerPrefs.SetInt("MyGold", _myGold);
    }

    void LoadGold()
    {
        _myGold = PlayerPrefs.GetInt("MyGold", _myGold);
    }

    void SaveGem()
    {
        PlayerPrefs.SetInt("MyGem", _myGem);
    }

    void LoadGem()
    {
        _myGem = PlayerPrefs.GetInt("MyGem",_myGem);        
    }

    void SavePotion()
    {
        PlayerPrefs.SetInt("MyPotion", _myPotion);
    }

    void LoadPotion()
    {
        _myPotion = PlayerPrefs.GetInt("MyPotion", _myPotion);
    }

    void SaveDamage()
    {
        PlayerPrefs.SetInt("MyDamage", _basicDamage);
    }

    void LoadDamage()
    {
        _basicDamage = PlayerPrefs.GetInt("MyDamage", _basicDamage);
    }

    void SaveHp()
    {
        PlayerPrefs.SetInt("MyHp", _playerMaxHp);
    }

    void LoadHp()
    {
        _playerMaxHp = PlayerPrefs.GetInt("MyHp", _playerMaxHp);
    }

    void SaveBestScore()
    {
        PlayerPrefs.SetInt("BestScore", _bestScore);
    }

    void LoadBestScore()
    {
        _bestScore = PlayerPrefs.GetInt("BestScore", 0);
    }

    void SaveSecondScore()
    {
        PlayerPrefs.SetInt("SecondScore", _secondScore);
    }

    void LoadSecondScore()
    {
        _secondScore = PlayerPrefs.GetInt("SecondScore", 0);
    }

    void SaveThirdScore()
    {
        PlayerPrefs.SetInt("ThirdScoree", _thirdScore);
    }

    void LoadThirdScore()
    {
        Debug.Log("3등 불러오기");
        _thirdScore = PlayerPrefs.GetInt("ThirdScore", _thirdScore);
    }

    public void ExitPopUpClick()
    {
        if(gameExitPopUp.activeSelf == false)
        {
            gameExitPopUp.SetActive(true);
            buyGoldPopUp.SetActive(false);
            buyGemPopUp.SetActive(false);
            buyGemCheckPopUp.SetActive(false);
            buyShopPopUp.SetActive(false);
            settingPopUp.SetActive(false);
            rankPopUp.SetActive(false);
            playerInformationPopUp.SetActive(false);
            gameStartPopUp.SetActive(false);
        }
        else
        if(gameExitPopUp.activeSelf == true)
        {
            gameExitPopUp.SetActive(false);
        }
    }

    public void ExitPopUpYes()
    {
        Application.Quit();
    }

    public void ExitPopUpCancel()
    {
        gameExitPopUp.SetActive(false);
    }

    public void BuyGoldPopUpClick()
    {
        if(buyGoldPopUp.activeSelf == false)
        {
            buyGoldPopUp.SetActive(true);
            gameExitPopUp.SetActive(false);
            buyGemPopUp.SetActive(false);
            buyGemCheckPopUp.SetActive(false);
            buyShopPopUp.SetActive(false);
            settingPopUp.SetActive(false);
            rankPopUp.SetActive(false);
            playerInformationPopUp.SetActive(false);
            gameStartPopUp.SetActive(false);
        }
        else
        if(buyGoldPopUp.activeSelf == true)
        {
            buyGoldPopUp.SetActive(false);
        }
    }

    public void BuyGoldPopUpYes()
    {
        buyGoldPopUp.SetActive(false);
        myGem -= 35;
        myGold += 100;
    }
    public void BuyGoldPopUpCancel()
    {
        buyGoldPopUp.SetActive(false);
    }

    public void BuyGemPopUpClick()
    {
        if(buyGemPopUp.activeSelf == false  )
        {
            buyGemPopUp.SetActive(true);
            gameExitPopUp.SetActive(false);
            buyGoldPopUp.SetActive(false);
            buyGemCheckPopUp.SetActive(false);
            buyShopPopUp.SetActive(false);
            settingPopUp.SetActive(false);
            rankPopUp.SetActive(false);
            playerInformationPopUp.SetActive(false);
            gameStartPopUp.SetActive(false);
        }
        else
        if (buyGemPopUp.activeSelf == true)
        {
            buyGemPopUp.SetActive(false);
        }
    }

    public void BuyGemPopUpCancel()
    {
        buyGemPopUp.SetActive(false);
    }

    public void BuyGem5()
    {
        buyGemPopUp.SetActive(false);
        buyGemCheckPopUp.SetActive(true);
        chkGemResult = chkGemEa.Find(x=>x.name == "x5");
        chkMoneyResult = chkMoney.Find(x => x.name == "1,000");
    }

    public void BuyGem15()
    {
        buyGemPopUp.SetActive(false);
        buyGemCheckPopUp.SetActive(true);
        chkGemResult = chkGemEa.Find(x => x.name == "x15");
        chkMoneyResult = chkMoney.Find(x => x.name == "3,000");
    }

    public void BuyGem25()
    {
        buyGemPopUp.SetActive(false);
        buyGemCheckPopUp.SetActive(true);
        chkGemResult = chkGemEa.Find(x => x.name == "x25");
        chkMoneyResult = chkMoney.Find(x => x.name == "5,000");
    }

    public void BuyGem50()
    {
        buyGemPopUp.SetActive(false);
        buyGemCheckPopUp.SetActive(true);
        chkGemResult = chkGemEa.Find(x => x.name == "x50");
        chkMoneyResult = chkMoney.Find(x => x.name == "10,000");
    }

    public void BuyGem75()
    {
        buyGemPopUp.SetActive(false);
        buyGemCheckPopUp.SetActive(true);
        chkGemResult = chkGemEa.Find(x => x.name == "x75");
        chkMoneyResult = chkMoney.Find(x => x.name == "15,000");
    }
    public void BuyGem100()
    {
        buyGemPopUp.SetActive(false);
        buyGemCheckPopUp.SetActive(true);
        chkGemResult = chkGemEa.Find(x => x.name == "x100");
        chkMoneyResult = chkMoney.Find(x => x.name == "20,000");
    }

    public void BuyGemYes()
    {
        buyGemCheckPopUp.SetActive(false);

        int gemResult = int.Parse(chkGemResult.GetComponent<UILabel>().text);
        myGem += gemResult; // haveGem에 할 경우 text라서 더 해지지 않음 
    }

    public void BuyGemNo()
    {
        buyGemCheckPopUp.SetActive(false);
        buyGemPopUp.SetActive(true);
    }    

    public void ShopPopUpClick()
    {
        if(buyShopPopUp.activeSelf == false)
        {
            buyShopPopUp.SetActive(true);
            buyGemPopUp.SetActive(false);
            gameExitPopUp.SetActive(false);
            buyGoldPopUp.SetActive(false);
            buyGemCheckPopUp.SetActive(false);
            settingPopUp.SetActive(false);
            rankPopUp.SetActive(false);
            playerInformationPopUp.SetActive(false);
            gameStartPopUp.SetActive(false);
        }
        else
        if(buyShopPopUp.activeSelf == true)
        {
            buyShopPopUp.SetActive(false);
        }
    }

    public void ShopPopUpCancel()
    {
        buyShopPopUp.SetActive(false);
    }

    IEnumerator WarringMessagePotion()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (potionGoldCheck.GetComponent<TweenAlpha>().to == 0 && potionGemCheck.GetComponent<TweenAlpha>().to == 0 )
            {
                warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
            }

            if (potionGoldCheck.GetComponent<TweenAlpha>().to == 1 && potionGemCheck.GetComponent<TweenAlpha>().to == 0)
            {
                if (myGold < 1000)
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }
           
            if (potionGoldCheck.GetComponent<TweenAlpha>().to == 0 && potionGemCheck.GetComponent<TweenAlpha>().to == 1 )
            {
                if (myGem < 100)
                {
                    warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                }
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageWeapon()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 0 && weaponGemCheck.GetComponent<TweenAlpha>().to == 0)
            {
                warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
            }

            if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 1 && weaponGemCheck.GetComponent<TweenAlpha>().to == 0)
            {
                if (myGold < 1000)
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }

            if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 0 && weaponGemCheck.GetComponent<TweenAlpha>().to == 1)
            {
                if (myGem < 100)
                {
                    warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                }
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageHp()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (hpGoldCheck.GetComponent<TweenAlpha>().to == 0 && hpGemCheck.GetComponent<TweenAlpha>().to == 0)
            {
                warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
            }

            if (hpGoldCheck.GetComponent<TweenAlpha>().to == 1 && hpGemCheck.GetComponent<TweenAlpha>().to == 0)
            {
                if (myGold < 1000)
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }

            if (hpGoldCheck.GetComponent<TweenAlpha>().to == 0 && hpGemCheck.GetComponent<TweenAlpha>().to == 1)
            {
                if (myGem < 100)
                {
                    warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                }
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    public void BuyPotion()
    {
        if (potionGoldCheck.GetComponent<TweenAlpha>().to == 1 && potionGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= 1000)
            {
                myGold -= 1000;
                myPotion += 1;
                Debug.Log("골드로 포션");
            }
            else
            if (myGold < 1000)
            {
                StartCoroutine("WarringMessagePotion");
            }
        }
        else
        if(potionGoldCheck.GetComponent<TweenAlpha>().to == 0 && potionGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if(myGem >=100)
            {
                myGem -= 100;
                myPotion += 1;
                Debug.Log("잼으로 포션");
            }
            if (myGem < 100)
            {
                StartCoroutine("WarringMessagePotion");
            }
        }
        else
        if (potionGoldCheck.GetComponent<TweenAlpha>().to == 0 && potionGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessagePotion");
        }
    }

    public void BuyWeapon()
    {
        if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 1 && weaponGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= 1000)
            {
                myGold -= 1000;
                basicDamage += 1;
                Debug.Log("골드로 무기");
            }
            else
            if (myGold < 1000)
            {
                StartCoroutine("WarringMessageWeapon");
            }
        }
        else
        if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 0 && weaponGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= 100)
            {
                myGem -= 100;
                basicDamage += 1;
                Debug.Log("잼으로 무기");
            }
            if (myGem < 100)
            {
                StartCoroutine("WarringMessageWeapon");
            }
        }
        else
        if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 0 && weaponGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageWeapon");
        }
    }

    public void BuyHp()
    {
        if (hpGoldCheck.GetComponent<TweenAlpha>().to == 1 && hpGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= 1000)
            {
                myGold -= 1000;
                playerMaxHp += 1;
                Debug.Log("골드로 hp");
            }
            else
            if (myGold < 1000)
            {
                StartCoroutine("WarringMessageHp");
            }
        }
        else
        if (hpGoldCheck.GetComponent<TweenAlpha>().to == 0 && hpGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= 100)
            {
                myGem -= 100;
                playerMaxHp += 1;
                Debug.Log("잼으로 hp");
            }
            if (myGem < 100)
            {
                StartCoroutine("WarringMessageHp");
            }
        }
        else
        if (hpGoldCheck.GetComponent<TweenAlpha>().to == 0 && hpGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageHp");
        }
    }

    public void SettingPopUpClick()
    {
        if(settingPopUp.activeSelf == false )
        {
            settingPopUp.SetActive(true);
            gameExitPopUp.SetActive(false);
            buyGoldPopUp.SetActive(false);
            buyGemPopUp.SetActive(false);
            buyGemCheckPopUp.SetActive(false);
            buyShopPopUp.SetActive(false);
            rankPopUp.SetActive(false);
            playerInformationPopUp.SetActive(false);
            gameStartPopUp.SetActive(false);
        }
        else
        if(settingPopUp.activeSelf == true)
        {
            settingPopUp.SetActive(false);
        }
    }

    public void SettingPopUpCancel()
    {
        settingPopUp.SetActive(false);
        SaveBgm();
    }

    public void RankPopUpClick()
    {
        //if(rankPopUp.activeSelf == false)
        //{
        //    rankPopUp.SetActive(true);
        //    gameExitPopUp.SetActive(false);
        //    buyGoldPopUp.SetActive(false);
        //    buyGemPopUp.SetActive(false);
        //    buyGemCheckPopUp.SetActive(false);
        //    buyShopPopUp.SetActive(false);
        //    settingPopUp.SetActive(false);
        //    playerInformationPopUp.SetActive(false);
        //    gameStartPopUp.SetActive(false);
        //}
        //else
        //if(rankPopUp.activeSelf == true)
        //{
        //    rankPopUp.SetActive(false);
        //}
        StartCoroutine("WattingUpdate");
    }

    public void RankPopUpCancel()
    {
        rankPopUp.SetActive(false);
    }

    public void PlayerInformationPopUpClick()
    {
        if(playerInformationPopUp.activeSelf == false)
        {
            playerInformationPopUp.SetActive(true);
            rankPopUp.SetActive(false);
            gameExitPopUp.SetActive(false);
            buyGoldPopUp.SetActive(false);
            buyGemPopUp.SetActive(false);
            buyGemCheckPopUp.SetActive(false);
            buyShopPopUp.SetActive(false);
            settingPopUp.SetActive(false);
            gameStartPopUp.SetActive(false);
        }
        else
        if(playerInformationPopUp.activeSelf == true)
        {
            playerInformationPopUp.SetActive(false);
        }
    }

    public void PlayerInformationPopUpCancel()
    {
        playerInformationPopUp.SetActive(false);
    }

    public void GameStartPopUpClick()
    {
        if(gameStartPopUp.activeSelf == false)
        {
            gameStartPopUp.SetActive(true);
            playerInformationPopUp.SetActive(false);
            rankPopUp.SetActive(false);
            gameExitPopUp.SetActive(false);
            buyGoldPopUp.SetActive(false);
            buyGemPopUp.SetActive(false);
            buyGemCheckPopUp.SetActive(false);
            buyShopPopUp.SetActive(false);
            settingPopUp.SetActive(false);
        }
        else
        if(gameStartPopUp.activeSelf == true)
        {
            gameStartPopUp.SetActive(false);
        }
    }

    public void GameStartPopUpCancel()
    {
        gameStartPopUp.SetActive(false);
    }

    public void EasyGame()
    {
        Application.LoadLevel("Stage_01");
        Time.timeScale = 1.0f;
    }

    IEnumerator WattingUpdate()
    {
        wattingUpdateLabel.SetActive(true);
        if (wattingUpdateLabel.activeSelf == true)
        {
               wattingUpdateLabel.GetComponent<UILabel>().text = "서비스 준비중 입니다.";

        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        wattingUpdateLabel.SetActive(false);
    }
}
