using System.Collections.Generic;

// todo possibly extract updating resource view logic from inventory and needResources controller here
public class UpdateResourceViewsCommand : ICommand
{
    private readonly Dictionary<ResourceType, int> resources;
    private readonly ResourceView[] views;

    public UpdateResourceViewsCommand(Dictionary<ResourceType, int> resources, ResourceView[] views)
    {
        this.resources = resources;
        this.views = views;
    }
    
    public void Execute()
    {

    }
}