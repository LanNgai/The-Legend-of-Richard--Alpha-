using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//This Script is responsible for spawning enemies and keeping track of when they die. 
//It is also responsible for handling the win and lose events in the event of all enemies being killed or the player being killed.

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] Vector3[] spawnPoints;
    [SerializeField] int totalNumberOfEnemies;
    GameObject player;
    List<GameObject> currentEnemies = new List<GameObject>{};


    // Start is called before the first frame update
    void Start()
    {
        if(player == null){
                //get reference to player
                player = GameObject.FindWithTag("Player");
        }
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i < totalNumberOfEnemies; i++) //
        {
            //choose a random spawn point
            int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            Vector3 spawnPoint = spawnPoints[randomIndex];
            
            //create an enemy at the chosen spawn point and add to list of current enemies
            GameObject enemy = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], spawnPoint, Quaternion.identity);
            currentEnemies.Append(enemy);
            Debug.Log(currentEnemies);
            
            yield return new WaitForSeconds(1f); //wait 1 second
        }
        
        //all enemies have been spawned, finish Coroutine 
        StopCoroutine(SpawnEnemies());
    }

    public void EnemyDied(GameObject enemy)
    {
        //remove enemy from list of current enemies
        currentEnemies.Remove(enemy);
        
        //check if all enemies are dead
        if (currentEnemies.Count == 0)
        {
            //all enemies are dead, Win State
            Debug.Log("All enemies are dead!");
        }

    }

    public void PlayerDied()
    {
        //Player died, lose State
        Debug.Log("Player died!");
        //stop spawning enemies
        StopCoroutine(SpawnEnemies());
    }
}
