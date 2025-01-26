using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private GameObject tree1;
    [SerializeField] private GameObject tree2;
    [SerializeField] private GameObject tree3;
    [SerializeField] private GameObject tree4;
    [SerializeField] private GameObject Quest1;
    [SerializeField] private TextMeshProUGUI Word1;
    [SerializeField] private GameObject Quest2;
    [SerializeField] private GameObject End1;
    [SerializeField] private GameObject End2;

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

 
            if (useCount == 1)
            {
                tree1.SetActive(false);
                tree2.SetActive(true);
                Quest1.SetActive(true);
            }
            if (useCount == 2)
            {
                Quest1.SetActive(false);
                tree2.SetActive(false);
                tree3.SetActive(true);
                Quest2.SetActive(true);
            }
            if (useCount == 3)
            {
                tree3.SetActive(false);
                tree4.SetActive(true);
                Quest2.SetActive(false);
                End1.SetActive(true);
                End2.SetActive(true);
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
