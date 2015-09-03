using UnityEngine;
using System.Collections;

public class UIController : MonoBehaviour {

	public Canvas title;
	public Canvas combat;

	private CombatCanvas combatCanvas;

	public CombatCanvas getCombatCanvas(){ return combatCanvas;}

	void Awake(){
		combatCanvas = combat.GetComponent<CombatCanvas>();
	}

	void Start () {
		TitleCanvas();
	}

	public void TitleCanvas(){
		combat.enabled = false;
		title.enabled = true;
	}

	public void CombatCanvas(){
		combat.enabled = true;
		title.enabled = false;
	}
}
