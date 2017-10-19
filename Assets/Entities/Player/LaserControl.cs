using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserControl : MonoBehaviour {
	public float damage = 100f;
	void OnBecameInvisible() { 
		Destroy(gameObject);
	}
	/* Or create a collider then put this code inside the collider
	 * Don't forget to create collider for projectile
	 void OnTriggerEnter2D(Collider2D col){
			Destroy(col.gameObject)
	}
	*/
	public float Hit(){
		Destroy (gameObject);
		return damage;
	}
}
