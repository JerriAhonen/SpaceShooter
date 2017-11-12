using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceShooter
{
    public class HealthPowerUp : MonoBehaviour
    {

        public int amountOfHealt;
        public int powerUpLifeSpan;
        public float movementSpeed;

        

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Translate(Vector3.down * movementSpeed * Time.deltaTime);

            powerUpLifeSpan -= 1;

            if(powerUpLifeSpan == 0)
            {
                Destroy(gameObject);    // Destroy the powerUp after a given amount of time.
            }
        }

        public void OnTriggerEnter2D(Collider2D other)
        {
            Health playerHealth = other.GetComponent<Health>(); //Get the player Health component

            playerHealth.IncreaseHealth(amountOfHealt);         //Heal the player up. The Health component takes care of the rest.

            Destroy(gameObject);                                // Destroy the powerUp after it has done it's job.
        }
    }
}
