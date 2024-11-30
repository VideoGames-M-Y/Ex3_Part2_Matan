using UnityEngine;

public class FadeOut : MonoBehaviour
{
    private Material tileMaterial; // The material of the red tile
    private Color originalColor;   // Store the original color of the material
    [SerializeField] private float fadeDuration = 3.5f; // Duration of fade (in seconds)
    // start fading out gradually within 3 seconds
    void Start()
    {
        tileMaterial = GetComponent<Renderer>().material;
        originalColor = tileMaterial.color;

        // Start the fade out process
        StartCoroutine(FadeOutOverTime());
    }

    // Coroutine to fade out the material over time
    private System.Collections.IEnumerator FadeOutOverTime()
    {
        float elapsedTime = 0f; // Elapsed time since the start of the fade
        while (elapsedTime < fadeDuration)
        {
            // Calculate the new alpha value based on the elapsed time
            float newAlpha = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            // Update the material's color with the new alpha value
            tileMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, newAlpha);
            // Increment the elapsed time
            elapsedTime += Time.deltaTime;
            // Wait for the next frame
            yield return null;
        }
        // Ensure the material is fully transparent at the end of the fade
        tileMaterial.color = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
        // Destroy the object after fading out
        Destroy(gameObject);
    }
}
