using UnityEngine;
using System.Collections;

public class GameSubject : Subject {

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
