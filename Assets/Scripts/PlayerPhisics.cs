using UnityEngine;
using System.Collections;

public class PlayerPhisics : MonoBehaviour {

	private StateManager stateManager;
	private PlayerSelectorManager playerSelectorManager;
	private Rigidbody body;
	private PowerManager powerManager;
	public float physicsForce = 10f;

	void Awake() {
		powerManager = Component.FindObjectOfType<PowerManager> ();
		stateManager = Component.FindObjectOfType<StateManager> ();
		playerSelectorManager = Component.FindObjectOfType<PlayerSelectorManager> ();

	}
	void FixedUpdate () {
		if (stateManager.state == StateManager.States.WAITING_FOR_PHYSICS) {
			if (playerSelectorManager.currentPlayer) {
				body = playerSelectorManager.currentPlayer.GetComponent<Rigidbody> ();		
				StartCoroutine( ApplyPhysics (body));
			} else {
				Debug.Log ("no body!");
			}
		}
	}
	IEnumerator ApplyPhysics(Rigidbody body) {
		Debug.Log ("Add Physics");
		body.velocity = body.transform.TransformDirection (
			Vector3.forward * powerManager.power * physicsForce);
		stateManager.state = StateManager.States.START;
		yield return new WaitForSeconds (2f);
		stateManager.state = StateManager.States.PLAYER_TURN;
	}
}
