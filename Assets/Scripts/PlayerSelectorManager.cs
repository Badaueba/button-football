using UnityEngine;
using System.Collections;

public class PlayerSelectorManager : MonoBehaviour {

	private int selectedPlayer = 0;
	StateManager stateManager;
	TurnManager turnManager;
	GameObject currentTeam;
	public GameObject currentPlayer;
	public Light lightSelection;

	void Awake () {
		stateManager = Component.FindObjectOfType<StateManager> ();
		turnManager = Component.FindObjectOfType<TurnManager> ();

	}
	void Start() {
		Selection (0);
	}

	void Update() {
		
		if (stateManager.state == StateManager.States.PLAYER_TURN) {
			GetIndex ();
			if (selectedPlayer != -1) {
				Selection (this.selectedPlayer);
			}
		}
		//Debug
		if (Input.GetKeyUp (KeyCode.Escape))
			Application.LoadLevel (0);
	}

	void GetIndex(){
		if (Input.GetKeyDown (KeyCode.I) ||
			Input.GetKeyDown(KeyCode.Joystick1Button0 )) {
			selectedPlayer = 0;
			return;
		}
		if (Input.GetKeyUp (KeyCode.J) ||
			Input.GetKeyDown(KeyCode.Joystick1Button1 )) {
			selectedPlayer = 1;
			return;
		}
		if (Input.GetKeyUp (KeyCode.K) ||
			Input.GetKeyDown(KeyCode.Joystick1Button2 )) {
			selectedPlayer = 2;
			return;
		}
		if (Input.GetKeyUp (KeyCode.L) ||
			Input.GetKeyDown(KeyCode.Joystick1Button3 ))  {
			selectedPlayer = 3;
			return;
		}
		else {
			selectedPlayer = -1;
		}

	}

	public void Selection( int selectedPlayer) {
		Debug.Log ("team: " + turnManager.teamTurn);	

		foreach (Team team in GameObject.FindObjectsOfType<Team>()) {
			if (team.id == turnManager.teamTurn) {
				currentTeam = team.gameObject;
			}
		}
		GameObject[] players = currentTeam.GetComponent<Team> ().players;
		Debug.Log (players.Length);
		currentPlayer = players [selectedPlayer];

		Vector3 pos = new Vector3 (
			currentPlayer.transform.position.x, 0.8f, currentPlayer.transform.position.z);

		lightSelection.transform.position = pos;
		lightSelection.transform.SetParent (currentPlayer.transform);
		selectedPlayer = 0;
	}

}

