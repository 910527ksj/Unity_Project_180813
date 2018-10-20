using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour {

    public GameObject enemyChange;
    public float enemyHp;
    public Rigidbody2D EnemyRigidbody2D;
    public float limitY;
    public float enemyMove;

	void Start ()
    {
        EnemyRigidbody2D.velocity = new Vector2(enemyMove, 0);
    }
	
	
	void Update ()
    {
        if(transform.position.y >= limitY   )
        {
            transform.position = new Vector2(transform.position.x,limitY); 
        }
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Arrow")
        {
            enemyHp -= 1;
            if (enemyHp <= 0)
            {
                Instantiate(enemyChange, transform.position, Quaternion.identity);
                Instantiate(enemyChange);
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {

    }
}
