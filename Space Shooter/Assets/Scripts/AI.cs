using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles NPC desicionmaking
public class AI : MonoBehaviour
{

    IState currentState;

    public List<ShipSystem> systems;

    private void Start()
    {
        ChangeState(new StateAggro(GetComponent<Ship>(), PlayerHandler.playerShip, systems));
    }

    void Update()
    {
        currentState.Update();
    }

    void ChangeState(IState state)
    {
        currentState?.Exit();
        currentState = state;
        currentState.Enter();
    }
}

//AI state
public interface IState
{
    void Enter();

    void Update();

    void Exit();
}

public class StateIdle : IState
{
    Ship ship;
    Vector2 wanderTarget;

    public StateIdle(Ship ship)
    {
        this.ship = ship;
        wanderTarget = ship.transform.position;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (NeedTarget())
            wanderTarget = GetTarget();

        ship.MoveTowards(wanderTarget);
    }

    bool NeedTarget()
    {
        return Vector2.Distance(wanderTarget, ship.transform.position) < 1f;
    }

    Vector2 GetTarget()
    {
        return (Vector2)ship.transform.position + Random.insideUnitCircle * 10f;
    }
}

public class StateAggro : IState
{

    Ship owner;
    Ship target;
    List<ShipSystem> systems;

    public StateAggro(Ship owner, Ship target, List<ShipSystem> systems)
    {
        this.owner = owner;
        this.target = target;
        this.systems = systems;
    }

    public void Enter()
    {

    }

    public void Exit()
    {

    }

    public void Update()
    {
        if (target == null)
            return;
        owner.MoveTowards(target.transform.position);

        foreach (ShipSystem ssystem in systems)
            ssystem.Activate();
    }
}
