using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class InputData : MonoBehaviour
{
    public static InputData Instance = new InputData();
    public Color first;
    public Color second;
    public Color decor1;
    public Color decor2;
    public Color decor3;
    public Color decor4;

    public float Scale_first;
    public float Scale_second;
    public float Scale_decor1;
    public float Scale_decor2;
    public float Scale_decor3;
    public float Scale_decor4;

    public float Sphere_radius;

    private void Start()
    {
        DontDestroyOnLoad(this);
    }
    

}
