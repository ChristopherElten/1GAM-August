using UnityEngine;
using System.Collections;

public class CombatManager : MonoBehaviour {

	public UnitFactoryManager unitFactoryManager;

	public void GenerateOpponent(){
		unitFactoryManager.CreateOpponentRocketShip();
	}
}
