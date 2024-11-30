using UnityEngine;

public class HeartSpawner : MonoBehaviour
{
    [Tooltip("Prefab of the heart to spawn")]
    [SerializeField] private GameObject heartPrefab;
    private GameObject[] hearts;

    private void Start()
    {
        int numberOfHearts = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPoints>().Health;

        // Spawn hearts at the start of the game
        for (int i = 0; i < numberOfHearts; i++)
        {
            Vector3 spawnPosition = new Vector3(i -4.6f, 4.3f, 0); // Adjust position
            Instantiate(heartPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }

    private void Update()
    {
        // If the player takes damage, destroy the last heart
        int healthPoints = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthPoints>().Health;
        GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
        if (healthPoints < hearts.Length)
        {
            if (hearts.Length > 0)
            {
                Destroy(hearts[hearts.Length - 1]);
            }
        }
        if (healthPoints > hearts.Length)
        {
            Vector3 spawnPosition = new Vector3(hearts.Length -4.6f , 4.3f, 0); // Adjust position
            Instantiate(heartPrefab, spawnPosition, Quaternion.identity, transform);
        }
    }
}
