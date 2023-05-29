using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    [SerializeField] public float dashDistance = 5f; // The distance the player will dash
    [SerializeField] public float dashDuration = 0.5f; // The duration of the dash in seconds

    private Rigidbody2D rb;
    private bool isDashing = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (!isDashing && Input.GetKeyDown(KeyCode.LeftShift) && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            Vector2 dashDirection = GetDashDirection();

            if (dashDirection != Vector2.zero)
            {
                StartCoroutine(Dash(dashDirection));
            }
        }
    }

    private Vector2 GetDashDirection()
    {
        Vector2 direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

        return direction.normalized;
    }

    private System.Collections.IEnumerator Dash(Vector2 direction)
    {
        isDashing = true;

        float dashTimer = 0f;
        Vector2 startPosition = transform.position;
        Vector2 targetPosition = startPosition + (direction * dashDistance);

        while (dashTimer < dashDuration)
        {
            float t = dashTimer / dashDuration;
            rb.MovePosition(Vector2.Lerp(startPosition, targetPosition, t));

            dashTimer += Time.deltaTime;
            yield return null;
        }

        isDashing = false;
    }
}
