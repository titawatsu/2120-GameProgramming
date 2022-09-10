using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private float moveInput;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpAmplitude = 5f;

    [SerializeField] private SpriteRenderer sRenderer;

    [SerializeField] private GemColor playerColor;

    [SerializeField] private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


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
        if (value.isPressed)
        {
            rb.AddForce(transform.up * jumpAmplitude, ForceMode2D.Impulse);
        }
    }

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
            Destroy(gemFunc.gameObject);
        }
    }
}
