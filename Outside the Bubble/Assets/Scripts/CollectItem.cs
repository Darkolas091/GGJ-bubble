using UnityEngine;

public class CollectItem : MonoBehaviour
{
    private ObjectID thisObject;

    private void Awake()
    {
        thisObject = GetComponent<ObjectID>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerPrefs.SetInt(thisObject.ID, PlayerPrefs.GetInt(thisObject.ID) + 1);
            Destroy(gameObject);
        }
    } 
}
