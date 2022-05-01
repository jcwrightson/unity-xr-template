using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof (Rigidbody))]
public class playerController : MonoBehaviour
{
    [SerializeField]
    private InputActionReference jumpActionRef;

    public float jumpForce = 150f;

    private Rigidbody body;


    void Start()
    {
        body = GetComponent<Rigidbody>();
        jumpActionRef.action.performed += OnJump;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnJump(InputAction.CallbackContext obj)
    {
        if (!IsGrounded()) return;
        body.AddForce(Vector3.up * jumpForce);
    }

    private bool IsGrounded()
    {
        // layerMask = ~layerMask;
        RaycastHit hit;

        // Does the ray intersect any objects excluding the player layer
        if (
            Physics
                .Raycast(new Vector3(transform.position.x,
                    transform.position.y + 1f,
                    transform.position.z),
                transform.TransformDirection(Vector3.down),
                out hit,
                1f)
        )
        {
            Debug
                .DrawRay(new Vector3(transform.position.x,
                    transform.position.y + 1f,
                    transform.position.z),
                transform.TransformDirection(Vector3.down) * hit.distance,
                Color.yellow);
            Debug.Log(hit.distance.ToString());
            return true;
        }
        else
        {
            return false;
        }
    }
}
