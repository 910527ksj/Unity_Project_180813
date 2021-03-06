﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class InventoryManagerScript : MonoBehaviour {

    static InventoryManagerScript _instance;
    public static InventoryManagerScript Instance()
    {
        return _instance;
    }

    public TextAsset jsonItemData;

    public bool redArmor;
    public bool blueArmor;
    public bool whiteArmor;
    public bool blackArmor;
    public bool redArrow;
    public bool blueArrow;
    public bool whiteArrow;
    public bool blackArrow;
    public bool redSkill;
    public bool blueSkill;
    public bool whiteSkill;
    public bool blackSkill;

    public bool cha01;

    private int redArmorItemEa;
    private int blueArmorItemEa;
    private int whiteArmorItemEa;
    private int blackArmorItemEa;
    private int redArrowItemEa;
    private int blueArrowItemEa;
    private int whiteArrowItemEa;
    private int blackArrowItemEa;
    private int redSkillEa;
    private int blueSkillEa;
    private int whiteSkillEa;
    private int blackSkillEa;

    private int cha01Ea;


    // 지금은 DB가 없으니... 노다가로 아이템 이름을 넣어요.

    public List<string> m_lItemNames = new List<string>();
    public List<int> m_lItemSellCost = new List<int>();

    public List<int> m_lItemValue = new List<int>();

    // 새로 만들어진 아이템들을 모아둡니다.(삭제 및 수정 등을 하기위해서)

    public List<ItemScript> m_lItems = new List<ItemScript>();

    public List<ItemScript> m_slotitem = new List<ItemScript>();

    // 우리가 만든 SampleItem을 복사해서 만들기 위해 선언합니다.

    public GameObject m_gObjArrowSampleItem;
    public GameObject m_gObjArmorSampleItem;
    public GameObject m_gObjSkillSampleItem;

    // 스크롤뷰를 reposition 하기위해 선언합니다.

    //public UIScrollView m_scrollView;

    // 그리드를 reset position 하기위해 선언합니다.

    public UIGrid m_grid;



    // 속도 향상을 위해 현재 선택된 아이템을 저장해 놓겠습니다.

    private ItemScript m_cCurScript;

    // 테스트를 위해 현재 소지금을 저장해볼께요.

    //public int m_nMoney;

    // 선택하면 정보를 표시할 레이블

    public UILabel m_lblInfo;

    // 버튼 오브젝트. 선택 안되면 안보여야 겠죠?

    public GameObject m_gObjSellButton;

    //장착창

    public GameObject redArrowSlot;
    public GameObject blueArrowSlot;
    public GameObject whiteArrowSlot;
    public GameObject blackArrowSlot;

    public GameObject redArmorSlot;
    public GameObject blueArmorSlot;
    public GameObject whiteArmorSlot;
    public GameObject blackArmorSlot;

    public GameObject redSkillSlot;
    public GameObject blueSkillSlot;
    public GameObject whiteSkillSlot;
    public GameObject blackSkillSlot;


    //장착,해제 버튼

    public GameObject equipBtn;
    public GameObject takeOffBtn;
    //장착,해제 버튼


    //장착창 장착시 수치 변경을 위한 bool
    bool redAbool = false;
    bool blueAbool = false;
    bool whiteAbool = false;
    bool blackAbool = false;
    bool redMbool = false;
    bool blueMbool = false;
    bool whiteMbool = false;
    bool blackMbool = false;
    bool redSbool = false;
    bool blueSbool = false;
    bool whiteSbool = false;
    bool blackSbool = false;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        InitItems();

        // 최초 null로 설정합니다. 

        m_cCurScript = null;

        // 레이블정보도 초기화합니다.

        m_lblInfo.text = string.Empty;

        // 버튼은 화면에서 안보이게.

        m_gObjSellButton.SetActive(false);
        equipBtn.SetActive(false);
        takeOffBtn.SetActive(false);


        //m_slotitem[0] = GameObject.Find("redA").GetComponent<ItemScript>();
        //m_gObjArrowSampleItem = GameObject.Find("Arrow_Sample");
        //m_slotitem[0] = transform.Find("redA").parent.GetComponent<ItemScript>();
        //GameObject.Find("Inven").transform.FindChild("redA").gameObject.SetActive(true);
        //m_slotitem[0] = GameObject.FindGameObjectWithTag("redA").GetComponent<ItemScript>();
    }

    void Update()
    {
        AddItem();
        //m_grid.Reposition();
        
    }

    private void InitItems()
    {
        var itemIconDATA = JSON.Parse(jsonItemData.text); //json 선언       
        m_lItemNames.Add(itemIconDATA[3]["Icon"]);
        m_lItemNames.Add(itemIconDATA[4]["Icon"]);
        m_lItemNames.Add(itemIconDATA[5]["Icon"]);
        m_lItemNames.Add(itemIconDATA[6]["Icon"]);
        m_lItemNames.Add(itemIconDATA[7]["Icon"]);
        m_lItemNames.Add(itemIconDATA[8]["Icon"]);
        m_lItemNames.Add(itemIconDATA[9]["Icon"]);
        m_lItemNames.Add(itemIconDATA[10]["Icon"]);
        m_lItemNames.Add(itemIconDATA[11]["Icon"]);
        m_lItemNames.Add(itemIconDATA[12]["Icon"]);
        m_lItemNames.Add(itemIconDATA[13]["Icon"]);
        m_lItemNames.Add(itemIconDATA[14]["Icon"]);
        var itemSellDATA = JSON.Parse(jsonItemData.text); //json 선언 
        m_lItemSellCost.Add(itemSellDATA[3]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[4]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[5]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[6]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[7]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[8]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[9]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[10]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[11]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[12]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[13]["SellGold"]);
        m_lItemSellCost.Add(itemSellDATA[14]["SellGold"]);
        var itemValueDATA = JSON.Parse(jsonItemData.text);  //json 선언 
        m_lItemValue.Add(itemValueDATA[3]["value"]);
        m_lItemValue.Add(itemValueDATA[4]["value"]);
        m_lItemValue.Add(itemValueDATA[5]["value"]);
        m_lItemValue.Add(itemValueDATA[6]["value"]);
        m_lItemValue.Add(itemValueDATA[7]["value"]);
        m_lItemValue.Add(itemValueDATA[8]["value"]);
        m_lItemValue.Add(itemValueDATA[9]["value"]);
        m_lItemValue.Add(itemValueDATA[10]["value"]);
        m_lItemValue.Add(itemValueDATA[11]["value"]);
        m_lItemValue.Add(itemValueDATA[12]["value"]);
        m_lItemValue.Add(itemValueDATA[13]["value"]);
        m_lItemValue.Add(itemValueDATA[14]["value"]);
    }


    // 키를 누르면 아이템을 화면에 보여주는 역할을 합니다.

    // 여기에서 가장 중요한 역할을 하는 함수죠.

    public void AddItem()
    {
        /*-------------------화살------------------*/
        if (redArrow == true && redArrowItemEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            //GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            //GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            arrowSampleItem.SetActive(true);

          // 이제 이름과 아이콘을 세팅할께요.

          // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

          // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

          ItemScript itemScript = arrowSampleItem.GetComponent<ItemScript>();
          itemScript.SettingInfo(m_lItemNames[0]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

          //하나만 생기게 하기위해 변수 선언 후 +1 증가
          redArrowItemEa += 1;
        }
        if (blueArrow == true && blueArrowItemEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            //GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            //GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            arrowSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = arrowSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[1]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            blueArrowItemEa += 1;
        }
        if (whiteArrow == true && whiteArrowItemEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            //GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            //GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            arrowSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = arrowSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[2]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            whiteArrowItemEa += 1;
        }
        if (blackArrow == true && blackArrowItemEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            //GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            //GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            arrowSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = arrowSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[3]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            blackArrowItemEa += 1;
        }
        /*-------------------화살------------------*/


        /*-------------------방어구------------------*/
        if (redArmor == true && redArmorItemEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            //GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            //GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            armorSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = armorSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[4]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            redArmorItemEa += 1;
        }
        if (blueArmor == true && blueArmorItemEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            //GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            //GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            armorSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = armorSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[5]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            blueArmorItemEa += 1;
        }
        if (whiteArmor == true && whiteArmorItemEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            //GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            //GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            armorSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = armorSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[6]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            whiteArmorItemEa += 1;
        }
        if (blackArmor == true && blackArmorItemEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            //GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            //GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            armorSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = armorSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[7]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            blackArmorItemEa += 1;
        }
        /*-------------------방어구------------------*/


        /*-------------------스킬------------------*/
        if (redSkill == true && redSkillEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            //GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            //GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            skillSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = skillSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[8]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            redSkillEa += 1;
        }
        if (blueSkill == true && blueSkillEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            //GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            //GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            skillSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = skillSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[9]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            blueSkillEa += 1;
        }
        if (whiteSkill == true && whiteSkillEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            //GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            //GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            skillSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = skillSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[10]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            whiteSkillEa += 1;
        }
        if (blackSkill == true && blackSkillEa == 0)
        {
            // 새로 만들어서 그리드 자식으로 넣겠습니다.         
            //GameObject armorSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArmorSampleItem);
            //GameObject arrowSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjArrowSampleItem);
            GameObject skillSampleItem = NGUITools.AddChild(m_grid.gameObject, m_gObjSkillSampleItem);

            // SampleItem의 Active가 꺼져있으니(아까 꼈죠?) 먼저 켜도록 할께요.

            skillSampleItem.SetActive(true);

            // 이제 이름과 아이콘을 세팅할께요.

            // 그럴려면 먼저 아까 만든 ItemScript를 가져와야겠죠.

            // GetComponent는 해당 게임 오브젝트가 가지고 있는 컴포넌트를 가져오는 역할을 해요.

            ItemScript itemScript = skillSampleItem.GetComponent<ItemScript>();
            itemScript.SettingInfo(m_lItemNames[11]);

            // 이제 그리드와 스크롤뷰를 재정렬 시킵시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 그리고 관리를 위해 만든걸 리스트에 넣어둡시다.

            m_lItems.Add(itemScript);

            //하나만 생기게 하기위해 변수 선언 후 +1 증가
            blackSkillEa += 1;
        }
        /*-------------------스킬------------------*/
    }



    //모두 삭제합니다.

    //private void ClearAll()

    //{

    //    아까 만든거 저장해둔 리스트에서 모두 삭제해줍니다.

    //    for (int nIndex = 0; nIndex < m_lItems.Count; nIndex++)

    //    {

    //        if (m_lItems[nIndex] != null && m_lItems[nIndex].gameObject != null)

    //            Destroy(m_lItems[nIndex].gameObject);

    //    }

    //    m_lItems.Clear();

    //    그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

    //   m_grid.Reposition();

    //    m_scrollView.ResetPosition();

    //}



    // 삭제합니다.




    public void DeleteItem()
    {
        /*-------화살-------*/
        if (redArrow == false && redArrowItemEa == 1 )
        {         
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "RedArrow_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "RedArrow_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            redArrowItemEa -= 1;
        }
        if (blueArrow == false && blueArrowItemEa == 1)
        { 
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "BlueArrow_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "BlueArrow_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            blueArrowItemEa -= 1;
        }
        if (whiteArrow == false && whiteArrowItemEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "WhiteArrow_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "WhiteArrow_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            whiteArrowItemEa -= 1;
        }
        if (blackArrow == false && blackArrowItemEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "BlackArrow_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "BlackArrow_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            blackArrowItemEa -= 1;
        }
        /*-------화살-------*/


        /*-------방어구-------*/
        if (redArmor == false && redArmorItemEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "RedArmor_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "RedArmor_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            redArmorItemEa -= 1;
        }
        if (blueArmor == false && blueArmorItemEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "BlueArmor_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "BlueArmor_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            blueArmorItemEa -= 1;
        }
        if (whiteArmor == false && whiteArmorItemEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "WhiteArmor_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "WhiteArmor_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            whiteArmorItemEa -= 1;
        }
        if (blackArmor == false && blackArmorItemEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "BlackArmor_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "BlackArmor_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            blackArmorItemEa -= 1;
        }
        /*-------방어구-------*/


        /*-------스킬-------*/
        if (redSkill == false && redSkillEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "RedSkill_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "RedSkill_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            redSkillEa -= 1;
        }
        if (blueSkill == false && blueSkillEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "BlueSkill_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "BlueSkill_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            blueSkillEa -= 1;
        }
        if (whiteSkill == false && whiteSkillEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "WhiteSkill_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "WhiteSkill_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            whiteSkillEa -= 1;
        }
        if (blackSkill == false && blackSkillEa == 1)
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            Destroy(m_lItems.Find(x => x.name == "BlackSkill_Icon").gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.Remove(m_lItems.Find(x => x.name == "BlackSkill_Icon"));

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            blackSkillEa -= 1;
        }
        /*-------스킬-------*/
    }




    // 삭제 함수를 만들겠습니다.

    private void ClearOne(ItemScript itemScript)

    {

        for (int nIndex = 0; nIndex < m_lItems.Count; nIndex++)

        {

            // 인자로 넘어온것과 같으면 리스트에서 제거하고

            // GameObject를 없애서 화면에서 지워줍니다.

            if (itemScript == m_lItems[nIndex])

            {

                DestroyImmediate(m_lItems[nIndex].gameObject);

                m_lItems.RemoveAt(nIndex);

                break;

            }

        }

    }



    // 아이템이 선택되면 이 함수가 호출됩니다.

    // 넘어온 정보를 가지고 이것저것 설정을 하고, 

    // 선택 프레임도 활성/비활성 시켜줍니다.

    public void SelectItem(ItemScript itemScript) // (ItemScript itemScript)이 스크립트가 들어가있는 오브젝트 누를시 아래 함수 실행)
    {

        // 현재 선택된 정보와 같으면 표시할 갱신할 필요 없겠죠?

        if (m_cCurScript == itemScript) return;

        // 현재 선택된 아이템 정보 저장해놓고.

        m_cCurScript = itemScript;

        // 이제 선택 프레임을 활성/비활성 합니다.

        // 전체 리스트를 가지고 있으니 그거가지고 하면 되겠네요.

        for (int nIndex = 0; nIndex < m_lItems.Count; nIndex++)

        {

            // 넘어온 정보와 같은 아이템이면 선택한 아이템이겠죠?

            //if(m_cCurScript == m_lItems[nIndex])

            //{

            //    m_lItems[nIndex].SetSelected(true);

            //}

            //else

            //{

            //    m_lItems[nIndex].SetSelected(false);

            //}

            // 전 한줄로 표시할께요 ㅎㅎ

            m_lItems[nIndex].SetSelected(m_cCurScript == m_lItems[nIndex]);
            
        }

        for (int nIndex = 0; nIndex < m_slotitem.Count; nIndex++)

        {

            // 넘어온 정보와 같은 아이템이면 선택한 아이템이겠죠?

            //if(m_cCurScript == m_lItems[nIndex])

            //{

            //    m_lItems[nIndex].SetSelected(true);

            //}

            //else

            //{

            //    m_lItems[nIndex].SetSelected(false);

            //}

            // 전 한줄로 표시할께요 ㅎㅎ

            m_slotitem[nIndex].SetSelected(m_cCurScript == m_slotitem[nIndex]);

        }

        //// 현재 선택된 정보를 표시하도록 할께요.
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[0])
            {
                 m_gObjSellButton.SetActive(true);
                 m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[0].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[1])
            {
                m_gObjSellButton.SetActive(true);
                  m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[1].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[2])
            {
              m_gObjSellButton.SetActive(true);
              m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[2].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[3])
            {
                m_gObjSellButton.SetActive(true);
              m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[3].ToString();
            }


            if (m_cCurScript.m_sprIcon.name == m_lItemNames[4])
            {
               m_gObjSellButton.SetActive(true);
             m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[4].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[5])
            {
              m_gObjSellButton.SetActive(true);
              m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[5].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[6])
            {
              m_gObjSellButton.SetActive(true);
              m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[6].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[7])
            {
                m_gObjSellButton.SetActive(true);
              m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[7].ToString();
            }


            if (m_cCurScript.m_sprIcon.name == m_lItemNames[8])
            {
              m_gObjSellButton.SetActive(true);
               m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[8].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[9])
            {
               m_gObjSellButton.SetActive(true);
               m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[9].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[10])
            {
               m_gObjSellButton.SetActive(true);
                m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[10].ToString();
            }
            if (m_cCurScript.m_sprIcon.name == m_lItemNames[11])
            {
                m_gObjSellButton.SetActive(true);
              m_lblInfo.text = "판매 금액 : " + m_lItemSellCost[11].ToString();
            }


        // 판매 버튼도 보이도록 할께요
        //m_gObjSellButton.SetActive(true);

        equipBtn.SetActive(true);
        takeOffBtn.SetActive(true);
    }



    // 판매하는 함수 입니다.


    public void Sell()
    {
        /*-----무기------*/
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[0])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[0];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);
            equipBtn.SetActive(false);
            takeOffBtn.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            redArrow = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveRedArrow.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[1])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[1];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            blueArrow = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveBlueArrow.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[2])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[2];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            whiteArrow = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveWhiteArrow.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[3])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[3];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            blackArrow = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveBlackArrow.text = "0";
        }
        /*-----무기------*/

        /*-----방어구------*/
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[4])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[4];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액0 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            redArmor = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveRedArmor.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[5])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[5];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액0 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            blueArmor = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveBlueArmor.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[6])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[6];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액0 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            whiteArmor = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveWhiteArmor.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[7])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[7];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액0 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            blackArmor = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveBlackArmor.text = "0";
        }
        /*-----방어구------*/

        /*-----스킬------*/
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[8])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[8];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액0 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            redSkill = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveRedSkill.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[9])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[9];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액0 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            blueSkill = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveBlueSkill.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[10])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[10];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액0 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            whiteSkill = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveWhiteSkill.text = "0";
        }

        if (m_cCurScript.m_sprIcon.name == m_lItemNames[11])
        {
            // 현재 선택된 데이터가 없으면 안되겠죠?

            //if (m_cCurScript == null) return;

            // 판매를 누르면 판매한 금액을 합산할께요.

            LobbySceneBtnScript.Instance().myGold += m_lItemSellCost[11];

            // 그리고 현재 아이템을 삭제해주어야 합니다.(위에 만든 삭제함수를 사용할꺼에요)

            //ClearOne(m_cCurScript);

            // 그리고 현재 선택된 아이템 정보를 초기화 합니다.

            //m_cCurScript = null;

            // 버튼도 숨기고 정보 레이블도 초기화합니다.

            m_lblInfo.text = string.Empty;

            m_gObjSellButton.SetActive(false);

            // 다시 정렬을 해줍시다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            // 확인 위해 로그찍어보아요

            Debug.Log("현재 금액0 : " + LobbySceneBtnScript.Instance().myGold.ToString());

            blackSkill = false;
            DeleteItem();
            LobbySceneBtnScript.Instance().haveBlackSkill.text = "0";
        }
        /*-----스킬------*/
    }




    public void EquipItem()
    {
        m_gObjSellButton.SetActive(false);
        m_lblInfo.text = string.Empty;
        //무기
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[0])
        {
            m_lItems.Find(x => x.name == m_lItemNames[0]).gameObject.SetActive(false);
            if(m_lItems.Find(x => x.name == m_lItemNames[1]) != null )
            {
                m_lItems.Find(x => x.name == m_lItemNames[1]).gameObject.SetActive(true);
            }
            if(m_lItems.Find(x => x.name == m_lItemNames[2]) != null )
            {
                m_lItems.Find(x => x.name == m_lItemNames[2]).gameObject.SetActive(true);
            }
            if(m_lItems.Find(x => x.name == m_lItemNames[3]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[3]).gameObject.SetActive(true);
            }
            redArrowSlot.SetActive(true);
       
            blueArrowSlot.SetActive(false);
            whiteArrowSlot.SetActive(false);
            blackArrowSlot.SetActive(false);
            m_grid.enabled =true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[1])
        {
            m_lItems.Find(x => x.name == m_lItemNames[1]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[0]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[0]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[2]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[2]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[3]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[3]).gameObject.SetActive(true);
            }
            blueArrowSlot.SetActive(true);      
            whiteArrowSlot.SetActive(false);
            blackArrowSlot.SetActive(false);
            redArrowSlot.SetActive(false);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[2])
        {
            m_lItems.Find(x => x.name == m_lItemNames[2]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[1]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[1]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[0]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[0]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[3]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[3]).gameObject.SetActive(true);
            }
            whiteArrowSlot.SetActive(true);       
            redArrowSlot.SetActive(false);
            blueArrowSlot.SetActive(false);
            blackArrowSlot.SetActive(false);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[3])
        {
            m_lItems.Find(x => x.name == m_lItemNames[3]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[1]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[1]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[2]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[2]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[0]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[0]).gameObject.SetActive(true);
            }
            blackArrowSlot.SetActive(true);        
            redArrowSlot.SetActive(false);
            blueArrowSlot.SetActive(false);
            whiteArrowSlot.SetActive(false);
            m_grid.enabled = true;
        }
        //무기

        //방어구
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[4])
        {
            m_lItems.Find(x => x.name == m_lItemNames[4]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[5]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[5]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[6]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[6]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[7]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[7]).gameObject.SetActive(true);
            }
            redArmorSlot.SetActive(true);
            blueArmorSlot.SetActive(false);
            whiteArmorSlot.SetActive(false);
            blackArmorSlot.SetActive(false);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[5])
        {
            m_lItems.Find(x => x.name == m_lItemNames[5]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[4]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[4]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[6]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[6]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[7]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[7]).gameObject.SetActive(true);
            }
            redArmorSlot.SetActive(false);
            blueArmorSlot.SetActive(true);
            whiteArmorSlot.SetActive(false);
            blackArmorSlot.SetActive(false);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[6])
        {
            m_lItems.Find(x => x.name == m_lItemNames[6]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[5]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[5]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[4]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[4]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[7]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[7]).gameObject.SetActive(true);
            }
            redArmorSlot.SetActive(false);
            blueArmorSlot.SetActive(false);
            whiteArmorSlot.SetActive(true);
            blackArmorSlot.SetActive(false);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[7])
        {
            m_lItems.Find(x => x.name == m_lItemNames[7]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[5]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[5]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[6]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[6]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[4]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[4]).gameObject.SetActive(true);
            }
            redArmorSlot.SetActive(false);
            blueArmorSlot.SetActive(false);
            whiteArmorSlot.SetActive(false);
            blackArmorSlot.SetActive(true);
            m_grid.enabled = true;
        }
        //방어구

        //스킬
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[8])
        {
            m_lItems.Find(x => x.name == m_lItemNames[8]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[9]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[9]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[10]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[10]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[11]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[11]).gameObject.SetActive(true);
            }
            redSkillSlot.SetActive(true);
            blueSkillSlot.SetActive(false);
            whiteSkillSlot.SetActive(false);
            blackSkillSlot.SetActive(false);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[9])
        {
            m_lItems.Find(x => x.name == m_lItemNames[9]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[8]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[8]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[10]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[10]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[11]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[11]).gameObject.SetActive(true);
            }
            redSkillSlot.SetActive(false);
            blueSkillSlot.SetActive(true);
            whiteSkillSlot.SetActive(false);
            blackSkillSlot.SetActive(false);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[10])
        {
            m_lItems.Find(x => x.name == m_lItemNames[10]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[9]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[9]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[8]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[8]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[11]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[11]).gameObject.SetActive(true);
            }
            redSkillSlot.SetActive(false);
            blueSkillSlot.SetActive(false);
            whiteSkillSlot.SetActive(true);
            blackSkillSlot.SetActive(false);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_lItemNames[11])
        {
            m_lItems.Find(x => x.name == m_lItemNames[11]).gameObject.SetActive(false);
            if (m_lItems.Find(x => x.name == m_lItemNames[9]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[9]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[10]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[10]).gameObject.SetActive(true);
            }
            if (m_lItems.Find(x => x.name == m_lItemNames[8]) != null)
            {
                m_lItems.Find(x => x.name == m_lItemNames[8]).gameObject.SetActive(true);
            }
            redSkillSlot.SetActive(false);
            blueSkillSlot.SetActive(false);
            whiteSkillSlot.SetActive(false);
            blackSkillSlot.SetActive(true);
            m_grid.enabled = true;
        }


        //아이템 변경 및 장착시 수치 변경

        // 무기
        //1
        if (redArrowSlot.activeSelf == true && redAbool == false)
        {
            redAbool = true;
            LobbySceneBtnScript.Instance().basicDamage += m_lItemValue[0];
        }
        if (redArrowSlot.activeSelf == false && redAbool == true)
        {
            redAbool = false;
            LobbySceneBtnScript.Instance().basicDamage -= m_lItemValue[0];
        }
        //1

        //2
        if (blueArrowSlot.activeSelf == true && blueAbool == false)
        {
            blueAbool = true;
            LobbySceneBtnScript.Instance().basicDamage += m_lItemValue[1];
        }
        if (blueArrowSlot.activeSelf == false && blueAbool == true)
        {
            blueAbool = false;
            LobbySceneBtnScript.Instance().basicDamage -= m_lItemValue[1];
        }
        //2

        //3
        if (whiteArrowSlot.activeSelf == true && whiteAbool == false)
        {
            whiteAbool = true;
            LobbySceneBtnScript.Instance().basicDamage += m_lItemValue[2];
        }
        if (whiteArrowSlot.activeSelf == false && whiteAbool == true)
        {
            whiteAbool = false;
            LobbySceneBtnScript.Instance().basicDamage -= m_lItemValue[2];
        }
        //3

        //4
        if (blackArrowSlot.activeSelf == true && blackAbool == false)
        {
            blackAbool = true;
            LobbySceneBtnScript.Instance().basicDamage += m_lItemValue[3];
        }
        if (blackArrowSlot.activeSelf == false && blackAbool == true)
        {
            blackAbool = false;
            LobbySceneBtnScript.Instance().basicDamage -= m_lItemValue[3];
        }
        //4


        //방어구
        //1
        if (redArmorSlot.activeSelf == true && redMbool == false)
        {
            redMbool = true;
            LobbySceneBtnScript.Instance().playerMaxHp += m_lItemValue[4];
        }
        if (redArmorSlot.activeSelf == false && redMbool == true)
        {
            redMbool = false;
            LobbySceneBtnScript.Instance().playerMaxHp -= m_lItemValue[4];
        }
        //1

        //2
        if (blueArmorSlot.activeSelf == true && blueMbool == false)
        {
            blueMbool = true;
            LobbySceneBtnScript.Instance().playerMaxHp += m_lItemValue[5];
        }
        if (blueArmorSlot.activeSelf == false && blueMbool == true)
        {
            blueMbool = false;
            LobbySceneBtnScript.Instance().playerMaxHp -= m_lItemValue[5];
        }
        //2

        //3
        if (whiteArmorSlot.activeSelf == true && whiteMbool == false)
        {
            whiteMbool = true;
            LobbySceneBtnScript.Instance().playerMaxHp += m_lItemValue[6];
        }
        if (whiteArmorSlot.activeSelf == false && whiteMbool == true)
        {
            whiteMbool = false;
            LobbySceneBtnScript.Instance().playerMaxHp -= m_lItemValue[6];
        }
        //3

        //4
        if (blackArmorSlot.activeSelf == true && blackMbool == false)
        {
            blackMbool = true;
            LobbySceneBtnScript.Instance().playerMaxHp += m_lItemValue[7];
        }
        if (blackArmorSlot.activeSelf == false && blackMbool == true)
        {
            blackMbool = false;
            LobbySceneBtnScript.Instance().playerMaxHp -= m_lItemValue[7];
        }
        //4


        //스킬
        //1
        if (redSkillSlot.activeSelf == true && redSbool == false)
        {
            redSbool = true;
            LobbySceneBtnScript.Instance().chargeDamage += m_lItemValue[8];
        }
        if (redSkillSlot.activeSelf == false && redSbool == true)
        {
            redSbool = false;
            LobbySceneBtnScript.Instance().chargeDamage -= m_lItemValue[8];
        }
        //1

        //2
        if (blueSkillSlot.activeSelf == true && blueSbool == false)
        {
            blueSbool = true;
            LobbySceneBtnScript.Instance().chargeDamage += m_lItemValue[9];
        }
        if (blueSkillSlot.activeSelf == false && blueSbool == true)
        {
            blueSbool = false;
            LobbySceneBtnScript.Instance().chargeDamage -= m_lItemValue[9];
        }
        //2

        //3
        if (whiteSkillSlot.activeSelf == true && whiteSbool == false)
        {
            whiteSbool = true;
            LobbySceneBtnScript.Instance().chargeDamage += m_lItemValue[10];
        }
        if (whiteSkillSlot.activeSelf == false && whiteSbool == true)
        {
            whiteSbool = false;
            LobbySceneBtnScript.Instance().chargeDamage -= m_lItemValue[10];
        }
        //3

        //4
        if (blackSkillSlot.activeSelf == true && blackSbool == false)
        {
            blackSbool = true;
            LobbySceneBtnScript.Instance().chargeDamage += m_lItemValue[11];
        }
        if (blackSkillSlot.activeSelf == false && blackSbool == true)
        {
            blackSbool = false;
            LobbySceneBtnScript.Instance().chargeDamage -= m_lItemValue[11];
        }
        //4
    }


    public void TakeOffItem()
    {
        //무기
        if (m_cCurScript.m_sprIcon.name ==  m_slotitem[0].name)
        {
            redArrowSlot.SetActive(false);
            if (redArrowSlot.activeSelf == false && redAbool == true)
            {
                redAbool = false;
                LobbySceneBtnScript.Instance().basicDamage -= m_lItemValue[0];
            }
            m_lItems.Find(x => x.name == m_lItemNames[0]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[1].name)
        {
            blueArrowSlot.SetActive(false);
            if (blueArrowSlot.activeSelf == false && blueAbool == true)
            {
                blueAbool = false;
                LobbySceneBtnScript.Instance().basicDamage -= m_lItemValue[1];
            }
            m_lItems.Find(x => x.name == m_lItemNames[1]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[2].name)
        {
            whiteArrowSlot.SetActive(false);
            if (whiteArrowSlot.activeSelf == false && whiteAbool == true)
            {
                whiteAbool = false;
                LobbySceneBtnScript.Instance().basicDamage -= m_lItemValue[2];
            }
            m_lItems.Find(x => x.name == m_lItemNames[2]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[3].name)
        {
            blackArrowSlot.SetActive(false);
            if (blackArrowSlot.activeSelf == false && blackAbool == true)
            {
                blackAbool = false;
                LobbySceneBtnScript.Instance().basicDamage -= m_lItemValue[3];
            }
            m_lItems.Find(x => x.name == m_lItemNames[3]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        //무기


        //방어구
        if (m_cCurScript.m_sprIcon.name == m_slotitem[4].name)
        {
            redArmorSlot.SetActive(false);
            if (redArmorSlot.activeSelf == false && redMbool == true)
            {
                redMbool = false;
                LobbySceneBtnScript.Instance().playerMaxHp -= m_lItemValue[4];
            }
            m_lItems.Find(x => x.name == m_lItemNames[4]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[5].name)
        {
            blueArmorSlot.SetActive(false);
            if (blueArmorSlot.activeSelf == false && blueMbool == true)
            {
                blueMbool = false;
                LobbySceneBtnScript.Instance().playerMaxHp -= m_lItemValue[5];
            }
            m_lItems.Find(x => x.name == m_lItemNames[5]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[6].name)
        {
            whiteArmorSlot.SetActive(false);
            if (whiteArmorSlot.activeSelf == false && whiteMbool == true)
            {
                whiteMbool = false;
                LobbySceneBtnScript.Instance().playerMaxHp -= m_lItemValue[6];
            }
            m_lItems.Find(x => x.name == m_lItemNames[6]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[7].name)
        {
            blackArmorSlot.SetActive(false);
            if (blackArmorSlot.activeSelf == false && blackMbool == true)
            {
                blackMbool = false;
                LobbySceneBtnScript.Instance().playerMaxHp -= m_lItemValue[7];
            }
            m_lItems.Find(x => x.name == m_lItemNames[7]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        //방어구


        //스킬
        if (m_cCurScript.m_sprIcon.name == m_slotitem[8].name)
        {
            redSkillSlot.SetActive(false);
            if (redSkillSlot.activeSelf == false && redSbool == true)
            {
                redSbool = false;
                LobbySceneBtnScript.Instance().chargeDamage -= m_lItemValue[8];
            }
            m_lItems.Find(x => x.name == m_lItemNames[8]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[9].name)
        {
            blueSkillSlot.SetActive(false);
            if (blueSkillSlot.activeSelf == false && blueSbool == true)
            {
                blueSbool = false;
                LobbySceneBtnScript.Instance().chargeDamage -= m_lItemValue[9];
            }
            m_lItems.Find(x => x.name == m_lItemNames[9]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[10].name)
        {
            whiteSkillSlot.SetActive(false);
            if (whiteSkillSlot.activeSelf == false && whiteSbool == true)
            {
                whiteSbool = false;
                LobbySceneBtnScript.Instance().chargeDamage -= m_lItemValue[10];
            }
            m_lItems.Find(x => x.name == m_lItemNames[10]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        if (m_cCurScript.m_sprIcon.name == m_slotitem[11].name)
        {
            blackSkillSlot.SetActive(false);
            if (blackSkillSlot.activeSelf == false && blackSbool == true)
            {
                blackSbool = false;
                LobbySceneBtnScript.Instance().chargeDamage -= m_lItemValue[11];
            }
            m_lItems.Find(x => x.name == m_lItemNames[11]).gameObject.SetActive(true);
            m_grid.enabled = true;
        }
        //스킬
    }


    // 이 게임 오브젝트가 파괴될 때 생성했던 아이템도 삭제해줍시다.

    // 메모리 정리라고 생각하세요.

    private void OnDestroy()

    {

        for (int nIndex = 0; nIndex < m_lItems.Count; nIndex++)

        {

            // 혹시 모르니까 null이 아닐 때에만 삭제하도록 해요.

            if (m_lItems[nIndex] != null && m_lItems[nIndex].gameObject != null)

                Destroy(m_lItems[nIndex].gameObject);

        }



        m_lItems.Clear();

        m_lItems = null;



        m_lItemNames.Clear();

        m_lItemNames = null;

        m_cCurScript = null;

    }

}
