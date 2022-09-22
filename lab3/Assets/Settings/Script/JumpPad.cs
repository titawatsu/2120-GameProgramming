using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPadForce = 10f;
    [SerializeField] private float additionalSleepJumpTime = 13f;

    [SerializeField] private Animator anim;

    private static readonly int Bounce = Animator.StringToHash("Bounce");

    public float GetJumpPadForce() => jumpPadForce;

    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;

    [SerializeField] private PlayerController player;

    public void TriggerJumpPad()
    {
        anim.SetTrigger("Bounce");
        player.Jump(jumpPadForce);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TriggerJumpPad();
        }
    }
}
