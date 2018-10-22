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
    public bool isUnBeatTime;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb2D;
    bool AttackedVelocityTime()
    {
        if (true)
        {
            float countTime = 0;
            countTime += Time.deltaTime;
        }
        if (false)
        {
            float countTime = 0;
        }
    }

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
        //if (transform.position.y < -2.5f)
        //{
        //    transform.position = new Vector3(transform.position.x, -2.5f, -0.1f);
        //}
    }

    IEnumerator UnBeatTime()
    {
        int countTime = 0;

        while (countTime < 10)
        {
            if (countTime % 2 == 0)
            {
                spriteRenderer.color = new Color32(255, 255, 255, 90);
            }
            else
            {
                spriteRenderer.color = new Color32(255, 255, 255, 180);
            }

            yield return new WaitForSeconds(0.2f);

            countTime++;
        }
        spriteRenderer.color = new Color32(255, 255, 255, 255);

        isUnBeatTime = false;

        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Enemy"  )
        {                        
            Vector2 attackedVelocity = Vector2.zero;
            if (other.gameObject.transform.position.x > transform.position.x)
            {                                              
                attackedVelocity = new Vector2(-2, 0);                
                if (countTime == 2)
                {
                    attackedVelocity = new Vector2(0, 0);
                    countTime = 0;
                }
            }
            else
            {
                attackedVelocity = new Vector2(2f,0);
            }
            rb2D.AddForce(attackedVelocity, ForceMode2D.Impulse);
            playerHp -= 1;            
            isUnBeatTime = true;
            StartCoroutine("UnBeatTime");
        }
    }
}
