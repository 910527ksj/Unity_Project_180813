using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySceneBtnScript : MonoBehaviour {

    public UILabel haveGold;
    public UILabel haveGem;
    public UILabel havePotion;

    public UILabel checkGem;
    public UILabel checkMoney;
    public List<GameObject> chkGemEa;
    public GameObject chkGemResult = null;
    public List<GameObject> chkMoney;
    public GameObject chkMoneyResult = null;

    public float gold;
    public float gem;
    public float potion;

    public GameObject exitPopUp;
    public GameObject buyGoldPopUp;
    public GameObject buyGemPopUp;
    public GameObject buyGemCheckPopUp;
    public GameObject buyShopPopUp;

	void Start ()
    {
		
	}
	
	
	void Update ()
    {
        haveGem.text = gem.ToString();
        haveGold.text = gold.ToString();
        havePotion.text = potion.ToString();
    
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

    public void ExitPopUpClick()
    {
        if(exitPopUp.activeSelf == false)
        {
            exitPopUp.SetActive(true);
            buyGoldPopUp.SetActive(false);
            buyGemPopUp.SetActive(false);
        }
        else
        if(exitPopUp.activeSelf == true)
        {
            exitPopUp.SetActive(false);
        }
    }

    public void ExitPopUpYes()
    {
        Application.Quit();
    }

    public void ExitPopUpCancel()
    {
        exitPopUp.SetActive(false);
    }

    public void BuyGoldPopUpClick()
    {
        if(buyGoldPopUp.activeSelf == false)
        {
            buyGoldPopUp.SetActive(true);
            exitPopUp.SetActive(false);
            buyGemPopUp.SetActive(false);
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
        gem -= 35;
        gold += 100;
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
            exitPopUp.SetActive(false);
            buyGoldPopUp.SetActive(false);
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
}
