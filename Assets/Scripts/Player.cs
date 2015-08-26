using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	public float speed, rotateSpeed, ySpeed, waterResistance;

	private Rigidbody r;
	private GameObject g;
	private PlayerHealth HealthScript;

	void Start () {
		r = GetComponent<Rigidbody> ();
		g = GameObject.Find("Player");
		HealthScript = g.GetComponent<PlayerHealth>();
	}
	
	void Update () {
		if (HealthScript.health > 0) { /* Player is alive */

			/* Rotate */
			if (Input.GetKey ("a")) {
				transform.Rotate (Vector3.down * rotateSpeed * Time.deltaTime);
			} else if (Input.GetKey ("d")) {
				transform.Rotate (Vector3.up * rotateSpeed * Time.deltaTime);
			}
			/* Go forward */
			transform.position += Input.GetAxis ("Vertical") * transform.forward * speed;
			
			if (Input.GetButton ("Fire1")) {
				Dive ();
			}
			if (Input.GetButton ("Fire2") && r.position.y < 0) {
				Jump ();
			}
		}
		
		/* Water Resistance */
		if (r.velocity.y != 0) {
			r.AddForce(Vector3.down * waterResistance * r.velocity.y / ySpeed);
		}
	}
	
	void Dive() { 
		GetComponent<Rigidbody>().AddForce(Vector3.down * ySpeed);
	}
	
	void Jump() { 
		GetComponent<Rigidbody>().AddForce(Vector3.up * ySpeed);
	}
	
	void OnCollisionEnter(Collision c) {
		/* Stops rotation on collision */
		r.freezeRotation = true;
	}
	
	void OnCollisionStay(Collision c) {
		/* Stops rotation on collision */
		r.freezeRotation = true;
	}
}	