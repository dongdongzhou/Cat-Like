using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TransformExtensions 
{
    // Created this extension method because it is used in multiple places
    public static void SetYRotation(this Transform transform, float degrees) =>
      transform.localRotation = Quaternion.Euler(0f, degrees, 0f);

}
