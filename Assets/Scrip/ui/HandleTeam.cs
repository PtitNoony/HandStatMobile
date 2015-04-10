using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class HandleTeam : MonoBehaviour {

	public Text TeamTitle;

	public GameObject playerButtonPrefab;

	public List<player> idlePlayers;
	public List<GameObject> idlePlayersButton;
	public GameObject idlePlayerListParent;

	public List<player> activePlayers;
	public List<GameObject> activePlayersButton;
	public GameObject activePlaterListParent;

	public Button editButton;

	string lastPlayerClicked;

	public void Start()
	{
		//Debug only
		RefreshPlayersButton ();
	}



	public void Update()
	{
		if (lastPlayerClicked != null && lastPlayerClicked.Length>2)
			editButton.interactable = true;
		else
			editButton.interactable = false;
	}

	public void setTeamName(InputField teamNameField)
	{
		TeamTitle.text = "Equipe : " + teamNameField.text;
	}

	public void RefreshPlayersButton()
	{
		lastPlayerClicked = "";
		//delete old buttons
		if (idlePlayersButton != null && idlePlayersButton.Count > 0) {
			for(int i=0; i<idlePlayersButton.Count; i++)
			{
				Destroy(idlePlayersButton[i]);
			}
		}
		idlePlayersButton = new List<GameObject> ();

		if (activePlayersButton != null && activePlayersButton.Count > 0) {
			for(int i=0; i<activePlayersButton.Count; i++)
			{
				Destroy(activePlayersButton[i]);
			}
		}
		activePlayersButton = new List<GameObject> ();

		//create new buttons
		if( idlePlayers.Count>0 )
		{
			idlePlayerListParent.GetComponent<RectTransform>().sizeDelta = new Vector2(idlePlayerListParent.GetComponent<RectTransform>().sizeDelta.x, 25*idlePlayers.Count);
			for(int i=0; i<idlePlayers.Count; i++)
			{
				GameObject newButtons = (GameObject)GameObject.Instantiate(playerButtonPrefab);
				newButtons.transform.GetChild(0).GetComponent<Text>().text = idlePlayers[i].numero+" : "+idlePlayers[i].prenom+" "+idlePlayers[i].nom;
				newButtons.GetComponent<Button>().onClick.AddListener(() => {OnPlayerClick(newButtons.transform.GetChild(0).GetComponent<Text>().text);});
				newButtons.GetComponent<RectTransform>().SetParent( idlePlayerListParent.transform);
				newButtons.GetComponent<RectTransform>().localPosition = new Vector3(0,-(i-1)*50+idlePlayerListParent.GetComponent<RectTransform>().sizeDelta.y/2.0f,0);
				idlePlayersButton.Add(newButtons);
			}
		}

		if( activePlayers.Count>0 )
		{
			activePlaterListParent.GetComponent<RectTransform>().sizeDelta = new Vector2(activePlaterListParent.GetComponent<RectTransform>().sizeDelta.x, 25*activePlayers.Count);
			for(int i=0; i<activePlayers.Count; i++)
			{
				GameObject newButtons = (GameObject)GameObject.Instantiate(playerButtonPrefab);
				newButtons.transform.GetChild(0).GetComponent<Text>().text = activePlayers[i].numero+" : "+activePlayers[i].prenom+" "+activePlayers[i].nom;
				newButtons.GetComponent<Button>().onClick.AddListener(() => {OnPlayerClick(newButtons.transform.GetChild(0).GetComponent<Text>().text);});
				newButtons.GetComponent<RectTransform>().SetParent( activePlaterListParent.transform);
				newButtons.GetComponent<RectTransform>().localPosition = new Vector3(0,-(i-1)*50+activePlaterListParent.GetComponent<RectTransform>().sizeDelta.y/2.0f,0);
				activePlayersButton.Add(newButtons);
			}
		}
	}

	public void OnPlayerClick(string name)
	{
		//Debug.Log ("Click on a player "+name);
		lastPlayerClicked = name;
	}

	public void addPlayer()
	{
		int id = -1;

		for (int i=0; i<idlePlayersButton.Count; i++) 
		{
			if( idlePlayersButton[i].transform.GetChild(0).GetComponent<Text>().text == lastPlayerClicked )
				id = i;
		}

		if(id>=0)
		{
			activePlayers.Add(idlePlayers[id]);
			idlePlayers.RemoveAt(id);
			RefreshPlayersButton();
		}
	}

	public void removePlayer()
	{
		int id = -1;
		
		for (int i=0; i<activePlayersButton.Count; i++) 
		{
			if( activePlayersButton[i].transform.GetChild(0).GetComponent<Text>().text == lastPlayerClicked )
				id = i;
		}
		
		if(id>=0)
		{
			idlePlayers.Add(activePlayers[id]);
			activePlayers.RemoveAt(id);
			RefreshPlayersButton();
		}
	}

	public player getCurrentPlayer()
	{
		player result = new player();

		int id = -1;
		
		for (int i=0; i<idlePlayersButton.Count; i++) 
		{
			if( idlePlayersButton[i].transform.GetChild(0).GetComponent<Text>().text == lastPlayerClicked )
				id = i;
		}
		if (id >= 0) {
			result = idlePlayers[id];
		}

		id = -1;
		
		for (int i=0; i<activePlayersButton.Count; i++) 
		{
			if( activePlayersButton[i].transform.GetChild(0).GetComponent<Text>().text == lastPlayerClicked )
				id = i;
		}
		
		if(id>=0)
		{
			result = activePlayers[id];
		}

		return result;
	}
}
