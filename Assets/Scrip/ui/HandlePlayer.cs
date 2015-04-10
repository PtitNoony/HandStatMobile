using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HandlePlayer : MonoBehaviour {

	public List<InputField> prerequis;

	public Button okButton;

	public Button posteButton;

	private bool validPlayer;

	public HandleTeam team;

	// Update is called once per frame
	void Update () {
		validPlayer = true;
		for(int i=0; i<prerequis.Count; i++)
		{
			if(prerequis[i].text.Length<=1)
				validPlayer = false;
		}
		int num1;
		bool res = int.TryParse(prerequis[2].text, out num1);
		if (res == false)
		{
			// String is not a number.
			validPlayer = false;
		}

		if(posteButton.transform.GetChild(0).GetComponent<Text>().text == "Séllectionner un poste")
			validPlayer = false;
		okButton.interactable = validPlayer;
	}

	public void createPlayer()
	{
		player result = new player ();

		result.prenom = prerequis [0].text;
		result.nom = prerequis [1].text;
		result.numero = int.Parse ( prerequis[2].text );

		team.idlePlayers.Add (result);
		team.RefreshPlayersButton ();
	}

	public void newPlayer()
	{
		for(int i=0; i<prerequis.Count; i++)
		{
			prerequis[i].text = "";
		}
		posteButton.transform.GetChild(0).GetComponent<Text>().text = "Séllectionner un poste";
	}

	public void editPlayer(GameObject caller)
	{
		player currPlayer = caller.GetComponent<HandleTeam>().getCurrentPlayer();
		prerequis [0].text = currPlayer.prenom ;
		prerequis [1].text = currPlayer.nom;
		prerequis[2].text = ""+currPlayer.numero;
		if(currPlayer.numero<=9)
			prerequis[2].text = "0"+currPlayer.numero;
		posteButton.transform.GetChild(0).GetComponent<Text>().text = currPlayer.positionActuelle.ToString();
	}
}
