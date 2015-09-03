using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ExecuteCombatState : IGameState, ICombatState {
	
	GameStateManager gameStateManager;
	List<BattleAction> actions;

	public ExecuteCombatState(GameStateManager newCombatStateManager){
		gameStateManager = newCombatStateManager;
	}

	public void SetActions(List<BattleAction> actions){
		this.actions = actions;
	}
	
	//IGameState
	public void Update(){
		
	}
	public void Render(){
		
	}
	public void OnEnter(){
		Debug.Log("ExecuteCombatState OnEnter");
		Action();
	}
	public void OnExit(){
		
	}
	public void Play(){
		gameStateManager.setGameState(gameStateManager.getActiveCombatState());
	}
	public void Pause(){
		gameStateManager.setGameState(gameStateManager.getActiveCombatState());
	}
	public void Exit(){
		gameStateManager.setGameState(gameStateManager.getGameMenuState());
	}
	
	//ICombatState
	public void Action(){
		//Running through the actions ready to be executed
		int i = 1;
		if (actions == null){ 
			Debug.Log("No Actions to be Taken");
			return;
		}
		foreach(BattleAction action in actions){
			Debug.Log(i + ". Action in list: " + action.description + " was executed!");
			//Executing Actions
			action.Execute();
			i++;
		}
		//Empties list of actions
		actions.Clear();
	}

	public void End(){
		Debug.Log("No more actions to be taken");
		//Hand off to players turn
		gameStateManager.setGameState(gameStateManager.getActiveCombatState());
	}

	//Observer Behavior
	public void OnNotify(GameEvent e){
		Debug.Log("ExecuteCombatState Notified of some event. "  + e.commandString);
	}
}
