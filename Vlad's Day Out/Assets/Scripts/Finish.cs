using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour {

    [SerializeField] string m_nextLevel;

    public void LoadNextLevel()
    {
        SceneManager.LoadScene(m_nextLevel);
    }
}
