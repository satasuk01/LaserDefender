using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {
	public float playerSpeed=8.0f;
	float xmin= -6.2f,xmax=6.2f,padding = 0.5f;
	// Use this for initialization
	void Start () {
		CameraRestrictPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (Input.GetKey (KeyCode.LeftArrow))
			MoveLeft();
		if (Input.GetKey (KeyCode.RightArrow))
			MoveRight ();
		movableSpace ();
	}
	void MoveLeft(){
		//-------------------------------
		//this.transform.position += new Vector3 (-playerSpeed*Time.deltaTime,0,0); //Time.deltaTime this multiply factor prevent when the script loads slower or faster the framerate
		//PS. Make sure movement is independent of framerate using Time.deltaTime
		//now the player will move smoothly
		//-------------------------------
		this.transform.position += Vector3.left*playerSpeed*Time.deltaTime; //Vector3.left is a 1 unit vector direction to -x
	}
	void MoveRight(){
		//this.transform.position = new Vector2 (this.transform.position.x+playerSpeed*Time.deltaTime, this.transform.position.y); Error if use + operator because this position is in vector3
		this.transform.position += Vector3.right*playerSpeed*Time.deltaTime;
	}
	void movableSpace(){ //restrict player in the game
		float newx = Mathf.Clamp (this.transform.position.x, xmin, xmax);
		this.transform.position = new Vector3 (newx, this.transform.position.y, this.transform.position.z);
	}
	void CameraRestrictPlayer(){ //restrict player by camera view
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		Vector3 rightBoundary = camera.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		Vector3 leftBoundary = camera.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		xmin = leftBoundary.x+padding;
		xmax = rightBoundary.x-padding;
	}
}
