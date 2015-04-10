using UnityEngine;
using System.Collections;

public class FireFxActivation : MonoBehaviour {

	public GameObject fireObject;

	public GameObject BallonObject;
	
	// Update is called once per frame
	void Update () {
		fireObject.SetActive (BallonObject.activeInHierarchy);
	}
}
