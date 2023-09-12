using MathNet.Numerics;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit.Utilities.Tweenables.Primitives;
using InputDevice = UnityEngine.XR.InputDevice;

public class SetXrTarget : TrainingEvent
{
    [SerializeField]
    Transform pointerTransform;

    [SerializeField]
    Transform rigTransform;

    [SerializeField]
    AutoInput input;

    [SerializeField]
    LineRenderer pointerLine;

    public InputDevice controller;
    Vector3 pointerPosition;
    Quaternion pointerRotation;


    private void LateUpdate()
    {
        pointerTransform.position = pointerPosition;
        pointerTransform.rotation = pointerRotation;
    }


    private void OnSetPos()
    {
        OnTrainingEvent(EventArgs.Empty);
        Ray ray = new Ray(pointerTransform.position, pointerTransform.forward);
        Plane ground = new Plane(Vector3.up, Vector3.zero);
        if(ground.Raycast(ray, out float enter))
        {
            input.SetHitPoint(ray.GetPoint(enter));
        }
       
    }

    private void OnMovePointer(InputValue pos)
    {
        
        pointerPosition = pos.Get<Vector3>() + rigTransform.position;
    }

    private void OnAimPointer(InputValue quat)
    {
        pointerRotation = quat.Get<Quaternion>() * rigTransform.rotation;
    }

    private void OnPointerVis(InputValue trig)
    {

        pointerLine.enabled = trig.Get<float>() > 0.02f;
    }
}
