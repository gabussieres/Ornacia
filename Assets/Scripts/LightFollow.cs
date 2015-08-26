using UnityEngine;
using System.Collections;

public class LightFollow : MonoBehaviour {
	
	public GameObject followThis;
	public Vector3 offset;
	public float lag;
	
	void LateUpdate () {
		if (this.followThis != null) {
			Vector3 desiredPositionOfCamera = this.followThis.transform.position + offset;
			this.transform.position += (desiredPositionOfCamera - this.transform.position) * lag;
			this.transform.LookAt(this.followThis.transform);
		}
	}
}
