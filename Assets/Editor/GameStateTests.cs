using System;
using NUnit.Framework;

public class GameStateTests {

	[Test]
	public void InitialState(){

		GameStateManager gameStateManager  = new GameStateManager();

		//Start at GameMenu
		Assert.That(gameStateManager.isGameStateEqual(gameStateManager.getGameMenuState()));
	}

	[Test]
	public void StartGame(){

		GameStateManager gameStateManager  = new GameStateManager();

		//Enter ActiveCombat State On Play Event
		gameStateManager.Play();

		Assert.That(gameStateManager.isGameStateEqual(gameStateManager.getActiveCombatState()));
	}

	[Test]
	public void EnterBattleMenuStateFromActiveCombatState(){
		
		GameStateManager gameStateManager  = new GameStateManager();
		
		//Enter BattleMenu State On Pause Event From ActiveCombat
		gameStateManager.setGameState(gameStateManager.getActiveCombatState());

		gameStateManager.Pause();
		
		Assert.That(gameStateManager.isGameStateEqual(gameStateManager.getBattleMenuState()));
	}

	[Test]
	public void EnterShopStateFromBattleMenuState(){

		GameStateManager gameStateManager  = new GameStateManager();
		
		//Enter Shop State On Pause Event From BattleMenu
		gameStateManager.setGameState(gameStateManager.getBattleMenuState());
		
		gameStateManager.Pause();
		
		Assert.That(gameStateManager.isGameStateEqual(gameStateManager.getShopState()));
	}

	[Test]
	public void EnterActiveCombatStateFromShopState(){
		
		GameStateManager gameStateManager  = new GameStateManager();
		
		//Enter Combat State On Play Event From Shop
		gameStateManager.setGameState(gameStateManager.getShopState());
		
		gameStateManager.Play();
		
		Assert.That(gameStateManager.isGameStateEqual(gameStateManager.getActiveCombatState()));
	}
	
	[Test]
	public void EnterActiveCombatStateFromExecuteCombatState(){

		GameStateManager gameStateManager  = new GameStateManager();

		gameStateManager.setGameState(gameStateManager.getExecuteCombatState());

		//Enter ActiveCombatState after Pause Event From Combat

		gameStateManager.Pause();

		Assert.That(gameStateManager.isGameStateEqual(gameStateManager.getActiveCombatState()));
	}
	
	[Test]
	public void EnterExecuteActionsCombatStateStateAfterActiveCombatStateEnd(){
		
		GameStateManager gameStateManager  = new GameStateManager();
		
		gameStateManager.setGameState(gameStateManager.getActiveCombatState());

		//Enter ExecuteActionsCombatState after Play Events by ActiveCombatState 
		gameStateManager.Play();

		Assert.That(gameStateManager.isGameStateEqual(gameStateManager.getExecuteCombatState()));
	}
}
