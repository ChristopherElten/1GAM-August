using UnityEngine;
using System.Collections;

public class GameStateController : MonoBehaviour {

	private GameStateManager gameStateManager;

	// Use this for initialization
	void Start () {
		gameStateManager = GetComponent<GameManager>().gameStateManager;
		gameStateManager.OnEnter();
	}
	
	public void Play(){
		gameStateManager.Play();
	}
	public void Pause(){
		gameStateManager.Pause();
	}
	public void Exit(){
		gameStateManager.Exit();
	}
	public void OnEnter(){
		gameStateManager.OnEnter();
	}
	public void OnExit(){
		gameStateManager.OnExit();
	}
	public void Update(){
		gameStateManager.Update();
	}
	public void Render(){
		gameStateManager.Render();
	}
}
