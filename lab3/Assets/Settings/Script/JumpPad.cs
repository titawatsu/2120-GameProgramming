using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpPad : MonoBehaviour
{
    [SerializeField] private float jumpPadForce = 15f;
    [SerializeField] private float additionalSleepJumpTime = 15f;

    [SerializeField] private Animator anim;

    private static readonly int Bounce = Animator.StringToHash("Bounce");

    public float GetJumpPadForce() => jumpPadForce;

    public float GetAdditionalSleepJumpTime() => additionalSleepJumpTime;

    public void TriggerJumpPad()
    {
        anim.SetTrigger("Bounce");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            TriggerJumpPad();
        }
    }
}
