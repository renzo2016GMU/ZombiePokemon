using UnityEngine;
using System.Collections;

public class PokemonAttack : MonoBehaviour {

    public float timeBetweenAttacks = 0.7f;     // The time in seconds between each attack.
    public int attackDamage = 10;               // The amount of health taken away per attack.

    GameObject player;                          // Reference to the player GameObject.
    PlayerShooting shotValue;
    PlayerHealth playerHealth;                  // Reference to the player's health.
    PokemonHealth pokemonHealth;                    // Reference to this enemy's health.
    bool playerInRange;                         // Whether player is within the trigger collider and can be attacked.
    float timer;                                // Timer for counting up to the next attack.

    // Use this for initialization
    void Start () {
        // Setting up the references.
        player = GameObject.Find("CardboardMain");
        playerHealth = player.GetComponent<PlayerHealth>();
        shotValue = player.GetComponent<PlayerShooting>();
        pokemonHealth = GetComponent<PokemonHealth>();
    }

    //So, I don't like that I had to do this, but honestly I can't think of any other way...for some reason this collision worked for the projectile collision detection
    //So, I just went with it
    void OnTriggerEnter(Collider other)
    {
        // If the entering collider is the player...
        Debug.Log("other's gameobject is: " + other.name);
        if (other.gameObject.tag.Equals("Bullet"))
        {
            pokemonHealth.TakeDamage(shotValue.shotDamage);
            Destroy(other.gameObject);
        }

        if (other.gameObject == player)
        {
            // ... the player is in range.
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        // If the exiting collider is the player...
        if (other.gameObject == player)
        {
            // ... the player is no longer in range.
            playerInRange = false;
        }
    }

    // Update is called once per frame
    void Update () {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

        // If the timer exceeds the time between attacks, the player is in range and this enemy is alive...
        if (timer >= timeBetweenAttacks && playerInRange && pokemonHealth.currentHealth > 0)
        {
            // ... attack.
            Debug.Log("Player health is:" + playerHealth.currentHealth);
            Attack();
        }
    }

    void Attack()
    {
        // Reset the timer.
        timer = 0f;

        // If the player has health to lose...
        if (playerHealth.currentHealth > 0)
        {
            // ... damage the player.
            playerHealth.TakeDamage(attackDamage);
        }
    }
}
