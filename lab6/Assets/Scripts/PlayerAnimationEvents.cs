using UnityEngine;

public class PlayerAnimationEvents : MonoBehaviour
{
    [SerializeField] private PlayerAudioController audioController;

    public void PlayWalkSound()
    {
        audioController.PlayWalk();
    }
}
