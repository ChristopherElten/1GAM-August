using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CombatCanvas : MonoBehaviour {

	[SerializeField] Sprite defaultActionIcon;

	[SerializeField]Image currentAllyActorImage;
	[SerializeField]Text currentAllyActorNameText;
	[SerializeField]Text currentAllyActorHealthText;
	[SerializeField]Text currentAllyActorDamageText;
	[SerializeField]Image currentAllyActorBattleAction;

	[SerializeField]Image currentOpponentActorImage;
	[SerializeField]Text currentOpponentActorNameText;
	[SerializeField]Text currentOpponentActorHealthText;
	[SerializeField]Text currentOpponentActorDamageText;


	public void ChangeCurrentAllyActor<T>(T unit) where T : Unit
	{
		currentAllyActorImage.sprite = unit.getUnitSprite();
		currentAllyActorNameText.text = unit.getUnitName();
		currentAllyActorHealthText.text = "Health: " + unit.getHealth().ToString();
		currentAllyActorDamageText.text = "Damage: " + unit.getDamage().ToString();
		if (unit.getBattleAction() != null){
		    if (unit.getBattleAction().actionIcon != null){
				currentAllyActorBattleAction.sprite = unit.getBattleAction().actionIcon;
			}
		} else {
			currentAllyActorBattleAction.sprite = defaultActionIcon;
		}
	}
	
	public void ChangeCurrentOpponentActor<T>(T unit) where T : Unit
	{
//		currentOpponentActorImage.sprite = unit.getUnitSprite();
		currentOpponentActorNameText.text = unit.getUnitName();
		currentOpponentActorHealthText.text = "Health: " + unit.getHealth().ToString();
		currentOpponentActorDamageText.text = "Damage: " + unit.getDamage().ToString();
	}
}
