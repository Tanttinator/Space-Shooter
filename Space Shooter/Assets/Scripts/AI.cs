using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Handles NPC desicionmaking
public class AI : MonoBehaviour
{

    IState currentState;

    private void Start()
    {
        ChangeState(new StateAggro(GetComponent<Ship>(), PlayerHandler.playerShip));
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
    EntityShip entity;
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

        ship.entity.MoveTowards(wanderTarget);
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

    public StateAggro(Ship owner, Ship target)
    {
        this.owner = owner;
        this.target = target;
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
        owner.entity.MoveTowards(target.transform.position);
        if(owner.HasWeapons)
            owner.weapons.Shoot();
    }
}
