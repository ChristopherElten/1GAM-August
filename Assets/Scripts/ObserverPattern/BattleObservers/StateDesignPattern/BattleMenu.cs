using UnityEngine;
using System.Collections;

public class BattleMenu : IGameState {

	GameStateManager gameStateManager;
	
	public BattleMenu(GameStateManager newGameState){
		gameStateManager = newGameState;
	}

	public void Update(){
		
	}
	public void Render(){
		
	}
	public void OnEnter(){
		Debug.Log("BattleMenu OnEnter");
	}
	public void OnExit(){

	}
	public void Play(){
		gameStateManager.setGameState(gameStateManager.getActiveCombatState());
	}
	public void Pause(){
		gameStateManager.setGameState(gameStateManager.getShopState());
	}
	public void Exit(){
		gameStateManager.setGameState(gameStateManager.getGameMenuState());
	}

	//Observer Behavior
	public void OnNotify(GameEvent e){
//		Debug.Log("BattleMenu Notified of some event. "  + e.eventDescription);
	}
}
