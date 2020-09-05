using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This will be used to facilitate trigger and action event sent to game objects,
/// simply add an Action event here and add a subscriber function in the start function of your
/// receiving GameObject by passing by the singleton attributes.
/// </summary>
public class GameEvents : MonoBehaviour
{
    public static GameEvents Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.LogWarning($"Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    /// <summary>
    /// Sample for demonstrating event system with classic solution ALL GO subscribers
    /// </summary>
    public event Action SampleEvent;
    public void TriggerSampleEvent() => SampleEvent?.Invoke();

    /// <summary>
    /// Sample for demonstrating event system with individual instance of GO
    /// </summary>
    public event Action<int> SampleSpecificEvent;
    public void TriggerSampleSpecificEvent(int id) => SampleSpecificEvent?.Invoke(id);

    
    public event Action<AsyncOperation> GameSceneHasFinishedToLoadEvent;
    public void TriggerGameSceneHasFinishedToLoadEvent(AsyncOperation op) => GameSceneHasFinishedToLoadEvent?.Invoke(op);
}
