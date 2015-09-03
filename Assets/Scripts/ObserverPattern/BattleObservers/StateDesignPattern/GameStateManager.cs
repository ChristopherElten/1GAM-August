using UnityEngine;
using System.Collections;

public class GameStateManager : GameSubject, IGameState {
	
	IGameState gameMenu;
	IGameState battleMenu;
	IGameState activeCombatState;
	IGameState executeCombatState;
	IGameState shop;

	IGameState gameState;
	
	public AudioObserver audioObserver;
	public AchievementObserver achievementObserver;
	public VisualEffectObserver visualEffectObserver;

	public GameStateManager(){

		gameMenu = new GameMenu(this);
		battleMenu = new BattleMenu(this);
		shop = new Shop(this);
		activeCombatState = new ActiveCombatState(this);
		executeCombatState = new ExecuteCombatState(this);

		//Initial State
		setGameState(gameMenu);
	}

	public void setGameState(IGameState newGameState){
		gameState = newGameState;
		GameEvent e = new GameEvent(gameState);
		notifyObserver(e);
	}
	
	public void SetObservers(AudioObserver audioObserver,AchievementObserver achievementObserver,VisualEffectObserver visualEffectObserver){
		this.audioObserver = audioObserver;
		this.achievementObserver = achievementObserver;
		this.visualEffectObserver = visualEffectObserver;
	}

	//IGameState
	public void Update(){
		gameState.Update();
	}
	public void Render(){
		gameState.Render();
	}
	public void OnEnter(){
		gameState.OnEnter();
	}
	public void OnExit(){
		gameState.OnExit();
	}
	public void Play(){
		gameState.Play();
	}
	public void Pause(){
		gameState.Pause();
	}
	public void Exit(){
		gameState.Exit();
	}

	public IGameState getGameMenuState(){return gameMenu;}
	public IGameState getBattleMenuState(){return battleMenu;}
	public IGameState getActiveCombatState(){return activeCombatState;}
	public IGameState getExecuteCombatState(){return executeCombatState;}
	public IGameState getShopState(){return shop;}
	
	public bool isGameStateEqual(IGameState otherGameState){
		return gameState == otherGameState;
	}

	//Observer
	public void OnNotify(GameEvent e){
//		Debug.Log("GameState Notified of some event. "  + e.eventDescription);
	}

}
