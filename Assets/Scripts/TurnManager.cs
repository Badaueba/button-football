using UnityEngine;
using System.Collections;

public class TurnManager : MonoBehaviour {
	
	//posse da bola
	public int teamTurn {get; private set;}
	private StateManager stateManager;
	private PlayerSelectorManager playerSelector;
	void Awake () {
		stateManager = Component.FindObjectOfType<StateManager> ();
		playerSelector = Component.FindObjectOfType<PlayerSelectorManager> ();
	}

	void Start () {
		teamTurn = SortTurn ();
		Debug.Log ("SortTurn: " + teamTurn);
	}
	//sortear posse de bola
	int SortTurn () {
		return Random.Range (0, 2);	
	}
	//trocar a posse de bola
	public void ChangeTurn () {
		if (this.teamTurn == 0) this.teamTurn = 1;
		else this.teamTurn = 0;
		stateManager.state = StateManager.States.PLAYER_TURN;
		playerSelector.Selection ();
		Debug.Log ("ChangeTurn: " + teamTurn);

	}
		
}
