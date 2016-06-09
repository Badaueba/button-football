using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DirectionManager : MonoBehaviour {

	public Vector3 direction { get; private set;}
	public Transform arrow;
	private StateManager stateManager;
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
		
		direction = new Vector3 (0, axis * speed * Time.deltaTime , 0);

		//arrow.rotation = Quaternion.Lerp (arrow.rotation, Quaternion.Euler (direction),
		//	360 * Time.deltaTime);
		arrow.Rotate(direction);
		Debug.Log ("Direction: " + direction);
	}


}
