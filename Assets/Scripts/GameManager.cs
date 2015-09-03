using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour, Subject {

	public GameStateManager gameStateManager;
	public UnitFactoryManager unitFactoryManager;

	public AudioObserver audioObserver;
	public AchievementObserver achievementObserver;
	public VisualEffectObserver visualEffectObserver;

	void Awake () {

		audioObserver = new AudioObserver();
		achievementObserver = new AchievementObserver();
		visualEffectObserver = new VisualEffectObserver();

		gameStateManager = new GameStateManager();

		gameStateManager.SetObservers(audioObserver, achievementObserver, visualEffectObserver);
//		unitFactoryManager.Register(gameStateManager.getActiveCombatState());
//		unitFactoryManager.Register(gameStateManager.getExecuteCombatState());

	}

	//Subject
	protected ArrayList observers = new ArrayList();
	
	public void Register(Observer o){
		observers.Add(o);
	}
	public void Unregister(Observer o){
		observers.Remove(o);
	}
	public void notifyObserver(GameEvent e){
		foreach(Observer observer in observers){
			observer.OnNotify(e);
		}
	}
}
