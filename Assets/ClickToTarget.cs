using UnityEngine;
using System.Collections;

public class ClickToTarget : MonoBehaviour {

	Unit unit;
	ActiveUnitManager activeUnitManager;

	void Start(){
		unit = GetComponent<UnitModel>().getUnit();
	}

	void OnMouseDown(){
		unit.notifyObserver(new GameEvent(unit));
	}

}
