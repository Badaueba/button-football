using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {
	
	//posse da bola
	public int teamTurn {get; private set;}

	void Start () {
		teamTurn = SortTurn ();
		Debug.Log ("SortTurn: " + teamTurn);
	}
	//sortear posse de bola
	int SortTurn () {
		return Random.Range (0, 2);	
	}
	//trocar a posse de bola
	void ChangeTurn () {
		if (this.teamTurn == 0) this.teamTurn = 1;
		else this.teamTurn = 0;
	}
		
}
