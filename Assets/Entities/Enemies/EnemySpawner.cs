using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	// Use this for initialization
	void Start () {
		GameObject enemy = Instantiate (enemyPrefab,new Vector3(0,0,0),new Quaternion(0,0,-180,0))/*as GameObject */; //rotate 180
		enemy.transform.parent= transform; //make enemy attached to game Obj.
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
