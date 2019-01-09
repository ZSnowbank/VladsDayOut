using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{
    [SerializeField] Transform m_min;
    [SerializeField] Transform m_max;
    [SerializeField] bool moveRight = true;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (moveRight)
        {
            transform.position += Vector3.right * Time.deltaTime;
            if (transform.position.x > m_max.position.x + 4)
            {
                Vector3 newPosition = transform.position;

                newPosition.x = m_min.position.x - 4;

                transform.position = newPosition;
            }
        }
        else
        {
            transform.position += Vector3.left * Time.deltaTime;
            if (transform.position.x < m_min.position.x - 4)
            {
                Vector3 newPosition = transform.position;

                newPosition.x = m_max.position.x + 4;

                transform.position = newPosition;
            }
        }
	}
}
