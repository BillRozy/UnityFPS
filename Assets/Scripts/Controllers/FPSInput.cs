using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Scripts/FPS Input")]
public class FPSInput : MonoBehaviour
{
    public float speed = 2.5f;
    public float gravity = -9.8f;
    public float jumpEnergy = 9.8f;
    public float jumpDuration = 0.8f;
    public float runMod = 2f;

    private bool _isJumping = false;
    private bool _isRunning = false;
    private bool _canJump = true;
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
        if (Time.time - _lastJumpTime >= jumpDuration / 2) {
            _isJumping = false;
            if (Time.time - _lastJumpTime > jumpDuration)
            {
                _canJump = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            if (!_isJumping && _canJump) {
                _isJumping = true;
                _canJump = false;
                _lastJumpTime = Time.time;
            }
        }
        _isRunning = Input.GetKey(KeyCode.LeftShift);
        float finalSpeed = _isRunning ? speed * runMod : speed;
        float dx = Input.GetAxis("Horizontal") * finalSpeed;
        float dz = Input.GetAxis("Vertical") * finalSpeed;
        Vector3 movement = new Vector3(dx, 0, dz);
        movement = Vector3.ClampMagnitude(movement, finalSpeed);
        movement.y = gravity;
        if (_isJumping) movement.y = jumpEnergy;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        _charController.Move(movement);
    }
}
