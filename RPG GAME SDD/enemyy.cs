using System.ComponentModel.DataAnnotations;
using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour {


    public float speed = 4f;
    public float health = 5f;
    public float hit = 1f;
    public float damage;
    public float moveSpeed = 4f;
    public Rigidbody2D rb;
    public GameObject Bullet;

    public GameObject player;

    }



}