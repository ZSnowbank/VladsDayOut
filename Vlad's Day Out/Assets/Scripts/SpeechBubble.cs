using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeechBubble : MonoBehaviour
{
    [SerializeField] string m_text;
    [SerializeField] float m_lifeTime = 2.0f;

	// Use this for initialization
	void Start ()
    {
        if(m_text != string.Empty)
        {
            GetComponentInChildren<TextMesh>().text = m_text;
        }
        if (m_lifeTime >= 0)
        {
            Destroy(gameObject, m_lifeTime);
        }
	}
}
