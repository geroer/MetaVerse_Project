using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    public float speed = 5f;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected AnimationHandler animationHandler;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    void Start()
    {
    }

    void Update()
    {

    }
    protected void FixedUpdate()
    {
        Movment(movementDirection);
    }

    private void Movment(Vector2 direction)
    {
        direction = direction * speed;

        if (direction.x < 0 && !characterRenderer.flipX) characterRenderer.flipX = true;
        else if (direction.x > 0 && characterRenderer.flipX) characterRenderer.flipX = false;

        _rigidbody.velocity = direction;
        animationHandler.Move(direction);
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnJump(InputValue inputValue)
    {
    }
}