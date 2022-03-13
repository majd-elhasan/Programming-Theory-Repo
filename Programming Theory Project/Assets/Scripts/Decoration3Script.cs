using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration3Script : Decor
{
    float angle = 0;
    float spiningRadius = 0;
    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = InputData.Instance.decor3;
        this.gameObject.transform.localScale = Vector3.one * InputData.Instance.Scale_decor3;
        spiningRadius = ball.Radius/60;
    }
    public override void MoveUpDown(GameObject gameObject_ToMove)  // POLYMORPHISM ( override the parent 'Decor' MoveUpDown method)
    {
        Vector3 OriginPos = Vector3.one;
        bool inspector = false;
        // the line below sets the current position of the decoration element to Vector3 Variable named 'OriginPos' and then will be using it to rotate the element around that positon
        // so  OriginPos will be the center of the rotation
        if (!inspector) { OriginPos = gameObject_ToMove.transform.position; inspector = true; }
        base.MoveUpDown(gameObject_ToMove);
        gameObject_ToMove.transform.position = new Vector3(spiningRadius  * Mathf.Cos(angle) + OriginPos.x,
        gameObject_ToMove.transform.position.y,
        spiningRadius  * Mathf.Sin(angle) + OriginPos.z);
    }
    private void Update()
    {
        angle += Time.deltaTime*12;
        // when the angle increase the cosine of that angle will move the element to a new position s othe element will be moving in a circle
        // the same thing with the sine of the angle.
        MoveUpDown(gameObject);
    }
}
