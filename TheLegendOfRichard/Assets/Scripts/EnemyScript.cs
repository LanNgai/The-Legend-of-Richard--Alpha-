using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public float speed;
    private Rigidbody enemyRb;
    private GameObject player;

    private float attackRange = 3.0f;
    private float boost = 10.0f;
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
        if (Vector3.Distance(player.transform.position, transform.position) > attackRange)
        {
            enemyRb.transform.Translate(lookDirection * speed * Time.deltaTime);
        }else if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
        {
            enemyRb.AddForce(lookDirection * boost, ForceMode.Impulse);
        }
    }
    
    //TODO: name of player projectile
    private void OnCollisionEnter(Collision other)
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        // If enemy gets hit by HairBall it will be destroyed
        if (other.gameObject.name == "HairBall")
        {
            Destroy(gameObject);
        }else if (other.gameObject.name == "Player")
        {
            enemyRb.transform.Translate(-lookDirection * speed * Time.deltaTime);
        }
    }
    
}
