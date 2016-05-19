using UnityEngine;

public class PlayerHealth : MonoBehaviour {

    public int startingHealth = 100;
    public int currentHealth = 0;

    bool isDead;
    bool damaged;

	// Use this for initialization
	void Start () {
        currentHealth = startingHealth;
	}
	
    public void TakeDamage(int damage)
    {
        damaged = true;

        currentHealth -= damage;

        if (currentHealth <= 0 && !isDead)
        {
            Death();
        }
    }

    void Death()
    {
        isDead = true;
    }
}
