using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents.Sensors;
using System.Linq;
using Unity.Barracuda;
using Mujoco;

/// <summary>
/// Deprecated. A class for grouping multiple the observations from observation sources into one sensor. 
/// This class will be removed in a future release, used in the AMP scene to be compatible with a policy trained with an older version of the package,
/// only to showcase a policy trained with AMP.
/// </summary>
public class ObservationSignalSensorComponent : SensorComponent
{
    [SerializeField]
    private List<ObservationSource> observationSources;

    [SerializeField, Range(1, 100)]
    private int numStackedObservations;

    ISensor sensor;

    public override ISensor[] CreateSensors()
    {
        foreach (var observation in observationSources) 
        { 
            observation.OnAgentStart();
        }
        sensor = new ObservationSignalSensor(observationSources, name + "_VectorSensor");
        return new[] { new StackingSensor(sensor, numStackedObservations) };
    }

    public void Initialize()
    {
        foreach (ObservationSource observationSource in observationSources.Where(obs => obs != null))
        {
            observationSource.OnAgentStart();
        }
    }

    private unsafe void Start()
    {
        if(!MjScene.InstanceExists || MjScene.Instance.Data == null) 
        {
            MjScene.Instance.postInitEvent += (_, _) => Initialize();
        }
        else
        {
            Initialize();
        }
    }
}

