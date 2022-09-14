using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int isGrounded = Animator.StringToHash("isGrounded");
    private static readonly int velocityX = Animator.StringToHash("velocityX");
    

    public void SetAnimationParameter(Vector2 playerVelocity, bool groundState)
    {
        animator.SetBool(isGrounded, groundState);
        animator.SetFloat(velocityX, Mathf.Abs(playerVelocity.x));
        
    }
}
