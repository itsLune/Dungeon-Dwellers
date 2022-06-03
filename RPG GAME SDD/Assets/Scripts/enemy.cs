using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using UnityEngine.SceneManagement;

public class enemy : MonoBehaviour {


    public float speed = 1f;
    public int health = 5;
    public float hit = 1f;
    public int damage;
    private Rigidbody2D rb;
    public GameObject Bullet;
    public float nextWaypointDistance = 3f;


    public GameObject healthdrop;
    public GameObject expdrop;
    Path path;
    int currentWaypoint = 0;
    bool reachedEndofPath;
    Seeker seeker;

    Vector3 playerPos;
    private Transform target;


    public void Start()
    {
        
        target = GameObject.FindWithTag("Player").transform;
        seeker = GetComponent<Seeker>();//Grabs Seeker Script from enemy so that it  tracks the player.
        rb = GetComponent<Rigidbody2D>();
        InvokeRepeating("UpdatePath", 0f, .5f);//Tells UpdatePath() to repeat every .5 seconds.
        
        

    }
    void UpdatePath()
    {
        if (seeker.IsDone()){
            seeker.StartPath(rb.position, target.position, OnPathComplete);//Starts a path to the target
        }
        
    }
    void OnPathComplete(Path p)//When enemy finishes it's Original path it creates a new one based on player position
    {
        if(!p.error){
            path = p;
            currentWaypoint = 0;
        }
    }

    public void Update()
    {
        
        
        if(health <= 0 ){
            int random = Random.Range(0, 10);
            if (random == 1){
                    Instantiate(healthdrop, transform.position, Quaternion.identity);//Creates a healthdrop at death pos at a random rate
                }
            Instantiate(expdrop, transform.position, Quaternion.identity);//Creates a exp drop at death pos
            if (gameObject.tag == "boss")//When you kill Gary it redirects you to  win  screen.
            {
                SceneManager.LoadScene("winScreen");
            }
            Destroy(gameObject);
        }
            
            
            
    }

    
    public void FixedUpdate(){
        if (path == null){
            return;
        }
        if (currentWaypoint >= path.vectorPath.Count)
        {
            reachedEndofPath = true;
            return;
        }
        else{
            reachedEndofPath = false;
        }
        Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;//Directs Enemy to player
        Vector2 force = direction * speed * Time.deltaTime;//Defines the force to enemy towards the palyer

        rb.AddForce(force);

        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);//Distance to enemy

        if (distance < nextWaypointDistance){
            currentWaypoint++;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "bullet")
        {
            int damage = GameObject.FindWithTag("Player").GetComponent<shooting>().damage;//Grabs the damage from shooting script from the player to adjust to the damage for each character.
            health = health - damage;
        }
    }
}

