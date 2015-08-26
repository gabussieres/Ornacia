using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour {

	public float health, maxHealth, hunger, maxHunger, hungerDamage, range;
	public Text GameOver;

	private Rigidbody r;
	private Light l;

	void Start() {
		r = GetComponent<Rigidbody> ();
		l = GetComponent<Light> ();
		GameOver.text = "";
		health = maxHealth;
		hunger = maxHunger;
	}

	void Update() {
		l.range = range * hunger / 100f; 

		if (health > 0) {
			if ((hunger >= 80) && (health < maxHealth)) {
				health += 0.1f;
			} else if (hunger <= 0){
				TakeDamage (0.1f);
			} else {
				hunger -= 0.01f;
			}
		}
	}

	void OnCollisionEnter(Collision c){
		if (c.collider.name == "Enemy"){
			TakeDamage(10);
		}
	}

	void TakeDamage(float damage){
		health -= damage;
		if (health <= 0) {
			Dead ();
		}
	}

	void Dead(){
		GameOver.text = "Game Over";
		r.useGravity = true;
		r.velocity = new Vector3(0, r.velocity.y, 0);
	}
}
