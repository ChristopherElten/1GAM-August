using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UnitModel : MonoBehaviour {

	private Unit unit;
	private SpriteRenderer spriteRenderer;

	//UI Displays
	[SerializeField]GameObject selectedIcon;
	[SerializeField]GameObject targetedIcon;

	void Start(){
		spriteRenderer = GetComponent<SpriteRenderer>();
	}

	public Unit getUnit(){ return unit;}
	public void SetUnit(Unit unit){ this.unit = unit;}

	void Update(){

		if (unit.getIsTargeted()){
			targetedIcon.SetActive(true);
		} else {
			targetedIcon.SetActive(false);
		}

		if (unit.getIsSelected()){
			selectedIcon.SetActive(true);
		} else {
			selectedIcon.SetActive(false);
		}

		if (unit.getHealth() <= 0){
			GameEvent unitDiedEvent = new GameEvent(unit);
			unit.notifyObserver(unitDiedEvent);
			Destroy(gameObject);
		}
	}

}
