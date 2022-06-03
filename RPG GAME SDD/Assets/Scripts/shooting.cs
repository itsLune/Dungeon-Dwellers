using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class shooting : MonoBehaviour
{

    public Transform firePoint;//Where the bullet instantiates
    public GameObject[] gun;// SMG = 1, Rifle = 2, LMG = 3, Shotgun = 4, Sniper = 5
    public GameObject bulletPrefab;

    public int damage;
    public int i;
    public float shootingDelay;
    public int exp;
    private int exptolevelup;
    public Rigidbody2D rb2d;
    public expbar expbar;
    public int amountOfBullets;

    private bool canShoot = true;
    public float spread, bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        i = 1;
        exptolevelup = 10;
        expbar.SetExp(exp);
        expbar.SetMaxExp(exptolevelup);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButton("Fire1") && canShoot){
            Shoot();
            StartCoroutine(shootDelay());
        }
        if (exp >= exptolevelup)
        {
            LevelUp();
        }
    }

    void Shoot()
    {   
        int l = 0;
        while(l < amountOfBullets){//Repeats until it Instantiates  all  the  bullets.
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();//Grabs rb from  bullet
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);//Adds spread to the bullets using spread float.
            rb.velocity = (dir + pdir) * bulletForce;// shoots  the bullet
            l++;
        }
    }

    IEnumerator shootDelay()//Delays  each shot so that  each gun is unique
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingDelay);
        canShoot = true;
    }
    public void LevelUp(){//Levels up the player
        damage = damage + 1;
        if (spread > 0.025f){
            spread = spread - 0.025f;
        }
        if  (shootingDelay >  0.1025f){
            shootingDelay =  shootingDelay - 0.025f;
        }
        exp  = 0;
        exptolevelup = exptolevelup + 1;
        expbar.SetExp(exp);
        expbar.SetMaxExp(exptolevelup);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "EXP")//Sets the expbar to exp amount and also destroy exp drop gameobject.
        {
            exp++;
            Destroy(collision.gameObject);
            expbar.SetExp(exp);
        }
    }
    
}
