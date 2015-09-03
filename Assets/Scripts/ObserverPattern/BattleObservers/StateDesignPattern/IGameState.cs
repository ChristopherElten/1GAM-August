public interface IGameState : Observer {

	void Update();
	void Render();
	void OnEnter();
	void OnExit();
	void Play();
	void Pause();
	void Exit();

}
