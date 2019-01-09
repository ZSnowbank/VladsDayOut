using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayBetweenScenes : MonoBehaviour
{
    static GameObject m_instance;

	// Use this for initialization
	void Start ()
    {
        DontDestroyOnLoad(gameObject);
        if (!m_instance)
        {
            m_instance = this.gameObject;
        }
        else
        {
            Destroy(gameObject);
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
