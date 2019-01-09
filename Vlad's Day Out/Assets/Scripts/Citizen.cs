using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Citizen : MonoBehaviour
{
    [SerializeField] SpeechBubble m_speechBubble;

    SpeechBubble m_dialogue;

    string[] m_sayings =
    {
        "You look pale.",
        "Watch for sunburn",
        "Howzit going",
        "Nice out today",
        "Hey",
        "*finger guns*",
        "Salutations",
        "Nice cape",
        "...",
        "*awkward silence",
    };
    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player" && !m_dialogue)
        {
            m_dialogue = Instantiate(m_speechBubble, transform);
            m_dialogue.GetComponentInChildren<TextMesh>().text = m_sayings[Random.Range(0, m_sayings.Length)];
            m_dialogue.transform.position = Vector3.up * 0.5f + transform.position + Vector3.back * (2f + Random.Range(0.0f, 0.05f));
        }
    }
}
