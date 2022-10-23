using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChrStats : MonoBehaviour
{
    public static float maxSpeed = 3;
    public static float attack = 4;
    // Start is called before the first frame update
    public void updateSpeed(float newSpeed)
    {
        maxSpeed = newSpeed;
    }
}
