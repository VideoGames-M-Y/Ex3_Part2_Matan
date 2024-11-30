using UnityEngine;

public class destroyOnTrigger2D : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == triggeringTag && enabled) {
            if (this.gameObject.tag == "Player") {
                this.gameObject.GetComponent<HealthPoints>().TakeDamage(1);
                Debug.Log("Player hit");
            } else {
                Destroy(this.gameObject);
            }
            Destroy(other.gameObject);
        }
    }

    private void Update() {
        /* Just to show the enabled checkbox in Editor */
    }
}
