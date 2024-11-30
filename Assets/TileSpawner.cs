using System.Collections;
using UnityEngine;

public class TileSpawner : MonoBehaviour
{
    [Tooltip("The RED tile prefab to spawn")]
    [SerializeField] private GameObject RedTilePrefab;

    [Tooltip("The GREEN tile prefab to spawn")]
    [SerializeField] private GameObject GreenTilePrefab;

    [Tooltip("The TRAP prefab to spawn")]
    [SerializeField] private GameObject TrapPrefab;

    [Tooltip("The time in seconds tiles spawn")]
    [SerializeField] private float spawnInterval = 1f;

    [Tooltip("The time in seconds before the tile is destroyed")]
    [SerializeField] private float waitTime = 3f;

    private float timeSinceLastSpawn;

    public int rows = 13;              // Number of rows in your tile grid
    public int columns = 14;           // Number of columns in your tile grid
    public float tileSize = 1f;       // Size of each tile

    private Vector3[,] tilePositions; // 2D array to hold the tile positions

    void Start()
    {
        // Generate the tile positions
        GenerateTilePositions();

        // Randomly spawn an object on a tile
        SpawnObjectOnRandomTile();
    }

    void GenerateTilePositions()
    {
        tilePositions = new Vector3[rows, columns];
        // Calculate the range of positions based on the provided boundaries
        float xMin = -4.41f;
        float xMax = 4.31f;
        float yMin = -3.21f;
        float yMax = 3.11f;

        // Loop through the grid and calculate each tile's position
        for (int row = 0; row < rows; row++)
        {
            for (int col = 0; col < columns; col++)
            {
                // Calculate position with even spacing within the boundaries
                float xPos = Mathf.Lerp(xMin, xMax, (float)col / (columns - 1)); // Interpolate between xMin and xMax
                float yPos = Mathf.Lerp(yMin, yMax, (float)row / (rows - 1));   // Interpolate between yMin and yMax

                // Assign the position to the tile matrix
                tilePositions[row, col] = new Vector3(xPos, yPos, 0);
            }
        }
    }

    void SpawnObjectOnRandomTile()
    {
        // Randomly pick an object to spawn
        GameObject objectToSpawn = Random.value < 0.5f ? GreenTilePrefab :  RedTilePrefab;

        // Randomly pick a tile position from the matrix
        int randomRow = Random.Range(0, rows);
        int randomCol = Random.Range(0, columns);

        Vector3 spawnPosition = tilePositions[randomRow, randomCol];

        //if the position is takem, do not spawn
        if (Physics2D.OverlapCircle(spawnPosition, 0.1f) != null)
        {
            return;
        }
        // Instantiate the object at the random tile position
        GameObject spawnedObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);

        if (objectToSpawn == RedTilePrefab){
            StartCoroutine(SpawnTrapAfterDelay(spawnPosition));
        }

        // Destroy the object after 3 seconds
        Destroy(spawnedObject, waitTime);
    }

    private IEnumerator SpawnTrapAfterDelay(Vector3 position)
    {
        // Wait for the red tile to be destroyed
        yield return new WaitForSeconds(waitTime);

        // Instantiate the trap at the same position
        GameObject trap = Instantiate(TrapPrefab, position, Quaternion.identity);
        
        // Destroy the trap after the same amount of time
        Destroy(trap, waitTime);
    }

    void SpawnTrap(Vector3 spawnPosition)
    {
        // Instantiate the object at the random tile position
        GameObject spawnedTrap = Instantiate(TrapPrefab, spawnPosition, Quaternion.identity);

        // Destroy the object after 3 seconds
        Destroy(spawnedTrap, waitTime);
    }

    void Update()
    {
        timeSinceLastSpawn += Time.deltaTime;
        if (timeSinceLastSpawn >= spawnInterval)
        {
            SpawnObjectOnRandomTile();
            timeSinceLastSpawn = 0;
        }
    }
}
