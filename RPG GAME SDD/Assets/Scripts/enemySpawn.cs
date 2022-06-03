using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpawn : MonoBehaviour
{
    public Transform[] enemySpawnPos;
    public GameObject[] enemies;
    int i;
    int enemyAmount;
    public bool stopGen;
    public void Start()
    {
        enemyAmount = Random.Range(1,11);
        stopGen = GameObject.Find("levelCreation").GetComponent<levelGeneration>().stopGeneration;
    }
    public void Update(){
        if (i < enemyAmount && stopGen == true){//Spawns the enemy when the level stops generating and the amount is random
            spawnEnemies();
            i+=1;
        }
    }
    public void spawnEnemies(){//Spawns enemies at a random spawn position from each room Prefab.
        int enemyPos = Random.Range(0, enemySpawnPos.Length);
        int enemy = Random.Range(0, enemies.Length);
        transform.position = enemySpawnPos[enemyPos].position;
        Instantiate(enemies[enemy], transform.position, Quaternion.identity);
    }
}