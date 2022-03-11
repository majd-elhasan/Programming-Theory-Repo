using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPoint : Ball
{
    void Update()
    {
        gameObject.transform.localScale = Vector3.one*2*Radius;
    }
}
