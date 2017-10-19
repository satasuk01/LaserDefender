using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public float health;
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
}
