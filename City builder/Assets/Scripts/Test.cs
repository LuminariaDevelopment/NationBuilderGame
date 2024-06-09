using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    public float number;

    void Update()
    {
        number += 1 * (Time.deltaTime * TimeController.timeMultiplier);
    }
}
