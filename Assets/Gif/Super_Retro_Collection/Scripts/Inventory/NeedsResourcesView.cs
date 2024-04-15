using UnityEngine;

public class NeedsResourcesView : MonoBehaviour
{
    public ResourceView[] resourceViews;
    private NeedsResourcesController controller;

    public void Init(NeedsResourcesController controller)
    {
        this.controller = controller;
    }

    private void Start()
    {
        controller.Start();
    }
}