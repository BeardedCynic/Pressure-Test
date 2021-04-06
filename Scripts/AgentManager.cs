using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentManager : MonoBehaviour
{

    public GameObject[] agents;
    public int selectedIndex = 0;
    

    // Start is called before the first frame update
    void Start()
    {
        selectedIndex = 0;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GoToChamber()
    {
        if (agents[selectedIndex].GetComponent<NavAgentStateMachine_Best>().IsCurrentState<GoUninstantiate>())
        {
            if (selectedIndex >= agents.Length-1)
            {
                selectedIndex = 0;
            }
            else
            {
                selectedIndex++;
            }

        }
        else
        {
            agents[selectedIndex].GetComponent<NavAgentStateMachine_Best>().ChangeState<ChamberState>();
            agents[selectedIndex].GetComponent<NavMeshAgent>().speed = 10;
        }

    }

    public void GoToDeath()
    {

        if (agents[selectedIndex].GetComponent<NavAgentStateMachine_Best>().IsCurrentState<ChamberState>())
        {
            agents[selectedIndex].GetComponent<NavMeshAgent>().speed = 5;
            agents[selectedIndex].GetComponent<NavAgentStateMachine_Best>().ChangeState<GoUninstantiate>();
            if (selectedIndex >= agents.Length-1)
            {
                selectedIndex = 0;
            }
            else
            {
                selectedIndex++;
            }

            GoToChamber();
        }
    }
}
