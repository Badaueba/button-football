using UnityEngine;
using System.Collections;

public class GoalManager : MonoBehaviour {

	void Start () {
	
	}
	void Update () {
	
	}

	void OnTriggerEnter (Collider collider) {
		if (collider.gameObject.tag == "GoalArea") {
			Debug.Log ("GoalArea: Gol");
		}
	}
}
