using UnityEngine;
using System.Collections;

public class ActiveCombatState : IGameState, ICombatState {
	
	GameStateManager gameStateManager;
	
	public ActiveCombatState(GameStateManager newCombatStateManager){
		gameStateManager = newCombatStateManager;
	}


	//IGameState
	public void Update(){
		
	}
	public void Render(){
		
	}
	public void OnEnter(){
		Debug.Log("ActiveCombatState OnEnter");
	}
	public void OnExit(){
		Debug.Log("ActiveCombatState OnExit");
	}
	public void Play(){
		Action();
		gameStateManager.setGameState(gameStateManager.getExecuteCombatState());
	}
	public void Pause(){
		gameStateManager.setGameState(gameStateManager.getBattleMenuState());
	}
	public void Exit(){
		gameStateManager.setGameState(gameStateManager.getGameMenuState());
	}

	//ICombatState
	public void Action(){
//		combatStateManager.InvokeActionsFromActors();
	}
	public void End(){
		//Hand off to execute queued actions
//		gameStateManager.setCombatTurn(combatStateManager.getExecuteActionsCombatState());
	}

	//Observer Behavior
	public void OnNotify(GameEvent e){
		Debug.Log("ActiveCombatState Notified of some event. "  + e.commandString);
	}
}
