/*using UnityEngine;

public class ShowObjectives : MonoBehaviour
{
    

    public class GoToObjective : MonoBehavior, IObjective
{
    [SerializedField]
    private string title;
    [SerializedField]
    private string description;
    [SerializedField]
    private Transform playerTransform;

    public string Title => title;
    public string Description => description;
    public bool IsCompleted { get; private set; }

    private void Start()
    {
        // Add the objective to an ObjectivesManager (Singleton) that holds a
        // List<IObjective> that you can read to get all Objectives (or remaining ones)
        // and display them on the UI

        ObjectivesManager.Instance.AddObjective(this);
    }

    private void Update()
    {
        CheckCompleted();
    }

    private void CheckCompleted()
    {
        if (IsCompleted)
            return;

        if (Vector3.Distance(playerTransform.position, transform.position) < 0.25f>)
        {
            IsCompleted = true;
            ObjectivesManager.Instance.SetObjectiveCompleted(this);
        }
    }
}
}*/
