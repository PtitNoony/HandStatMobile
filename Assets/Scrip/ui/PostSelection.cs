using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PostSelection : MonoBehaviour {

	public GameObject previousMenu;
	public Button CallerButton;

	public void OnPostSelected(Button caller)
	{
		CallerButton.transform.GetChild (0).GetComponent<Text> ().text = caller.transform.GetChild (0).GetComponent<Text> ().text;
		previousMenu.SetActive (true);
		gameObject.SetActive (false);
	}
}
