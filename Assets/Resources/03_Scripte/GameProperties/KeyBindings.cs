using UnityEngine;
using System.Collections;

public class KeyBindings : MonoBehaviour 
{
    public KeyCode keyMoveForward = KeyCode.W;
    public KeyCode keyMoveBackward = KeyCode.S;
    public KeyCode keyMoveLeft = KeyCode.A;
    public KeyCode keyMoveRight = KeyCode.D;
    public KeyCode keyMoveJump = KeyCode.Space;
    public KeyCode keyMoveRun = KeyCode.LeftShift;
    public KeyCode keyMoveCrouch = KeyCode.LeftControl;

    public KeyCode keyToggleInventory = KeyCode.I;

    public KeyCode keyItemPickUP = KeyCode.E;
}
