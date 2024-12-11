using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "LostTarget", story: "[Agent] loses sight of [Enemy]", category: "Action", id: "64c5fbec8171b515bb8d026568d662c7")]
public partial class LostTargetAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Enemy;

    NavMeshAgent agent;
    AISensor sensor;

    protected override Status OnStart()
    {
        agent = Agent.Value.GetComponent<NavMeshAgent>();
        sensor = Agent.Value.GetComponent<AISensor>();
        return Status.Running;
    }

    protected override Status OnUpdate()
    {
        if (sensor.canSeePlayer)
        {
            return Status.Running;
        }
        Enemy.Value = null;
        return Status.Success;
    }

    protected override void OnEnd()
    {
    }
}

