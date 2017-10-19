using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public GameObject projectile;
	public float health=150f;
	public float projectileSpeed=10f;
	public float  shotPerSecond = 0.5f;
	void OnTriggerEnter2D(Collider2D collider){
		LaserControl projectile = collider.gameObject.GetComponent<LaserControl> ();
		if (projectile) { //projectile != null
			Debug.Log("Hit by a projectile");
			health -= projectile.Hit ();
			if (health <= 0) {
				Destroy (gameObject);
			}
		}
	}

	void Update(){
		float probability = Time.deltaTime * shotPerSecond;
		if(Random.value < probability){ 
			EnemyAttack ();
		}
	}

	void EnemyAttack(){
		GameObject missile = Instantiate (projectile,transform.position,Quaternion.identity);
		missile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projectileSpeed);
	}
}
