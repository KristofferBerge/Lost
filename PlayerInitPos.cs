﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInitPos : MonoBehaviour {

    private Dictionary<string, Vector3> spawnPositions = new Dictionary<string, Vector3>();
    private Dictionary<string, Vector3> spawnScale = new Dictionary<string, Vector3>();
    private string newSpawn;
    private Transform player;

    void Start(){
        //Storing scale and positions of different spawn points
        spawnPositions.Add("beach", new Vector3(274, 3.9f, 267));
        spawnScale.Add("beach", new Vector3(2, 2, 2));
        spawnPositions.Add("hatch", new Vector3(347,18.4f,631));
        spawnScale.Add("hatch", new Vector3(2,2,2));
        spawnPositions.Add("bunker", new Vector3(20, -15, -2));
        spawnScale.Add("bunker", new Vector3(1,1,1));
        player = GameObject.Find("First Person Controller").transform;
    }

    void OnLevelWasLoaded(){
        player.position = spawnPositions[newSpawn];
        player.localScale = spawnScale[newSpawn];
    }

    public void setSpawn(string spwn) {
        newSpawn = spwn;
    }

}
