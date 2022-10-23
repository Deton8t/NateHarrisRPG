using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ChrMovementController : MonoBehaviour
{
    public KeyCode up;
    public KeyCode down;
    public KeyCode left;
    public KeyCode right;
    public KeyCode attack, interact;
    public float speed;
    public Rigidbody2D body;
    public SwingWeapon swingController;
    public bool holdingButton;
    public bool isAttacking;



    // Start is called before the first frame update
    void Start()
    {
        initBinds();
        initStats();
        body = this.GetComponent<Rigidbody2D>();
        swingController = this.GetComponentInChildren<SwingWeapon>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        checkMove();
        checkAttack();
    }
    void Update()
    {

    }

    public void initBinds()
    {
        up = ChrBinds.playerUp;
        down = ChrBinds.playerDown;
        left = ChrBinds.playerLeft;
        right = ChrBinds.playerRight;
        attack = ChrBinds.attack;
        interact = ChrBinds.interact;


    }
    public void initStats()
    {
        speed = ChrStats.maxSpeed;
    }
    public void checkMove()
    {
        if (Input.GetKey(right) && !Input.GetKey(left))
        {
            body.velocity = new Vector2(speed, body.velocity.y);
        }
        else if (Input.GetKey(left) && !Input.GetKey(right))
        {
            body.velocity = new Vector2(-speed, body.velocity.y);
        }
        else
        {
            body.velocity = new Vector2(0, body.velocity.y);
        }
        if (Input.GetKey(up) && !Input.GetKey(down))
        {
            body.velocity = new Vector2(body.velocity.x, speed);
        }
        else if (Input.GetKey(down) && !Input.GetKey(up))
        {
            body.velocity = new Vector2(body.velocity.x, -speed);
        }
        else
        {
            body.velocity = new Vector2(body.velocity.x, 0);
        }

    }

    public void checkAttack()
    {
        if (Input.GetKey(attack))
        {
            if (holdingButton)
            {
                return;
            }
            swingController.doAnimation();
            isAttacking = true;
            holdingButton = true;
        }
        else
        {
            holdingButton = false;
        }

    }
    public void attackEnd()
    {
        isAttacking = false;
    }
}
