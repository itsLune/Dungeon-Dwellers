using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawnEnemy : MonoBehaviour
{
    public GameObject[] objects;

    // Start is called before the first frame update
    private void Start()
    {//Spawns Enemies at random spawn poionts based on objects[].postitions
        int rand = Random.Range(0, objects.Length);
        int spawn = Random.Range(0, 10);
        if (spawn == 1){
            GameObject instance = (GameObject)Instantiate(objects[rand], transform.position, Quaternion.identity);
            instance.transform.parent = transform;
        } 
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
