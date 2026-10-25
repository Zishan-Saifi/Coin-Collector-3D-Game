using UnityEngine;
using UnityEngine.InputSystem; // Unity 6 ka New Input System namespace

public class BallController : MonoBehaviour
{
    public float speed = 10f;
    private Rigidbody rb;
    public DynamicJoystick dynamicJoystick;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        float moveH = 0f;
        float moveV = 0f;

        if(dynamicJoystick != null && (dynamicJoystick.Horizontal != 0f || dynamicJoystick.Vertical != 0f))
        {
            moveH = dynamicJoystick.Horizontal;
            moveV = dynamicJoystick.Vertical;
        }
        else
        {
            // Unity 6 ke New Input System se Arrow Keys check karna
            if (Keyboard.current != null)
            {
                if (Keyboard.current.upArrowKey.isPressed)
                {
                    moveV = 1f;
                }
                else if (Keyboard.current.downArrowKey.isPressed)
                {
                    moveV = -1f;
                }

                if (Keyboard.current.rightArrowKey.isPressed)
                {  
                    moveH = 1f;
                }
                else if (Keyboard.current.leftArrowKey.isPressed)
                {
                    moveH = -1f;
                }
            }
        }

        // Ball movement calculation
        Vector3 movement = new Vector3(moveH, 0.0f, moveV);
        rb.AddForce(movement * speed);
    }
}
