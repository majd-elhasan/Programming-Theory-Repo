using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor : MonoBehaviour
{
    protected bool IsMovingUp = false;
    protected bool IsMovingDown = false;
    protected Ball ball = new Ball();  // we made an instance of Ball class to this class to reach the 'Radius' variable

    public virtual void MoveUpDown(GameObject gameObject_ToMove) // ABSTRACTION : by this way its enough to enter the gameObject_ToMove's gameObject
    {
        if (gameObject_ToMove == null) return;


        if (gameObject_ToMove.transform.position.y >= ball.Radius * 4)   // if our gameObject higher than 4 times the Radius of sphere the decoration element will move to down  
        {
            IsMovingDown = true;
            IsMovingUp = false;
        }

        if (gameObject_ToMove.transform.position.y <= ( ball.Radius / 2)) // if our gameObject lower than half the Radius of sphere the decoration element will move to up
        {
            IsMovingUp = true;
            IsMovingDown = false;
        }
        if (!IsMovingDown && !IsMovingUp) { IsMovingDown = true; }


        if (IsMovingUp)
        {
            // the first line sets the  position of the highest point of the movement
            Vector3 target = new Vector3(gameObject_ToMove.transform.position.x, gameObject_ToMove.transform.position.y + 35, gameObject_ToMove.transform.position.z);
            gameObject_ToMove.transform.position = Vector3.MoveTowards(gameObject_ToMove.transform.position, target, 0.15f);

        }

        if (IsMovingDown)
        {
            // the first line sets the  position of the lowest point of the movement
            Vector3 target = new Vector3(gameObject_ToMove.transform.position.x, gameObject_ToMove.transform.position.y - 35, gameObject_ToMove.transform.position.z);
            gameObject_ToMove.transform.position = Vector3.MoveTowards(gameObject_ToMove.transform.position, target, 0.15f);
        }
    }
}
