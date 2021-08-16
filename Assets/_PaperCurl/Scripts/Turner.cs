using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour
{
    Vector3 _startPosition;
    Material _myMaterial;
    Rect _rect;

    private void Start()
    {
        _myMaterial = GetComponent<Renderer>().material;
        _rect = new Rect();
    }

    private void OnMouseDown()
    {
        _startPosition = Input.mousePosition;

        Debug.Log("MouseDown");
    }

    private void OnMouseDrag()
    {
        Vector3 direction = Input.mousePosition - _startPosition;
        _myMaterial.SetVector("_Direction", direction);
    }
}
