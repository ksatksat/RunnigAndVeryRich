using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100, startHealth = 20;
    private int currentHealth;

    public HealthBar healthBar;

    void Start()
    {
        currentHealth = startHealth;
        healthBar.SetMaxHealth(startHealth);
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        if (currentHealth < 1){
            Die();
        }
    }

    private void Die(){
        Debug.Log("I died !");
        //stop moving
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BadPickup"))
        {
            TakeDamage(5);
            Debug.Log("Health: " + currentHealth);
        }
        if (collision.gameObject.CompareTag("GoodPickup"))
        {
            Heal(5);
            Debug.Log("Health: " + currentHealth);
        }
    }
}
