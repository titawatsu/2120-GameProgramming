using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] private float moveInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpAmplitude = 5f;

    [Header("For Player Components")]
    [SerializeField] private SpriteRenderer sRenderer;

    [SerializeField] private GemColor playerColor;

    [SerializeField] private Rigidbody2D rb;

    [SerializeField] private Animator animator;

    [SerializeField] private PowerupCollectible powerupCollectible;

    [SerializeField] private Collider2D playerCollider;

    [SerializeField] private BoxCollider2D boxCol2d;

    [SerializeField] private PlayerAnimationController animController;

    [Header("For checking Ground")]
    [SerializeField] private LayerMask groundLayers;
    [SerializeField] private float extraGroundCheckDistance = 0.05f;

    private bool isGrounded;
    private bool groundState;

    [Header("For coyote time")]
    [SerializeField] private float coyoteTime = 0.15f;
    [SerializeField] private float coyoteCount;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    private void Update()
    {
        CheckGround();
        CheckCoyotetime();
        SetAnimParameter();
        SpriteDirection();
    }
    #region Actions
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void OnMove(InputValue value)
    {
        moveInput = value.Get<float>();
        //rb.velocity = (Vector2)transform.right * moveInput * rb.velocity.y;
        
    }

    private void OnJump(InputValue value)
    {
        if (!value.isPressed) return;
        TryJumpFunction();
    }

    public void Jump(float force)
    {
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(transform.up * force, ForceMode2D.Impulse);
        coyoteCount = 0f;
    }

    private void TryJumpFunction()
    {
        if (!isGrounded && coyoteCount <= 0f) return;
        
        Jump(jumpAmplitude);
    }

    private void SpriteDirection()
    {
        if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void CheckCoyotetime()
    {
        if (isGrounded)
        {
            coyoteCount = coyoteTime;
        }
        else
        {
            coyoteCount -= Time.deltaTime;
        }
    }

    #endregion

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out GemFunc gemFunc))
        {
            GemColor playerColor = gemFunc.color;

            switch (playerColor)
            {
                case GemColor.Red:
                    sRenderer.color = Color.red;
                    break;
                case GemColor.Green:
                    sRenderer.color = Color.green;
                    break;
                case GemColor.Blue:
                    sRenderer.color = Color.blue;
                    break;

            }
            collision.gameObject.SetActive(false);
            //Destroy(gemFunc.gameObject);
            
        }

        if (collision.CompareTag("Finish")){
            GameManager.instance.LoadNextLevel();
        }

        if (boxCol2d.IsTouchingLayers(LayerMask.GetMask("Hazard")))
        {
            TakeDamage();
        }
    }

    private void SetAnimParameter()
    {
        animController.SetAnimationParameter(rb.velocity, isGrounded);
    }

    private void CheckGround()
    {
        var playerColliderBounds = playerCollider.bounds;

        var raycastHit = Physics2D.BoxCast(playerColliderBounds.center,
            playerColliderBounds.size, 
            0f, 
            Vector2.down, 
            extraGroundCheckDistance,
            groundLayers);

        isGrounded = raycastHit.collider != null;
    }

    private void TakeDamage()
    {
        GameManager.instance.ProcessPlayerDeath();
    }
}
