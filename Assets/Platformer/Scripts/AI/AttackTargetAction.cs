using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "AttackTarget", story: "[Agent] attacks [Target]", category: "Action", id: "e372783c3af3d1c6650ae75deb8b4f02")]
public partial class AttackTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;

    TankController tankController;

    HealthManager healthWidget;

    protected override Status OnStart()
    {
        tankController = Agent.Value.GetComponent<TankController>();
        healthWidget = HealthManager.instance;
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        switch (healthWidget.currentState)
        {
            case PlayerState.Alive:
                tankController.AttackTarget();
                return Status.Success;
            case PlayerState.Invulnerable:
                return Status.Running;
            default:
                return Status.Failure;
        }
    }

    protected override void OnEnd()
    {
    }
}

