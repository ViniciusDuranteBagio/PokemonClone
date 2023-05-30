using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

// Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        initialSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        //ignoreCollider();
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

    public void ignoreCollider() 
    {
   //     playerCollider = GetComponent<BoxCollider2D>();
   //     bushCollider = GameObject.Find("Bush").GetComponent<BoxCollider2D>();
   //
   //     Physics2D.IgnoreCollision(playerCollider, bushCollider, true);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Collided with: " + other.name);
       //
       // if (other.tag == "Player")
       // {
       //     //access the player
       //     // if the powerupID is 0
       //     Player player = other.GetComponent<Player>();
       //
       //     if (player != null)
       //     {
       //         if (powerupID == 0)
       //         {
       //             player.TipleShootPowerUpOn();
       //         }
       //
       //         else if (powerupID == 1)
       //         {
       //             player.SpeedBoostPowerUpOn();
       //         }
       //
       //         else if (powerupID == 2)
       //         {
       //             player.EnableShields();
       //         }
       //
       //
       //     }
       //
       //     AudioSource.PlayClipAtPoint(_clip, Camera.main.transform.position, 1f);
       //     //Destroy ourself
       //     Destroy(this.gameObject);
       // }

    }

}
