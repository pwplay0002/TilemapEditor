using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private float _zoomChange;
    [SerializeField] private float _smoothChange;
    [SerializeField] private float _minSize, _maxSize;

    [SerializeField] private float _moveSpeed;

    private Camera _cam;

    private void Start()
    {
        _cam = GetComponent<Camera>();
    }

    private void Update()
    {
        Vector3 pos = _cam.transform.position;
        if (Input.mouseScrollDelta.y > 0)
            _cam.orthographicSize -= _zoomChange * Time.deltaTime * _smoothChange;
        if (Input.mouseScrollDelta.y < 0)
            _cam.orthographicSize += _zoomChange * Time.deltaTime * _smoothChange;

        if (Input.GetKey(KeyCode.W))
            pos.y += _moveSpeed * Time.deltaTime * _smoothChange;
        if (Input.GetKey(KeyCode.A))
            pos.x -= _moveSpeed * Time.deltaTime * _smoothChange;
        if (Input.GetKey(KeyCode.S))
            pos.y -= _moveSpeed * Time.deltaTime * _smoothChange;
        if (Input.GetKey(KeyCode.D))
            pos.x += _moveSpeed * Time.deltaTime * _smoothChange;

        _cam.orthographicSize = Mathf.Clamp(_cam.orthographicSize, _minSize, _maxSize);
        _cam.transform.position = pos;
    }
}
