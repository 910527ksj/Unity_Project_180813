using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

    public GameObject arrow;
    public GameObject chargeBullet;

	public void Fire()
    {
        GameObject arrowObj = Instantiate(arrow) as GameObject;
        arrowObj.transform.position = gameObject.transform.position;
        //Debug.Log("FirePos  ::::: " + transform.position.y);
    }
    public void ChargeAttack()
    {
        GameObject chargeObj = Instantiate(chargeBullet) as GameObject;
        chargeObj.transform.position = gameObject.transform.position;
    }
}
