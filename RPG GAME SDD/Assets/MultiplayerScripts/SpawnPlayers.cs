using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnPlayers : MonoBehaviour
{
    public GameObject[] player;
    public float minX, minY, maxX, maxY;

    private void Start(){
        Vector2 randomPosition = new Vector2(Random.Range(minX, maxX), Random.Range(minY,  maxY));
        int rand = Random.Range(0, player.Length);
        PhotonNetwork.Instantiate(player[rand].name, randomPosition, Quaternion.identity);
    }

}

