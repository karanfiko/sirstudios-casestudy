using System;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public static GameEvents instance;

    private void Awake()
    {
        if (instance)
        {
            Destroy(this);
            return;
        }

        instance = this;
    }

    //Collect Event
    public event Action<ICollectable> onObjectCollected;

    public void ObjectCollected(ICollectable obj)
    {
        onObjectCollected?.Invoke(obj);
    }
}