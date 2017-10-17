using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	public void loadLevel(string name){
		Debug.Log ("Clicked Level load requested for : "+name);
		//Application.LoadLevel (name);
		SceneManager.LoadScene(name);
	}
	public void quitRequest(){
		Debug.Log ("Requested for quit");
		Application.Quit();
	}
	public void loadNextLevel(){
		//Application.LoadLevel (Application.loadedLevel + 1); //loaded level return int
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
	}

}