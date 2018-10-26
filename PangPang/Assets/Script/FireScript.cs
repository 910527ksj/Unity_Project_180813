using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public GameObject arrow;
    public GameObject charge100Bullet;
    public GameObject charge50Bullet;

	public void Fire()
    {
        GameObject arrowObj = Instantiate(arrow) as GameObject;
        arrowObj.transform.position = gameObject.transform.position;
        //Debug.Log("FirePos  ::::: " + transform.position.y);
    }

    public void Charge100Attack()
    {
        GameObject charge100Obj = Instantiate(charge100Bullet) as GameObject;
        charge100Obj.transform.position = gameObject.transform.position;
    }
    public void Charge50Attack()
    {
        GameObject charge50Obj = Instantiate(charge50Bullet) as GameObject;
        charge50Obj.transform.position = gameObject.transform.position;
    }
}
