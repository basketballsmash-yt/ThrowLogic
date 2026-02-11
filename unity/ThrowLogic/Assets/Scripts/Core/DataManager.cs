using System;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public MotionData CurrentMotionData { get; private set; }
    public AIResult CurrentAIResult { get; private set; }

    public event Action OnDataUpdated;

    public void UpdateMotionData(MotionData data)
    {
        CurrentMotionData = data;
        OnDataUpdated?.Invoke();
    }

    public void UpdateAIResult(AIResult result)
    {
        CurrentAIResult = result;
        OnDataUpdated?.Invoke();
    }

    public ThrowData CurrentThrowData { get; private set; }

    public void SetThrowData(ThrowData data)
    {
        CurrentThrowData = data;
        OnDataUpdated?.Invoke();
    }

}
