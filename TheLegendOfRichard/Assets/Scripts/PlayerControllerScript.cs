using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameObject projectilePrefab;
    private float fireRate = 0.5f;
    private float nextFire = 0;
    public float horizontalInput;
    public float verticalInput;
    public float speed;
    public float rotationSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * speed);
        transform.Rotate(Vector3.up * horizontalInput * Time.deltaTime * rotationSpeed);


        // On spacebar press, if enough time has passed since last fire, shoot hairball in the direction the player is facing
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;// reset nextFire to current time + fireRate
            Vector3 projectileSpawnPosition = transform.position + (transform.forward * 3);
            Instantiate(projectilePrefab, projectileSpawnPosition, transform.rotation);
        }
    }
}
