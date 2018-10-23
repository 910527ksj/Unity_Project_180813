using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    public float playerSpeed;
    public Animator playerAnim;
    public GameObject firePos;
    //public GameObject bullet;
    public float shotDelay;
    public float shotCool;
    public float limtX;
    public float playerHp;
    public float playerMaxHp;
    public UIProgressBar hpBar;

    public bool isUnBeatTime;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb2D;

    public bool AttackedVelocityTime;
    public float timeA;
    public float timeB = 0.1f;

    void Start()
    {
        shotDelay = 1;
    }



    void Update ()
    {
        shotDelay += Time.deltaTime;

        playerMaxHp = playerHp / 5; // hp,max 만든 다음 -> ( /5 ) = hp수치를 써주면 됌. 프로그레스바 벨류가 1이므로 비율을 맞추기위해 나누기5 해줌
        hpBar.value = playerMaxHp;

        PlayerMoveLimit();

        //if (transform.position.y < -2.5f) 
        //// 플레이어 높이 제한 ( 맨위에 둬야는 이유는 함수로 사용 안할 시 업데이트는 순서대로 돌아가므로 자 객체인 firepos의 월드포지션이 계속 내려감 
        //{
        //    transform.position = new Vector2(transform.position.x, -2.5f);
        //}

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



        if (Input.GetKey(KeyCode.Space)) // 이 밑 로직들은 제자리 공격시 캐릭터 x값에 따라 다른 모션을 취하기 위한 로직
        {
                //ArrowFire(); // 발사 함수 불러오기
                //*firePos.GetComponent<FireScript>().Fire(); //  fireScript에서 fire 함수 불러오기
                if (gameObject.transform.position.x < 0)
                {
                    playerAnim.SetBool("Left Bool", true);
                    if (shotDelay > shotCool)
                    {
                        firePos.GetComponent<FireScript>().Fire();
                        shotDelay = 0;
                    }
                }
                if (gameObject.transform.position.x >= 0)
                {
                    playerAnim.SetBool("Right Bool", true);
                    if (shotDelay > shotCool)
                    {
                        firePos.GetComponent<FireScript>().Fire();
                        shotDelay = 0;
                    }
                }
        }                  

        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow)) // 이 밑 로직들은 캐릭터 좌,우 이동시 기존 모션과 반대로 공격모션 취하기 위한 로직
        {
            GetComponent<Animator>().Play("right");
            if (shotDelay > shotCool)
            {
                firePos.GetComponent<FireScript>().Fire();
                shotDelay = 0;
            }
        }
        if (Input.GetKey(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow))
        {
            GetComponent<Animator>().Play("left");
            if (shotDelay > shotCool)
            {
                firePos.GetComponent<FireScript>().Fire();
                shotDelay = 0;
            }
        }



        //if (transform.position.x > limtX) // 좌,우 이동 제한
        //{
        //    transform.position = new Vector2(limtX, transform.position.y);
        //}

        //if (transform.position.x < -limtX)
        //{
        //    transform.position = new Vector2(-limtX, transform.position.y);
        //}



        //Debug.Log(firePos.transform.position);
        if (AttackedVelocityTime == true) // 몬스터에게 넉백 당하고 멈추기 위한 bool
        {
            timeA += Time.deltaTime;
            if (timeA > timeB)
            {
                timeA = 0;
                AttackedVelocityTime = false;
            }
            if (AttackedVelocityTime == false)
            {
                //Debug.Log("2");
                rb2D.velocity = new Vector2(0, 0);
            }
        }
    }

    void PlayerMoveLimit() // 이동제한 함수
    {
        if (transform.position.y < -2.5f)
        {
            transform.position = new Vector2(transform.position.x, -2.5f);
        }

        if (transform.position.x > limtX)
        {
            transform.position = new Vector2(limtX, transform.position.y);
        }

        if (transform.position.x < -limtX)
        {
            transform.position = new Vector2(-limtX, transform.position.y);
        }
    }

    //void ArrowFire() // 발사 함수
    //{
    //    GameObject arrow = Instantiate(bullet) as GameObject;
    //    arrow.transform.position = firePos.transform.position;
    //    Debug.Log(arrow.transform.position);
    //}

    IEnumerator UnBeatTime() // 코루틴 - 깜박임(무적처럼 보이게하기 위한) 효과
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
        if (other.tag == "Enemy" && !isUnBeatTime)
        // 코루틴 false, 적과 부딪혔을시 ( 코루틴 실행시 hp 안닳게 하기위해 && ! 사용)
        {
            playerHp -= 1;
            if (playerHp >= 1)
            {
                isUnBeatTime = true;
                StartCoroutine("UnBeatTime");
            }
            AttackedVelocityTime = true;
            if (AttackedVelocityTime == true)
            {
                //Vector2 attackVel = Vector2.zero;
                //Debug.Log("1");
                if (other.gameObject.transform.position.x > transform.position.x) // 밀림 효과
                {
                    rb2D.velocity = new Vector2(-10f, 5f);
                }
                else
                {
                    rb2D.velocity = new Vector2(10f, 5f);
                }
                //{
                //    attackVel = new Vector2(-10f, 5f);
                //}
                //else
                //{
                //    attackVel = new Vector2(10f, 5f);
                //}
                //rb2D.AddForce(attackVel, ForceMode2D.Impulse);
            }
        }
    }
}
