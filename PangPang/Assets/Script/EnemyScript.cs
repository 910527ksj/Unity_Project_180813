using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class EnemyScript : MonoBehaviour {

    public GameObject enemyChange;

    public TextAsset jsonEnemyData;
    public List<int> enemyStateHP = new List<int>();

    public int enemyHp;
    public Rigidbody2D enemyRigidbody2D;
    public float limitY;
    public int enemyMove;
    public GameObject dieEffect;
    int score = 5 ;



	void Start ()
    {
        EnemyState();
        StartEnemyState();
    }
		
	void Update ()
    {        
        if (transform.position.y >= limitY)
        {
            transform.position = new Vector3(transform.position.x, limitY, transform.position.z);
        }
    }


    private void EnemyState()
    {
        var enemyStateData = JSON.Parse(jsonEnemyData.text);
        enemyStateHP.Add(enemyStateData[0]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[1]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[2]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[3]["HP_LV_1~5"]);
        //까지 01
        enemyStateHP.Add(enemyStateData[4]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[5]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[6]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[7]["HP_LV_1~5"]);
        //까지 02
        enemyStateHP.Add(enemyStateData[8]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[9]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[10]["HP_LV_1~5"]);
        enemyStateHP.Add(enemyStateData[11]["HP_LV_1~5"]);
        //까지 03
        enemyStateHP.Add(enemyStateData[12]["HP_LV_1~5"]);
    }


    public void StartEnemyState()
    {
        //파랑
        if (gameObject.name == "Enemy_Blue_01(Clone)")
        {
            enemyHp = enemyStateHP[0];
            enemyMove = Random.Range(0, 2).Equals(0) ? -2 : 2; // 삼항연산자 - 0,1 을 랜덤으로 하고(확률50%) 0은 -1 , 1은 2
            enemyRigidbody2D.velocity = new Vector2(enemyMove, 0);
        }
        if (gameObject.name == "Enemy_Blue_02(Clone)")
        {
            enemyHp = enemyStateHP[4];
        }
        if (gameObject.name == "Enemy_Blue_03(Clone)")
        {
            enemyHp = enemyStateHP[5];
        }
        //파랑

        //빨강
        if (gameObject.name == "Enemy_Red_01(Clone)")
        {
            enemyHp = enemyStateHP[1];
            enemyMove = Random.Range(0, 2).Equals(0) ? -2 : 2; // 삼항연산자 - 0,1 을 랜덤으로 하고(확률50%) 0은 -1 , 1은 2
            enemyRigidbody2D.velocity = new Vector2(enemyMove, 0);
        }
        if (gameObject.name == "Enemy_Red_02(Clone)")
        {
            enemyHp = enemyStateHP[5];
        }
        if (gameObject.name == "Enemy_Red_03(Clone)")
        {
            enemyHp = enemyStateHP[9];
        }
        //빨강

        //검정
        if (gameObject.name == "Enemy_Black_01(Clone)")
        {
            enemyHp = enemyStateHP[2];
            enemyMove = Random.Range(0, 2).Equals(0) ? -2 : 2; // 삼항연산자 - 0,1 을 랜덤으로 하고(확률50%) 0은 -1 , 1은 2
            enemyRigidbody2D.velocity = new Vector2(enemyMove, 0);
        }
        if (gameObject.name == "Enemy_Black_02(Clone)")
        {
            enemyHp = enemyStateHP[6];
        }
        if (gameObject.name == "Enemy_Black_03(Clone)")
        {
            enemyHp = enemyStateHP[10];
        }
        //검정

        //하얀
        if (gameObject.name == "Enemy_White_01(Clone)")
        {
            enemyHp = enemyStateHP[3];
            enemyMove = Random.Range(0, 2).Equals(0) ? -2 : 2; // 삼항연산자 - 0,1 을 랜덤으로 하고(확률50%) 0은 -1 , 1은 2
            enemyRigidbody2D.velocity = new Vector2(enemyMove, 0);
        }
        if (gameObject.name == "Enemy_White_02(Clone)")
        {
            enemyHp = enemyStateHP[7];
        }
        if (gameObject.name == "Enemy_White_03(Clone)")
        {
            enemyHp = enemyStateHP[11];
        }
        //하얀
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Arrow")
        {
            enemyHp -= LobbySceneBtnScript.Instance().basicDamage;
            if (enemyHp <= 0)
            {
                //LobbySceneBtnScript.Instance().myScore += score;
                Instantiate(dieEffect, transform.position,transform.rotation);
                Destroy(gameObject);
                GameObject obj1 = Instantiate(enemyChange) as GameObject;
                obj1.transform.position = transform.position;
                obj1.GetComponent<Rigidbody2D>().velocity = new Vector2 (-enemyMove,0);
                GameObject obj2 = Instantiate(enemyChange) as GameObject;
                obj2.transform.position = transform.position;
                obj2.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyMove, 0);
            }
        }
        if (coll.tag == "Charge50Attack")
        {
            enemyHp -= (LobbySceneBtnScript.Instance().basicDamage + LobbySceneBtnScript.Instance().chargeDamage);
            if (enemyHp <= 0)
            {
                //LobbySceneBtnScript.Instance().myScore += score;
                Instantiate(dieEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                GameObject obj1 = Instantiate(enemyChange) as GameObject;
                obj1.transform.position = transform.position;
                obj1.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyMove, 0);
                GameObject obj2 = Instantiate(enemyChange) as GameObject;
                obj2.transform.position = transform.position;
                obj2.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyMove, 0);
            }
        }
        if (coll.tag == "Charge100Attack")
        {
            enemyHp -= LobbySceneBtnScript.Instance().basicDamage + (LobbySceneBtnScript.Instance().chargeDamage * 2);
            if (enemyHp <= 0)
            {
                //LobbySceneBtnScript.Instance().myScore += score;
                Instantiate(dieEffect, transform.position, transform.rotation);
                Destroy(gameObject);
                GameObject obj1 = Instantiate(enemyChange) as GameObject;
                obj1.transform.position = transform.position;
                obj1.GetComponent<Rigidbody2D>().velocity = new Vector2(-enemyMove, 0);
                GameObject obj2 = Instantiate(enemyChange) as GameObject;
                obj2.transform.position = transform.position;
                obj2.GetComponent<Rigidbody2D>().velocity = new Vector2(enemyMove, 0);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
      
    }
}
