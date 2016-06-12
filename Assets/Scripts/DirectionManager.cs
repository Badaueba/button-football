using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DirectionManager : MonoBehaviour {

	public Vector3 rotateDirection { get; private set;}
	public Vector3 translateDirection;
	public Transform arrow;
	private StateManager stateManager;
	PlayerSelectorManager playerSelectorManager;
	public float speed;

	void Awake() {
		stateManager = Component.FindObjectOfType<StateManager> ();
	}
	void Update() {
		if (stateManager.state == StateManager.States.PLAYER_TURN ) {
			ChangeDirection ();
		}
			
	}

	void ChangeDirection () {
		float y = Input.GetAxis ("Horizontal");
		if (y != 0.0f)
			ApplyRotation (y);

	}

	void ApplyRotation ( float axis ) {

		rotateDirection = new Vector3 (0, axis * speed * Time.deltaTime , 0);
		arrow.Rotate(rotateDirection);

	}


}
