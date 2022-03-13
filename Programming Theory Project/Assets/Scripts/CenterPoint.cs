using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterPoint : Ball
{
    void Update()
    {
        // assigns the Radius to the scale of the (semi-transparent) center point 'Sphere'
        gameObject.transform.localScale = Vector3.one*2*Radius;  // INHERITANCE : Radius of Ball class
    }
}
