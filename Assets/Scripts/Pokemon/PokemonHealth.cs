using UnityEngine;
using System.Collections;

public class PokemonHealth : MonoBehaviour {

    public int startingHealth = 5;
    public int currentHealth;
    public int scoreValue = 1;

    bool isDead;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
	}
	
	// Update is called once per frame
	void Update () {
        //nothing atm
	}

    public void TakeDamage(int amount)
    {
        if (isDead) //if you're dead, you can't take anymore damage
            return;

        currentHealth -= amount;

        if (currentHealth <= 0)
        {
            Death(); //if the hp is less than or equal to zero, then you're dead.
        }
    }

    void Death()
    {
        isDead = true;
        ScoreManager.score += scoreValue;
        Destroy(gameObject, 0.5f);
    }
}
