using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HUD : MonoBehaviour {
	
	public Text healthText, hungerText, countText;

	private float health, hunger;
	private GameObject g;
	private PlayerHealth HealthScript;
	private PickUp PickUpScript;

	void Start () {
		g = GameObject.Find("Player");
		HealthScript = g.GetComponent<PlayerHealth>();
		PickUpScript = g.GetComponent<PickUp> ();

		healthText.text = "Health: " + health.ToString ();
		hungerText.text = "Hunger: " + hunger.ToString ();
	}

	void Update () {
		health = (int) HealthScript.health;
		hunger = (int) HealthScript.hunger;

		healthText.text = "Health: " + health.ToString ();
		hungerText.text = "Hunger: " + hunger.ToString ();
	}

	public void SetCountText(int count) {
		countText.text = "Planktons: " + count.ToString ();
	}	
}
