using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Vector3 scale;
    public Color Ballcolor;
    private float radius = 10;
    public Vector3 Scale   // ENCAPSULATION : to assign a value to the Scale between 0 and 5 
    { 
        get => scale;
        set {
            if (value.x < 5 && value.y < 5 && value.z < 5 && value.x > 0 && value.y > 0 && value.z > 0) scale = value;
            else Debug.Log("You can not assign a Scale less than zero (0) Or greater than five (5)");
        }
    }
    public float Radius {get => radius;  // ENCAPSULATION : to assign a value to the Radius between 0 and 50 
        set {
            if (value < 50 && value > 0) radius = value;
            else Debug.Log("You can not assign a Radius less than zero (0) Or greater than fifty (50)");
        }
    }
    
    private void Start()
    {
        scale = Vector3.one *InputData.Instance.Scale_first;
        Ballcolor = InputData.Instance.first;
        radius = InputData.Instance.Sphere_radius;
    }
}
