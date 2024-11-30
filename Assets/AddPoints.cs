// using UnityEngine;

// public class AddPoints : MonoBehaviour
// {
//    [SerializeField] private int pointValue = 1;
//     private void OnTriggerEnter2D(Collider2D other)
//     {
//         if (other.tag == "Player")
//         {
//             other.GetComponent<ScoreManager>().UpdateScore(pointValue);
//             Destroy(gameObject);
//         }
//     }
// }

using UnityEngine;

public class AddPoints : MonoBehaviour
{
   [SerializeField] private int pointValue = 1;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            GameObject.FindFirstObjectByType<ScoreManager>().UpdateScore(pointValue);
            Destroy(gameObject);
        }
    }
}
