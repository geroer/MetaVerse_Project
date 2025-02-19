using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Animator animator;
    Rigidbody2D _rigidbody;

    public float flapForce = 6f;   //점프하는 힘
    public float forwardSpeed = 3f; //전진 속도
    public bool isDead = false; //게임오버여부
    float deathCooldown = 0f;   //일정 시간 후 죽도록 함

    bool isFlap = false;    //점프 여부

    public bool godMode = false;    //테스트용 갓모드

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.Instance;

        animator = GetComponentInChildren<Animator>();    //GetComponentInChildren<>()  본인 뿐 아니라 하위 object에서도 있는지 확인하고 반환
        _rigidbody = GetComponent<Rigidbody2D>();   //GetComponent<>()  script가 달려있는 object 한테 원하는 component가 있는지 없는지 확인하고 있으면 반환

        if (animator == null)
            Debug.LogError("Not Found Animator");

        if (_rigidbody == null)
            Debug.LogError("Not Found Rigidbody");
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead)
        {
            if (deathCooldown <= 0)
            {
                //게임 재시작
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    gameManager.RestartGame();
                }
            }
            else
            {
                deathCooldown -= Time.deltaTime;    
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)) //GetMouseButtonDown()  마우스 클릭 반환 ( 0 : 좌클릭, 1: 우클릭, 2: 휠, 3: 뒤로, 4: 앞으로 )
            {
                isFlap = true;
            }
        }
    }

    private void FixedUpdate()
    {
        if (isDead) return;

        Vector3 velocity = _rigidbody.velocity; //가속도
        velocity.x = forwardSpeed;

        if (isFlap)
        {
            velocity.y += flapForce;    //점프
            isFlap = false;
        }

        _rigidbody.velocity = velocity; //변경된 가속도 적용

        float angle = Mathf.Clamp((_rigidbody.velocity.y * 10f), -90, 90);    //특정한 값을 기준으로  min과 max로 고정
        transform.rotation = Quaternion.Euler(0, 0, angle); //회전
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (godMode) return;

        if (isDead) return;

        isDead = true;
        deathCooldown = 1f;

        animator.SetInteger("IsDie", 1);
        gameManager.GameOver();
    }
}
