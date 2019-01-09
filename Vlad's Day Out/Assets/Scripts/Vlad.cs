using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vlad : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 10.0f)] float m_speed = 1.0f;
    [SerializeField] HealthBar m_healthBar;
    [SerializeField] [Range(0.0f, 100.0f)] float m_maxHealth = 100;
    [SerializeField] [Range(0.0f, 100.0f)] float m_health = 100;
    [SerializeField] GameObject m_deathObject;
    [SerializeField] GameObject m_speechBubble;

    string[] m_sayings =
    {
        "I think I'm lost",
        "...take a right on 2nd...",
        "I think I'm close",
        "Did he say\nright or left?"
    };

    void Awake()
    {
        if (GetComponent<ParticleSystem>()) GetComponent<ParticleSystem>().Stop();
    }

    // Update is called once per frame
    void Update()
    {
        //death
        if(m_health <= 0)
        {
            Instantiate(m_deathObject, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        //input
        Vector3 velocity = Vector3.zero;
        velocity.x = Input.GetAxis("Horizontal") * Time.deltaTime * m_speed;

        //movement
        transform.position += velocity;

        //animation
        if (velocity.x < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
        else if (velocity.x > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }

        GetComponent<Animator>().SetFloat("WalkSpeed", Math.Abs(velocity.x));

        if (Physics2D.Linecast(transform.position, transform.position, LayerMask.GetMask("Shadow")))
        {
            GetComponent<Animator>().SetBool("IsOnFire", false);
            GetComponent<AudioSource>().Stop();
            GetComponent<ParticleSystem>().Stop();
        }
        else
        {
            GetComponent<Animator>().SetBool("IsOnFire", true);
            if (!GetComponent<AudioSource>().isPlaying)
            {
                GetComponent<AudioSource>().Play();
            }
            if(!GetComponent<ParticleSystem>().isPlaying)
            {
                GetComponent<ParticleSystem>().Play();
            }
        }

        //health
        if(GetComponent<Animator>().GetBool("IsOnFire"))
        {
            m_health -= Time.deltaTime * 20;
        }

        m_healthBar.SetHealth(m_health, m_maxHealth);
    }

    public void OnTriggerEnter2D(Collider2D c)
    {
        if(c.CompareTag("Finish") && c.GetComponent<Finish>())
        {
            print(c.gameObject.layer.ToString());
            if (c.gameObject.layer != 9)
            {
                GameObject dialogue = Instantiate(m_speechBubble, transform);
                dialogue.GetComponentInChildren<TextMesh>().text = m_sayings[UnityEngine.Random.Range(0, m_sayings.Length)];
                dialogue.transform.position = Vector3.up * 0.5f + transform.position + Vector3.back * (2f + UnityEngine.Random.Range(0.0f, 0.05f));
                StartCoroutine(GoToNextLevel(c, 2));
            }
            else
            {
                StartCoroutine(GoToNextLevel(c, 1));
            }
        }
    }

    IEnumerator GoToNextLevel(Collider2D c, int seconds)
    {
        yield return new WaitForSeconds(seconds);
        c.GetComponent<Finish>().LoadNextLevel();
    }
}
