using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	// Use this for initialization
	private Text health;
	private PlayerController player;
	void Start () {
		health = GetComponent<Text> ();
		player = GameObject.FindObjectOfType<PlayerController> ();
	}
	void Update(){
		if (player.health == 3)
			health.text = "❤❤❤";
		if (player.health == 2)
			health.text = "❤❤";
		if (player.health == 1)
			health.text = "❤";
		if (player.health == 0)
			health.text = "";
	}
}
