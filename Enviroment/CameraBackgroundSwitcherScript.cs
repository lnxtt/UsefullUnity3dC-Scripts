using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraBackgroundSwitcherScript : MonoBehaviour {

	public Sprite DarkIcon;
	public Sprite LightIcon;
	public Color DarkBackgroundColor;
	public Color LightBackgroundColor;

	public GameObject Camera;

	public bool changeObjectColors;
	public Text[] TextLabels;
	public Button[] Buttons;	
	public Image[] Images;

	string color = "light";

	void Start () {
		color = PlayerPrefs.GetString ("CameraBackgroundColor");	//loads the stored color
		if (color == "dark") {
			SwitchToDarkColor ();
		}
	}

	void SwitchToDarkColor(){
		Camera.GetComponent<Camera> ().backgroundColor = DarkBackgroundColor;
		if (changeObjectColors) {
			for (int i = 0; i < Buttons.Length; i++) {
				if (Buttons [i].name == "DarkModeBtn") {
					Buttons [i].image.overrideSprite = LightIcon;
				}
					Buttons [i].image.color = LightBackgroundColor;
			}
			for (int a = 0; a < TextLabels.Length; a++) {
				TextLabels[a].color = LightBackgroundColor;
				if (TextLabels [a].name == "CameraColorLabel") {TextLabels[a].text = "Light";}}
			for (int r = 0; r < Images.Length; r++) {Images [r].color = LightBackgroundColor;}
		}
		PlayerPrefs.SetString ("CameraBackgroundColor", "dark");
	}

	void SwitchToLightColor(){
		Camera.GetComponent<Camera> ().backgroundColor = LightBackgroundColor;
		if (changeObjectColors) {
			for (int i = 0; i < Buttons.Length; i++) {
				if (Buttons [i].name == "DarkModeBtn") {
					Buttons [i].image.overrideSprite = DarkIcon;
				}
					Buttons [i].image.color = DarkBackgroundColor;
			}
			for (int a = 0; a < TextLabels.Length; a++) {
				TextLabels[a].color = DarkBackgroundColor;
				if (TextLabels [a].name == "CameraColorLabel") {TextLabels[a].text = "Dark";}}
			for (int r = 0; r < Images.Length; r++) {Images [r].color = DarkBackgroundColor;}

		}
		PlayerPrefs.SetString ("CameraBackgroundColor", "light");
	}

	public void SwitchColor(){
		color = PlayerPrefs.GetString ("CameraBackgroundColor");
		if (color == "light") {
			SwitchToDarkColor ();
		} else {
			SwitchToLightColor ();
		}
	}
}
