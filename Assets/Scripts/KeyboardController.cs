using UnityEngine;
using System.Collections;

public class KeyboardController : MonoBehaviour {

	int selectedPlayer;
	StateManager stateManager;
	TurnManager turnManager;
	GameObject currentTeam;
	public Light lightSelection;

	void Awake () {
		stateManager = Component.FindObjectOfType<StateManager> ();
		turnManager = Component.FindObjectOfType<TurnManager> ();
	}
	void Update() {
		if (stateManager.state != StateManager.States.PLAYER_TURN) {
			SelectPlayer ();
			if (selectedPlayer != -1) {
				Selection (selectedPlayer);
			}
		}
	}
		
	void SelectPlayer(){
		if (Input.GetKeyDown (KeyCode.I)) {
			selectedPlayer = 0;
			return;
		}
		if (Input.GetKeyUp (KeyCode.J)) {
			selectedPlayer = 1;
			return;
		}
		if (Input.GetKeyUp (KeyCode.K)) {
			selectedPlayer = 2;
			return;
		}
		if (Input.GetKeyUp (KeyCode.L)) {
			selectedPlayer = 3;
			return;
		}
		else {
			selectedPlayer = -1;
		}

	}



	void Selection(int value) {
		Debug.Log("Selection");		
		foreach (Team team in GameObject.FindObjectsOfType<Team>()) {
			if (team.id == turnManager.teamTurn) {
				currentTeam = team.gameObject;
			}
		}
		Debug.Log (currentTeam.name);

	}

}

