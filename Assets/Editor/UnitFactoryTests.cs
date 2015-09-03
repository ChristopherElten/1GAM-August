using System;
using NUnit.Framework;

public class UnitFactoryTests {

	[Test]
	public void CreateUFOShip(){
		
		UnitFactory unitFactory  = new UnitFactory();

		Unit unit = unitFactory.makeUnit("U", false);
		
		Assert.IsInstanceOf<UFOShip>(unit);
	}

	[Test]
	public void CreateRocketShip(){
		
		UnitFactory unitFactory  = new UnitFactory();
		
		Unit unit = unitFactory.makeUnit("R", false);
		
		Assert.IsInstanceOf<RocketShip>(unit);
	}

	[Test]
	public void CreateBigUFOShip(){
		
		UnitFactory unitFactory  = new UnitFactory();
		
		Unit unit = unitFactory.makeUnit("B", false);
		
		Assert.IsInstanceOf<BigUFOShip>(unit);
	}
}
