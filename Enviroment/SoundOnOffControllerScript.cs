using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class SoundOnOffControllerScript : MonoBehaviour {

	public Button SoundOnOffBtn;
	public Sprite SoundOnIcon;
	public Sprite SoundOffIcon;
	public GameObject ScoreSound;

	bool soundOn;
	bool musicIsOnOnload;	// to reload the past music condition after switch
	GameObject[] MusicObjects;

	void Start () {
		if (PlayerPrefs.GetInt ("IsSoundOn") == 0) {
				soundOn = false;}
			else{
				soundOn = true;}
		try{
			MusicObjects = GameObject.FindGameObjectsWithTag("Music");
			if (MusicObjects.Length > 1) {	// to prevent multiple AudioSources
				for (int i = 1; i < MusicObjects.Length; i++) {
					Destroy(MusicObjects [i]);
				}
				MusicObjects = new GameObject[]{MusicObjects[0]};
			}
			if (MusicObjects [0].activeSelf) {
				musicIsOnOnload = true;
			} else {
				musicIsOnOnload = false;
			}
		}
		catch(Exception ex){}
		SetSoundApperance ();
	}

	private void SetSoundApperance(){
		if (soundOn) {
			ScoreSound.GetComponent<AudioSource> ().volume = 1;
			if (musicIsOnOnload) {
				MusicObjects [0].SetActive (true);
			}
			SoundOnOffBtn.image.overrideSprite = SoundOnIcon;
		} else {
			ScoreSound.GetComponent<AudioSource> ().volume = 0;
			try{
				MusicObjects [0].SetActive (false);}
			catch(Exception ex){}
			SoundOnOffBtn.image.overrideSprite = SoundOffIcon;
		}
	}

	public void changeSoundSettings(){
		if (soundOn) {
			soundOn = false;
			PlayerPrefs.SetInt ("IsSoundOn", 0); 	// 0 = off 1 = on
		} else {
			PlayerPrefs.SetInt ("IsSoundOn", 1);
			soundOn = true;
		}
		SetSoundApperance ();
	}
}
