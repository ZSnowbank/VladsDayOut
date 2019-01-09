using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PerceptionSphere : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 360.0f)] float m_fov = 360.0f;
    [SerializeField] [Range(0.0f, 100.0f)] float m_radius = 5.0f;
    [SerializeField] LayerMask m_layerMask;

    public GameObject[] GetAllGameObjectsWithTag(string tag)
    {
        List<GameObject> gameObjects = new List<GameObject>();
        Collider[] colliders = Physics.OverlapSphere(transform.position, m_radius);

        foreach(Collider c in colliders)
        {  
            if(c.CompareTag(tag))
            {
                gameObjects.Add(c.gameObject);
            }
        }
        
        return gameObjects.ToArray();
    }

    public GameObject GetNearestGameObjectWithTag(string tag)
    {
        GameObject[] gos = GetAllGameObjectsWithTag(tag);

        GameObject nearestGameObject = gos.Length > 0 ? gos[0] : null;

        foreach(GameObject go in gos)
        {
            float distance = (transform.position - go.transform.position).magnitude;
            float record = (transform.position - nearestGameObject.transform.position).magnitude;

            if(distance < record)
            {
                nearestGameObject = go;
            }
        }

        return nearestGameObject;
    }
}
