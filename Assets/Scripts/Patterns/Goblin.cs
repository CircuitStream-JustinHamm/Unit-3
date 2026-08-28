using UnityEngine;

public class Goblin : MonoBehaviour
{
    [SerializeField] GoblinData data;

    public void Update()
    {
        
    }

    public void Add(int a, int b)
    {
        a += b;
    }

    public void ChangeGoblinName(GoblinData target)
    {
        target.actorName = "Terry";
    }
}