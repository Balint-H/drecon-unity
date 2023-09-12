using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTransformHandler : TrainingEventHandler
{
    [SerializeField]
    Transform sourceTransform;

    [SerializeField]
    Transform targetTransform;

    public override EventHandler Handler => (_, _) => { targetTransform.position = sourceTransform.position; targetTransform.rotation = sourceTransform.rotation; };
}
