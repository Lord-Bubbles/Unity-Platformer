using System;
using Unity.Behavior;
using UnityEngine;
using Action = Unity.Behavior.Action;
using Unity.Properties;
using UnityEngine.AI;
using UnityEngine.Splines;

[Serializable, GeneratePropertyBag]
[NodeDescription(name: "DetectPlayer", story: "[Agent] detects [Target]", category: "Action", id: "144109ed12e22d77ffe3417d3b11702a")]
public partial class DetectPlayerAction : Action
{
    [SerializeReference] public BlackboardVariable<GameObject> Agent;
    [SerializeReference] public BlackboardVariable<GameObject> Target;
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
            Target.Value = GameObject.FindGameObjectWithTag("Player");
            return Status.Success;
        }
        return Status.Running;
    }

    protected override void OnEnd()
    {
    }
}

