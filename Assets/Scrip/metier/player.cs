using UnityEngine;
using System.Collections;

[System.Serializable]
public class player {

	public enum Poste
	{
		AILIER_DROIT,
		AILIER_GAUCHE,
		ARRIERE_DROIT,
		ARRIERE_GAUCHE,
		DEMI_CENTRE,
		GARDIEN,
		PIVOT,
		/**
     * used for opposing teams
     */
		UNDEFINED
	}
	
	public string prenom;
	public string nom;
	public int numero;
	public int twoMinSecondsRemaining = 0;
	public Poste positionPreferee;
	public Poste positionActuelle;
}
