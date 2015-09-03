using UnityEngine;
using System.Collections;

public class UnitFactory {

	public Unit makeUnit(string newUnitId, bool isOpponent){
		Unit newUnit;

		if (newUnitId == "U"){
			newUnit = new UFOShip();
		} else if (newUnitId.Equals("R")){
			newUnit =  new RocketShip();
		} else if (newUnitId.Equals("B")){
			newUnit = new BigUFOShip();
		} else {
			return null;
		}

		newUnit.setIsOpponent(isOpponent);
		return newUnit;
	}
		
}
