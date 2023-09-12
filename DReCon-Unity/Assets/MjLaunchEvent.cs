using ModularAgents.Kinematic;
using ModularAgents.Kinematic.Mujoco;
using ModularAgents;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mujoco;
using System;
using Unity.VisualScripting;

namespace Mujoco.Extensions
{
    /// <summary>
    /// Ballistic targeting with first order approx of target position.
    /// </summary>
    public class MjLaunchEvent : TrainingEventHandler
    {
        [SerializeField]
        Transform origin;

        [SerializeField]
        MjFreeJoint projectileDofs;

        [SerializeField]
        float startingVelocity;

        public override EventHandler Handler => LaunchProjectile;

        private unsafe void LaunchProjectile(object sender, EventArgs e)
        {
            Launch(origin.forward * startingVelocity);


        }

        private unsafe void Launch(Vector3 velocity)
        {
            MjState.TeleportMjRoot(projectileDofs, origin.position, false);
            MjEngineTool.SetMjVector3(MjScene.Instance.Data->qvel + projectileDofs.DofAddress, velocity);
            MjEngineTool.SetMjVector3(MjScene.Instance.Data->qvel + projectileDofs.DofAddress + 3, Vector3.zero);
        }

       
    }
}