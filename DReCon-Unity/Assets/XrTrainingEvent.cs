using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using InputDevice = UnityEngine.XR.InputDevice;

public class XrTrainingEvent : TrainingEvent
{
    public InputDevice controller;
    private void OnFire()
    {
        OnTrainingEvent(EventArgs.Empty);
    }
}
