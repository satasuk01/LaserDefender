using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour {
	public GameObject projectile;
	public GameObject bossProjectile;
	public int health=2;
	public float projectileSpeed=10f;
	public float  shotPerSecond = 0.5f;
	public int scoreValue = 150;
	public AudioClip fireSound;
	public AudioClip deathSound;
	public bool isBoss = false;
	public bool spawnEnable = true;
	public GameObject smokeWhenDie;
	private ScoreKeeper scoreKeeper;
	void Start(){
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}
	void OnTriggerEnter2D(Collider2D collider){
		LaserControl projectile = collider.gameObject.GetComponent<LaserControl> ();
		if (projectile) { //projectile != null
			Debug.Log("Hit by a projectile");
			health -= projectile.Hit ();
			if (health <= 0) {
				AudioSource.PlayClipAtPoint (deathSound, transform.position,1f);
				SmokeWhenDie ();
				Destroy (gameObject);
				scoreKeeper.Score (scoreValue);
			}
		}
	}

	void Update(){
		float probability = Time.deltaTime * ((float)shotPerSecond+(FindObjectOfType<EnemySpawner>().cycle)*0.3f);
		if(Random.value < probability){ 
			EnemyAttack ();
			if (isBoss == true)
				BossAttack ();
		}

	}

	void EnemyAttack(){
		GameObject missile = Instantiate (projectile,transform.position,Quaternion.identity);
		missile.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projectileSpeed);
		AudioSource.PlayClipAtPoint (fireSound, transform.position,0.05f);
	}
	void BossAttack(){
		GameObject energyBall = Instantiate (bossProjectile,transform.position,Quaternion.identity);
		energyBall.GetComponent<Rigidbody2D> ().velocity = new Vector2 (1.5f, -projectileSpeed*0.7f);
		AudioSource.PlayClipAtPoint (fireSound, transform.position,0.05f);
		GameObject energyBall2 = Instantiate (bossProjectile,transform.position,Quaternion.identity);
		energyBall2.GetComponent<Rigidbody2D> ().velocity = new Vector2 (-1.5f, -projectileSpeed*0.7f);
		AudioSource.PlayClipAtPoint (fireSound, transform.position,0.05f);
		GameObject energyBall3 = Instantiate (bossProjectile,transform.position,Quaternion.identity);
		energyBall3.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, -projectileSpeed*0.7f);
		AudioSource.PlayClipAtPoint (fireSound, transform.position,0.05f);
	}
	void SmokeWhenDie(){
		GameObject smokePuff = Instantiate (smokeWhenDie, transform.position, Quaternion.identity);
	}
}
