using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 5f;
    public float gravity = -9.8f;
    public float jumpEnergy = 15f;
    public float jumpDuration = 0.3f;

    private bool _isJumping = false;
    private float _lastJumpTime = 0;

    private CharacterController _charController;
    // Start is called before the first frame update
    void Start()
    {
        _lastJumpTime = Time.time;
        _charController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - _lastJumpTime > jumpDuration) {
            _isJumping = false;
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!_isJumping) {
                _isJumping = true;
                _lastJumpTime = Time.time;
            }
        }
        float dx = Input.GetAxis("Horizontal") * speed;
        float dz = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(dx, 0, dz);
        movement = Vector3.ClampMagnitude(movement, speed);
        movement.y = gravity;
        if (_isJumping) movement.y += jumpEnergy;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
