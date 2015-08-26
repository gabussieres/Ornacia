using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	private GameObject g;
	private PlayerHealth HealthScript;
	private float missingHunger, maxHunger, currentHunger;
	private HUD HUDScript;

	public int count;

	void Start() {
		g = GameObject.Find("Player");
		HealthScript = g.GetComponent<PlayerHealth>();
		HUDScript = g.GetComponent<HUD>();
		maxHunger = HealthScript.maxHunger;
	}

	void OnTriggerEnter(Collider item) {

		if (item.gameObject.tag == "Plankton") {
			item.gameObject.SetActive (false);

			count += 1;
			HUDScript.SetCountText(count);

			if (count == 10){
				Win();
			}

			currentHunger = HealthScript.hunger;
			missingHunger = maxHunger - currentHunger;

			if (missingHunger < 20){
				HealthScript.hunger = maxHunger;
			} else if (currentHunger < maxHunger){
				HealthScript.hunger += 20;
			}
		}
	}

	void Win () {
		print ("win");
	}
}
