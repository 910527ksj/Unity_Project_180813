using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManagerScript : MonoBehaviour {

    static InventoryManagerScript _instance;
    public static InventoryManagerScript Instance()
    {
        return _instance;
    }

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

   
    void Start ()
    {
        if (_instance == null)
        {
            _instance = this;
        }
    }
	
	
	void Update ()
    {
		
	}
}
