using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float xMin, xMax, yMin, yMax;

    [SerializeField] float movementSpeed = 10f;

    [SerializeField] int health = 50;

    float padding = 0.5f;

    [SerializeField] GameObject deathVFX;
    [SerializeField] float explosionDuration = 1f;

    [SerializeField] AudioClip playerDeathSound;
    [SerializeField] [Range(0, 1)] float playerDeathSoundVolume = 0.75f;

    // Start is called before the first frame update
    void Start()
    {
        SetUpMoveBoundaries();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void SetUpMoveBoundaries(){
        Camera gameCamera = Camera.main;

        xMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x + padding;
        xMax = gameCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x - padding;

        yMin = gameCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).y + padding;
        yMax = gameCamera.ViewportToWorldPoint(new Vector3(0, 1, 0)).y - padding;
    }

        // Moves the Player ship
    private void Move()
    {
        //var changes its variable type depending on what I save in it
        //deltaX will have the difference in the x-axis which the Player moves
        var deltaX = Input.GetAxis("Horizontal") * Time.deltaTime * movementSpeed;

        //newXPos = current x-position + difference in x
        var newXPos = transform.position.x + deltaX;

        //clamp the ship between xMin and xMax
        newXPos = Mathf.Clamp(newXPos, xMin, xMax);

        //move the Player ship to the newXPos
        this.transform.position = new Vector2(newXPos, -3);
    }


    //reduces health whenever enemy collides with a gameObject
    //which has a DamageDealer component
    private void OnTriggerEnter2D(Collider2D otherObject)
    {
        //access the DamgeDealer class from "otherObject" which hits enemy adn reduce
        //health accordingly
        DamageDealer dmgDealer = otherObject.gameObject.GetComponent<DamageDealer>();
        ProcessHit(dmgDealer);
    }

    //whenever ProcessHit() is called, send us the DamageDealer details
    private void ProcessHit(DamageDealer dmgDealer)
    {
        health -= dmgDealer.GetDamage();
        dmgDealer.Hit();
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Destroy(gameObject);

        //instantiate explosion effects
        GameObject explosion = Instantiate(deathVFX, transform.position, Quaternion.identity);
        //destroy after explosionDuration (1f)
        Destroy(explosion, explosionDuration);

        AudioSource.PlayClipAtPoint(playerDeathSound, Camera.main.transform.position, playerDeathSoundVolume);

        //find the object of type Level from the hierarcht and load its method LoadGameOver()
        FindObjectOfType<Level>().LoadGameOver();
    }
}
