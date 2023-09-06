using ModularAgents.Kinematic;
using ModularAgents.DReCon;
using ModularAgents.Kinematic.Mujoco;
using MotionMatch;
using Mujoco.Extensions;
using System.Collections;
using System.Collections.Generic;
using Unity.MLAgents.Sensors;
using UnityEngine;
using ModularAgents;

public class DReConHeadingObservation : ObservationSource
{
    [SerializeField]
    DampedTrajectoryInput trajectoryInput;

    [SerializeField]
    Transform root;
    IKinematic rootKinematics;

    ModularAgents.DReCon.ReferenceFrame CurFrame => rootKinematics.GetReferenceFrame();

    public override int Size => 2;

    public override void FeedObservationsToSensor(VectorSensor sensor)
    {

        sensor.AddObservation(CurFrame.WorldDirectionToCharacter(trajectoryInput.AnalogueHeading.ProjectTo3D()).Horizontal());
    }

    public override void OnAgentStart()
    {

    }

    private void Awake()
    {
        MjState.ExecuteAfterMjStart(MjInitialize);
    }

    void MjInitialize()
    {
        rootKinematics = root.GetIKinematic();
    }

    private void OnDrawGizmosSelected()
    {
        if (!Application.isPlaying) return;
        CurFrame.Draw();
        Gizmos.color = Color.magenta;
        Gizmos.DrawRay(rootKinematics.Position, trajectoryInput.AnalogueHeading.ProjectTo3D());
    }
}
