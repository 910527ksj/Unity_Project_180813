using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// 

/// Item 클래스. 
/// 각 아이템은 이 클래스를 가지고 있습니다.
/// 
public class ItemScript : MonoBehaviour
{
    static ItemScript _instance;
    public static ItemScript Instance()
    {
        return _instance;
    }

    // 아이템 이름. 구분 짓기 위해 만들어요.
    public string m_strName;

    // 아이콘을 표시할 스프라이트 이름입니다.
    private string m_strSpriteName;

    // 아이콘을 표시하는 Sprite 클래스 입니다.
    // 여기에 아이템 아이콘 이미지 세팅 할꺼에요.
    public UISprite m_sprIcon;



    // 선택 프레임을 표시할 스프라이트에요.

    public UISprite m_sprFrame;

    // 장착 표시

    public GameObject m_equipLabel;

    // Inventory 부모도 가지고 있겠습니다.

    // 선택하면 부모에게 알리고 다른 아이들은 선택을 하지 않도록 할꺼에요.

    public InventoryManagerScript m_cParent;



    // 아이템 정보 클래스를 여기에 두도록 해요.

    //private ItemInfo m_Item;    

    // 외부에서 접근하기위해 public으로 바꾸겠습니다.(연습이니까 이렇게해요 ㅎㅎ)

    public ItemInfo m_Item;

    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }

    void Start()
    {
        // 최초 선택은 되지 않을것이므로, 선택 프레임 이미지를 disable 합니다.

        //m_sprFrame.enabled = false;   // <= 이렇게 하셔도 됩니다.

        m_sprFrame.gameObject.SetActive(false); // 저는 게임 오브젝트를 끄도록 하겠습니다.
    }

    void Update()
    {

    }

    // 내가 선택되었는지 판별하여 선택 프레임을 활성/비활성 합니다.

    public void SetSelected(bool bSelected)

    {

        // 선택 여부에 따라 조절합니다.

        m_sprFrame.gameObject.SetActive(bSelected);

        // 이렇게 하셔도 됩니다.

        //m_sprFrame.enabled = bSelected;

    }


    // 정보를 설정하는 함수 입니다.
    public void SettingInfo(string spriteName)
    {
        // 같은 아틀라스에 있으니 스프라이트 이름 찾아 넣어주면 이미지가 바껴요.
        m_sprIcon.spriteName = spriteName;
        gameObject.name = spriteName;
        // 이름도 설정 합시다.(확인 위해 이름설정하는거)
        m_strName = spriteName;
    }





    // 터치 하면 발생하는 이벤트입니다.
    // 전에 Button을 썼지만 OnClick으로 사용하겠습니다.
    // OnClick은 NGUI에서 제공하는 함수로 터치하면 발생됩니다.
    void OnClick()
    {
        // 확인 위해 로그 찍어봅니다.
        Debug.Log(m_strName + " 이 클릭되었습니다.");

        // 부모에게 내가 선택 되었다고 알립니다.


        //InventoryManagerScript 함수
        m_cParent.SelectItem(this);     // 이 함수는 조금 후에 만들꺼에요. 우선 이렇게 작성.

    }
}