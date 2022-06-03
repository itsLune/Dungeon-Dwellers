using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class health : MonoBehaviour {

    public int life = 10;
    private int maxLife = 10;
    public healthBar healthBar;
    public void Start() {
        life = maxLife;
        healthBar.SetMaxHealth(maxLife);//Tells healthBar Script to perform SetMaxHealth with  maxLife int
    }
    public void Update() {
        if(life <= 0 ){
            Destroy(gameObject);
            SceneManager.LoadScene("Lose");
        }

        //*healthSlider.value = life;
    }
    public void OnCollisionEnter2D(Collision2D collision) {
        

        
        if(collision.gameObject.tag == "enemy"){
            
            life = life - 1;
            healthBar.SetHealth(life);//Tealls healthbar script  to perform set health with the Life int
        }
        if(collision.gameObject.tag == "boss"){
            
            life = life - 5;
            healthBar.SetHealth(life);
        }
        if(collision.gameObject.tag == "potions"){//If player comes in  contact with the health drop dropped by enemies it adds 1hp and then updates healthbar slider.
            if (life < maxLife){
                life = life + 1;
                healthBar.SetHealth(life);
            }
            Destroy(collision.gameObject);//Destroys the health drop on collision
        }
    }

}