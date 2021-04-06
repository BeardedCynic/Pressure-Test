using UnityEngine;
using System.Collections;
using UnityEngine.AI;
using UnityEditor;


public class NavAgentStateMachine_Best : FSGDN.StateMachine.MachineBehaviour
{
    [SerializeField] NavPoint[] myNavPoints;
    [SerializeField] NavPoint[] myOtherNavPoints;
    [SerializeField] GameObject ChamberNav;
    int navIndex = 0;
    int otherNavIndex = 0;
    
    public override void AddStates()
    {
        AddState<PatrolState_Best>();
        AddState<IdleState_Best>();
        AddState<PauseState>();
        AddState<ChamberState>();
        AddState<GoUninstantiate>();

        SetInitialState<PatrolState_Best>();
    }

    public void pickNextNavPoint()
    {
        ++navIndex;
        if (navIndex >= myNavPoints.Length)
            navIndex = 0;
    }

    public void pickOtherNextNavPoint()
    {
        ++otherNavIndex;
        if (otherNavIndex >= myOtherNavPoints.Length)
            otherNavIndex = 0;
    }

    public void FindDestination()
    { 
        GetComponent<NavMeshAgent>().SetDestination(myNavPoints[navIndex].transform.position);
    }

    public void FindOtherDestination()
    {
        GetComponent<NavMeshAgent>().SetDestination(myOtherNavPoints[otherNavIndex].transform.position);
    }

    public void SetChamberDestination()
    {
        GetComponent<NavMeshAgent>().SetDestination(ChamberNav.transform.position);
    }

    void OnTriggerEnter(Collider other)
    {
        
        if (IsCurrentState<ChamberState>())
        {
            return;
        }
        if (other.gameObject.GetComponent<NavPoint>())
            ChangeState<IdleState_Best>();
    }

    // Helper function for setting the object color
    public void SetMainColor(Color color)
    {
        GetComponent<Renderer>().material.color = color;
    }

    bool paused = false;
    FSGDN.StateMachine.State lastState = null;

    public void Pause()
    {
        // toggle paused value
        paused = !paused;

        if (paused)
        {
            // store current state for use when unpausing
            lastState = currentState;

            // change state to Pause
            ChangeState<PauseState>();
            GetComponent<NavMeshAgent>().isStopped = true;
        }
        else
        {
            // restore stored state when pausing earlier
            ChangeState(lastState.GetType());
            GetComponent<NavMeshAgent>().isStopped = false;
        }
    }

    public override void Update()
    {
        // since this overrides the state machine’s Update()
        // it is very important to call parent class’ Update()
        // because that is where the state machine does it’s work for us
        base.Update();

        // check for keypress and then change state
    }
}

// New base class for NavAgent states that gives us some utility
// functions to help clean things up even more
public class NavAgentState : FSGDN.StateMachine.State
{
    // Nice accessor for getting our state machine script reference
    protected NavAgentStateMachine_Best NavAgentStateMachine()
    {
        return ((NavAgentStateMachine_Best)machine);
    }
}

// NOTE: now inherits from NavAgentState
public class PatrolState_Best : NavAgentState
{
    public override void Enter()
    {
        base.Enter();
        NavAgentStateMachine().FindDestination();
    }
}

// NOTE: now inherits from NavAgentState
public class IdleState_Best : NavAgentState
{
    float timer = 0;

    public override void Enter()
    {
        base.Enter();
        timer = 0;
    }

    public override void Execute()
    {
        timer += Time.deltaTime;
        if (timer >= 2.0f)
        {
            machine.ChangeState<PatrolState_Best>();
            NavAgentStateMachine().pickNextNavPoint();
        }
    }
}

public class PauseState : NavAgentState
{
    public override void Enter()
    {
        base.Enter();
    }
}

public class ChamberState : NavAgentState
{
    public override void Enter()
    {
        base.Enter();

        NavAgentStateMachine().SetChamberDestination();
    }
}

public class GoUninstantiate : NavAgentState
{
    public override void Enter()
    {
        base.Enter();

        NavAgentStateMachine().FindOtherDestination();
    }
}
