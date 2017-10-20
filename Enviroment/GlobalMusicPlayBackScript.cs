using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalMusicPlayBackScript : MonoBehaviour {

	void Awake(){
		DontDestroyOnLoad (this.gameObject);
	}
}
