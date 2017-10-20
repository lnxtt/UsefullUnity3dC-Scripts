using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdvertisementControlScript : MonoBehaviour {

	public bool ShowAdvertisements = false;		//assign values in editor
	public int showAdvertisementAfterGameCount = 10;
	int gamesPlayed;

	public void CheckForAd() {
		if (ShowAdvertisements) {
			gamesPlayed = PlayerPrefs.GetInt ("GamesPlayed");
			if (gamesPlayed != showAdvertisementAfterGameCount) {
				PlayerPrefs.SetInt ("GamesPlayed", gamesPlayed + 1);
			} else {
				PlayerPrefs.SetInt ("GamesPlayed", 1);
				ShowAd ();
			}
		}
	}

	private void ShowAd () {
		Advertisement.Show ();		// to prevent crashes on iOS (when no internet connection is present) load the unity3d advertisement framework into xCode
	}
}
