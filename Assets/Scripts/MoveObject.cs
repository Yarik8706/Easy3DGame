using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Screen;

public class MoveObject : MonoBehaviour
{
    public enum WhereClick
    {
        UpAndDown,
        LeftAndRight,
        None
    }
    
    public WhereClick whereClick;
    public KeyCode keyOne;
    public KeyCode keyTwo;
    private Rigidbody _rigidbody;
    public Vector3 moveDirection;

    // Start is called before the first frame update
    public virtual void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        if(Input.GetKey(keyOne))
        {
            _rigidbody.velocity += moveDirection;
        }
        if(Input.GetKey(keyTwo))
        {
            _rigidbody.velocity -= moveDirection;
        }
        TouchClick();
    }

    public virtual void OnTriggerEnter(Collider other)
    {
        if (this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            foreach (var button in FindObjectsOfType<Activator>())
            {
                button.canPush = false;
            }
        }
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (this.CompareTag("Cube") && other.CompareTag("Cube"))
        {
            foreach (var button in FindObjectsOfType<Activator>())
            {
                button.canPush = true;
            }
        }
    }

    private void TouchClick()
    {
        if (Input.touchCount <= 0) return;
        var touch = Input.GetTouch(0);
        if (touch.position.x > width / 3 && whereClick == WhereClick.LeftAndRight)
        {
            _rigidbody.velocity += moveDirection;
        }
        else if (touch.position.x < width / 3 && whereClick == WhereClick.LeftAndRight)
        {
            _rigidbody.velocity -= moveDirection;
        }
        else if (touch.position.y < height / 3 && whereClick == WhereClick.UpAndDown)
        {
            _rigidbody.velocity += moveDirection;
        }
        else if (touch.position.y > height / 3 && whereClick == WhereClick.UpAndDown)
        {
            _rigidbody.velocity -= moveDirection;
        }
    }
}
