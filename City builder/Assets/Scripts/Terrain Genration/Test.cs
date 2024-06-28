using UnityEngine;

public class Test : MonoBehaviour
{
    public AnimationCurve customCurve;

    public Keyframe[] keyframes;

    public Test()
    {
        // Define the length of the keyframes array
        int length = 10;
        keyframes = new Keyframe[length * 2];

        // Create keyframes
        CreateCurve(length);

        // Create an AnimationCurve from the keyframes
        customCurve = new AnimationCurve(keyframes);
    }

    public void CreateCurve(int length)
    {
        for (int i = 0; i < length; i++)
        {
            // Set up time values to create steps
            float time = (float)i / length;
            float nextTime = (float)(i + 1) / length;

            // Create step shape by having two keyframes at each step
            keyframes[i * 2] = new Keyframe(time, time);
            keyframes[i * 2 + 1] = new Keyframe(time, nextTime);

            Debug.Log($"Curve Keyframe A {i * 2}: ({time}, {time})");
            Debug.Log($"Curve Keyframe B {i * 2 + 1}: ({nextTime}, {time})");
        }
    }

    private void Update()
    {
        Debug.Log($"Length : {customCurve.length}");
        Debug.Log($"Evaluate x : {customCurve.Evaluate(0.0f)}");
        Debug.Log($"Evaluate y : {customCurve.Evaluate(1.0f)}");
    }
}
