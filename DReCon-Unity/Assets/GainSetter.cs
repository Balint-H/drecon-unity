using ModularAgents.DReCon;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GainSetter : TrainingEventHandler
{
    [SerializeField]
    StablePDActuator actuator;

    [SerializeField]
    float kP;

    [SerializeField]
    float kD;

    public override EventHandler Handler => (_, _) => actuator.SetGains(kP, kD);
}
