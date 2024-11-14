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

        Vector3 movementDirection = new Vector3(horizontalInput, 0, verticalInput);

        transform.Translate(movementDirection * Time.deltaTime * speed, Space.World);

        //rotate player according to the direction the player is moving
        if (movementDirection != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(movementDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
        }

        // On spacebar press, if enough time has passed since last fire, shoot hairball in the direction the player is facing
        if (Input.GetKeyDown(KeyCode.Space) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;// reset nextFire to current time + fireRate
            Vector3 projectileSpawnPosition = transform.position + (transform.forward * 3);
            Instantiate(projectilePrefab, projectileSpawnPosition, transform.rotation);
        }
    }
}
