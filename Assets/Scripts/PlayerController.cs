using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	public float playerSpeed=8.0f;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.LeftArrow))
			MoveLeft();
		if (Input.GetKey (KeyCode.RightArrow))
			MoveRight ();
	}
	void MoveLeft(){
		this.transform.position += new Vector3 (-playerSpeed*Time.deltaTime,0,0); //Time.deltaTime this multiply factor prevent when the script loads slower or faster the framerate
		//PS. Make sure movement is independent of framerate using Time.deltaTime
		//now the player will move smoothly
	}
	void MoveRight(){
		//this.transform.position = new Vector2 (this.transform.position.x+playerSpeed*Time.deltaTime, this.transform.position.y); Error if use + operator because this position is in vector3
		this.transform.position += new Vector3 (playerSpeed*Time.deltaTime,0,0);
	}
}
