using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
	public GameObject enemyPrefab;
	public float width = 10f,height = 5f;
	public float houndSpeed = 2f;
	private float xmax,xmin;
	private bool movingRight = true;
	// Use this for initialization
	void Start () {
		CameraRestrictEnemy ();
		foreach (Transform child in transform) {
			GameObject enemy = Instantiate (enemyPrefab,child.transform.position,new Quaternion(0,0,-180,0)) as GameObject; //rotate 180
			enemy.transform.parent= child; //make enemy attached to game Obj.(Obj will be created under "position" obj.)
		}
	}

	// Update is called once per frame
	void Update () {
		Move ();
	}

	void Move(){
		if (movingRight) {
			transform.Translate (Vector3.right * Time.deltaTime * houndSpeed);
		} else {
			transform.Translate(Vector3.left * Time.deltaTime * houndSpeed);
		}
		float rightEdgeFormation = transform.position.x + width * 0.5f;
		float leftEdgeFormation = transform.position.x - width * 0.5f;
		if (leftEdgeFormation < xmin || rightEdgeFormation > xmax) {
			movingRight = !movingRight;
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
