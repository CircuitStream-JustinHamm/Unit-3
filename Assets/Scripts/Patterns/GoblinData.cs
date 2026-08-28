using UnityEngine;

[CreateAssetMenu(fileName = "GoblinData", menuName = "Goblins")]
public class GoblinData : ScriptableObject
{
    public string actorName = "Goblino";
    public float health;

    public Mesh mesh;
    public AudioClip goblinGrunt;
}