using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration2Script : Decor
{
    float angle = 0;
    float spiningRadius = 0;
    private void Start()
    {
        spiningRadius = ball.Radius / 60;
    }
    public override void MoveUpDown(GameObject gameObject_ToMove)
    {
        Vector3 OriginPos = Vector3.one;
        bool inspector = false;
        if (!inspector) { OriginPos = gameObject_ToMove.transform.position; inspector = true; }
        base.MoveUpDown(gameObject_ToMove);
        gameObject_ToMove.transform.position = new Vector3(spiningRadius * Mathf.Cos(angle) + OriginPos.x,
        gameObject_ToMove.transform.position.y,
        spiningRadius * Mathf.Sin(angle) + OriginPos.z);
    }
    private void Update()
    {
        angle += Time.deltaTime * 12;
        base.MoveUpDown(gameObject);
    }
}
