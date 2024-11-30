using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthPoints : MonoBehaviour
{
    [Tooltip("The amount of health points this object has")]
    [SerializeField] private int Max_healthPoints = 3;
    private int health;

    private void Start()
    {
        health = Max_healthPoints;
    }

    public int Health
    {
        get => health;
        set => health = value;
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage. Remaining health: {health}");
        if (health <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }

    public void Heal(int heal)
    {
        if (health < Max_healthPoints)
        {
            health += heal;
            Debug.Log($"{gameObject.name} healed {heal} points. Remaining health: {health}");
        }
    }
}
