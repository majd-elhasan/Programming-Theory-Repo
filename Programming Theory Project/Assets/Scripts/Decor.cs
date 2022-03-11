using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor : MonoBehaviour
{
    public bool IsMovingUp = false;
    public bool IsMovingDown = false;
    protected Ball ball = new Ball();

    public virtual void MoveUpDown(GameObject gameObject_ToMove)
    {
        if (gameObject_ToMove == null) return;


        if (gameObject_ToMove.transform.position.y >= ball.Radius * 4)
        {
            IsMovingDown = true;
            IsMovingUp = false;
        }

        if (gameObject_ToMove.transform.position.y <= ( ball.Radius / 2))
        {
            IsMovingUp = true;
            IsMovingDown = false;
        }
        if (!IsMovingDown && !IsMovingUp) { IsMovingDown = true; }


        if (IsMovingUp)
        {
            Vector3 target = new Vector3(gameObject_ToMove.transform.position.x, gameObject_ToMove.transform.position.y + 35, gameObject_ToMove.transform.position.z);
            gameObject_ToMove.transform.position = Vector3.MoveTowards(gameObject_ToMove.transform.position, target, 0.15f);

        }

        if (IsMovingDown)
        {
            Vector3 target = new Vector3(gameObject_ToMove.transform.position.x, gameObject_ToMove.transform.position.y - 35, gameObject_ToMove.transform.position.z);
            gameObject_ToMove.transform.position = Vector3.MoveTowards(gameObject_ToMove.transform.position, target, 0.15f);
        }
    }
}
