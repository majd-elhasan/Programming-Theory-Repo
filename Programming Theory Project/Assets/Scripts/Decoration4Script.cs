using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decoration4Script : Decor
{
    private void Start()
    {
        this.gameObject.GetComponent<Renderer>().material.color = InputData.Instance.decor4;
        this.gameObject.transform.localScale = Vector3.one * InputData.Instance.Scale_decor4;
    }
    private void Update()
    {
        base.MoveUpDown(gameObject);
    }
}
