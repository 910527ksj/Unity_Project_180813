using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour {
    // ItemManager는 Singleton으로 만들어 어디에서든 접근 가능하게!

    private static ItemManager m_pInstance;



    private static object m_pLock = new object();



    public static ItemManager INSTANCE

    {

        get

        {

            lock (m_pLock)

            {

                if (m_pInstance == null)

                {

                    m_pInstance = (ItemManager)FindObjectOfType(typeof(ItemManager));



                    if (FindObjectsOfType(typeof(ItemManager)).Length > 1)

                    {

                        return m_pInstance;

                    }



                    if (m_pInstance == null)

                    {

                        GameObject singleton = new GameObject();

                        m_pInstance = singleton.AddComponent<ItemManager>();

                        singleton.name = typeof(ItemManager).ToString();



                        DontDestroyOnLoad(singleton);

                    }

                }

            }



            return m_pInstance;

        }

    }



    // 파싱한 정보를 다 저장할꺼에요.

    Dictionary<int, ItemInfo> m_dicData = new Dictionary<int, ItemInfo>();

    // 아이템 추가.

    public void AddItem(ItemInfo _cInfo)

    {

        // 아이템은 고유해야 되니까, 먼저 체크!

        if (m_dicData.ContainsKey(_cInfo.ID)) return;



        // 이제 아이템을 추가.

        m_dicData.Add(_cInfo.ID, _cInfo);

    }

    // 하나의 아이템 얻기

    public ItemInfo GetItem(int _nID)

    {

        // 있는지 체크 해야겠죠?

        if (m_dicData.ContainsKey(_nID))

            return m_dicData[_nID];



        // 없으면 null 리턴!

        return null;

    }

    // 전체 리스트 얻기

    public Dictionary<int, ItemInfo> GetAllItems()

    {

        return m_dicData;

    }

    // 전체 갯수 얻기

    public int GetItemsCount()

    {

        return m_dicData.Count;

    }

}



public class ItemInfo

{

    private int m_nID;

    private string m_strName;

    private string m_strIcon;

    private int m_nBuyGoldCost;

    private int m_nBuyGemCost;

    private int m_nSellCost;



    public int ID

    {

        set { m_nID = value; }

        get { return m_nID; }

    }

    public string NAME

    {

        set { m_strName = value; }

        get { return m_strName; }

    }

    public string ICON

    {

        set { m_strIcon = value; }

        get { return m_strIcon; }

    }

    public int BUY_GOLDCOST

    {

        set { m_nBuyGoldCost = value; }

        get { return m_nBuyGoldCost; }

    }

    public int BUY_GEMCOST

    {

        set { m_nBuyGemCost = value; }

        get { return m_nBuyGemCost; }

    }

    public int SELL_COST

    {

        set { m_nSellCost = value; }

        get { return m_nSellCost; }

    }

}
