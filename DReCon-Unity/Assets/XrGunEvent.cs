using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;

using InputDevice = UnityEngine.XR.InputDevice;

public class XrGunEvent : TrainingEvent
{
    [SerializeField]
    Transform gunTransform;

    [SerializeField]
    Transform rigTransform;

    public InputDevice controller;
    Vector3 gunPosition;
    Quaternion gunRotation;

    private void LateUpdate()
    {
        gunTransform.position = gunPosition;
        gunTransform.rotation = gunRotation;
    }


    private void OnTrigger()
    {
        OnTrainingEvent(EventArgs.Empty);
    }

    private void OnMove(InputValue pos)
    {
        gunPosition = pos.Get<Vector3>()+rigTransform.position;
    }

    private void OnAim(InputValue quat)
    {
        gunRotation = quat.Get<Quaternion>() * rigTransform.rotation;
    }
}
