using UnityEngine;
using System.Collections;

public class StateManager : MonoBehaviour {

	public enum States {
		START,
		GOAL,
		PLAYER_TURN,
		PLAYER_KICK,
		TURN_ENDING
	}
		
	public States state;

	void Start() {
		state = States.PLAYER_TURN;
		StartCoroutine (DebugState ());
	}

	//Debug
	public IEnumerator DebugState () {
		while (true) {
			Debug.Log (state);
			yield return new WaitForSeconds (1.5f);	
		}

	}
}
