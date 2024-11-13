using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        player = GameObject.Find("Player");
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.transform.Translate(lookDirection * speed * Time.deltaTime);
    }
    
    //TODO: name of player projectile
    private void OnCollisionEnter(Collision other)
    {
        // If enemy gets hit by HairBall it will be destroyed
        if (other.gameObject.name == "HairBall")
        {
            Destroy(gameObject);
        } 
    }
}
