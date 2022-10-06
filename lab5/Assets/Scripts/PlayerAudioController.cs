using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioController : MonoBehaviour
{
    
    [SerializeField] private AudioSource audioSource;

    [Header("MOVEMENT")]
    [SerializeField] private SoAudioClips walkAudioClips;
    [SerializeField] private SoAudioClips jumpAudioClips;
    [SerializeField] private SoAudioClips fallAudioClips;
    [SerializeField] private SoAudioClips JumppadAudioClips;

    [Header("COLLECTIBLE")]
    [SerializeField] private SoAudioClips collectGetAudioClips;
    [SerializeField] private SoAudioClips collectRespawnAudioClips;

    [Header("WIN/LOSE CONDITION")]
    [SerializeField] private SoAudioClips deathAudioClips;
    [SerializeField] private SoAudioClips finishAudioClips;

    public void PlayJumpSound() => audioSource.PlayOneShot(jumpAudioClips.GetAudioClip(), 0.5f);

    public void PlayWalkSound() => audioSource.PlayOneShot(walkAudioClips.GetAudioClip(), 0.5f);

    public void PlayFallSound() => audioSource.PlayOneShot(fallAudioClips.GetAudioClip(), 0.5f);

    public void PlayJumppadSound() => audioSource.PlayOneShot(JumppadAudioClips.GetAudioClip(), 0.5f);

    public void PlayCollectGetSound() => audioSource.PlayOneShot(collectGetAudioClips.GetAudioClip(), 0.5f);

    public void PlayCollectRespawnSound() => audioSource.PlayOneShot(collectRespawnAudioClips.GetAudioClip(), 0.5f);

    public void PlayDeathSound() => audioSource.PlayOneShot(deathAudioClips.GetAudioClip(), 0.5f);

    public void PlayFinishSound() => audioSource.PlayOneShot(finishAudioClips.GetAudioClip(), 0.5f);

}
