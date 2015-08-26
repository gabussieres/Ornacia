using UnityEngine;
using System.Collections;

public class FakeLight : MonoBehaviour {

	private Light l;

	void Start () {
		l = GetComponent<Light>();
		l.gameObject.SetActive (false);
	}
}