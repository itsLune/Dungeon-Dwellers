using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MultiplayerMovement : MonoBehaviour
{
   public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public GameObject eyes;
    public Camera cam;
    public float RotationSpeed = 30f;

    public float dashSpeed = 20f;
    public float activeMoveSpeed;
    
    public float dashLength = .2f;
    public float dashCooldown = .5f;
    private float dashCounter;
    private float dashCoolCounter;
    //*public Slider stamina; 
    Vector3 mousePos;
    Vector2 move;

    PhotonView view;
    


    // Start is called before the first frame update
    void Start () 
    {
        activeMoveSpeed = moveSpeed;
        view = GetComponent<PhotonView>();
        if (!view.IsMine){
            Destroy(cam);
        }
    }

    // Update is called once per frame
    void Update () {
        if(view.IsMine){
            move.x = Input.GetAxisRaw ("Horizontal");
            move.y = Input.GetAxisRaw ("Vertical");
            move.Normalize();
            mousePos = Input.mousePosition;
        }
        
    }

    void FixedUpdate () { 
        if (view.IsMine)
        {
            rb.MovePosition(rb.position + move * activeMoveSpeed * Time.deltaTime);
    
            if(Input.GetKeyDown(KeyCode.LeftShift))
            {
                if(dashCoolCounter <=0 && dashCounter<=0)
                {
                    activeMoveSpeed = dashSpeed;
                    dashCounter = dashLength;
                }

            }
            if (dashCounter > 0 )
            {
                dashCounter -= Time.deltaTime;
                if (dashCounter <=0)
                {
                    activeMoveSpeed = moveSpeed;
                    dashCoolCounter = dashCooldown;
                }
            }
            if (dashCoolCounter > 0)
            {
                dashCoolCounter -= Time.deltaTime;
            }
                // convert mouse position into world coordinates
            Vector2 mouseScreenPosition = cam.ScreenToWorldPoint(Input.mousePosition);
            // get direction you want to point at
            Vector2 direction = (mouseScreenPosition - (Vector2) transform.position).normalized;
            // set vector of transform directly
            transform.up = direction * Time.deltaTime * RotationSpeed;

        }
        
        
    }
}
