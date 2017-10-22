using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicPlayer : MonoBehaviour {
	static musicPlayer instance = null;
	private AudioSource music;
	void Awake() { //put int awake will make music flow stimutaneously
		Debug.Log ("Music player Awake " + GetInstanceID ());
		if (instance != null) { //prevent new musicplayer is created(If another scene has music player or move back to start menu)
			Destroy (gameObject);
			Debug.Log ("Duplicate music player self-destructing!");//make new music get destroy before run start
		} else {
			instance = this;
			Debug.Log ("Music created!!!");
			music = GetComponent<AudioSource> ();
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
	public void PlayClip(AudioClip clip){
		music.clip = clip;
		music.Play ();
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Music player Start "+ GetInstanceID());
		}


}

