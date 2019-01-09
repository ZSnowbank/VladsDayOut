using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kid : MonoBehaviour
{
    [SerializeField] Kite m_kite;

	// Use this for initialization
	void Start ()
    {
        GetComponent<ParticleSystem>().Stop();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            m_kite.KiteHolder = c.gameObject;
            GetComponent<ParticleSystem>().Play();
        }
    }
}
