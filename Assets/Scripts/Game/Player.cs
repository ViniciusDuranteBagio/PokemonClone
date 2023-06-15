using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour 
{

    private BoxCollider2D playerCollider, bushCollider;
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
        if (IsPlayerOnBush(collision.gameObject.tag))
        {
            HasFindMonster();
        }
    }

    public bool IsPlayerOnBush(string ObjectTagCollision)
    {
        if (ObjectTagCollision == "Bush")
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
