using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRooms : MonoBehaviour
{
    // Start is called before the first frame update
    public LayerMask whatIsRoom;
    public levelGeneration levelGeneration;

    // Update is called once per frame
    void Update()
    {//Spawns rooms based on levelGeneration Move()
        Collider2D roomDetection = Physics2D.OverlapCircle(transform.position, 1, whatIsRoom);
        if (roomDetection == null && levelGeneration.stopGeneration == true){
            int rand = Random.Range(0, levelGeneration.rooms.Length);
            Instantiate(levelGeneration.rooms[rand], transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
