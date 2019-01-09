using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonArranger : MonoBehaviour
{
    [SerializeField] float m_sizeX;
    [SerializeField] float m_sizeY;
    [SerializeField] float m_positionX;
    [SerializeField] float m_positionY;

    Button m_button;

	// Use this for initialization
	void Start ()
    {
        m_button = GetComponent<Button>();

        //scaling
        Vector3 scale = Vector3.zero;
        scale.x = Screen.width * m_sizeX;
        scale.y = Screen.height * m_sizeY;

        //position
        Vector3 position = Vector3.zero;
        position.x = Screen.width * m_positionX;
        position.y = Screen.height * m_positionY;

        if (m_button)
        {
            m_button.image.rectTransform.sizeDelta = scale;
            m_button.image.rectTransform.position = position;
        }

        if(GetComponentInChildren<Text>())
        {
            GetComponentInChildren<Text>().fontSize = Mathf.FloorToInt(scale.y / 3f);
        }
    }
}
