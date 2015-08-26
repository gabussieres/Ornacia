using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour {
	
	public GameObject followThis;
	public float lag;
	public Vector3 offset;
	
	void Start() {
		offset = followThis.transform.position - transform.position;
	}
	
	void LateUpdate() {
		float currentAngle = transform.eulerAngles.y;
		float desiredAngle = followThis.transform.eulerAngles.y;
		float angle = Mathf.LerpAngle(currentAngle, desiredAngle, Time.deltaTime * lag);
		
		Quaternion rotation = Quaternion.Euler(0, angle, 0);
		transform.position = followThis.transform.position - (rotation * offset);
		
		transform.LookAt(followThis.transform);
	}
}