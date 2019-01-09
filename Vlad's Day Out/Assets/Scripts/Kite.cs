using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kite : MonoBehaviour
{
    [SerializeField] GameObject m_kiteHolder;
    [SerializeField] GameObject m_stuckKite;

    LineRenderer m_lineRenderer;

    public GameObject KiteHolder { get { return m_kiteHolder; } set { m_kiteHolder = value; } }

	// Use this for initialization
	void Start ()
    {
        m_lineRenderer = GetComponent<LineRenderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (m_kiteHolder)
        {
            m_lineRenderer.SetPosition(1, m_kiteHolder.transform.position);

            if (!m_kiteHolder.GetComponent<Kid>())
            {
                GetComponent<SinWaveMovement2D>().enabled = false;

                Vector3 targetPosition = m_kiteHolder.transform.position;
                targetPosition.y = transform.position.y;

                Vector3 velocity = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime);

                //animation
                if (velocity.x - transform.position.x > 0) { GetComponent<SpriteRenderer>().flipX = false; }
                else if (velocity.x - transform.position.x < 0) { GetComponent<SpriteRenderer>().flipX = true; }

                //movement
                transform.position = velocity;
            }
            else
            {
                GetComponent<SinWaveMovement2D>().enabled = true;
            }
        }

        m_lineRenderer.SetPosition(0, transform.position);
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.CompareTag("Tree"))
        {
            Vector3 offset = Vector3.zero;

            if(GetComponent<SpriteRenderer>().flipX) { offset = Vector3.left * 0.5f; }
            else { offset = Vector3.right * 0.5f; }

            GameObject newKite = Instantiate(m_stuckKite, transform.position + offset, Quaternion.identity);

            newKite.GetComponent<SpriteRenderer>().flipX = GetComponent<SpriteRenderer>().flipX;

            Destroy(gameObject);
        }
    }
}
