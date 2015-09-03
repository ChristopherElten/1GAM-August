using UnityEngine;
using System.Collections;

public interface Subject {

	void Register(Observer o);
	void Unregister(Observer o);
	void notifyObserver(GameEvent e);

}
