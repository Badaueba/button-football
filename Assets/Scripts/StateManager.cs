using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public enum States {
		START,
		GOL,
		PLAYER_TURN
	}
		
	public States state;

	void Start() {
		state = States.START;
	}

}
