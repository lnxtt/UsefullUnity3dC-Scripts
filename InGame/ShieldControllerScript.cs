using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Scripting;

public class ShieldControllerScript : MonoBehaviour {

	public Text PercantageLabel;
	public string[] DamagingObjectTags;		//the names of the objects that can hurt the players shield
	public int[] DamagingObjectsDamagePercentage; // the percentage that will be taken from the shields on Collision
	public GameObject GameStatusController;
	GameStatusControllerScript statusConScript;
	int currentpercentage;

	void Start(){
		statusConScript = GameStatusController.GetComponent<GameStatusControllerScript>();	// to call a method when the game is lost
	}

	private int getCurrentPercentage(){
		if (int.TryParse (PercantageLabel.text.Remove (PercantageLabel.text.Length - 1), out currentpercentage)) {
			currentpercentage = int.Parse (PercantageLabel.text.Remove (PercantageLabel.text.Length - 1));
		}
		return currentpercentage;
	}

	private void reduceShieldPercentage(int damage){
		if ((getCurrentPercentage() - damage) < 0) {	// to prevent negativ percentages
			PercantageLabel.text = "0%";
			statusConScript.ChangeGameStatus (false);	// game lost
		} else {
			int newPercantage = getCurrentPercentage() - damage;
			PercantageLabel.text = newPercantage.ToString() + "%";
		}
	}

	public void CollisionOccured(Collision2D col){
		for (int i = 0; i < DamagingObjectTags.Length; i++) {
			if (DamagingObjectTags [i] == col.gameObject.tag) {
				reduceShieldPercentage (DamagingObjectsDamagePercentage[i]);
			}
		}
	}
}
