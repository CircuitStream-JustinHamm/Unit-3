

/*public interface IGameState
{
    void Run(Game game);

    void OnEnter(Game game);
    void OnExit(Game game);
}

public class MenuState : IGameState
{
    int level = 0;

    public void Run(Game game)
    {
        
    }

    public void OnEnter(Game game) { game.currentLevel = level; }
    public void OnExit(Game game) { }
}

public class PlayState : IGameState
{
    int level = 1;

    public void Run(Game game)
    {

    }

    public void OnEnter(Game game) { game.currentLevel = level; }
    public void OnExit(Game game) { }
}

public class GameOverState : IGameState
{
    int level = 2;

    public void Run(Game game)
    {

    }

    public void OnEnter(Game game) { game.currentLevel = level; }
    public void OnExit(Game game) { }
}

public class Game
{
    IGameState currentState;

    public int currentLevel;

    public void Update()
    {
        currentState.Run(this);
    }

    public void Transition(IGameState newState)
    {
        if(currentState != null)
        {
            currentState.OnExit(this);
        }

        newState.OnEnter(this);
        currentState = newState;
    }
}*/