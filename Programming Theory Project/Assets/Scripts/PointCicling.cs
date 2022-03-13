using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointCicling :  Ball 
{
    public float H_angle_degree = 0;
    public float V_angle_degree = 0;

    float vertical_Angle ;
    float horizontal_Angle = 0;

    GameObject centerPoint;
    void Awake()
    {
        
        centerPoint = GameObject.Find("CenterPoint");
        vertical_Angle = Mathf.Deg2Rad * 90;
        // transform.position = new Vector3(centerPoint.transform.position.x,centerPoint.transform.position.y+ radius, transform.position.z);  /// can not be assigned because of the assigned angles
    }
    void keepRadius()
    {
        transform.position = new Vector3(
        Radius* Mathf.Cos(vertical_Angle) * Mathf.Cos(horizontal_Angle) + centerPoint.transform.position.x,  // INHERITANCE : Radius of Ball class
        Mathf.Sin(vertical_Angle) * Radius + centerPoint.transform.position.y,   // height       
        Radius * Mathf.Cos(vertical_Angle) * Mathf.Sin(horizontal_Angle) + centerPoint.transform.position.z
        );

    }
    void Move()
    {
        horizontal_Angle = H_angle_degree * Mathf.Deg2Rad;
        vertical_Angle = V_angle_degree * Mathf.Deg2Rad;

        keepRadius();
    }
    void Update()
    {
        transform.localScale = Scale; // INHERITANCE : Scale of Ball class
        gameObject.GetComponent<Renderer>().material.color = Ballcolor; // INHERITANCE : Ballcolor of Ball class
        Move();
    }
}
