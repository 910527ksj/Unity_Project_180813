using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    static PlayerScript _instance;
    public static PlayerScript Instance()
    {
        return _instance;
    }

    public float playerSpeed;
    public float limtX;
    public Animator playerAnim;
    public GameObject firePos;
    //public GameObject bullet;

    public float shotDelay;
    public float shotCool;
    public float curShotCool;
    public UIProgressBar shotBar;
    public UILabel shotCoolLabel;

    public float playerHp;  // 맥스와함께 float으로 해줘야 hp바의 프로그레스바 value가 소수점 단위로 움직임
    public float playerMaxHp;
    public float curPlayerHp;
    public UIProgressBar hpBar;
    public UILabel hpLabel;

    public GameObject dieEffect;

    public bool isUnBeatTime;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rb2D;

    public bool AttackedVelocityTime;
    public float timeA;
    public float timeB = 0.1f;

    //public bool attackTouch;

    public GameObject winPopUp;
    public GameObject losePopUp;
    public GameObject pausePopUpCheck;
    public GameObject exitLobbyCheck;

    public float chargeGage;
    public float chargeMax;
    public float curCharge;
    public bool chargeGageBool;
    public GameObject chargeEffect;
    public UIProgressBar chargeBar;

    public UILabel haveGold;
    public UILabel haveGem;
    public UILabel havePotion;

    int score = 10;
    int scoreBest;
    public UILabel bestScore;
    public UILabel nowSocer;

    public int winItemEA;

    void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        //shotDelay = 1;
        playerHp = LobbySceneBtnScript.Instance().playerMaxHp; // 인스턴스와 같다고 해줘야 업그레이드시 정보 넘어옴
        playerMaxHp = LobbySceneBtnScript.Instance().playerMaxHp;
        if(Application.loadedLevelName == "Stage_01")
        {
            winItemEA = 8;
        }
    }



    void Update ()
    {
        ShotDelay();

        curPlayerHp = playerHp / playerMaxHp; // hp,max 만든 다음 -> ( /5(playerMaxHp) ) = hp수치를 써주면 됌. 프로그레스바 벨류가 1이므로 비율을 맞추기위해 나누기5 해줌
        hpBar.value = curPlayerHp;

        ChargeGageBar(); // 업데이트가 길면 안되므로 함수로 만들어서 적으면 정상 작동 함

        PlayerMoveLimit(); // 업데이트가 길면 안되므로 함수로 만들어서 적으면 정상 작동 함

        hpLabel.text = "HP  :  " + playerHp.ToString();

        haveGem.text = LobbySceneBtnScript.Instance().myGem.ToString();
        haveGold.text = LobbySceneBtnScript.Instance().myGold.ToString();
        havePotion.text = LobbySceneBtnScript.Instance().myPotion.ToString();

        //nowSocer.text = "Score  :  "  + LobbySceneBtnScript.Instance().myScore.ToString();
        //bestScore.text = "3rd Score  :  " +  LobbySceneBtnScript.Instance().thirdScore.ToString();
        //bestScore.text = scoreBest.ToString();

        //if (scoreBest > LobbySceneBtnScript.Instance().thirdScore)
        //{
        //    bestScore.text = "2nd Score  :  " + LobbySceneBtnScript.Instance().secondScore.ToString();
        //}

        //if (scoreBest > LobbySceneBtnScript.Instance().secondScore)
        //{
        //    bestScore.text = "1st Score  :  " + LobbySceneBtnScript.Instance().bestScore.ToString();
        //}

        if (chargeEffect.activeSelf == true)
        { 
            chargeGage += Time.deltaTime;
            if (chargeGage > chargeMax)
            {
                chargeGage = chargeMax;
                if (chargeGage == chargeMax)
                {
                    chargeGageBool = true;
                }
            }
        }

        //if (transform.position.y < -2.5f) 
        //// 플레이어 높이 제한 ( 맨위에 둬야는 이유는 함수로 사용 안할 시 업데이트는 순서대로 돌아가므로 자 객체인 firepos의 월드포지션이 계속 내려감 
        //{
        //    transform.position = new Vector2(transform.position.x, -2.5f);
        //}
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
            {
                Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                transform.Translate(touchDeltaPosition.x * Time.deltaTime, 0, 0);
                if (gameObject.transform.position.x < 0)
                {
                    GetComponent<Animator>().Play("left");
                }
                if (gameObject.transform.position.x >= 0)
                {
                    GetComponent<Animator>().Play("right");
                }
            }
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
            {
                GetComponent<Animator>().Play("left");
                transform.Translate(-playerSpeed * Time.deltaTime, 0, 0);
            }
        }       
        else
        {
            playerAnim.SetBool("Left Bool", false);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
            {
                GetComponent<Animator>().Play("right");
                transform.Translate(playerSpeed * Time.deltaTime, 0, 0);
            }
        }
        else
        {
            playerAnim.SetBool("Right Bool", false);
        }



        if (Input.GetKeyDown(KeyCode.Space) ) // 이 밑 로직들은 제자리 공격시 캐릭터 x값에 따라 다른 모션을 취하기 위한 로직
        {
            if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
            {
                //ArrowFire(); // 발사 함수 불러오기
                //*firePos.GetComponent<FireScript>().Fire(); //  fireScript에서 fire 함수 불러오기
                if (gameObject.transform.position.x < 0)
                {
                    playerAnim.SetBool("Left Bool", true);
                    if (shotDelay <= 0)
                    {
                        firePos.GetComponent<FireScript>().Fire(); //  fireScript에서 fire 함수 불러오기
                        shotDelay = shotCool;
                    }
                }
                if (gameObject.transform.position.x >= 0)
                {
                    playerAnim.SetBool("Right Bool", true);
                    if (shotDelay <= 0)
                    {
                        firePos.GetComponent<FireScript>().Fire();
                        shotDelay = shotCool;
                    }
                }
            }
        }                  

        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.RightArrow)) // 이 밑 로직들은 캐릭터 좌,우 이동시 기존 모션과 반대로 공격모션 취하기 위한 로직
        {
            if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
            {
                GetComponent<Animator>().Play("right");
                if (shotDelay <= 0)
                {
                    firePos.GetComponent<FireScript>().Fire();
                    shotDelay = shotCool;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.LeftArrow))
        {
            if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
            {
                GetComponent<Animator>().Play("left");
                if (shotDelay <= 0)
                {
                    firePos.GetComponent<FireScript>().Fire();
                    shotDelay = shotCool;
                }
            }
        }
        if(Input.GetKey(KeyCode.Space) ) // 챠지 어택 게이지 모으기 , 스페이스 누르고 있으면
        {
            if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
            {
                chargeEffect.SetActive(true);               
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) // 챠지 어택 , 스페이스 손 떼면
        {
            if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
            {
                if (gameObject.transform.position.x < 0)
                {
                    playerAnim.SetBool("Left Bool", true);
                    if (chargeGage >= chargeMax && chargeGageBool == true)
                    {
                        Debug.Log("chargeMax");
                        firePos.GetComponent<FireScript>().Charge100Attack();
                        chargeGage = 0;
                        chargeEffect.SetActive(false);
                    }
                    else
                    {
                        chargeGage = 0;
                        chargeEffect.SetActive(false);
                    }
                    if (chargeBar.value > 0.5 && chargeBar.value < 1.0)
                    {
                        Debug.Log("chargeMiddle");
                        firePos.GetComponent<FireScript>().Charge50Attack();
                        chargeGage = 0;
                        chargeGageBool = false;
                        chargeEffect.SetActive(false);
                    }
                    else
                    {
                        chargeGage = 0;
                        chargeGageBool = false;
                        chargeEffect.SetActive(false);
                    }
                }
            }
            if (gameObject.transform.position.x >= 0)
            {
                if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
                {
                    playerAnim.SetBool("Right Bool", true);
                    if (chargeGage >= chargeMax && chargeGageBool == true)
                    {
                        Debug.Log("chargeMax");
                        firePos.GetComponent<FireScript>().Charge100Attack();
                        chargeGage = 0;
                        chargeEffect.SetActive(false);
                    }
                    else
                    {
                        chargeGage = 0;
                        chargeEffect.SetActive(false);
                    }
                    if (chargeBar.value > 0.5 && chargeBar.value < 1.0)
                    {
                        Debug.Log("chargeMiddle");
                        firePos.GetComponent<FireScript>().Charge50Attack();
                        chargeGage = 0;
                        chargeGageBool = false;
                        chargeEffect.SetActive(false);
                    }
                    else
                    {
                        chargeGage = 0;
                        chargeGageBool = false;
                        chargeEffect.SetActive(false);
                    }
                }
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

    void ShotDelay() // 기본 공격 쿨타임 
    {
        shotDelay -= Time.deltaTime;
        if(shotDelay < 0)
        {
            shotDelay = 0;
        }
        /*----------- 게이지 ----------- */
        curShotCool = shotDelay / shotCool;
        shotBar.value = curShotCool;
        /*----------- 게이지 ----------- */

        /*----------- 타이머 ----------- */
        //curShotCool = (float)(shotBar.value); // shotBar.value = curShotCool; 와 중복 된다 , INT로 보여지고 싶으면 FLOAT대신 쓰면 됌

        float coolText = shotBar.value; 
        coolText *= shotDelay;  
        // 변수 만들어 준 이유는 쿨타임 변경시 보여지는 초도 같이 수정되기 위해서. 변수 만들고 *= 안해줄시 1에서만 줄어들고 속도가 느려지거나 빨라짐
        shotCoolLabel.text = "" + coolText.ToString("N1");
        if(coolText == 0.0f)
        {
            shotCoolLabel.text = "";
        }

        /*----------- 타이머 ----------- */
    }


    void ChargeGageBar()
    {
        curCharge = chargeGage / chargeMax;
        chargeBar.value = curCharge;
    }

    public void UsePotionBtnClick()
    {
        if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false && winPopUp.activeSelf == false)
        {
            if(LobbySceneBtnScript.Instance().myPotion >= 1 )
            {
                if (playerHp > 0 && playerHp != LobbySceneBtnScript.Instance().playerMaxHp)
                {
                    playerHp += 1;
                    LobbySceneBtnScript.Instance().myPotion -= 1;
                }

                if (playerHp >= LobbySceneBtnScript.Instance().playerMaxHp)
                {
                    playerHp = LobbySceneBtnScript.Instance().playerMaxHp;
                }
            }           
        }
    }

    //public void AttackBtnClick() // 버튼 한번 클릭시 공격
    //{
    //    PlayerMoveLimit();
    //    if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
    //    {
    //        if (gameObject.transform.position.x < 0)
    //        {
    //            GetComponent<Animator>().Play("left");
    //            if (shotDelay <= 0)
    //            {
    //                firePos.GetComponent<FireScript>().Fire(); //  fireScript에서 fire 함수 불러오기
    //                shotDelay = shotCool;
                   
    //            }
    //        }
    //        if (gameObject.transform.position.x >= 0)
    //        {
    //            GetComponent<Animator>().Play("right");
    //            if (shotDelay <= 0)
    //            {
    //                firePos.GetComponent<FireScript>().Fire();
    //                shotDelay = shotCool;
                    
    //            }
    //        }
    //    }
    //}

    public void ChargeAttackBtnPress() 
    // 챠지 어택 , time.deltatime 혹은 연산자를 이용 제한값 두는것은 매프레임 실행되야므로 업데이트에 해야함.이벤트 트리거의 프레스는 한번만 실행함
    // 버튼 스크립트의 on clikc까지 사용해서 한버튼에 3개 사용시 기본 공격이 스킬과 함께 나가므로 버튼 방식은 2개만
    // 챠지와 기본 공격 함께 넣음
    {
        PlayerMoveLimit();
        if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false && winPopUp.activeSelf == false)
        {
            chargeEffect.SetActive(true);
            if (gameObject.transform.position.x < 0)
            {
                GetComponent<Animator>().Play("left");
                if (shotDelay <= 0)
                {
                    firePos.GetComponent<FireScript>().Fire(); //  fireScript에서 fire 함수 불러오기
                    shotDelay = shotCool;

                }
            }
            if (gameObject.transform.position.x >= 0)
            {
                GetComponent<Animator>().Play("right");
                if (shotDelay <= 0)
                {
                    firePos.GetComponent<FireScript>().Fire();
                    shotDelay = shotCool;

                }
            }
        }      
    }

    public void ChargeAttackRelease() // 챠지 어택 해제
    {
        PlayerMoveLimit();
        if (pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false && winPopUp.activeSelf == false)
        {
            if (gameObject.transform.position.x < 0)
            {
                GetComponent<Animator>().Play("left");
                if (chargeGage >= chargeMax && chargeGageBool == true)
                {
                    Debug.Log("chargeMax");
                    firePos.GetComponent<FireScript>().Charge100Attack();
                    chargeGage = 0;
                    chargeGageBool = false;
                    chargeEffect.SetActive(false);
                }
                else
                {
                    chargeGage = 0;
                    chargeGageBool = false;
                    chargeEffect.SetActive(false);
                }
                if( chargeBar.value > 0.5 && chargeBar.value < 1.0)
                {
                    Debug.Log("chargeMiddle");
                    firePos.GetComponent<FireScript>().Charge50Attack();
                    chargeGage = 0;
                    chargeGageBool = false;
                    chargeEffect.SetActive(false);
                }
                else
                {
                    chargeGage = 0;
                    chargeGageBool = false;
                    chargeEffect.SetActive(false);
                }
            }
            if (gameObject.transform.position.x >= 0)
            {
                GetComponent<Animator>().Play("right");
                if (chargeGage >= chargeMax && chargeGageBool == true)
                {
                    Debug.Log("chargeMax");
                    firePos.GetComponent<FireScript>().Charge100Attack();
                    chargeGage = 0;
                    chargeGageBool = false;
                    chargeEffect.SetActive(false);
                }
                else
                {
                    chargeGage = 0;
                    chargeGageBool = false;
                    chargeEffect.SetActive(false);
                }
                if (chargeBar.value > 0.5 && chargeBar.value < 1.0)
                {
                    Debug.Log("chargeMiddle");
                    firePos.GetComponent<FireScript>().Charge50Attack();
                    chargeGage = 0;
                    chargeGageBool = false;
                    chargeEffect.SetActive(false);
                }
                else
                {
                    chargeGage = 0;
                    chargeGageBool = false;
                    chargeEffect.SetActive(false);
                }
            }
        }
    }

    //public void AttackBtnClick() // 버튼 누를시 기본 공격
    //{
    //   if(pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
    //    {
    //        attackTouch = true;
    //    }
    //}

    //public void AttackBtnRelease() // 버튼 손떼면 기본공격 해제
    //{
    //    if(pausePopUpCheck.activeSelf == true && exitLobbyCheck.activeSelf == false)
    //    {
    //        attackTouch = false;
    //    }
    //}

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



    //IEnumerator PlayerDiePause() // 코루틴을 이용한 시간 정지, 이 스크립트에서는 사용 불가. 이유는 사망시 오브젝트가 파괴 되므로
    //{
    //    Time.timeScale = 1.0f;
    //    yield return new WaitForSeconds(2f);
    //    Time.timeScale = 0.0f;
    //}

    //void TimeScaleStop() // 인보크를 이용한 시간 정지, 이 스크립트에서는 사용 불가. 이유는 사망시 오브젝트가 파괴 되므로
    //{
    //    Time.timeScale = 0f;
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
                //LobbySceneBtnScript.Instance().myScore -= score;
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
        if (playerHp == 0)
        {
            Instantiate(dieEffect, transform.position, transform.rotation);
            losePopUp.SetActive(true); // 팝업은 켜지지만 플레이어 파괴라서 보상이 실시간으로 보이지 않음. 되도록이면 다른곳에 달아줄거나 밑에처럼 한번더 써줄것
            LobbySceneBtnScript.Instance().myGold += 100;
            LobbySceneBtnScript.Instance().myPotion += 35;
            haveGold.text = LobbySceneBtnScript.Instance().myGold.ToString();
            havePotion.text = LobbySceneBtnScript.Instance().myPotion.ToString();
            hpLabel.text = "HP  :  0";
            hpBar.value = 0;
            Destroy(gameObject);
        }
        if (other.tag == "Win")
        {
            winItemEA -= 1;
            //LobbySceneBtnScript.Instance().myScore += 100;
            if (Application.loadedLevelName == "Stage_01" && winItemEA == 0)
            {
                winPopUp.SetActive(true); // 밑에 보상은 플레이어 오브젝트가 파괴 되지 않아서 실시간으로 오름
                //LobbySceneBtnScript.Instance().myScore += 3500;
                LobbySceneBtnScript.Instance().myGold += 100;
                LobbySceneBtnScript.Instance().myGem += 35;
            }
        }
    }
}
