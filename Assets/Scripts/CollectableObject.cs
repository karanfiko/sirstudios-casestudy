using UnityEngine;

public class CollectableObject : MonoBehaviour, ICollectable
{
    [SerializeField] private int point;
    public int collectablePoint { get { return point; } set => point = value; }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameEvents.instance.ObjectCollected(this);
            Destroy(gameObject);
        }
    }
}
