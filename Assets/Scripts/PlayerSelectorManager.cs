﻿using UnityEngine;
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
		Selection (selectedPlayer);
	}
	void Update() {
		if (stateManager.state == StateManager.States.PLAYER_TURN) {
			GetIndex ();
			if (selectedPlayer != -1) {
				Selection (selectedPlayer);
			}
		}
	}

	void GetIndex(){
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
		foreach (Team team in GameObject.FindObjectsOfType<Team>()) {
			if (team.id == turnManager.teamTurn) {
				currentTeam = team.gameObject;
			}
		}
		currentPlayer = currentTeam.GetComponent<Team>().players [selectedPlayer];
		Vector3 pos = new Vector3 (
			currentPlayer.transform.position.x, 0.8f, currentPlayer.transform.position.z);

		lightSelection.transform.position = pos;
		lightSelection.transform.SetParent (currentPlayer.transform);

		Debug.Log (currentPlayer.name);

	}

}

