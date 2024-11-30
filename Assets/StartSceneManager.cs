using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;  // To manage scene transitions

public class StartSceneManager : MonoBehaviour
{
    void Update()
    {
        // Check if the SPACE key is pressed
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Load the GameScene when the SPACE key is pressed
            SceneManager.LoadScene("SampleScene");
        }
    }
}
