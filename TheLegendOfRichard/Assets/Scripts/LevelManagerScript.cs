using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] List<GameObject> currentEnemies;
    [SerializeField] Vector3[] spawnPoints;
    [SerializeField] int totalNumberOfEnemies;
    [SerializeField] GameObject player;


    // Start is called before the first frame update
    void Start()
    {
        //start spawning enemies and keep track of how many are alive
        if(player == null){
            // //try get player until player is not null
            // while(player == null){
                player = GameObject.FindWithTag("Player");
            //}
        }
        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        for (int i = 0; i <= totalNumberOfEnemies; i++) //
        {
            //choose a random spawn point
            int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            Vector3 spawnPoint = spawnPoints[randomIndex];
            
            //create an enemy at the chosen spawn point
            GameObject enemy = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], spawnPoint, Quaternion.identity);
            //add enemy to list of current enemies 
            currentEnemies.Append(enemy);
            
            yield return new WaitForSeconds(1f);
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
        //Player died, Game Over State
        Debug.Log("Player died!");
        //stop spawning enemies
        StopCoroutine(SpawnEnemies());
    }
}
