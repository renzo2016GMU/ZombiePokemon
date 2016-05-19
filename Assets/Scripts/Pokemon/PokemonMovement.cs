using UnityEngine;
using System.Collections;

public class PokemonMovement : MonoBehaviour {

    Transform player;               // Reference to the player's position.
    PlayerHealth playerHealth;      // Reference to the player's health.
    PokemonHealth pokemonHealth;        // Reference to this enemy's health.
    NavMeshAgent nav;

    // Use this for initialization
    void Start () {
        // Set up the references.
        player = GameObject.Find("CardboardMain").transform;
        playerHealth = player.GetComponent<PlayerHealth>();
        pokemonHealth = GetComponent<PokemonHealth>();
        nav = GetComponent<NavMeshAgent>();
    }
	
	// Update is called once per frame
	void Update () {
        //If the enemy and the player have health left...
        if (pokemonHealth.currentHealth > 0 && playerHealth.currentHealth > 0)
        {
            // ... set the destination of the nav mesh agent to the player.
            nav.SetDestination(player.position);    
        }
        // Otherwise...
        else
        {
            // ... disable the nav mesh agent.
            nav.enabled = false;

        }
    }
}
