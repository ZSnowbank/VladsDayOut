using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveXMovement : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 10.0f)] float m_speed = 1;
    [SerializeField] [Range(0.0f, 10.0f)] float m_amplitude = 1;
    [SerializeField] bool m_flipX = true;
    [SerializeField] bool m_randomStartPoint = true;

    Vector3 origin;
    float randomQuantity = 0;

	// Use this for initialization
	void Start ()
    {
        origin = transform.position;
        if(m_randomStartPoint)
        {
            randomQuantity = Random.Range(0, 100);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 newPosition = origin;
        newPosition.x += Mathf.Sin(Time.time * m_speed) * m_amplitude * Time.deltaTime;
        transform.position = newPosition;
        print(transform.position);

        if(m_flipX && Mathf.Sin(Time.time + randomQuantity) < 0) { GetComponent<SpriteRenderer>().flipX = true; }
        else
        if (m_flipX && Mathf.Sin(Time.time + randomQuantity) > 0) { GetComponent<SpriteRenderer>().flipX = false; }
	}
}
