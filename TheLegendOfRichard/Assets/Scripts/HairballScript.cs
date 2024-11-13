using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hairball : MonoBehaviour
{
    public float speed = 40;
    public int damageAmount = 20;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        HealthAndDamageScript healthAndDamageScript = GetComponent<HealthAndDamageScript>();
        
        if (healthAndDamageScript != null)
        {
            //make enemy take damage
            healthAndDamageScript.Damage(damageAmount);
            //destroy projectile upon hitting enemy
            Destroy(gameObject);
        }
    }
}
