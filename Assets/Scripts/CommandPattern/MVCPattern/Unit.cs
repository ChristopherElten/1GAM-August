using UnityEngine;
using System.Collections;

public class Unit: CombatActions, UnitReceiver {

	protected string unitName = "unit";
	protected double damage = 0.0;
	protected double health = 0.0;
	protected bool isOpponent = true;
	protected Sprite unitSprite;

	protected bool isTargeted = false;
	protected bool isSelected = false;

	protected BattleAction battleAction;
	
	public string getUnitName(){ return unitName;}
	public void setName(string unitName){ this.unitName = unitName;}
	
	public double getDamage(){ return damage;}
	public void setDamage(double damage){ this.damage = damage;}
	
	public double getHealth(){ return health;}
	public void setHealth(double health){ this.health = health;}
	
	public bool getIsOpponent(){ return isOpponent;}
	public void setIsOpponent(bool isOpponent){ this.isOpponent = isOpponent;}

	public Sprite getUnitSprite(){ return unitSprite;}
	public void setUnitSprite(Sprite unitSprite){ this.unitSprite = unitSprite;}
	
	public bool getIsTargeted(){ return isTargeted;}
	public void setIsTargeted(bool isTargeted){ this.isTargeted = isTargeted;}

	public bool getIsSelected(){ return isSelected;}
	public void setIsSelected(bool isSelected){ this.isSelected = isSelected;}

	public BattleAction getBattleAction(){ return battleAction;}
	public void setBattleAction(BattleAction battleAction){ this.battleAction = battleAction;}

	//Send GameEvent with combatAction method (delegate)
	private void InvokeAction(Unit targetUnit, CombatAction combatAction, Sprite actionIcon){
		battleAction = new BattleAction("Battle Action", combatAction, this, targetUnit, actionIcon);
	}
	//Clearing prepared battle action
	public void ClearBattleAction(){
		if (battleAction == null){ return;}

		battleAction.actionTargetUnit.setIsTargeted(false);
		battleAction = null;
	}
	private void PrepareBattleAction(){
		if (battleAction == null){ return;}
		
		battleAction.actionTargetUnit.setIsTargeted(true);
	}

	//Actions by units available
	public virtual void BasicAttack(Unit targetUnit){
		ClearBattleAction();
		Sprite actionIcon = Resources.Load<Sprite>("BattleActionIcons/basic-attack");
		InvokeAction(targetUnit, BasicAttack, actionIcon);
		PrepareBattleAction();
	}
	//ADD DEFAULT HERE -> Plus OTHER METHODS!

	//Send finalized action
	public void EndTurn(){
		// START COROUTINE HERE? Animations? Sound?
		GameEvent newEvent = new GameEvent(battleAction);
		notifyObserver(newEvent);

	}
}
