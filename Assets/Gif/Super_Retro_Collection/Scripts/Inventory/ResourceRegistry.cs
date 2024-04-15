
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;

public class ResourceRegistry
{
    private readonly ResourceData[] resourceDatas;

    public ResourceRegistry()
    {
        resourceDatas = Resources.LoadAll("ResourceData", typeof(ResourceData)).Select(data => (ResourceData)data)
            .ToArray();
    }

    [CanBeNull]
    public Sprite GetResourceSprite(ResourceType type)
    {
        var data = resourceDatas.FirstOrDefault(data => data.type == type);
        if (data != null)
        {
            return data.image;
        }

        return null;
    }
}