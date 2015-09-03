using UnityEngine;
using System.Collections;

public class Shop : IGameState {

	GameStateManager gameStateManager;
	
	public Shop(GameStateManager newGameState){
		gameStateManager = newGameState;
	}

	public void Update(){
		
	}
	public void Render(){
		
	}
	public void OnEnter(){
		Debug.Log("Shop OnEnter");
	}
	public void OnExit(){
	
	}
	public void Play(){
		gameStateManager.setGameState(gameStateManager.getActiveCombatState());
	}
	public void Pause(){
		gameStateManager.setGameState(gameStateManager.getBattleMenuState());
	}
	public void Exit(){
		gameStateManager.setGameState(gameStateManager.getGameMenuState());
	}

	//Observer Behavior
	public void OnNotify(GameEvent e){
		Debug.Log("Shop Notified of some event. "  + e.commandString);
	}
}
