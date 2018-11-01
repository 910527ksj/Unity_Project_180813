using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject enemyChange;
    public float enemyHp;
    public Rigidbody2D enemyRigidbody2D;
    public float limitY;
    public int enemyMove;
    public GameObject dieEffect;
    int score = 5 ;

	void Start ()
    {
        if (gameObject.name == "Enemy_Blue_01(Clone)")
        {
            enemyMove = Random.Range(0, 2).Equals(0) ? -2 : 2; // 삼항연산자 - 0,1 을 랜덤으로 하고(확률50%) 0은 -1 , 1은 2
            enemyRigidbody2D.velocity = new Vector2(enemyMove, 0);
        }
    }
		
	void Update ()
    {        
        if (transform.position.y >= limitY)
        {
            transform.position = new Vector3(transform.position.x, limitY, transform.position.z);
        }
    }



    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Arrow")
        {
            enemyHp -= LobbySceneBtnScript.Instance().basicDamage;
            if (enemyHp <= 0)
            {
                LobbySceneBtnScript.Instance().myScore += score;
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
            enemyHp -= LobbySceneBtnScript.Instance().basicDamage +2;
            if (enemyHp <= 0)
            {
                LobbySceneBtnScript.Instance().myScore += score;
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
            enemyHp -= LobbySceneBtnScript.Instance().basicDamage +4;
            if (enemyHp <= 0)
            {
                LobbySceneBtnScript.Instance().myScore += score;
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
