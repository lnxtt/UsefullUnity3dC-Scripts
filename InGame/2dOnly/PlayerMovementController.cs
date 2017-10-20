//copyright: creator Marvin Plum github.com/lnxtt
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovementController : MonoBehaviour {

	public float moveForce;
	Rigidbody2D rigd;

	public bool useEngine = false;
	public GameObject[] Engines;

	public float[] EngineOnOffSpeed = new float[2]; // tells the speed the Engine-particles should have when they are on or off([0] = On / [1] = Off Speed)
	ParticleSystem[] EngineParticleSystems;

	void Start(){
		rigd = this.GetComponent<Rigidbody2D> ();
		if (Engines.Length != 0) {	// Not all ships need to use dynamic a Engine
			EngineParticleSystems = new ParticleSystem[Engines.Length];
			for (int i = 0; i < Engines.Length; i++) {
				EngineParticleSystems[i] = Engines[i].GetComponent<ParticleSystem> ();
			}
		}
	}

	void changeEngineParticleSpeed(float Speed){
		if (useEngine) {
			for (int i = 0; i < Engines.Length; i++){
				if (EngineParticleSystems [i].startSpeed != Speed) {	// to prevent unnessary changes
					EngineParticleSystems [i].startSpeed = Speed;
				}
			}
		}
	}

	void FixedUpdate () {
		Vector2 moveVec = new Vector2 (CrossPlatformInputManager.GetAxis ("Horizontal")*moveForce, CrossPlatformInputManager.GetAxis ("Vertical")*moveForce);

		float angle = -Mathf.Atan2(CrossPlatformInputManager.GetAxis ("Horizontal"), (CrossPlatformInputManager.GetAxis ("Vertical")))*Mathf.Rad2Deg;
		if (angle != 180 && angle != 0) { //to prevent a rotation reset then the joystick is in it's normal position. The below is only Activated when the joystick is touched.
			transform.rotation = Quaternion.Euler (0, 0, angle);
			changeEngineParticleSpeed (EngineOnOffSpeed[0]); // turns the engines on
		} else {
			changeEngineParticleSpeed(EngineOnOffSpeed[1]);	// turns the engines off
		}

		Vector3 currentPosition = Camera.main.WorldToViewportPoint (transform.position);	// gets the position relative to the camera (To be in the field of view : 0>playerpos>1)

		if (currentPosition.x > 0.85 && moveVec.x > 0) {moveVec.x = 0;}		// to prevent, that the player goes out of the screen
		if (currentPosition.x < 0.2 && moveVec.x < 0) {moveVec.x = 0;}
		if (currentPosition.y > 0.85 && moveVec.y > 0) {moveVec.y = 0;}
		if (currentPosition.y < 0.2 && moveVec.y < 0) {moveVec.y = 0;}
			
		rigd.AddForce (moveVec);
	}
}
