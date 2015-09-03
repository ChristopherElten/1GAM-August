using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActiveUnitManager : MonoBehaviour, Observer, Subject {

	[SerializeField]LinkedList<Unit> opponentActors = new LinkedList<Unit>();
	[SerializeField]LinkedList<Unit> allyActors = new LinkedList<Unit>();
	[SerializeField]LinkedListNode<Unit> currentAllyActor;
	[SerializeField]LinkedListNode<Unit> currentOpponentActor;

	//List for battle actions
	[SerializeField]List<BattleAction> battleActions = new List<BattleAction>();

	public LinkedList<Unit> getOpponentActors(){ return opponentActors;}
	public LinkedList<Unit> getAllyActors(){ return allyActors;}
	public LinkedListNode<Unit> getCurrentAllyActor(){ 
		if (currentAllyActor == null) { NextAllyActor();}
		return currentAllyActor;
	}
	public LinkedListNode<Unit> getCurrentOpponentActor(){ 
		if (currentOpponentActor == null) { NextOpponentActor();}
		return currentOpponentActor;
	}
	public List<BattleAction> getActions(){ return battleActions;}
	

	public void AddActor<T>(T newUnit) where T : Unit
	{
		LinkedListNode<Unit> unit = new LinkedListNode<Unit>(newUnit);
		if (newUnit.getIsOpponent()){
			opponentActors.AddLast(unit);
		} else {
			allyActors.AddLast(unit);
		}

		//Subject-Observer
		newUnit.Register(this);

	}
	public void RemoveActor<T>(T unit) where T : Unit
	{
		//TODO: EXAMINE THIS LATER
		//Subject-Observer
//		unit.Unregister(this);

		if (unit.getIsOpponent()){
			opponentActors.Remove(unit);
		} else {
			allyActors.Remove(unit);
		}

		if (opponentActors.Count <= 0){
			Debug.Log("Bean All");
			ClearedOpponents();
		}

	}
	public void NextAllyActor(){
		if (allyActors.First == null) {
			Debug.Log("No Ally Actors Present");
			return;
		}
		
		if (currentAllyActor != null){
			currentAllyActor.Value.setIsSelected(false);
			if (currentAllyActor.Next != null){
				currentAllyActor = currentAllyActor.Next;
			} else {
				currentAllyActor = allyActors.First;
			} 
		} else {
			currentAllyActor = allyActors.First;
		}
		currentAllyActor.Value.setIsSelected(true);
	}
	public void NextOpponentActor(){
		if (opponentActors.First == null) {
			Debug.Log("No Opponent Actors Present");
			return;
		}
		
		if (currentOpponentActor != null){
			currentOpponentActor.Value.setIsSelected(false);
			if (currentOpponentActor.Next != null){
				currentOpponentActor = currentOpponentActor.Next;
			} else {
				currentOpponentActor = opponentActors.First;
			} 
		} else {
			currentOpponentActor = opponentActors.First;
		}
		currentOpponentActor.Value.setIsSelected(true);
	}
	public void PreviousAllyActor(){
		if (allyActors.First == null) {
			Debug.Log("No Ally Actors Present");
			return;
		}

		if (currentAllyActor != null){
			currentAllyActor.Value.setIsSelected(false);
			if (currentAllyActor.Previous != null){
				currentAllyActor = currentAllyActor.Previous;
			} else {
				currentAllyActor = allyActors.Last;
			} 
		} else {
			currentAllyActor = allyActors.Last;
		}
		currentAllyActor.Value.setIsSelected(true);
	}
	public void PreviousOpponentActor(){
		if (opponentActors.First == null) {
			Debug.Log("No Opponent Actors Present");
			return;
		}
		
		if (currentOpponentActor != null){
			currentOpponentActor.Value.setIsSelected(false);
			if (currentOpponentActor.Previous != null){
				currentOpponentActor = currentOpponentActor.Previous;
			} else {
				currentOpponentActor = opponentActors.Last;
			} 
		} else {
			currentOpponentActor = opponentActors.Last;
		}
		currentOpponentActor.Value.setIsSelected(true);
	}
	public void AddAction<T>(T newAction) where T : BattleAction{
		battleActions.Add(newAction);
	}
	public void ClearActions(){
		battleActions.Clear();
	}
	//GetRandomTarget
	public Unit GetRandomUnitTarget(bool targetOpponent){
//		if (targetOpponent){
//			return opponentActors[Random.Range(0, opponentActors.Count)];
//		} else {
//			return allyActors[Random.Range(0, allyActors.Count)];
//		}
		return allyActors.First.Value;
	}

	//Events
	public void ClearedOpponents(){
		GameEvent clearedOpponentsEvent = new GameEvent("Cleared Opponents");
		notifyObserver(clearedOpponentsEvent);
	}

	//Observer
	public void OnNotify(GameEvent e){

		if (e.unit != null){
			//Check if unit passed should be removed (Died/Destroyed)
			if (e.unit.getHealth() <= 0){
				RemoveActor(e.unit);
			}
		}
		if (e.action != null){
			AddAction(e.action);
		}
	}

	//Subject
	private ArrayList observers = new ArrayList();
	
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
