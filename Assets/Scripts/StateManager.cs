using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public enum States {
		START,
		GOAL,
		PLAYER_TURN,
		WAITING_FOR_PHYSICS
	}
		
	public States state;

	void Start() {
		state = States.PLAYER_TURN;
	}

}
