using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Vector3 scale;
    public Color Ballcolor;
    private float radius = 10;
    public bool IsMovingUp = false;
    public bool IsMovingDown = false;
    public Vector3 Scale {
        get => scale;
        set {
            if (value.x < 5 && value.y < 5 && value.z < 5 && value.x > 0 && value.y > 0 && value.z > 0) scale = value;
            else Debug.Log("You can not assign a Scale less than zero (0) Or greater than five (5)");
        }
    }
    public float Radius {get => radius; 
        set {
            if (value < 50 && value > 0) radius = value;
            else Debug.Log("You can not assign a Radius less than zero (0) Or greater than five (50)");
        }
    }
    public virtual void MoveUpDown(GameObject gameObject_ToMove,string up_Or_down)
    {
        if (gameObject_ToMove == null) return;


        if (gameObject_ToMove.transform.position.y >= Radius * 4)
        {
            IsMovingDown = true;
            IsMovingUp = false;
        }

        if (gameObject_ToMove.transform.position.y <= (Radius / 2))
        {
            IsMovingUp = true;
            IsMovingDown = false;
        }
        if(!IsMovingDown && !IsMovingUp) { IsMovingDown = true; }


        if(IsMovingUp)
        {
            Vector3 target = new Vector3(gameObject_ToMove.transform.position.x, gameObject_ToMove.transform.position.y + 35, gameObject_ToMove.transform.position.z);
            gameObject_ToMove.transform.position = Vector3.MoveTowards(gameObject_ToMove.transform.position,target , 0.15f);
            
        }

        if(IsMovingDown)
        {
            Vector3 target = new Vector3(gameObject_ToMove.transform.position.x, gameObject_ToMove.transform.position.y - 35, gameObject_ToMove.transform.position.z);
            gameObject_ToMove.transform.position = Vector3.MoveTowards(gameObject_ToMove.transform.position,target , 0.15f);
        }
    }
    private void Start()
    {
        scale = Vector3.one;
        Ballcolor = Color.blue;
        radius = 10;
    }
}
