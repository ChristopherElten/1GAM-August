using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BattleManager : MonoBehaviour, Observer {

	private UnitFactoryManager unitFactoryManager;
	private BattleGroundManager battleGroundManager;
	private ActiveUnitManager activeUnitManager;
	private UIController uiController;

	void Start () {
		unitFactoryManager = GetComponent<UnitFactoryManager>();
		battleGroundManager = GetComponent<BattleGroundManager>();
		activeUnitManager = GetComponent<ActiveUnitManager>();
		uiController = GetComponent<UIController>();

		//Subject-Observer
		activeUnitManager.Register(this);
	}

	//Adding Units...
	void AddActiveUnits(){
		battleGroundManager.GenerateUnits(activeUnitManager.getAllyActors(), activeUnitManager.getOpponentActors());
	}
	void AddUnit<T>(T newUnit) where T : Unit {
		activeUnitManager.AddActor(newUnit);
		battleGroundManager.initUnitModel(newUnit);
	}

	//Public handlers for ui (buttons, etc)
	public void StartBattle(){
		battleGroundManager.SetupBattleGrounds(); 
		Debug.Log("Start Actions Here");
	}
	public void NextAllyUnit(){
		activeUnitManager.NextAllyActor();
		uiController.getCombatCanvas().ChangeCurrentAllyActor(activeUnitManager.getCurrentAllyActor().Value);
	}
	public void PreviousAllyUnit(){
		activeUnitManager.PreviousAllyActor();
		uiController.getCombatCanvas().ChangeCurrentAllyActor(activeUnitManager.getCurrentAllyActor().Value);
	}
	public void NextOpponentUnit(){
		activeUnitManager.NextOpponentActor();
		uiController.getCombatCanvas().ChangeCurrentOpponentActor(activeUnitManager.getCurrentOpponentActor().Value);
	}
	public void PreviousOpponentUnit(){
		activeUnitManager.PreviousOpponentActor();
		uiController.getCombatCanvas().ChangeCurrentOpponentActor(activeUnitManager.getCurrentOpponentActor().Value);
	}
	//TODO Fix up lataaa
	private void UpdateCombatCanvas(){
		uiController.getCombatCanvas().ChangeCurrentAllyActor(activeUnitManager.getCurrentAllyActor().Value);
		uiController.getCombatCanvas().ChangeCurrentOpponentActor(activeUnitManager.getCurrentOpponentActor().Value);
	}
	//TODO
	public void ShowBattleOptions(){
		Debug.Log("SHOW BATTLE OPTIONS");
	}
	public void BasicAttack(){
		if (activeUnitManager.getCurrentOpponentActor() == null){
			Debug.LogWarning("No Target Selected...");
			return;
		} else {
			activeUnitManager.getCurrentAllyActor().Value.BasicAttack(activeUnitManager.getCurrentOpponentActor().Value);
			UpdateCombatCanvas();
		}
	}

	public void EndPlayerTurn(){
		foreach(Unit allyUnit in activeUnitManager.getAllyActors()){
			allyUnit.EndTurn();
		}
		//TODO: MOVE THIS
		UpdateCombatCanvas();
		StartOpponentsTurn();
		EndOpponentsTurn();
		StartCoroutine(ExecuteActions());
	}
	public void StartOpponentsTurn(){
		//Decide BattleActions
		foreach(Unit opponentUnit in activeUnitManager.getOpponentActors()){
			opponentUnit.BasicAttack(activeUnitManager.getAllyActors().First.Value);
		}
	}
	public void EndOpponentsTurn(){
		//Decide BattleActions
		foreach(Unit opponentUnit in activeUnitManager.getOpponentActors()){
			opponentUnit.EndTurn();
		}
	}
	//Turn Coroutine -> Executes queued action at the end of the turn.
	IEnumerator ExecuteActions(){
		//Running through the actions ready to be executed
		if (activeUnitManager.getActions() != null){

			foreach(BattleAction battleAction in activeUnitManager.getActions()){
				//Executing Actions (delagate) in coroutine
				Debug.Log("Action Coroutine");
				yield return new WaitForSeconds(1);
				Debug.Log("Action executing");

				//Checking if the unit targeted still exists (not destroyed in a previous battle action)
				if (battleAction.actionTargetUnit != null){
					battleAction.Execute();
					battleAction.actionInvokerUnit.ClearBattleAction();
				}

				UpdateCombatCanvas();		
			}
			activeUnitManager.ClearActions();
		}

		Debug.Log("Turn Restart");
	}
	//Temp new game func for prototype
	public void NewGame(){
		Unit newUnit;

		newUnit = unitFactoryManager.CreateAllyRocketShip();
		AddUnit(newUnit);
		newUnit = unitFactoryManager.CreateAllyUFO();
		AddUnit(newUnit);

		newUnit = unitFactoryManager.CreateOpponentRocketShip();
		AddUnit(newUnit);
		newUnit = unitFactoryManager.CreateOpponentBigUFOShip();
		AddUnit(newUnit);
		newUnit = unitFactoryManager.CreateOpponentUFO();
		AddUnit(newUnit);

		//TODO : Visual Init
		activeUnitManager.NextAllyActor();
		activeUnitManager.NextOpponentActor();
		UpdateCombatCanvas();
	}
	//Temp Wave Generation
	public void TempOpponentWaveGenerate(){
		Unit newUnit;

		newUnit = unitFactoryManager.CreateOpponentRocketShip();
		AddUnit(newUnit);
		newUnit = unitFactoryManager.CreateOpponentBigUFOShip();
		AddUnit(newUnit);
		newUnit = unitFactoryManager.CreateOpponentUFO();
		AddUnit(newUnit);
	}

	//Observer
	public void OnNotify(GameEvent e){
		
		if (e.commandString == "Cleared Opponents"){
			Debug.Log("Cleared wave! Generating new wave...");
			TempOpponentWaveGenerate();
		}
	}
}
