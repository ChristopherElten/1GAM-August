using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleGroundManager : MonoBehaviour {
	
	[SerializeField] private float xSpawnRange;
	[SerializeField] private float ySpawnRange;
	
	private GameObject alliesContainer;
	private GameObject opponentsContainer;
	
	[SerializeField] GameObject unitPrefab;
	[SerializeField] Transform allyPosition;
	[SerializeField] Transform opponentPosition;

	void Start(){
		alliesContainer = new GameObject();
		opponentsContainer = new GameObject();
		alliesContainer.name = "Allies";
		opponentsContainer.name = "Opponents";
	}
	
	public void SetupBattleGrounds(){
		Debug.Log("Set up battle grounds here...");
	}

	public void GenerateUnits<T>(LinkedList<T> allyActors, LinkedList<T> opponentActors) 
		where T : Unit
	{
		foreach(Unit ally in allyActors){
			initUnitModel(ally);
		}
		foreach(Unit opponent in opponentActors){
			initUnitModel(opponent);
		}
	}

	//Helpers
	public GameObject initUnitModel<T>(T unit)
		where T : Unit
	{
		GameObject newUnitGameObject = Instantiate(unitPrefab) as GameObject;
		UnitModel newUnitModel = newUnitGameObject.GetComponent<UnitModel>();
		SpriteRenderer spriteRenderer = newUnitGameObject.GetComponent<SpriteRenderer>();

		newUnitModel.SetUnit(unit);
		spriteRenderer.sprite = unit.getUnitSprite();

		if (unit.getIsOpponent() == true){
			newUnitGameObject.transform.parent = opponentsContainer.transform;
			newUnitGameObject.transform.position = PlaceUnitInGeneralArea(opponentPosition);
		} else {
			newUnitGameObject.transform.parent = alliesContainer.transform;
			newUnitGameObject.transform.position = PlaceUnitInGeneralArea(allyPosition);
		}

		return newUnitGameObject;
	}
	
	private Vector2 PlaceUnitInGeneralArea<U>(U areaCenter) 
		where U : Transform
	{
		Vector2 pos;
		pos.x = areaCenter.position.x + Random.Range(-xSpawnRange, xSpawnRange);
		pos.y = areaCenter.position.y + Random.Range(-ySpawnRange, ySpawnRange);
		return pos; 
	}

	//Gizmo for placing units
	void OnDrawGizmos(){
		Gizmos.color = new Color(1, 0, 0, 0.5F);
		Gizmos.DrawWireCube(allyPosition.position, new Vector3(xSpawnRange*2,ySpawnRange*2, 1));
		Gizmos.DrawWireCube(opponentPosition.position, new Vector3(xSpawnRange*2,ySpawnRange*2, 1));
	}
}
