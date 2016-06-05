using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerManager : MonoBehaviour {

	StateManager stateManager;
	TurnManager turnManager;
	public Transform powerPanel;
	public float maxPowerBar = 4f;
	float scaleY  = 0f;

	void Awake () {
		stateManager = Component.FindObjectOfType<StateManager> ();
		turnManager = Component.FindObjectOfType<TurnManager> ();
	}
	void Update() {
		if (stateManager.state == StateManager.States.PLAYER_TURN) {
			float input = Input.GetAxis ("Vertical");
			if (scaleY < maxPowerBar) {
				scaleY = Mathf.MoveTowards(scaleY, maxPowerBar * input , Time.deltaTime * maxPowerBar);
			}

			if (scaleY > 0f) {
				powerPanel.localScale = new Vector3 (scaleY, 11, 1);
			}

		}
	}

}
