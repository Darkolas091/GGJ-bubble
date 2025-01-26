using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    private GameObject heldItem;
    private int useCount = 0;  

    private void Start()
    {
        heldItem = null;
        useCount = 0; 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (heldItem != null)
            {
                UseItem();
            }
            else
            {
                CollectItem();
            }
        }
    }

    private void CollectItem()
    {
        Collider2D itemCollider = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("Item"));
        if (itemCollider != null)
        {
            GameObject item = itemCollider.gameObject;

            heldItem = item;
            item.SetActive(false);
            Debug.Log("Item collected: " + item.name);
        }
    }

    private void UseItem()
    {
        Collider2D targetCollider = Physics2D.OverlapCircle(transform.position, 1f, LayerMask.GetMask("TargetArea"));
        if (targetCollider != null)
        {
            GameObject target = targetCollider.gameObject;

            target.GetComponent<TargetArea>().Activate(heldItem);
            heldItem = null;
            useCount++; 
            Debug.Log("Item used.");

 
            if (useCount >= 2)
            {
                WinGame();
            }
        }
    }

    private void WinGame()
    {

        Debug.Log("You win! Item used twice.");
        Debug.Log("You win! Item used twice.");
        Debug.Log("You win! Item used twice.");
        Debug.Log("You win! Item used twice.");
        Debug.Log("You win! Item used twice.");

    }
}
