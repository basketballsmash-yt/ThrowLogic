using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[Serializable]
public class JointData
{
    public float[] shoulder;
    public float[] elbow;
    public float[] wrist;
}

[Serializable]
public class FrameData
{
    public float t;
    public JointData joints;
}


[Serializable]
public class ThrowData
{
    public List<FrameData> frames;
    public int release;
}

public class ThrowPlayer : MonoBehaviour
{
    public Transform shoulder;
    public Transform elbow;
    public Transform wrist;

    public float fps = 60f;

    private ThrowData data;
    private int frameIdx = 0;
    private float timer = 0f;

    void Start()
    {
        string path = Path.Combine(Application.streamingAssetsPath, "dummy_throw.json");
        Debug.Log(path);
        string json = File.ReadAllText(path);
        Debug.Log(json);
        data = JsonUtility.FromJson<ThrowData>(json);
        Debug.Log($"data null? {data == null}");
    }

    void Update()
    {
        if (data == null) return;

        timer += Time.deltaTime;
        if (timer >= 1f / fps)
        {
            timer = 0f;
            ApplyFrame(data.frames[frameIdx]);
            frameIdx = (frameIdx + 1) % data.frames.Count;
        }
    }

    void ApplyFrame(FrameData frame)
    {
        ApplyJoint(shoulder, frame.joints.shoulder);
        ApplyJoint(elbow, frame.joints.elbow);
        ApplyJoint(wrist, frame.joints.wrist);
    }

    void ApplyJoint(Transform joint, float[] q)
    {
        joint.localRotation = new Quaternion(q[0], q[1], q[2], q[3]);
    }
}
