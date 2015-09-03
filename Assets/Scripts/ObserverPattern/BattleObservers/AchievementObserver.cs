using UnityEngine;
using System.Collections;

public class AchievementObserver : Observer {

	public void OnNotify(GameEvent e){

		if (e.achievement != null){
			Debug.Log ("Achievement Unlocked: " + e.achievement.description);
		}
	}
}
