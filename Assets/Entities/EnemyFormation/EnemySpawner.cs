﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab,child.transform.position,new Quaternion(0,0,-180,0)) as GameObject; //rotate 180
			enemy.transform.parent= child; //make enemy attached to game Obj.(Obj will be created under "position" obj.)
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
