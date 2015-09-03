using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Combat : Observer {

	//List of actions
	List<BattleAction> actions = new List<BattleAction>();

	//Actions storage
	private void AddAction(BattleAction newAction){
		actions.Add(newAction);
	}

	//Observer
	public void OnNotify(GameEvent e){
		//Check for string commands
		if (e.commandString != null){
			if (e.commandString == "E"){
//				End();
//				Action();
			} else if (e.commandString == "A"){
//				InvokeActionsFromActors();
			}
		}

		//If Combat Observer detects a unit, store
		if (e.unit != null){
//			AddActor(e.unit);
		}

		//If Combat Observer detects an action, store
		if (e.action != null){
			AddAction(e.action);
			Debug.Log(actions.Count + " action(s) in list.");
		}
	}
}
