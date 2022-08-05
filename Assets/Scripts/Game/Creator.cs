using UnityEngine;

public class Creator : MonoBehaviour
{
    private ViewServices _viewServices;

    private void Start()
    {
        _viewServices = new ViewServices();
    }

    public GameObject GetOrCreateObject(GameObject gameObject, Transform startPosition)
    {
        return _viewServices.Create(gameObject, startPosition);
    }   
    
    public void DestroyObject(GameObject prefab, GameObject gameObject)
    {
        _viewServices.Destroy(prefab ,gameObject);
    }
}
