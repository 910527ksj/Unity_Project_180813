using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class JsonExample : MonoBehaviour {

    public TextAsset jsonData;


	void Start ()
    {
        var DATA = JSON.Parse(jsonData.text);

        for (int i = 0; i < DATA.Count; i++)
        {
            Debug.Log(DATA[i]["Unit"]);
        }
	}
	
	

	void Update () {
		
	}
}
