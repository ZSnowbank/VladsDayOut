using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyFollowCamera : MonoBehaviour
{
    [SerializeField] float m_followLength;
    [SerializeField] float m_screenWidth;
    [SerializeField] GameObject m_target;
    [SerializeField] Transform m_min;
    [SerializeField] Transform m_max;

    Vector3 m_offset = Vector3.up * 3;

    // Use this for initialization
    void Start()
    {
        Vector3 target = m_target.transform.position + m_offset;
        target.z = transform.position.z;

        transform.position = target;
    }

    // Update is called once per frame
    void Update ()
    {
        if (m_target)
        {
            if ((m_target.transform.position - transform.position).magnitude > m_followLength)
            {
                Vector3 target = m_target.transform.position + m_offset;
                target.z = transform.position.z;

                float speed = (target - transform.position).magnitude;

                Vector3 newPosition = Vector3.MoveTowards(transform.position, target, Time.deltaTime * speed);

                transform.position = newPosition;
            }

            if (transform.position.x < m_min.position.x + m_screenWidth)
            {
                Vector3 newPosition = transform.position;
                newPosition.x = m_min.position.x + m_screenWidth;

                transform.position = newPosition;
            }
            else if (transform.position.x > m_max.position.x - m_screenWidth)
            {
                Vector3 newPosition = transform.position;
                newPosition.x = m_max.position.x - m_screenWidth;

                transform.position = newPosition;
            }
        }
    }
}
