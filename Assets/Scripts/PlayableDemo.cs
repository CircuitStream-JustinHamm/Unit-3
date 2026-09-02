using UnityEngine;
using UnityEngine.Playables;

public class PlayableDemo : PlayableAsset
{
    public override Playable CreatePlayable(PlayableGraph graph, GameObject owner)
    {
        Debug.Log("Started Playable");
        Playable newPlayable = new Playable();
        return newPlayable;
    }
}
