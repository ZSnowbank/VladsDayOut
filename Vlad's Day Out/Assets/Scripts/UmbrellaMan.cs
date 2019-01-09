using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UmbrellaMan : MonoBehaviour
{
    [SerializeField] [Range(0.0f, 10.0f)] float m_speed;
    [SerializeField] GameObject m_umbrella;
    [SerializeField] GameObject m_speechBubble;
    [SerializeField] GameObject m_player;

    Vector3 m_origin;
    [HideInInspector] public StateMachine<UmbrellaMan> stateMachine = new StateMachine<UmbrellaMan>();

    public GameObject Player { get { return m_player; } }
    public Vector3 Origin {  get { return m_origin; } }

	// Use this for initialization
	void Start ()
    {
        m_origin = transform.position;

        stateMachine.AddState("Chase", new Chase(this));
        stateMachine.AddState("Return", new Return(this));
        stateMachine.AddState("Wait", new Wait(this));

        stateMachine.SetState("Wait");
        m_speechBubble.GetComponentInChildren<TextMesh>().text = "Hey My Umbrella!";
	}
	
	// Update is called once per frame
	void Update ()
    {
        stateMachine.Update();
	}

    public void OnTriggerEnter2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            if (stateMachine.State == "Wait")
            {
                //Get angry and make a speech bubble
                GameObject dialogue = Instantiate(m_speechBubble, transform);
                dialogue.transform.position = Vector3.up * 0.5f + transform.position + Vector3.back * 0.1f;

                //give the umbrella to player
                m_umbrella.transform.parent = m_player.transform;
                m_umbrella.transform.position = m_player.transform.position + Vector3.up * 0.43f + Vector3.back;

                //wait to change state
                StartCoroutine("StartChasing");
            }
            else if (stateMachine.State == "Chase")
            {
                //change state
                stateMachine.SetState("Return");

                //take back umbrella
                Vector3 offset = Vector3.back * 0.5f;
                offset.x = 0.5f;
                offset.y = 0.41f;
                m_umbrella.transform.position = transform.position + offset;

                m_umbrella.transform.parent = transform;

            }
        }
    }
    IEnumerator StartChasing()
    {
        yield return new WaitForSeconds(1.5f);
        stateMachine.SetState("Chase");
    }

    public void MoveTowards(Vector3 position)
    {
        transform.position = Vector3.MoveTowards(transform.position, position, Time.deltaTime * m_speed);
    }
}

class Chase : State<UmbrellaMan>
{
    public Chase(UmbrellaMan um)
    {
        m_owner = um;
    }
    public override void Update()
    {
        m_owner.MoveTowards(m_owner.Player.transform.position);
    }
}

class Return : State<UmbrellaMan>
{
    public Return(UmbrellaMan um)
    {
        m_owner = um;
    }

    public override void Enter()
    {
        m_owner.GetComponent<CapsuleCollider2D>().enabled = false;
    }

    public override void Update()
    {
        m_owner.MoveTowards(m_owner.Origin);

        if(m_owner.transform.position == m_owner.Origin)
        {
            m_owner.stateMachine.SetState("Wait");
        }
    }

    public override void Exit()
    {
        m_owner.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}

class Wait : State<UmbrellaMan>
{
    public Wait(UmbrellaMan um)
    {
        m_owner = um;
    }
}
