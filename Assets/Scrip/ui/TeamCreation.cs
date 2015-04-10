using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class TeamCreation : MonoBehaviour {

	public InputField teamName;

	public List<Toggle> championships;

	public Button CreateTeamButton;
	
	// Update is called once per frame
	void Update () {

		bool toogleOk = false;
		for (int i=0; i<championships.Count; i++)
			if (championships [i].isOn)
				toogleOk = true;

		if (toogleOk && teamName.text.Length >= 4) 
		{
			CreateTeamButton.interactable = true;
		}
		else
		{
			CreateTeamButton.interactable = false;
		}

	}

	public void OnValueChange(Toggle caller)
	{
		if (caller.isOn) {

			for(int i=0; i<championships.Count; i++)
			{
				if(championships[i] != caller)
					championships[i].isOn = false;
			}

		}
	}
}
