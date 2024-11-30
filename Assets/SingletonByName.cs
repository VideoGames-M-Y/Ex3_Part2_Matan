using System.Linq;
using UnityEngine;

public class SingletonByName : MonoBehaviour
{
    void Awake() {
        string myName = gameObject.name;
        // The following line is based on code by Isaiah Kelly: http://answers.unity.com/answers/1252385/view.html
        GameObject[] otherObjectsWithSameName = Resources.FindObjectsOfTypeAll<GameObject>().Where(obj => obj.name == myName).ToArray<GameObject>();
        Debug.Log("otherObjectsWithSameName.Length: "+otherObjectsWithSameName.Length);
        if (otherObjectsWithSameName.Length > 1) {
            Destroy(gameObject);
        } else {
            Object.DontDestroyOnLoad(gameObject);
        }
    }
}
