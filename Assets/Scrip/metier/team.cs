using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class team {

	public enum Championship
	{
		NATIONAL_HOMME,
		NATIONAL_FEMME,
		M_18_NAT,
		NAT_3
	}

	public List<player> allPlayers;
	public List<player> activePlayers;
	public List<game> games;
	
	public string teamName;
	public Championship championship;
	public List<team> opponentTeams;
	//
	public Color preferedColor = Color.blue;
}
