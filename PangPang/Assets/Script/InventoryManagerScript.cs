using System.Collections;
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

    private List<string> m_lItemNames = new List<string>();

    // 새로 만들어진 아이템들을 모아둡니다.(삭제 및 수정 등을 하기위해서)

    public List<ItemScript> m_lItems = new List<ItemScript>();

    // 우리가 만든 SampleItem을 복사해서 만들기 위해 선언합니다.

    public GameObject m_gObjArrowSampleItem;
    public GameObject m_gObjArmorSampleItem;
    public GameObject m_gObjSkillSampleItem;

    // 스크롤뷰를 reposition 하기위해 선언합니다.

    //public UIScrollView m_scrollView;

    // 그리드를 reset position 하기위해 선언합니다.

    public UIGrid m_grid;



    // Use this for initialization

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        InitItems();
    }

    void Update()
    {
        AddItem();
        DeleteItem();
    }

    private void InitItems()
    {
        var itemDATA = JSON.Parse(jsonItemData.text); //json 선언       
        m_lItemNames.Add(itemDATA[5]["Icon"]);
        m_lItemNames.Add(itemDATA[6]["Icon"]);
        m_lItemNames.Add(itemDATA[7]["Icon"]);
        m_lItemNames.Add(itemDATA[8]["Icon"]);
        m_lItemNames.Add(itemDATA[10]["Icon"]);
        m_lItemNames.Add(itemDATA[11]["Icon"]);
        m_lItemNames.Add(itemDATA[12]["Icon"]);
        m_lItemNames.Add(itemDATA[13]["Icon"]);
        m_lItemNames.Add(itemDATA[15]["Icon"]);
        m_lItemNames.Add(itemDATA[16]["Icon"]);
        m_lItemNames.Add(itemDATA[17]["Icon"]);
        m_lItemNames.Add(itemDATA[18]["Icon"]);
    }



    // 키를 누르면 아이템을 화면에 보여주는 역할을 합니다.

    // 여기에서 가장 중요한 역할을 하는 함수죠.

    private void AddItem()
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



    // 하나 랜덤으로 삭제합니다.

    private void DeleteItem()
    {
        if (redArrow == false && redArrowItemEa == 1 )
        {
            //// 만든 아이템이 없으면 안되겠죠?

            //if (m_lItems.Count == 0) return;

            //// 지울꺼 랜덤으로 찾고.

            //int nRandomIndex = Random.Range(0, m_lItems.Count);

            // 게임오브젝트 없애줍니다.

            // 여기에서는 DestroyImmediate를 사용합니다. 지우고 바로 갱신을 해야하니까요.

            // 나중에 천천히 설명하겠습니다.

            DestroyImmediate(m_lItems[0].gameObject);

            // 리스트에서도 지워줍시다.

            m_lItems.RemoveAt(0);

            // 그리고 그리드와 스크롤뷰 재정렬 시켜줍니다.

            m_grid.Reposition();

            //m_scrollView.ResetPosition();

            redArrowItemEa -= 1;
        }
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

    }

}
