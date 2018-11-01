using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScript : MonoBehaviour {

    
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            //Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
            //transform.Translate(0, touchDeltaPosition.y * Time.deltaTime, 0);
            Application.LoadLevel("Lobby");
        }
        //if(Input.GetMouseButtonDown(0))
        //{
        //    Application.LoadLevel("Lobby");
        //}
    }
}
