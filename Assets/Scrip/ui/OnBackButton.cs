using UnityEngine;
using System.Collections;

public class OnBackButton : MonoBehaviour {

	public GameObject toEnable;
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape) ) 
		{
			toEnable.SetActive(true);
			gameObject.SetActive(false);
		}
	}
}
