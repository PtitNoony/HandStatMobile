using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class game {

	public static int MIN_PLAYERS_PER_MATCH = 6;
	public static int MAX_PLAYERS_PER_MATCH = 12;
	public static int HALF_TIME_DURATION = 30 * 60 * 1000;

	private team homeTeam;
	private team awayTeam;
	private string gameDate;

	private List<player> homePlayers;
	private List<player> awayPlayers;
}
