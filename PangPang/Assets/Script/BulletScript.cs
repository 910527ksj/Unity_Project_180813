using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed;
    public float deleteTime;
    public GameObject hitEffect;

	void Start ()
    {
        Destroy(gameObject, deleteTime);
        //Debug.Log("Arrow Position  :::::::::::::::::  "+transform.position);
	}
	
	
	void Update ()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
	}

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.tag == "Enemy")
        {
            Instantiate(hitEffect,transform.position,transform.rotation);
            Destroy(gameObject);
        }
    }
}
