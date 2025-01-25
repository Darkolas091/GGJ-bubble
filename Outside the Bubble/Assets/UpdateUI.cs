using UnityEngine;
using TMPro;

public class UpdateUI : MonoBehaviour
{
    [SerializeField] private GameObject ObjectPrefab;
    private TextMeshProUGUI AmmountText;
    private string ObjectID;

    private void Awake()
    {
        AmmountText = GetComponent<TextMeshProUGUI>();
        ObjectID = ObjectPrefab.GetComponent<ObjectID>().ID;
    }

    private void LateUpdate()
    {
        AmmountText.text = PlayerPrefs.GetInt(ObjectID).ToString();
    }

}
