using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{
    private Rigidbody2D rig;

    [SerializeField] private float speed;
    [SerializeField] private float runSpeed;
    [SerializeField] private float rollSpeed;

    private float initialSpeed;
    private bool _isRunning;
    private Vector2 _direction;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }
    void Update()
    {
        OnInput();
        OnRun();
    }

    private void FixedUpdate()
    {
        OnMove();
    }

    void OnInput()
    {
        _direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
    }
    void OnMove()
    {
        rig.MovePosition(rig.position + _direction * speed * Time.fixedDeltaTime);

    }
    void OnRun()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            speed = runSpeed;
           //_isRunning = true;
        }

        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            speed = initialSpeed;
            //_isRunning = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("achou");

        if (IsPlayerOnBush(collision.gameObject.tag))
        {
            HasFindMonster();
        }

        if (IsPlayerOnDoor(collision.gameObject.tag))
        {
            Debug.Log("achou2");
            SceneManager.LoadScene("InsideHouse");
        }
    }

    public bool IsPlayerOnBush(string ObjectTagCollision)
    {
        return CheckWathPlayerCollide(ObjectTagCollision, "Bush");
    }

    public bool IsPlayerOnDoor(string ObjectTagCollision)
    {
        return CheckWathPlayerCollide(ObjectTagCollision, "Door");
    }

    public bool CheckWathPlayerCollide(string ObjectTagCollision, string CollideWith)
    {
        if (ObjectTagCollision == CollideWith)
            return true;

        return false;
    }

    public void HasFindMonster()
    {
        if (Random.value > 0.7) //%30 percent chance (1 - 0.7 is 0.3)
        {
            Debug.Log("achou");
            SceneManager.LoadScene("Battle");
        }
    }

}
