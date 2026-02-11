using UnityEngine;

public class ThrowPlayer : MonoBehaviour
{
    public DataManager dataManager;

    private ThrowData data;
    private int frameIdx = 0;
    private float timer = 0f;
    public float fps = 60f;

    public Transform shoulder;
    public Transform elbow;
    public Transform wrist;

    public bool IsPlaying { get; private set; } = true;

    public void Play()
    {
        IsPlaying = true;
    }

    public void Pause()
    {
        IsPlaying = false;
    }

    public void NextFrame()
    {
        if (data == null) return;

        frameIdx = (frameIdx + 1) % data.frames.Count;
        ApplyFrame(data.frames[frameIdx]);
    }

    void OnEnable()
    {
        dataManager.OnDataUpdated += OnDataLoaded;
    }

    void OnDisable()
    {
        dataManager.OnDataUpdated -= OnDataLoaded;
    }

    void OnDataLoaded()
    {
        data = dataManager.CurrentThrowData;
        frameIdx = 0;
    }

    void Update()
    {
        if (!IsPlaying) return;
        if (data == null) return;

        timer += Time.deltaTime;
        if (timer >= 1f / fps)
        {
            timer = 0f;
            NextFrame();
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
        if (joint == null || q == null || q.Length < 4) return;

        joint.localRotation = new Quaternion(q[0], q[1], q[2], q[3]);
    }

}
