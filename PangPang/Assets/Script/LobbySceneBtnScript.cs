using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class LobbySceneBtnScript : MonoBehaviour {

    static LobbySceneBtnScript _instance;
    public static LobbySceneBtnScript Instance()
    {
        return _instance;
    }

    public TextAsset jsonItemData;

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

    public GameObject tapPotion;
    public GameObject tapWeapon;
    public GameObject tapHp;

    public GameObject tapArrow;
    //public GameObject tapRedArrow;
    //public GameObject tapBlueArrow;
    //public GameObject tapWhitArrow;
    //public GameObject tapBlackArrow;
    public GameObject arrowScroll;

    public GameObject tapArmor;
    //public GameObject tapRedArmor;
    //public GameObject tapBlueArmor;
    //public GameObject tapWhiteArmor;
    //public GameObject tapBlackArmor;
    public GameObject armorScroll;

    public GameObject tapSkill;
    //public GameObject tapRedSkill;
    //public GameObject tapBlueSkill;
    //public GameObject tapWhiteSkill;
    //public GameObject tapBlackkill;
    public GameObject skillScroll;

    public GameObject potionGoldCheck;
    public GameObject potionGemCheck;
    public GameObject weaponGoldCheck;
    public GameObject weaponGemCheck;
    public GameObject hpGoldCheck;
    public GameObject hpGemCheck;

    public GameObject redArrowGoldCheck;
    public GameObject redArrowGemCheck;
    public GameObject blueArrowGoldCheck;
    public GameObject blueArrowGemCheck;
    public GameObject whiteArrowGoldCheck;
    public GameObject whiteArrowGemCheck;
    public GameObject blackArrowGoldCheck;
    public GameObject blackArrowGemCheck;

    public GameObject redArmorGoldCheck;
    public GameObject redArmorGemCheck;
    public GameObject blueArmorGoldCheck;
    public GameObject blueArmorGemCheck;
    public GameObject whiteArmorGoldCheck;
    public GameObject whiteArmorGemCheck;
    public GameObject blackArmorGoldCheck;
    public GameObject blackArmorGemCheck;

    public GameObject redSkillGoldCheck;
    public GameObject redSkillGemCheck;
    public GameObject blueSkillGoldCheck;
    public GameObject blueSkillGemCheck;
    public GameObject whiteSkillGoldCheck;
    public GameObject whiteSkillGemCheck;
    public GameObject blackSkillGoldCheck;
    public GameObject blackSkillGemCheck;

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

    public UILabel nowChargeDamage;
    public int chargeDamage = 2; 

    public GameObject gameStartPopUp;


    /* ---------------미완성 스코어 보드 --------------------*/
    //public UILabel bestScoreLabel; 
    //public UILabel secondScoreLabel;
    //public UILabel thirdScoreLabel;
    //public int _bestScore;
    //public int _secondScore;
    //public int _thirdScore;
    //int _myScore;

    //public int bestScore
    //{
    //    get
    //    {
    //        return _bestScore;
    //    }
    //}

    //public int secondScore
    //{
    //    get
    //    {
    //        return _secondScore;
    //    }
    //}

    //public int thirdScore
    //{
    //    get
    //    {
    //        return _thirdScore;
    //    }
    //}

    //public int myScore
    //{
    //    get
    //    {
    //        return _myScore;
    //    }
    //    set
    //    {
    //        _myScore = value;
    //        if (_myScore >= _bestScore)
    //        {
    //            _thirdScore = _secondScore;
    //            _secondScore = _bestScore;
    //            _bestScore = _myScore;
    //            SaveBestScore();
    //        }
    //        else
    //        if (_myScore > _secondScore)
    //        {
    //            _thirdScore = _secondScore;
    //            _secondScore = _myScore;
    //            SaveSecondScore();
    //        }
    //        else
    //        if (_myScore > _thirdScore )
    //        {
    //            Debug.Log("3등 저장하기");
    //            _thirdScore = _myScore;
    //            SaveThirdScore();
    //        }

    //    }
    //}
    /* ---------------미완성 스코어 보드 --------------------*/


    /* 상점 경고 라벨 */
    public GameObject wattingUpdateLabel;
    /* 상점 경고 라벨 */


    /* 상점 json */
    int hpPotionGem;
    int hpPotionGold;
    int weaponGem;
    int weaponGold;
    int hpGem;
    int hpGold;
    int redArrowGem;
    int redArrowGold;
    int blueArrowGem;
    int blueArrowGold;
    int whiteArrowGem;
    int whiteArrowGold;
    int blackArrowGem;
    int blackArrowGold;
    int redArmorGem;
    int redArmorGold;
    int blueArmorGem;
    int blueArmorGold;
    int whiteArmorGem;
    int whiteArmorGold;
    int blackArmorGem;
    int blackArmorGold;
    int redSkillGem;
    int redSkillGold;
    int blueSkillGem;
    int blueSkillGold;
    int whiteSkillGem;
    int whiteSkillGold;
    int blackSkillGem;
    int blackSkillGold;
    /* 상점 json */


    public UILabel haveRedArmor;
    public UILabel haveBlueArmor;
    public UILabel haveWhiteArmor;
    public UILabel haveBlackArmor;
    public UILabel haveRedArrow;
    public UILabel haveBlueArrow;
    public UILabel haveWhiteArrow;
    public UILabel haveBlackArrow;
    public UILabel haveRedSkill;
    public UILabel haveBlueSkill;
    public UILabel haveWhiteSkill;
    public UILabel haveBlackSkill;

    //스테이지 
    public GameObject stage02OFF;
    public GameObject stage02ON;
    public GameObject stage03OFF;
    public GameObject stage03ON;
    public GameObject stage04OFF;
    public GameObject stage04ON;

    //스테이지 클리어 확인
    public bool stage02Clear;
    public bool stage03Clear;
    public bool stage04Clear;

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

        //LoadBestScore();
        //LoadSecondScore();
        //LoadThirdScore();
    }

    void Start ()
    {
        var itemDATA = JSON.Parse(jsonItemData.text); //json 선언       
        hpPotionGem = itemDATA[0]["PriceGem"];
        hpPotionGold = itemDATA[0]["PriceGold"];
        weaponGem = itemDATA[1]["PriceGem"];
        weaponGold = itemDATA[1]["PriceGold"];
        hpGem = itemDATA[2]["PriceGem"];
        hpGold = itemDATA[2]["PriceGold"];
        redArrowGem = itemDATA[3]["PriceGem"];
        redArrowGold = itemDATA[3]["PriceGold"];
        blueArrowGem = itemDATA[4]["PriceGem"];
        blueArrowGold = itemDATA[4]["PriceGold"];
        whiteArrowGem = itemDATA[5]["PriceGem"];
        whiteArrowGold = itemDATA[5]["PriceGold"];
        blackArrowGem = itemDATA[6]["PriceGem"];
        blackArrowGold = itemDATA[6]["PriceGold"];
        redArmorGem = itemDATA[7]["PriceGem"];
        redArmorGold = itemDATA[7]["PriceGold"];
        blueArmorGem = itemDATA[8]["PriceGem"];
        blueArmorGold = itemDATA[8]["PriceGold"];
        whiteArmorGem = itemDATA[9]["PriceGem"];
        whiteArmorGold = itemDATA[9]["PriceGold"];
        blackArmorGem = itemDATA[10]["PriceGem"];
        blackArmorGold = itemDATA[10]["PriceGold"];
        redSkillGem = itemDATA[11]["PriceGem"];
        redSkillGold = itemDATA[11]["PriceGold"];
        blueSkillGem = itemDATA[12]["PriceGem"];
        blueSkillGold = itemDATA[12]["PriceGold"];
        whiteSkillGem = itemDATA[13]["PriceGem"];
        whiteSkillGold = itemDATA[13]["PriceGold"];
        blackSkillGem = itemDATA[14]["PriceGem"];
        blackSkillGold = itemDATA[14]["PriceGold"];
    }
	
	void Update ()
    {
        StageClear();

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

        nowChargeDamage.text = chargeDamage.ToString();

        //bestScoreLabel.text = bestScore.ToString();
        //secondScoreLabel.text = secondScore.ToString();
        //thirdScoreLabel.text = thirdScore.ToString();
 
    
        if(buyGemCheckPopUp.activeSelf == true)
        {
            BuyGemResult();
        }

    }

    public void StageClear()
    {
        if(stage02Clear == true)
        {
            stage02OFF.SetActive(false);
            stage02ON.SetActive(true);
        }
        if (stage03Clear == true)
        {
            stage03OFF.SetActive(false);
            stage03ON.SetActive(true);
        }
        if (stage04Clear == true)
        {
            stage04OFF.SetActive(false);
            stage04ON.SetActive(true);
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

    //void SaveBestScore()
    //{
    //    PlayerPrefs.SetInt("BestScore", _bestScore);
    //}

    //void LoadBestScore()
    //{
    //    _bestScore = PlayerPrefs.GetInt("BestScore", 0);
    //}

    //void SaveSecondScore()
    //{
    //    PlayerPrefs.SetInt("SecondScore", _secondScore);
    //}

    //void LoadSecondScore()
    //{
    //    _secondScore = PlayerPrefs.GetInt("SecondScore", 0);
    //}

    //void SaveThirdScore()
    //{
    //    PlayerPrefs.SetInt("ThirdScoree", _thirdScore);
    //}

    //void LoadThirdScore()
    //{
    //    Debug.Log("3등 불러오기");
    //    _thirdScore = PlayerPrefs.GetInt("ThirdScore", _thirdScore);
    //}

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
            ShopPotionTap();
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

    public void ShopPotionTap()
    {
        tapPotion.SetActive(true);
        tapWeapon.SetActive(false);
        tapHp.SetActive(false);
        tapArrow.SetActive(false);
        tapArmor.SetActive(false);
        tapSkill.SetActive(false);
        //tapRedArrow.SetActive(false);
        //tapBlueArrow.SetActive(false);
        //tapWhitArrow.SetActive(false);
        //tapBlackArrow.SetActive(false);
        //tapRedArmor.SetActive(false);
        //tapBlueArmor.SetActive(false);
        //tapWhiteArmor.SetActive(false);
        //tapBlackArmor.SetActive(false);
        //tapRedSkill.SetActive(false);
        //tapBlueSkill.SetActive(false);
        //tapWhiteSkill.SetActive(false);
        //tapBlackkill.SetActive(false);
        arrowScroll.SetActive(false);
        armorScroll.SetActive(false);
        skillScroll.SetActive(false);
    }

    public void ShopUpgradeTap()
    {
        tapPotion.SetActive(false);
        tapWeapon.SetActive(true);
        tapHp.SetActive(true);
        tapArrow.SetActive(false);
        tapArmor.SetActive(false);
        tapSkill.SetActive(false);
        //tapRedArrow.SetActive(false);
        //tapBlueArrow.SetActive(false);
        //tapWhitArrow.SetActive(false);
        //tapBlackArrow.SetActive(false);
        //tapRedArmor.SetActive(false);
        //tapBlueArmor.SetActive(false);
        //tapWhiteArmor.SetActive(false);
        //tapBlackArmor.SetActive(false);
        //tapRedSkill.SetActive(false);
        //tapBlueSkill.SetActive(false);
        //tapWhiteSkill.SetActive(false);
        //tapBlackkill.SetActive(false);
        arrowScroll.SetActive(false);
        armorScroll.SetActive(false);
        skillScroll.SetActive(false);
    }

    public void ShopArrowTap()
    {
        tapPotion.SetActive(false);
        tapWeapon.SetActive(false);
        tapHp.SetActive(false);
        tapArrow.SetActive(true);
        tapArmor.SetActive(false);
        tapSkill.SetActive(false);
        //tapRedArrow.SetActive(true);
        //tapBlueArrow.SetActive(true);
        //tapWhitArrow.SetActive(true);
        //tapBlackArrow.SetActive(true);
        //tapRedArmor.SetActive(false);
        //tapBlueArmor.SetActive(false);
        //tapWhiteArmor.SetActive(false);
        //tapBlackArmor.SetActive(false);
        //tapRedSkill.SetActive(false);
        //tapBlueSkill.SetActive(false);
        //tapWhiteSkill.SetActive(false);
        //tapBlackkill.SetActive(false);
        arrowScroll.SetActive(true);
        armorScroll.SetActive(false);
        skillScroll.SetActive(false);
    }

    public void ShopArmorTap()
    {
        tapPotion.SetActive(false);
        tapWeapon.SetActive(false);
        tapHp.SetActive(false);
        tapArrow.SetActive(false);
        tapArmor.SetActive(true);
        tapSkill.SetActive(false);
        //tapRedArrow.SetActive(false);
        //tapBlueArrow.SetActive(false);
        //tapWhitArrow.SetActive(false);
        //tapBlackArrow.SetActive(false);
        //tapRedArmor.SetActive(true);
        //tapBlueArmor.SetActive(true);
        //tapWhiteArmor.SetActive(true);
        //tapBlackArmor.SetActive(true);
        //tapRedSkill.SetActive(false);
        //tapBlueSkill.SetActive(false);
        //tapWhiteSkill.SetActive(false);
        //tapBlackkill.SetActive(false);
        arrowScroll.SetActive(false);
        armorScroll.SetActive(true);
        skillScroll.SetActive(false);
    }

    public void ShopSkillTap()
    {
        tapPotion.SetActive(false);
        tapWeapon.SetActive(false);
        tapHp.SetActive(false);
        tapArrow.SetActive(false);
        tapArmor.SetActive(false);
        tapSkill.SetActive(true);
        //tapRedArrow.SetActive(false);
        //tapBlueArrow.SetActive(false);
        //tapWhitArrow.SetActive(false);
        //tapBlackArrow.SetActive(false);
        //tapRedArmor.SetActive(false);
        //tapBlueArmor.SetActive(false);
        //tapWhiteArmor.SetActive(false);
        //tapBlackArmor.SetActive(false);
        //tapRedSkill.SetActive(true);
        //tapBlueSkill.SetActive(true);
        //tapWhiteSkill.SetActive(true);
        //tapBlackkill.SetActive(true);
        arrowScroll.SetActive(false);
        armorScroll.SetActive(false);
        skillScroll.SetActive(true);
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
                if (myGold < hpPotionGold )
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }
           
            if (potionGoldCheck.GetComponent<TweenAlpha>().to == 0 && potionGemCheck.GetComponent<TweenAlpha>().to == 1 )
            {
                if (myGem < hpPotionGem )
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
                if (myGold < weaponGold)
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }

            if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 0 && weaponGemCheck.GetComponent<TweenAlpha>().to == 1)
            {
                if (myGem < weaponGem)
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
                if (myGold < hpGold)
                {
                    warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                }
            }

            if (hpGoldCheck.GetComponent<TweenAlpha>().to == 0 && hpGemCheck.GetComponent<TweenAlpha>().to == 1)
            {
                if (myGem < hpGem)
                {
                    warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                }
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageRedArrow()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().redArrow == false)
            {
                if (redArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && redArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (redArrowGoldCheck.GetComponent<TweenAlpha>().to == 1 && redArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < redArrowGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (redArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && redArrowGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < redArrowGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().redArrow == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageBlueArrow()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().blueArrow == false)
            {
                if (blueArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (blueArrowGoldCheck.GetComponent<TweenAlpha>().to == 1 && blueArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < blueArrowGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (blueArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueArrowGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < blueArrowGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().blueArrow == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageWhiteArrow()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().whiteArrow == false)
            {
                if (whiteArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (whiteArrowGoldCheck.GetComponent<TweenAlpha>().to == 1 && whiteArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < whiteArrowGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (whiteArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteArrowGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < whiteArrowGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().whiteArrow == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageBlackArrow()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().blackArrow == false)
            {
                if (blackArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (blackArrowGoldCheck.GetComponent<TweenAlpha>().to == 1 && blackArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < blackArrowGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (blackArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackArrowGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < blackArrowGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().blackArrow == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageRedArmor()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().redArmor == false)
            {
                if (redArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && redArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (redArmorGoldCheck.GetComponent<TweenAlpha>().to == 1 && redArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < redArmorGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (redArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && redArmorGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < redArmorGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().redArmor == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageBlueArmor()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().blueArmor == false)
            {
                if (blueArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (blueArmorGoldCheck.GetComponent<TweenAlpha>().to == 1 && blueArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < blueArmorGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (blueArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueArmorGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < blueArmorGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().blueArmor == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageWhiteArmor()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().whiteArmor == false)
            {
                if (whiteArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (whiteArmorGoldCheck.GetComponent<TweenAlpha>().to == 1 && whiteArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < whiteArmorGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (whiteArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteArmorGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < whiteArmorGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().whiteArmor == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageBlackArmor()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().blackArmor == false)
            {
                if (blackArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (blackArmorGoldCheck.GetComponent<TweenAlpha>().to == 1 && blackArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < blackArmorGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (blackArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackArmorGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < blackArmorGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().blackArmor == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageRedSkill()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().redSkill == false)
            {
                if (redSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && redSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (redSkillGoldCheck.GetComponent<TweenAlpha>().to == 1 && redSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < redSkillGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (redSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && redSkillGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < redSkillGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().redSkill == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageBlueSkill()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().blueSkill == false)
            {
                if (blueSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (blueSkillGoldCheck.GetComponent<TweenAlpha>().to == 1 && blueSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < blueSkillGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (blueSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueSkillGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < blueSkillGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().blueSkill == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageWhiteSkill()
    {
        warringLabel.SetActive(true);
        if (warringLabel.activeSelf == true)
        {
            if (InventoryManagerScript.Instance().whiteSkill == false)
            {
                if (whiteSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (whiteSkillGoldCheck.GetComponent<TweenAlpha>().to == 1 && whiteSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < whiteSkillGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (whiteSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteSkillGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < whiteSkillGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().whiteSkill == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
            }
        }
        yield return new WaitForSeconds(2f);
        Debug.Log("메시지 숨김");
        warringLabel.SetActive(false);
    }

    IEnumerator WarringMessageBlackSkill()
    {
        warringLabel.SetActive(true);
        if(InventoryManagerScript.Instance().blackSkill == false)
        {
            if (warringLabel.activeSelf == true)
            {
                if (blackSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    warringLabel.GetComponent<UILabel>().text = "구매 방식을 선택해주세요.";
                }

                if (blackSkillGoldCheck.GetComponent<TweenAlpha>().to == 1 && blackSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
                {
                    if (myGold < blackSkillGold)
                    {
                        warringLabel.GetComponent<UILabel>().text = "골드가 부족합니다.";
                    }
                }

                if (blackSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackSkillGemCheck.GetComponent<TweenAlpha>().to == 1)
                {
                    if (myGem < blackSkillGem)
                    {
                        warringLabel.GetComponent<UILabel>().text = "잼이 부족합니다.";
                    }
                }
            }
            if (InventoryManagerScript.Instance().blackSkill == true)
            {
                warringLabel.GetComponent<UILabel>().text = "이미 보유하고 있습니다.";
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
            if (myGold >= hpPotionGold)
            {
                myGold -= hpPotionGold;
                myPotion += 1;
                Debug.Log("골드로 포션");
            }
            else
            if (myGold < hpPotionGold)
            {
                StartCoroutine("WarringMessagePotion");
            }
        }
        else
        if(potionGoldCheck.GetComponent<TweenAlpha>().to == 0 && potionGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if(myGem >= hpPotionGem)
            {
                myGem -= hpPotionGem;
                myPotion += 1;
                Debug.Log("잼으로 포션");
            }
            if (myGem < hpPotionGem)
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
            if (myGold >= weaponGold)
            {
                myGold -= weaponGold;
                basicDamage += 1;
                Debug.Log("골드로 무기");
            }
            else
            if (myGold < weaponGold)
            {
                StartCoroutine("WarringMessageWeapon");
            }
        }
        else
        if (weaponGoldCheck.GetComponent<TweenAlpha>().to == 0 && weaponGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= weaponGem)
            {
                myGem -= weaponGem;
                basicDamage += 1;
                Debug.Log("잼으로 무기");
            }
            if (myGem < weaponGem)
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
            if (myGold >= hpGold)
            {
                myGold -= hpGold;
                playerMaxHp += 1;
                Debug.Log("골드로 hp");
            }
            else
            if (myGold < hpGold)
            {
                StartCoroutine("WarringMessageHp");
            }
        }
        else
        if (hpGoldCheck.GetComponent<TweenAlpha>().to == 0 && hpGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= hpGem)
            {
                myGem -= hpGem;
                playerMaxHp += 1;
                Debug.Log("잼으로 hp");
            }
            if (myGem < hpGem)
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

    public void BuyRedArrow()
    {
        if (redArrowGoldCheck.GetComponent<TweenAlpha>().to == 1 && redArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= redArrowGold && InventoryManagerScript.Instance().redArrow == false)
            {
                myGold -= redArrowGold;
                haveRedArrow.text = "1";
                InventoryManagerScript.Instance().redArrow = true;
                Debug.Log("골드로 RedArrow");
            }
            else
            if (myGold < redArrowGold || InventoryManagerScript.Instance().redArrow == true)
            {
                StartCoroutine("WarringMessageRedArrow");
            }
        }
        else
        if (redArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && redArrowGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= redArrowGem && InventoryManagerScript.Instance().redArrow == false)
            {
                myGem -= redArrowGem;
                haveRedArrow.text = "1";
                InventoryManagerScript.Instance().redArrow = true;
                Debug.Log("잼으로 RedArrow");
            }
            else
            if (myGem < redArrowGem || InventoryManagerScript.Instance().redArrow == true)
            {
                StartCoroutine("WarringMessageRedArrow");
            }
        }
        else
        if (redArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && redArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageRedArrow");
        }
    }

    public void BuyBlueArrow()
    {
        if (blueArrowGoldCheck.GetComponent<TweenAlpha>().to == 1 && blueArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= blueArrowGold && InventoryManagerScript.Instance().blueArrow == false)
            {
                myGold -= blueArrowGold;
                haveBlueArrow.text = "1";
                InventoryManagerScript.Instance().blueArrow = true;
                Debug.Log("골드로 BlueArrow");
            }
            else
            if (myGold < blueArrowGold || InventoryManagerScript.Instance().blueArrow == true)
            {
                StartCoroutine("WarringMessageBlueArrow");
            }
        }
        else
        if (blueArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueArrowGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= blueArrowGem && InventoryManagerScript.Instance().blueArrow == false)
            {
                myGem -= blueArrowGem;
                haveBlueArrow.text = "1";
                InventoryManagerScript.Instance().blueArrow = true;
                Debug.Log("잼으로 BlueArrow");
            }
            else
            if (myGem < blueArrowGem || InventoryManagerScript.Instance().blueArrow == true)
            {
                StartCoroutine("WarringMessageBlueArrow");
            }
        }
        else
        if (blueArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageBlueArrow");
        }
    }

    public void BuyWhiteArrow()
    {
        if (whiteArrowGoldCheck.GetComponent<TweenAlpha>().to == 1 && whiteArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= whiteArrowGold && InventoryManagerScript.Instance().whiteArrow == false)
            {
                myGold -= whiteArrowGold;
                haveWhiteArrow.text = "1";
                InventoryManagerScript.Instance().whiteArrow = true;
                Debug.Log("골드로 WhiteArrow");
            }
            else
            if (myGold < whiteArrowGold || InventoryManagerScript.Instance().whiteArrow == true)
            {
                StartCoroutine("WarringMessageWhiteArrow");
            }
        }
        else
        if (whiteArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteArrowGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= whiteArrowGem && InventoryManagerScript.Instance().whiteArrow == false)
            {
                myGem -= whiteArrowGem;
                haveWhiteArrow.text = "1";
                InventoryManagerScript.Instance().whiteArrow = true;
                Debug.Log("잼으로 WhiteArrow");
            }
            else
            if (myGem < whiteArrowGem || InventoryManagerScript.Instance().whiteArrow == true)
            {
                StartCoroutine("WarringMessageWhiteArrow");
            }
        }
        else
        if (whiteArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageWhiteArrow");
        }
    }

    public void BuyBlackArrow()
    {
        if (blackArrowGoldCheck.GetComponent<TweenAlpha>().to == 1 && blackArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= blackArrowGold && InventoryManagerScript.Instance().blackArrow == false)
            {
                myGold -= blackArrowGold;
                haveBlackArrow.text = "1";
                InventoryManagerScript.Instance().blackArrow = true;
                Debug.Log("골드로 BlackArrow");
            }
            else
            if (myGold < blackArrowGold || InventoryManagerScript.Instance().blackArrow == true)
            {                
                StartCoroutine("WarringMessageBlackArrow");
            }
        }
        else
        if (blackArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackArrowGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= blackArrowGem && InventoryManagerScript.Instance().blackArrow == false)
            {
                myGem -= blackArrowGem;
                haveBlackArrow.text = "1";
                InventoryManagerScript.Instance().blackArrow = true;
                Debug.Log("잼으로 BlackArrow");
            }
            else
            if (myGem < blackArrowGem || InventoryManagerScript.Instance().blackArrow == true)
            {
                StartCoroutine("WarringMessageBlackArrow");
            }
        }
        else
        if (blackArrowGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackArrowGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageBlackArrow");
        }
    }

    public void BuyRedArmor()
    {
        if (redArmorGoldCheck.GetComponent<TweenAlpha>().to == 1 && redArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= redArmorGold && InventoryManagerScript.Instance().redArmor == false)
            {
                myGold -= redArmorGold;
                haveRedArmor.text = "1";
                InventoryManagerScript.Instance().redArmor = true;
                Debug.Log("골드로 RedArmor");
            }
            else
            if (myGold < redArmorGold || InventoryManagerScript.Instance().redArmor == true)
            {
                StartCoroutine("WarringMessageRedArmor");
            }
        }
        else
        if (redArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && redArmorGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= redArmorGem && InventoryManagerScript.Instance().redArmor == false)
            {
                myGem -= redArmorGem;
                haveRedArmor.text = "1";
                InventoryManagerScript.Instance().redArmor = true;
                Debug.Log("잼으로 RedArmor");
            }
            else        
            if (myGem < redArmorGem || InventoryManagerScript.Instance().redArmor == true)
            {
                StartCoroutine("WarringMessageRedArmor");
            }
        }
        else
        if (redArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && redArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageRedArmor");
        }
    }

    public void BuyBlueArmor()
    {
        if (blueArmorGoldCheck.GetComponent<TweenAlpha>().to == 1 && blueArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= blueArmorGold && InventoryManagerScript.Instance().blueArmor == false)
            {
                myGold -= blueArmorGold;
                haveBlueArmor.text = "1";
                InventoryManagerScript.Instance().blueArmor = true;
                Debug.Log("골드로 BlueArmor");
            }
            else
            if (myGold < blueArmorGold || InventoryManagerScript.Instance().blueArmor == true)
            {
                StartCoroutine("WarringMessageBlueArmor");
            }
        }
        else
        if (blueArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueArmorGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= blueArmorGem && InventoryManagerScript.Instance().blueArmor == false)
            {
                myGem -= blueArmorGem;
                haveBlueArmor.text = "1";
                InventoryManagerScript.Instance().blueArmor = true;
                Debug.Log("잼으로 BlueArmor");
            }
            else
            if (myGem < blueArmorGem || InventoryManagerScript.Instance().blueArmor == true)
            {
                StartCoroutine("WarringMessageBlueArmor");
            }
        }
        else
        if (blueArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageBlueArmor");
        }
    }

    public void BuyWhiteArmor()
    {
        if (whiteArmorGoldCheck.GetComponent<TweenAlpha>().to == 1 && whiteArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= whiteArmorGold && InventoryManagerScript.Instance().whiteArmor == false)
            {
                myGold -= whiteArmorGold;
                haveWhiteArmor.text = "1";
                InventoryManagerScript.Instance().whiteArmor = true;
                Debug.Log("골드로 WhiteArmor");
            }
            else
            if (myGold < whiteArmorGold || InventoryManagerScript.Instance().whiteArmor == true)
            {
                StartCoroutine("WarringMessageWhiteArmor");
            }
        }
        else
        if (whiteArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteArmorGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= whiteArmorGem && InventoryManagerScript.Instance().whiteArmor == false)
            {
                myGem -= whiteArmorGem;
                haveWhiteArmor.text = "1";
                InventoryManagerScript.Instance().whiteArmor = true;
                Debug.Log("잼으로 WhiteArmor");
            }
            else
            if (myGem < whiteArmorGem || InventoryManagerScript.Instance().whiteArmor == true)
            {
                StartCoroutine("WarringMessageWhiteArmor");
            }
        }
        else
        if (whiteArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageWhiteArmor");
        }
    }

    public void BuyBlackArmor()
    {
        if (blackArmorGoldCheck.GetComponent<TweenAlpha>().to == 1 && blackArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= blackArmorGold && InventoryManagerScript.Instance().blackArmor == false)
            {
                myGold -= blackArmorGold;
                haveBlackArmor.text = "1";
                InventoryManagerScript.Instance().blackArmor = true;
                Debug.Log("골드로 BlackArmor");
            }
            else
            if (myGold < blackArmorGold || InventoryManagerScript.Instance().blackArmor == true)
            {
                StartCoroutine("WarringMessageBlackArmor");
            }
        }
        else
        if (blackArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackArmorGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= blackArmorGem && InventoryManagerScript.Instance().blackArmor == false)
            {
                myGem -= blackArmorGem;
                haveBlackArmor.text = "1";
                InventoryManagerScript.Instance().blackArmor = true;
                Debug.Log("잼으로 BlackArmor");
            }
            else
            if (myGem < blackArmorGem || InventoryManagerScript.Instance().blackArmor == true)
            {
                StartCoroutine("WarringMessageBlackArmor");
            }
        }
        else
        if (blackArmorGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackArmorGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageBlackArmor");
        }
    }

    public void BuyRedSkill()
    {
        if (redSkillGoldCheck.GetComponent<TweenAlpha>().to == 1 && redSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= redSkillGold && InventoryManagerScript.Instance().redSkill == false)
            {
                myGold -= redSkillGold;
                haveRedSkill.text = "1";
                InventoryManagerScript.Instance().redSkill = true;
                Debug.Log("골드로 RedSkill");
            }
            else
            if (myGold < redSkillGold || InventoryManagerScript.Instance().redSkill == true)
            {
                StartCoroutine("WarringMessageRedSkill");
            }
        }
        else
        if (redSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && redSkillGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= redSkillGem && InventoryManagerScript.Instance().redSkill == false)
            {
                myGem -= redSkillGem;
                haveRedSkill.text = "1";
                InventoryManagerScript.Instance().redSkill = true;
                Debug.Log("잼으로 RedSkill");
            }
            else
            if (myGem < redSkillGem || InventoryManagerScript.Instance().redSkill == true)
            {
                StartCoroutine("WarringMessageRedSkill");
            }
        }
        else
        if (redSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && redSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageRedSkill");
        }
    }

    public void BuyBlueSkill()
    {
        if (blueSkillGoldCheck.GetComponent<TweenAlpha>().to == 1 && blueSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= blueSkillGold && InventoryManagerScript.Instance().blueSkill == false)
            {
                myGold -= blueSkillGold;
                haveBlueSkill.text = "1";
                InventoryManagerScript.Instance().blueSkill = true;
                Debug.Log("골드로 BlueSkill");
            }
            else
            if (myGold < blueSkillGold || InventoryManagerScript.Instance().blueSkill == true)
            {
                StartCoroutine("WarringMessageBlueSkill");
            }
        }
        else
        if (blueSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueSkillGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= blueSkillGem && InventoryManagerScript.Instance().blueSkill == false)
            {
                myGem -= blueSkillGem;
                haveBlueSkill.text = "1";
                InventoryManagerScript.Instance().blueSkill = true;
                Debug.Log("잼으로 BlueSkill");
            }
            else
            if (myGem < blueSkillGem || InventoryManagerScript.Instance().blueSkill == true)
            {
                StartCoroutine("WarringMessageBlueSkill");
            }
        }
        else
        if (blueSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && blueSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageBlueSkill");
        }
    }

    public void BuyWhiteSkill()
    {
        if (whiteSkillGoldCheck.GetComponent<TweenAlpha>().to == 1 && whiteSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= whiteSkillGold && InventoryManagerScript.Instance().whiteSkill == false)
            {
                myGold -= whiteSkillGold;
                haveWhiteSkill.text = "1";
                InventoryManagerScript.Instance().whiteSkill = true;
                Debug.Log("골드로 WhiteSkill");
            }
            else
            if (myGold < whiteSkillGold || InventoryManagerScript.Instance().whiteSkill == true)
            {
                StartCoroutine("WarringMessageWhiteSkill");
            }
        }
        else
        if (whiteSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteSkillGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= whiteSkillGem && InventoryManagerScript.Instance().whiteSkill == false)
            {
                myGem -= whiteSkillGem;
                haveWhiteSkill.text = "1";
                InventoryManagerScript.Instance().whiteSkill = true;
                Debug.Log("잼으로 WhiteSkill");
            }
            else
            if (myGem < whiteSkillGem || InventoryManagerScript.Instance().whiteSkill == true)
            {
                StartCoroutine("WarringMessageWhiteSkill");
            }
        }
        else
        if (whiteSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && whiteSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageWhiteSkill");
        }
    }

    public void BuyBlackSkill()
    {
        if (blackSkillGoldCheck.GetComponent<TweenAlpha>().to == 1 && blackSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            if (myGold >= blackSkillGold && InventoryManagerScript.Instance().blackSkill == false)
            {
                myGold -= blackSkillGold;
                haveBlackSkill.text = "1";
                InventoryManagerScript.Instance().blackSkill = true;
                Debug.Log("골드로 BlackSkill");
            }
            else
            if (myGold < blackSkillGold || InventoryManagerScript.Instance().blackSkill == true)
            {
                StartCoroutine("WarringMessageBlackSkill");
            }
        }
        else
        if (blackSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackSkillGemCheck.GetComponent<TweenAlpha>().to == 1)
        {
            if (myGem >= blackSkillGem && InventoryManagerScript.Instance().blackSkill == false)
            {
                myGem -= blackSkillGem;
                haveBlackSkill.text = "1";
                InventoryManagerScript.Instance().blackSkill = true;
                Debug.Log("잼으로 BlackSkill");
            }
            else
            if (myGem < blackSkillGem || InventoryManagerScript.Instance().blackSkill == true)
            {
                StartCoroutine("WarringMessageBlackSkill");
            }
        }
        else
        if (blackSkillGoldCheck.GetComponent<TweenAlpha>().to == 0 && blackSkillGemCheck.GetComponent<TweenAlpha>().to == 0)
        {
            Debug.Log("체크 하세요");
            StartCoroutine("WarringMessageBlackSkill");
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
        //if(ItemScript.Instance().m_sprFrame.enabled == true)
        //{
        //    ItemScript.Instance().m_sprFrame.enabled = false;
        //}
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

    public void Stage01()
    {
        Application.LoadLevel("Stage_01");
        gameStartPopUp.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Stage02()
    {
        Application.LoadLevel("Stage_02");
        gameStartPopUp.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Stage03()
    {
        Application.LoadLevel("Stage_03");
        gameStartPopUp.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void Stage04()
    {
        Application.LoadLevel("Stage_04");
        gameStartPopUp.SetActive(false);
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
