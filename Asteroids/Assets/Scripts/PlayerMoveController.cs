using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PlayerMoveController : MonoBehaviour
{
    private bool keyboard = true;
    public float speed = 5;
    private Rigidbody2D rb;
    Vector2 rotation;
    public float rotationSpeed;

    private Vector3 mousePosition;
    private Vector3 difference;
    float rotationZ;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        MoveController();
    }
    private void MoveController()
    {
        ChangeControl();
        MoveForward();

    }
    private void ChangeControl()
    {
        switch (keyboard)
        {
            case true:
                KeyboardController();
                break;
            case false:
                MouseController();
                break;
        }
    }
    private void MouseController()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = Vector2.MoveTowards(transform.position, mousePosition, 0);
        difference = mousePosition - transform.position;
        difference.Normalize();
        rotationZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationZ);
    }
    private void MoveForward()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            rb.AddRelativeForce(new Vector2(speed, 0));
        }
    }
    private void KeyboardController()
    {
        rotation = new Vector2(0, -Input.GetAxisRaw("Horizontal"));
        rb.AddTorque(rotation[1] * rotationSpeed);
    }
}
