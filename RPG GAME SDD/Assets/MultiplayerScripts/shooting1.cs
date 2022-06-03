using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class shooting1 : MonoBehaviour
{

    public Transform firePoint;
    public GameObject[] gun;// SMG = 1, Rifle = 2, LMG = 3, Shotgun = 4, Sniper = 5
    public GameObject bulletPrefab;

    public int damage = 20;
    public int i;
    public float shootingDelay;

    PhotonView view;

    public bool automatic;
    public int amountOfBullets;

    private bool canShoot = true;
    public float spread, bulletForce;
    // Start is called before the first frame update
    void Start()
    {
        view  = GetComponent<PhotonView>();
        i = 1;
    }

    // Update is called once per frame
    void Update()
    {   if (view.IsMine){
            if(Input.GetButton("Fire1") && canShoot){
                Shoot();
                StartCoroutine(shootDelay());
            }
        }
    }

    void Shoot()
    {   
        int l = 0;
        while(l < amountOfBullets){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            Vector2 dir = transform.rotation * Vector2.up;
            Vector2 pdir = Vector2.Perpendicular(dir) * Random.Range(-spread, spread);
            rb.velocity = (dir + pdir) * bulletForce;
            //rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
            l++;
        }
    }

    IEnumerator shootDelay()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootingDelay);
        canShoot = true;
    }
    
}
