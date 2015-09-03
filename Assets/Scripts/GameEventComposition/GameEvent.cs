using UnityEngine;
using System.Collections;

public class GameEvent {

	public string commandString;
	public BattleAction action;
	public Achievement achievement;
	public Sound sound;
	public Unit unit;
	public IGameState gameState;


	public GameEvent(string commandString){
		this.commandString = commandString;
	}

	public GameEvent(BattleAction action){
		this.action = action;
	}
	
	public GameEvent(Achievement achievement){
		this.achievement = achievement;
	}

	public GameEvent(Sound sound){
		this.sound = sound;
	}

	public GameEvent(Unit unit){
		this.unit = unit;
	}

	public GameEvent(IGameState gameState){
		this.gameState = gameState;
	}
}
