using UnityEngine;
using System.Collections;

public class PlayerPhisics : MonoBehaviour {

	private PowerManager powerManager;
	private StateManager stateManager;
	private TurnManager turnManager;
	private PlayerSelectorManager playerSelectorManager;
	private PowerBar powerBarManager;
	private DirectionManager directionManager;
	private Rigidbody body;
	private Transform arrow;

	public float physicsForce;

	void Awake() {
		powerManager = Component.FindObjectOfType<PowerManager> ();
		stateManager = Component.FindObjectOfType<StateManager> ();
		turnManager = Component.FindObjectOfType<TurnManager> ();
		powerBarManager = Component.FindObjectOfType<PowerBar> ();
		playerSelectorManager = Component.FindObjectOfType<PlayerSelectorManager> ();
		directionManager = Component.FindObjectOfType<DirectionManager> ();
		arrow = directionManager.arrow;


	}
	void FixedUpdate () {
		if (stateManager.state == StateManager.States.PLAYER_KICK) {
			if (playerSelectorManager.currentPlayer) {
				body = playerSelectorManager.currentPlayer.GetComponent<Rigidbody> ();		
				StartCoroutine( ApplyPhysics (body));
			} else {
				Debug.Log ("no body!");
			}
		}
	}
	IEnumerator ApplyPhysics(Rigidbody body) {
		stateManager.state = StateManager.States.TURN_ENDING;	

		body.transform.localRotation = Quaternion.Euler (0, -90, 0);

		body.AddRelativeForce (arrow.forward * powerManager.power * physicsForce);

		yield return new WaitForSeconds (2f);
		powerBarManager.ChangeScale (new Vector3 (0, 11, 1));
		turnManager.ChangeTurn ();
	}  

}
