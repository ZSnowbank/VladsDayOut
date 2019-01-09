using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] GameObject m_camera;
    [SerializeField] GameObject m_outline;
    [SerializeField] GameObject m_health;

    LineRenderer m_outLineLineRenderer;
    LineRenderer m_healthLineRenderer;

    // Use this for initialization
    void Start()
    {
        m_outLineLineRenderer = m_outline.GetComponent<LineRenderer>();
        m_healthLineRenderer = m_health.GetComponent<LineRenderer>();
    }

    public void SetHealth(float health, float maxHealth)
    {
        Vector3[] outLinepositions = { Vector3.zero, Vector3.zero };
        m_outLineLineRenderer.GetPositions(outLinepositions);

        //calculate health
        m_outLineLineRenderer.GetPositions(outLinepositions);

        Vector3 max = outLinepositions[1] - outLinepositions[0];
        Vector3 curHealth = max * health / maxHealth;

        m_healthLineRenderer.SetPosition(1, curHealth + outLinepositions[0]);
    }
}
