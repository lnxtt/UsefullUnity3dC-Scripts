using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicSettingsLoader : MonoBehaviour {

	public Button SoundControlBtn;
	public Sprite SoundOnIcon;
	public Sprite SoundOffIcon;
	bool useMusic = false;

	GameObject[] MusicObjects;

	void Start () {
		MusicObjects = GameObject.FindGameObjectsWithTag("Music");
		if (MusicObjects.Length > 1) {	// to prevent multiple AudioSources
			for (int i = 1; i < MusicObjects.Length; i++) {
				Destroy(MusicObjects [i]);
			}
			MusicObjects = new GameObject[]{MusicObjects[0]};
		}
		if (PlayerPrefs.GetInt ("MusicUse") == 1) {
			useMusic = true;
		} else {
			useMusic = false;
		}
		changeMusicAppearance ();
	}

	private void changeMusicAppearance(){
		if (useMusic) {
			SoundControlBtn.image.overrideSprite = SoundOnIcon;
			MusicObjects[0].SetActive (true);
		} else {
			SoundControlBtn.image.overrideSprite = SoundOffIcon;
			MusicObjects[0].SetActive (false);
		}
	}

	public void ChangeMusicSetting () {		// can be called with a button
		if (useMusic) {
			PlayerPrefs.SetInt ("MusicUse", 0);
			useMusic = false;
		} else {
			PlayerPrefs.SetInt ("MusicUse", 1);
			useMusic = true;
		}
		changeMusicAppearance ();
	}
}
