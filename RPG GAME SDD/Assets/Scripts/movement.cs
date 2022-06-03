using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movement : MonoBehaviour {
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Camera cam;
    public float RotationSpeed = 30f;

    public float dashSpeed = 20f;
    public float activeMoveSpeed;
    
    public float dashLength = .2f;
    public float dashCooldown = .5f;
    private float dashCounter;
    private float dashCoolCounter;
    Vector3 mousePos;
    Vector2 move;
    private Transform spawn2;//SpawnPoint for second level
    private Transform spawn3;//Spawn point for boss
    


    // Start is called before the first frame update
    void Start () 
    {
        activeMoveSpeed = moveSpeed;
        //*stamina.maxValue = dashCooldown;
        //Physics2D.IgnoreCollision();
        spawn2 = GameObject.FindWithTag("spawn2").transform;
        spawn3 = GameObject.FindWithTag("spawn3").transform;
    }

    // Update is called once per frame
    void Update () {
        move.x = Input.GetAxisRaw ("Horizontal");//Uses Unity predetermined axis  for velocity
        move.y = Input.GetAxisRaw ("Vertical");//Uses Unity predetermined axis  for velocity
        move.Normalize();
        mousePos = Input.mousePosition;//Grabs mouse pos on the screen.
        
    }

    void FixedUpdate () {
        rb.MovePosition(rb.position + move * activeMoveSpeed * Time.deltaTime);//Moves the Rb in the direction of inputs. Time.deltaTime  makes the rb move at the time of the world rather than frames.
        //*stamina.value = dashCounter;
        if(Input.GetKeyDown(KeyCode.LeftShift))//if left  shift is pressed dash by making active move speed = dash speed
        {
            if(dashCoolCounter <=0 && dashCounter<=0)
            {
                activeMoveSpeed = dashSpeed;
                dashCounter = dashLength;
            }

        }
        if (dashCounter > 0 )//Dash Cooldown
        {
            dashCounter -= Time.deltaTime;
            if (dashCounter <=0)//when dash is over slow back down to original speed.
            {
                activeMoveSpeed = moveSpeed;
                dashCoolCounter = dashCooldown;
            }
        }
        if (dashCoolCounter > 0)//Start  cooldown for dash
        {
            dashCoolCounter -= Time.deltaTime;
        }
        
  // convert mouse position into world coordinates
        Vector2 mouseScreenPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
 // get direction you want to point at
        Vector2 direction = (mouseScreenPosition - (Vector2) transform.position).normalized;
 // set vector of transform directly
        transform.up = direction * Time.deltaTime * RotationSpeed;


    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag ==  "teleport"){//If colides with original Pink square teleport to level 2
            transform.position = spawn2.position;
        }
        if(collision.gameObject.tag ==  "TELEPORT"){//If collides with second pink square teleport to Boss
            transform.position = spawn3.position;
        }
    }

}