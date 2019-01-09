using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SinWaveMovement2D : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 10.0f)] float m_frequency = 1;
    [SerializeField] [Range(0.0f, 10.0f)] float m_amplitude = 1;
    [SerializeField] bool m_flipX = true;
    [SerializeField] bool m_randomStartPoint = true;

    Vector3 m_origin;
    float randomQuantity = 0;
    float m_prevSinValue;
    SpriteRenderer m_spriteRenderer;

	// Use this for initialization
	void Start ()
    {
        m_origin = transform.position;
        m_spriteRenderer = GetComponent<SpriteRenderer>();

        if(m_randomStartPoint)
        {
            randomQuantity = Random.Range(0, 100);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
        float sinValue = Mathf.Sin(Time.time * m_frequency) * m_amplitude;
        transform.position = m_origin + Vector3.right * sinValue;

        if(m_flipX)
        {
            if (sinValue > m_prevSinValue)
            {
                m_spriteRenderer.flipX = false;
            }
            else if (sinValue < m_prevSinValue)
            {
                m_spriteRenderer.flipX = true;
            }
        }
        m_prevSinValue = sinValue;
	}
}
