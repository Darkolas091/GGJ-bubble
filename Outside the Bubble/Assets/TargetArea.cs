using UnityEngine;

public class TargetArea : MonoBehaviour
{
    public void Activate(GameObject item)
    {
        if (item != null)
        {
            Debug.Log("Item used on target area: " + item.name);

        }
    }
}