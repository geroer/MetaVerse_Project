using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    public float speed = 5f;

    [SerializeField] private SpriteRenderer characterRenderer;

    protected AnimationHandler animationHandler;

    protected Vector2 movementDirection = Vector2.zero;
    public Vector2 MovementDirection { get { return movementDirection; } }

    private bool isIntract = false;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            isIntract = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Interact"))
        {
            isIntract = false;
        }
    }

    void OnMove(InputValue inputValue)
    {
        movementDirection = inputValue.Get<Vector2>();
        movementDirection = movementDirection.normalized;
    }

    void OnJump(InputValue inputValue)
    {
    }

    void OnInteract(InputValue inputValue)
    {
        if (isIntract)
        {
            SceneManager.LoadScene("MiniGameScene");
        }
    }
}