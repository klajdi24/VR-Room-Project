using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class DoorHingeLimiter : MonoBehaviour
{
    public float minAngle = -90f;
    public float maxAngle = 0f;
    private HingeJoint hinge;

    void Start()
    {
        hinge = GetComponent<HingeJoint>();
        JointLimits limits = hinge.limits;
        limits.min = minAngle;
        limits.max = maxAngle;
        hinge.limits = limits;
        hinge.useLimits = true;
    }
}

