using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour {

    [SerializeField] LayerMask m_layerMask;
    [SerializeField] GameObject[] m_objects;
    int m_selected;
    
    // Use this for initialization
	void Start() 
	{
        m_selected = 0;
	}
	
	// Update is called once per frame
	void Update() 
	{
		if(Input.GetKeyDown(KeyCode.RightShift))
        {
            m_selected++;
            m_selected %= m_objects.Length;
        }

        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 50.0f, m_layerMask))
            {
                Instantiate(m_objects[m_selected], hit.point, Quaternion.identity);
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            LayerMask layerMask = m_objects[m_selected].layer;

            if (Physics.Raycast(ray, out hit, 50.0f))
            {
                if (hit.collider.tag == m_objects[m_selected].tag)
                {
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
