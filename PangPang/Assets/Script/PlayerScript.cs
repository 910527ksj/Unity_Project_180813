using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float playerSpeed;
    public Animator playerAnim;
    public GameObject firePos;
    public GameObject bullet;
    public float shotDelay;
    public float shotCool;
    public float limtX;
    public float playerHp;


    void Start()
    {
        shotDelay = 0;
    }



    void Update ()
    {
        shotDelay += Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Animator>().Play("left");
            transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
        }       
        else
        {
            playerAnim.SetBool("Left Bool", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Animator>().Play("right");
            transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
        }
        else
        {
            playerAnim.SetBool("Right Bool", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            shotDelay += Time.deltaTime;
            if (gameObject.transform.position.x < 0)
            {
                playerAnim.SetBool("Left Bool", true);
                if (shotDelay > shotCool)
                {
                    Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                    shotDelay = 0;
                }
            }            
            if (gameObject.transform.position.x >= 0)
            {
                playerAnim.SetBool("Right Bool", true);
                if (shotDelay > shotCool)
                {
                    Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                    shotDelay = 0;
                }                
            }            
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow))
        {
            GetComponent<Animator>().Play("right");
            if (shotDelay > shotCool)
            {
                Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                shotDelay = 0;
            }
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Animator>().Play("left");
            if (shotDelay > shotCool)
            {
                Instantiate(bullet, firePos.transform.position, firePos.transform.rotation);
                shotDelay = 0;
            }
        }
        if (transform.position.x > limtX)
        {
            transform.position = new Vector3(limtX, transform.position.y, transform.position.z);
        }
        if (transform.position.x < -limtX)
        {
            transform.position = new Vector3(-limtX, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Enemy"  )
        {
            playerHp -= 1;
        }
    }
}
