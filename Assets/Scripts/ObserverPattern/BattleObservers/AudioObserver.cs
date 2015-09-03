using UnityEngine;
using System.Collections;

public class AudioObserver : Observer {
	
	public void OnNotify(GameEvent e){
		if (e.sound != null){
			Debug.Log ("Some random Sound should be played. " + e.commandString);
		}
	}
}
