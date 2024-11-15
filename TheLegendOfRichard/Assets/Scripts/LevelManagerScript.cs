using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;


//This Script is responsible for spawning enemies and keeping track of when they die. 
//It is also responsible for handling the win and lose events in the event of all enemies being killed or the player being killed.

public class LevelManagerScript : MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] Vector3[] spawnPoints;
    [SerializeField] int totalNumberOfEnemies;
    [SerializeField] GameObject levelWinScreen;
    [SerializeField] GameObject levelLoseScreen;
    GameObject player;
    List<GameObject> currentEnemies = new List<GameObject>{};


    // Start is called before the first frame update
    void Start()
    {
        if(player == null){
                //get reference to player
                player = GameObject.FindWithTag("Player");
        }
        
    }

    public void StartGame(){
        //delay start of coroutine

        StartCoroutine(SpawnEnemies());
    }

    public void RestartLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StartNextLevel(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    public void EnemyDied(GameObject enemy)
    {
        //remove enemy from list of current enemies
        currentEnemies.Remove(enemy);
        Debug.Log(currentEnemies.Count);
        
        //check if all enemies are dead
        if (currentEnemies.Count == 0)
        {

            //all enemies are dead, Win State
            Debug.Log("All enemies are dead!");
            levelWinScreen.SetActive(true); 
            //after delay open next level 
        }

    }

    public void PlayerDied()
    {
        //Player died, lose State
        Debug.Log("Player died!");
        foreach (GameObject enemy in currentEnemies)
        {
            //stop all enemies
            enemy.GetComponent<EnemyScript>().enabled = false;   
        }
        //stop spawning enemies
        StopCoroutine(SpawnEnemies());
        //show lose screen
        levelLoseScreen.SetActive(true);
    }

    IEnumerator SpawnEnemies()
    {
        //wait for 3 seconds before spawning enemies
        yield return new WaitForSeconds(3f);
        for (int i = 0; i < totalNumberOfEnemies; i++) //
        {
            //choose a random spawn point
            int randomIndex = UnityEngine.Random.Range(0, spawnPoints.Length);
            Vector3 spawnPoint = spawnPoints[randomIndex];
            
            //create an enemy at the chosen spawn point and add to list of current enemies
            GameObject enemy = Instantiate(enemies[UnityEngine.Random.Range(0, enemies.Count)], spawnPoint, Quaternion.identity);
            currentEnemies.Add(enemy);
            Debug.Log(currentEnemies.Count);
            
            yield return new WaitForSeconds(1f); //wait 1 second
        }
        
        //all enemies have been spawned, finish Coroutine 
        StopCoroutine(SpawnEnemies());
    }
}
