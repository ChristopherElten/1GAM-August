using UnityEngine;
using System.Collections;

public class UnitFactoryManager : MonoBehaviour, Subject {
	
	private UnitFactory unitFactory;

	void Awake(){
		unitFactory = new UnitFactory();
	}

	//CREATING GAME OBJECT
	private Unit CreateUnit(string unitId, bool isOpponent){

		Unit newUnit = unitFactory.makeUnit(unitId, isOpponent);
		//Sending Notification of new unit
		GameEvent e = new GameEvent(newUnit);
		notifyObserver(e);

		return newUnit;
	}

	//Unit Factory public handlers (THINK: Game shop button options)
	public Unit CreateAllyRocketShip(){
		return CreateUnit("R", false);
	}
	public Unit CreateOpponentRocketShip(){
		return CreateUnit("R", true);
	}
	public Unit CreateAllyUFO(){
		return CreateUnit("U", false);
	}
	public Unit CreateOpponentUFO(){
		return CreateUnit("U", true);
	}
	public Unit CreateAllyBigUFOShip(){
		return CreateUnit("B", false);
	}
	public Unit CreateOpponentBigUFOShip(){
		return CreateUnit("B", true);
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
