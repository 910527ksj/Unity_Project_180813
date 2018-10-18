using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float playerSpeed;
    public Animator playerAnim;

    void Start ()
    {
		
	}
	

	
	void Update ()
    {
		if(Input.GetKey(KeyCode.LeftArrow))
        {
            playerAnim.SetBool("Left Bool",true);
            playerAnim.SetFloat("Left Float", 1);
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            playerAnim.SetBool("Left Bool", false);

        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            playerAnim.SetBool("Right Bool", true);
            playerAnim.SetFloat("Right Float", 1);
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            playerAnim.SetBool("Right Bool", false);

        }
    }
}
