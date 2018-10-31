using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySceneBtnScript : MonoBehaviour {

    static LobbySceneBtnScript _instance;
    public static LobbySceneBtnScript Instance()
    {
        return _instance;
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

    public float _gold;
    public float _myGem;
    public float _potion;

    public float _gemChange;

    public float myGem
    {
        get
        {
            return _myGem;
        }
        set
        {
            if (_myGem > 0)
            {
                _myGem = _myGem;
                SaveGem();
            }
        }
    }

    //public float gemChange
    //{
    //    get
    //    {
    //        return _gemChange;
    //    }
    //    set
    //    {
    //        _gemChange = value;
    //        if (_gemChange > 0)
    //        {
    //            _myGem = _gemChange;
    //            SaveGem();
    //        }
    //    }
    //}


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

    public GameObject gameStartPopUp;


    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        LoadGem();
    }

    void Start ()
    {
    }
	
	
	void Update ()
    {
        haveGem.text = myGem.ToString();
        haveGold.text = _gold.ToString();
        havePotion.text = _potion.ToString();

 
    
        if(buyGemCheckPopUp.activeSelf == true)
        {
            BuyGemResult();
        }

    }

    void BuyGemResult()
    {
        checkGem.text = chkGemResult.GetComponent<UILabel>().text;
        checkMoney.text = chkMoneyResult.GetComponent<UILabel>().text;
    }

    void SaveGem()
    {
        PlayerPrefs.SetFloat("MyGem", _myGem);
        Debug.Log("잼 저장");
    }
    void LoadGem()
    {
        _myGem = PlayerPrefs.GetFloat("MyGem",_myGem);
        Debug.Log("잼 로드");
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
        _myGem -= 35;
        _gold += 100;
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
        Debug.Log(gemResult);

        _myGem += gemResult; // haveGem에 할 경우 text라서 더 해지지 않음 
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
                if (_gold < 1000)
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }
           
            if (potionGoldCheck.GetComponent<TweenAlpha>().to == 0 && potionGemCheck.GetComponent<TweenAlpha>().to == 1 )
            {
                if (_myGem < 100)
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
                if (_gold < 1000)
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }

            if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 0 && weaponGemCheck.GetComponent<TweenAlpha>().to == 1)
            {
                if (_myGem < 100)
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
                if (_gold < 1000)
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }

            if (hpGoldCheck.GetComponent<TweenAlpha>().to == 0 && hpGemCheck.GetComponent<TweenAlpha>().to == 1)
            {
                if (_myGem < 100)
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
            if (_gold >= 1000)
            {
                _gold -= 1000;
                _potion += 1;
                Debug.Log("골드로 포션");
            }
            else
            if (_gold < 1000)
            {
                StartCoroutine("WarringMessagePotion");
            }
        }
        else
        if(potionGoldCheck.GetComponent<TweenAlpha>().to == 0 && potionGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if(_myGem >=100)
            {
                _myGem -= 100;
                _potion += 1;
                Debug.Log("잼으로 포션");
            }
            if (_myGem < 100)
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
            if (_gold >= 1000)
            {
                _gold -= 1000;
                Debug.Log("골드로 무기");
            }
            else
            if (_gold < 1000)
            {
                StartCoroutine("WarringMessageWeapon");
            }
        }
        else
        if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 0 && weaponGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (_myGem >= 100)
            {
                _myGem -= 100;                
                Debug.Log("잼으로 무기");
            }
            if (_myGem < 100)
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
            if (_gold >= 1000)
            {
                _gold -= 1000;
                Debug.Log("골드로 hp");
            }
            else
            if (_gold < 1000)
            {
                StartCoroutine("WarringMessageHp");
            }
        }
        else
        if (hpGoldCheck.GetComponent<TweenAlpha>().to == 0 && hpGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (_myGem >= 100)
            {
                _myGem -= 100;           
                Debug.Log("잼으로 hp");
            }
            if (_myGem < 100)
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
    }

    public void RankPopUpClick()
    {
        if(rankPopUp.activeSelf == false)
        {
            rankPopUp.SetActive(true);
            gameExitPopUp.SetActive(false);
            buyGoldPopUp.SetActive(false);
            buyGemPopUp.SetActive(false);
            buyGemCheckPopUp.SetActive(false);
            buyShopPopUp.SetActive(false);
            settingPopUp.SetActive(false);
            playerInformationPopUp.SetActive(false);
            gameStartPopUp.SetActive(false);
        }
        else
        if(rankPopUp.activeSelf == true)
        {
            rankPopUp.SetActive(false);
        }
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
}
