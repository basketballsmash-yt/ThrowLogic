using UnityEngine;

public class PlaybackUI : MonoBehaviour
{
    public ThrowPlayer player;

    public void OnPlay()
    {
        player.Play();
    }

    public void OnPause()
    {
        player.Pause();
    }

    public void OnNext()
    {
        player.NextFrame();
    }
}
