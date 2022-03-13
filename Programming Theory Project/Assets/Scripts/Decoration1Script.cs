using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration1Script : Decor
{
    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = InputData.Instance.decor1;
        this.gameObject.transform.localScale = Vector3.one* InputData.Instance.Scale_decor1;
    }
    private void Update()
    {
        base.MoveUpDown(gameObject);
    }
}
