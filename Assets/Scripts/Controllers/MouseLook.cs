using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public enum RotationAxes {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public RotationAxes axes = RotationAxes.MouseXAndY;
    public float horSens = 200f;
    public float verSens = 200f;
    public float[] vertClamp = {-45f, 45f};

    private float _rotationX = 0;
    private float _rotationY = 0;


    void Start() {
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null) body.freezeRotation = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (axes == RotationAxes.MouseX) {
            _rotationY += Input.GetAxis("Mouse X") * horSens * Time.deltaTime;
            transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, _rotationY , 0);
        } else if (axes == RotationAxes.MouseY) {
            _rotationX -= Input.GetAxis("Mouse Y") * verSens * Time.deltaTime;
            _rotationX = Mathf.Clamp(_rotationX, vertClamp[0], vertClamp[1]);
            transform.localEulerAngles = new Vector3(_rotationX, transform.localEulerAngles.y, 0);
        } else {
            _rotationY += Input.GetAxis("Mouse X") * horSens * Time.deltaTime;
            _rotationX -= Input.GetAxis("Mouse Y") * verSens * Time.deltaTime;
            _rotationX = Mathf.Clamp(_rotationX, vertClamp[0], vertClamp[1]);
            transform.localEulerAngles = new Vector3(_rotationX, _rotationY, 0);
        }
    }
}
