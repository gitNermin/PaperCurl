using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turner : MonoBehaviour
{
    Vector3 _startPosition;
    Material _myMaterial;

    [SerializeField]
    float _width;
    [SerializeField]
    float _height;
    [SerializeField]
    float _deltaDistance = 0.1f;

    float _distance = 0;

    Vector3[] _corners = new Vector3[4];

    private void Start()
    {
        _myMaterial = GetComponent<Renderer>().material;
        _corners[0] = transform.position + Vector3.right * _width / 2f + Vector3.up * _height / 2;
        _corners[1] = transform.position + Vector3.left * _width / 2f + Vector3.up * _height / 2;
        _corners[2] = transform.position + Vector3.right * _width / 2f + Vector3.down * _height / 2;
        _corners[3] = transform.position + Vector3.left * _width / 2f + Vector3.down * _height / 2;
    }

    private void OnMouseDown()
    {
        _startPosition = Input.mousePosition;

        Debug.Log("MouseDown");
        _distance = 0;
    }

    private void OnMouseDrag()
    {
        Vector3 direction = (Input.mousePosition - _startPosition).normalized;
        _myMaterial.SetVector("_Direction", direction);
        
        Vector3 corner = _corners[0];
        float maxDot = Vector3.Dot(direction, transform.position - corner);

        for (int i = 1; i < _corners.Length; i++)
        {
            float dot = Vector3.Dot(direction, transform.position - _corners[i]);
            if(dot > maxDot)
            {
                maxDot = dot;
                corner = _corners[i];
            }
        }

        _distance += _deltaDistance;
        _myMaterial.SetVector("_Position", corner + direction * _distance);
    }
}
