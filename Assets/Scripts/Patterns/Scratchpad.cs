

/*using UnityEngine;

public interface StatModifierCalculateStrategy
{
    void Calculate(Stat stat);
}

public interface StatModifierUpdateStrategy
{
    void Update(Stat stat);
}

public class StatCalculateDoubleStrategy : StatModifierCalculateStrategy
{
    public void Calculate(Stat stat)
    {
        stat.value *= 2;
    }
}

public class StatCalculateHalfStrategy : StatModifierCalculateStrategy
{
    public void Calculate(Stat stat)
    {
        stat.value /= 2;
    }
}

public class StatBlankUpdateStrategy : StatModifierUpdateStrategy
{
    public void Update(Stat stat)
    { }
}

public class StatModifier
{
    public StatModifierCalculateStrategy calculateStrategy;
    public StatModifierUpdateStrategy updateStrategy;

    public void Calculate(Stat stat)
    { calculateStrategy.Calculate(stat); }

    public void Update(Stat stat) 
    { updateStrategy.Update(stat); }
}

public class Stat
{
    public int value;
    public StatModifier[] modifiers;

    public int GetValue()
    {
        foreach(var mod in modifiers)
        {
            mod.Calculate(this);
        }

        return value;
    }

}

public interface ItemConsumeStrategy
{
    void Consume(Item item);
}

public class ItemPotionConsumeStrategy : ItemConsumeStrategy
{
    public void Consume(Item item)
    {
        Debug.Log("Increased HP!");
    }
}

public interface ItemExpirationStrategy
{
    bool IsExpired(Item item);
}

public class Item 
{
    public ItemConsumeStrategy consumeStrategy;
    public ItemExpirationStrategy expirationStrategy;

    public bool IsExpired()
    {
        return expirationStrategy.IsExpired(this);
    }

    public void Consume()
    {
        consumeStrategy.Consume(this);
    }
}


public class RPGPlayer
{
    Item item;
    Stat luck;
    Stat health;

    public void Update()
    {
        StatModifier modifier = new StatModifier();
        modifier.calculateStrategy = new StatCalculateHalfStrategy();
        modifier.updateStrategy = new StatBlankUpdateStrategy();

        item = new Item();
        item.consumeStrategy = new ItemPotionConsumeStrategy();
        item.Consume();
    }
}*/

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