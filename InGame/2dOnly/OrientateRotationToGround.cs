//copyright: creator Marvin Plum github.com/lnxtt 
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrientateRotationToGround : MonoBehaviour {

	void Start () {
		Vector3 Bottomposition = new Vector3 (transform.position.x, -1, transform.position.z);
		Vector3 direction = Bottomposition - transform.position;
		float angle = Mathf.Atan2 (direction.x,direction.y)*Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis (2*angle, Vector3.forward);
		transform.rotation = rotation;
	}
}
