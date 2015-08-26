using UnityEngine;
using System.Collections;

public class EnemySight : MonoBehaviour {

	public Transform target; 
	public int moveSpeed, rotationSpeed, maxdistance; 
	public Light aboveLight;

	private Transform myTransform;
	private Light l;
	private Vector3 startVector;
	private Rigidbody enemy;
	private float startIntensity, startAboveIntesity;
	
	void Awake(){
		myTransform = transform;
	}
	
	void Start () {
		GameObject player = GameObject.FindGameObjectWithTag("Player");
		target = player.transform;
		l = GetComponent<Light> ();
		enemy = GetComponent<Rigidbody> ();
		startVector = enemy.position;
		startIntensity = l.intensity;
		startAboveIntesity = aboveLight.intensity;
	}

	void Update () {

		if (Vector3.Distance (target.position, myTransform.position) < maxdistance) {
			/* Move towards target */
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (target.position - myTransform.position), rotationSpeed * Time.deltaTime);
			l.intensity = startIntensity;
			aboveLight.intensity = startAboveIntesity;
		} else {
			myTransform.rotation = Quaternion.Slerp (myTransform.rotation, Quaternion.LookRotation (startVector - myTransform.position), rotationSpeed * Time.deltaTime);
			l.intensity = 0;
			aboveLight.intensity = 0;
		}
		myTransform.position += myTransform.forward * moveSpeed * Time.deltaTime;
	}
}