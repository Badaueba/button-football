using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PowerManager : MonoBehaviour {

	private StateManager stateManager;
	private TurnManager turnManager;
	public PowerBar powerBarManager;
	private bool canThrow = false;
	private float input = 0.0f;
	private float lastInput = 0.0f;
	public float maxPowerBar;
	public float power  = 0f;

	void Awake () {
		stateManager = Component.FindObjectOfType<StateManager> ();
		turnManager = Component.FindObjectOfType<TurnManager> ();
		powerBarManager = Component.FindObjectOfType<PowerBar> ();
	}
	void Update() {
		
		//esta na hora de fazer a jogada? 
		if (stateManager.state == StateManager.States.PLAYER_TURN) {
			//atualiza powerbar
			PowerUpdate ();
			//teste pra ver se o player algum momento solta a lavanca
			//se o player soltar a lavanca significa que a vez dele foi concluida
			CanITrhow ();
		}
			
	}

	void PowerUpdate() {
		input = Input.GetAxis ("Vertical");
		//se ainda puder carregar o powerbar
		if (power < maxPowerBar) {
			//power sera adicionado passo a passo, de acordo com o input
			power = Mathf.MoveTowards(power, maxPowerBar * input, Time.deltaTime * maxPowerBar);
		}
		//aumentar/diminuir o tamanho da UI de acordo com power
		if (power > 0.0f) {
			powerBarManager.ChangeScale(new Vector3 (power, 11, 1));
		}
	}
	void CanITrhow() {
		//Teste para saber se o player soltou a power bar
		if (input < lastInput) {
			//conclui sua vez, agora muda o estado do jogo
			stateManager.state = StateManager.States.PLAYER_KICK;
			lastInput = 0.0f;
			input = 0.0f;
			return;
		}
		//atualiza o ultimo input do frame
		lastInput = input;
		Debug.Log ("Can i throw?: " + canThrow);
	}

}
