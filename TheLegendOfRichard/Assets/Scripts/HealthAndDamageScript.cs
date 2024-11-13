using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


//This Script is responsible for keeping track of a GameObjects health and, 
//in the event of receiving damage, reducing the health or, in the event of healing, increasing the health
public class HealthAndDamageScript : MonoBehaviour
{
    [SerializeField] int health; // Health of the GameObject
    LevelManagerScript levelManager; //reference to levelmanager, will be called when gameobject is "dead"

    void Start()
    {
        // get reference to level manager
        levelManager = FindObjectOfType<LevelManagerScript>();
    }

    // method to receive damage, will be called when enemy is shot by player or player is damaged by enemy
    public void Damage(int damageReceived){
        health -= damageReceived;
        
        if(health <= 0){

            if(gameObject.tag == "enemy" || gameObject.tag == "EnemyTrash"){
                //if is enemy, call LevelManager enemy died method 
                levelManager.EnemyDied(this.gameObject);
            }
            else if(gameObject.tag == "player"){
                // if is player, call LevelManager player died method
                levelManager.PlayerDied();
            }
            // destroy the game object
            Destroy(gameObject);
        }
    }
    
}
