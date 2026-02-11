using System;
using System.Collections.Generic;

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
