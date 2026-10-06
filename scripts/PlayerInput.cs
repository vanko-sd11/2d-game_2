using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public float movement { get; private set; }
    public bool isJump { get; private set; }

    public void Move()
    {
        movement = Input.GetAxis("Horizontal");  
        isJump = Input.GetKeyDown(KeyCode.Space);
    }

}
