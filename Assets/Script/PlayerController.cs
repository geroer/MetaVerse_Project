using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    private Camera camera;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected AnimationHandler animationHandler;

    //이동하는 방향
    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        animationHandler = GetComponent<AnimationHandler>();
    }

    void Start()
    {
        camera = Camera.main;
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
        direction = direction * 5;

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