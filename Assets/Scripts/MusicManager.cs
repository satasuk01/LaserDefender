using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour {
	public AudioClip start;
	public AudioClip game;
	private Scene activeScene;
	void Awake(){
		Debug.Log ("Awake");
		activeScene = SceneManager.GetActiveScene ();
		if (activeScene.name == "Start" && !GameObject.Find ("musicPlayer").GetComponent<AudioSource> ().isPlaying) {
			GameObject.Find("musicPlayer").GetComponent<musicPlayer>().PlayClip(start);
		}if (activeScene.name == "Game" && !GameObject.Find ("musicPlayer").GetComponent<AudioSource> ().isPlaying) {
			GameObject.Find("musicPlayer").GetComponent<musicPlayer>().PlayClip(game);
		}
		if (activeScene.name == "EndGame" && !GameObject.Find ("musicPlayer").GetComponent<AudioSource> ().isPlaying) {
			GameObject.Find("musicPlayer").GetComponent<musicPlayer>().PlayClip(game);
		}
	}

}
