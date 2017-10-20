using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObjectToCoordinates : MonoBehaviour {

	public Vector3[] TargetCoordinates;	// the coordinates that the Object, that should rotate, faces
	public GameObject RotationObject;
	private int currentIndex = 0;
	public float speed;

	public void RotateLeft(){
		if (currentIndex >= (TargetCoordinates.Length - 1)) {
			currentIndex = 0;
		} else {
			currentIndex += 1;
		}
	}

	public void RotateRight(){
		if (currentIndex - 1 < 0 ){
			currentIndex = TargetCoordinates.Length - 1;
		} else {
			currentIndex -= 1;
		}
	}

	void Update(){
		Vector3 direction = TargetCoordinates[currentIndex] - RotationObject.transform.position;
		float angle = Mathf.Atan2 (direction.x,direction.y)*Mathf.Rad2Deg;
		Quaternion rotation = Quaternion.AngleAxis (angle, Vector3.forward);
		RotationObject.transform.rotation = Quaternion.Slerp (RotationObject.transform.rotation, rotation, speed);
	}
}
