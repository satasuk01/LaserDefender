﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f,height = 5f;
	public float houndSpeed = 2f;
	public float spawnDelay = 0.5f;
	private float xmax,xmin;
	private bool movingRight = true;
	public bool enableSpawn = true;
	public int scoreWhenCall = 1500;
	public int cycle=1;
	// Use this for initialization
	void Start () {
		CameraRestrictEnemy ();
		SpawnEnemies ();
	}
	// Update is called once per frame
	void Update () {
		Move ();
		if (IsAllMembersDead ()) {
			Debug.Log ("Empty enemy");
			SpawnEnemies ();
		}
		BossIncoming (); //call the boss when score beat
	}

	void BossIncoming(){
		if (ScoreKeeper.score == scoreWhenCall*cycle) {
			enableSpawn = false;
			FindObjectOfType<BossSpawner> ().enableSpawn=true;
			cycle += 2;
		}
	}

	Transform NextFreePosition(){
		foreach (Transform childPosition in transform) {
			if (childPosition.childCount == 0) {
				return childPosition.transform;
			} 
		}
		return null;
	}
	bool IsAllMembersDead(){
		//transform.childCount;
		foreach (Transform childPosition in transform) {
			if (childPosition.childCount > 0) {
				return false;
			} 
		}
		return true;
	}
	void SpawnEnemies (){
		/*foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab,child.transform.position,new Quaternion(0,0,-180,0)) as GameObject; //rotate 180
			enemy.transform.parent= child; //make enemy attached to game Obj.(Obj will be created under "position" obj.)
		}*/
		if(enableSpawn)SpawnUntilFull ();
	}
	void SpawnUntilFull(){
		Transform freePosition = NextFreePosition ();
		if (freePosition) {
			GameObject enemy = Instantiate (enemyPrefab, freePosition.position, new Quaternion (0, 0, -180, 0)) as GameObject; //rotate 180
			enemy.transform.parent = freePosition;
		}
		if(NextFreePosition()) Invoke ("SpawnUntilFull", spawnDelay); //Prevent calling enemy all the time
	}
	void Move(){
		if (movingRight) {
			transform.Translate (Vector3.right * Time.deltaTime * houndSpeed);
		} else {
			transform.Translate(Vector3.left * Time.deltaTime * houndSpeed);
		}
		float rightEdgeFormation = transform.position.x + width * 0.5f;
		float leftEdgeFormation = transform.position.x - width * 0.5f;
		if (leftEdgeFormation < xmin ) {
			movingRight = true;
		}else if (rightEdgeFormation > xmax) {
			movingRight = false;
		}
	}
	void movableSpace(){ //restrict the hound in the game
		float newx = Mathf.Clamp (this.transform.position.x, xmin, xmax);
		this.transform.position = new Vector3 (newx, this.transform.position.y, this.transform.position.z);
	}
	void CameraRestrictEnemy(){ //restrict player by camera view
		Camera camera = Camera.main;
		float distance = transform.position.z - camera.transform.position.z;
		Vector3 rightBoundary = camera.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		Vector3 leftBoundary = camera.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		xmin = leftBoundary.x;
		xmax = rightBoundary.x;
	}
	public void OnDrawGizmos(){
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
}
