using UnityEngine;

public class CollectableGenerator : MonoBehaviour
{

    public int activeCollectableCount = 5;
    [SerializeField] private GameObject collectablePrefab;

    //Genarion Area
    [SerializeField] private Vector3 generationAreaPos, generationAreaSize;

    private void Start()
    {
        GameEvents.instance.onObjectCollected += OnObjectCollected;
        
        //InitialGeneration
        for (int i = 0; i < activeCollectableCount; i++)
        {
            GenerateNewCollectableObject();
        }

    }

    private void OnObjectCollected(ICollectable obj)
    {
        float time = UnityEngine.Random.Range(1, 3);
        Invoke("GenerateNewCollectableObject", time);
    }

    private void GenerateNewCollectableObject()
    {
        GameObject newGeneratedObject = Instantiate(collectablePrefab, GetUniqueGenerationTransform(), Quaternion.identity);
    }

    private Vector3 GetUniqueGenerationTransform()
    {
        var uniquePosition = Vector3.zero;
        uniquePosition.x = UnityEngine.Random.Range(generationAreaPos.x - (generationAreaSize.x / 2), generationAreaPos.x + (generationAreaSize.x / 2));
        uniquePosition.z = UnityEngine.Random.Range(generationAreaPos.z - (generationAreaSize.z / 2), generationAreaPos.z + (generationAreaSize.z / 2));
        return uniquePosition;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireCube(generationAreaPos, generationAreaSize);
    }
}
