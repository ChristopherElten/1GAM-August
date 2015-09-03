using UnityEngine;
using System.Collections;

public class GameMenu : IGameState {

	GameStateManager gameStateManager;

	public GameMenu(GameStateManager newGameState){
		gameStateManager = newGameState;
	}

	public void Update(){

	}
	public void Render(){

	}
	public void OnEnter(){
		Debug.Log("GameMenu OnEnter");
	}
	public void OnExit(){

	}
	public void Play(){
		gameStateManager.setGameState(gameStateManager.getActiveCombatState());
	}
	public void Pause(){
		
	}
	public void Exit(){
		gameStateManager.setGameState(gameStateManager.getGameMenuState());
	}

	//Observer Behavior
	public void OnNotify(GameEvent e){
//		Debug.Log("GameMenu Notified of some event. "  + e.eventDescription);
	}
}
