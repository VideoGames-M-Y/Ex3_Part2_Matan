using UnityEngine;

public class healthLoss : MonoBehaviour
{
    // If the Player takes damage, heart object will be destroyed

    private void DestroyHeart()
    {
        // if there is no heart object with grater x value than this object, destroy this object
        if (HasAnotherHeart() == false) {
            Destroy(this.gameObject);
        }
    }

    private bool HasAnotherHeart()
    {
        // Check if there is a heart object with grater x value than this object
        GameObject[] hearts = GameObject.FindGameObjectsWithTag("Heart");
        foreach (GameObject heart in hearts)
        {
            if (heart.transform.position.x > this.transform.position.x)
            {
                return true;
            }
        }
        return false;
    }
}
