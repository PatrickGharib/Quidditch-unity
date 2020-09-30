using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class StaticHelpers
{

    public static Vector3 Clamp(this Vector3 inputVal, Vector3 min, Vector3 max)
    {
        return new Vector3(Mathf.Clamp(inputVal.x, min.x, max.x),
                            Mathf.Clamp(inputVal.y, min.y, max.y),
                            Mathf.Clamp(inputVal.z, min.z, max.z));
    }
   
}
