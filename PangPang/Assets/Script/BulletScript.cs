using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour {

    public float bulletSpeed;
    public float deleteTime;

	void Start ()
    {
        Destroy(gameObject, deleteTime);
	}
	
	
	void Update ()
    {
        transform.Translate(0, bulletSpeed * Time.deltaTime, 0);
	}
}
