using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelGeneration : MonoBehaviour
{
    public Transform[] startingPositions;
    public GameObject[] rooms; // index 0 = LR, index 1 = LRB, index 2 = LRT, index 3 = LRBT

    private int direction;
    public float moveAmount;
    private float timeBetweenRoom;
    public float startTimBetweenRoom = 0.25f;

    public LayerMask room;

    public float minX;
    public float maxX;
    public float minY;
    // Incorporate spawning enimies using a random range for each room, when it is the boss room
    // Specify it with the stopGeneration bool
    //Create spawn points in each room that will randomize which enemy will be spawned and how many.
    public bool stopGeneration;

    private int downCounter;
    private void Start()
    {
        int randStartingPos = Random.Range(0, startingPositions.Length);//Random Starting Point for the level Generation based on list length.
        transform.position = startingPositions[randStartingPos].position;
        Instantiate(rooms[0], transform.position, Quaternion.identity);//Spawns room based on transform position of the random starting point.
        direction = Random.Range(1, 6);//Chooses a random direction to go in next.
    }

    // Update is called once per frame
    private void Update()
    {
        if (timeBetweenRoom <= 0 && stopGeneration == false){
            Move();
            timeBetweenRoom = startTimBetweenRoom;
        }
        else {
            timeBetweenRoom -= Time.deltaTime;
        }
    }
    private void Move()//Moves the direct path to the end in a certain direction so that there will be no block offs.
    {

        if (direction == 1 || direction == 2)//If directions is 1 or 2 move to the right 
        {
            if(transform.position.x < maxX){
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x + moveAmount, transform.position.y);
                transform.position = newPos;
                int rand = Random.Range(1, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(1,6);
                if (direction == 3){
                    direction = 2;
                }
                else if (direction == 4){
                    direction = 5;
                }
            }
            else {
                direction = 5;
            }
        }
        else if (direction == 3 || direction == 4)//If Direction is 3 or 4 move left
        {
            if(transform.position.x > minX){
                downCounter = 0;
                Vector2 newPos = new Vector2(transform.position.x - moveAmount, transform.position.y);
                transform.position = newPos;

                int rand = Random.Range(1, rooms.Length);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);

                direction = Random.Range(3,6);


            }
            else{
                direction = 5;
            }
        }
        else if (direction == 5)//Direction is 5 move down 
        {
            downCounter++;

            if(transform.position.y > minY){//If transform.postion is at the lowest minY stop generation and the Instantiate rooms in all the left over spots.
                
                Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, room);
                if (roomDetection.GetComponent<roomType>().type != 1 && roomDetection.GetComponent<roomType>().type !=3){

                    if (downCounter >= 2) {
                        roomDetection.GetComponent<roomType>().RoomDestruction();
                        Instantiate(rooms[3], transform.position, Quaternion.identity);

                    }
                    else{
                        roomDetection.GetComponent<roomType>().RoomDestruction();
                        int randBottomRoom = Random.Range(1,4);
                        if (randBottomRoom == 2){
                            randBottomRoom = 1;
                    }
                    Instantiate(rooms[randBottomRoom], transform.position, Quaternion.identity);
                    }

                    
                }
                
                Vector2 newPos = new Vector2(transform.position.x, transform.position.y - moveAmount);
                transform.position = newPos;
                direction = Random.Range(1,6);
                int rand = Random.Range(2, 4);
                Instantiate(rooms[rand], transform.position, Quaternion.identity);
            }
            else{
                stopGeneration = true;
                
            }
        }
    
    }
}
