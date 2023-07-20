using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MMKinematicRigSubscriber : MonoBehaviour
{
    [SerializeField] 
    MjKinematicRig rig;

    [SerializeField]
    MMController controller;

    private void Awake()
    {
        controller.frameReadyHandler += (object sender, EventArgs args) => rig.TrackKinematics();
    }

}
