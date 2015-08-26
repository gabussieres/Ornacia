using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public float speed;
	public Rigidbody r;
	
	void Start () {
		r = GetComponent<Rigidbody> ();
	}
	
	void Update () {
		GameObject gameObject = GameObject.Find ("Player");
		if (gameObject == null) {
			return;
		}
		
		Vector3 diff =
			(gameObject.transform.position - this.transform.position);
		diff.Normalize ();
		diff *= speed;
		
		r.AddForce(new Vector3(diff.x, 0, diff.z));
	}
}
