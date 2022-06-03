using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour {
    public void Start()
    {
    }
    void OnCollisionEnter2D(Collision2D collision) {
        //If Game Object Tags don't equal bullet Destroy Bullet.
        //I did this because bullets  were destroying  each other
        if (collision.gameObject.tag != "bullet"){
            Destroy(gameObject);
        }
    }


}