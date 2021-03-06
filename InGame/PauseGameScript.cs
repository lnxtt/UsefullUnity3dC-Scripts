using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseGameScript : MonoBehaviour {
	private bool gamepaused = false;

	public GameObject[] ObjectsThatShouldNotWorkOnPause;	//gets disabled to prevent Cheaters, set value in editor
	public Sprite PauseIcon;
	public Sprite PlayIcon;
	public Button PauseButton;

	public void SwitchGamePauseStatus(){
		if (gamepaused) {
			Time.timeScale = 1;
			PauseButton.image.overrideSprite = PauseIcon;
			gamepaused = false;
		} else {
			Time.timeScale = 0;
			PauseButton.image.overrideSprite = PlayIcon;
			gamepaused = true;
		}
		changeObjectActivStatus (ObjectsThatShouldNotWorkOnPause, !gamepaused);
	}

	private void changeObjectActivStatus(GameObject[] obj, bool status){
		for (int i = 0; i < obj.Length; i++) {
			obj [i].SetActive (status);
		}
	}
}
