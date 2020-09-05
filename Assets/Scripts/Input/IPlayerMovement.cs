using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public interface IPlayerMovement
{
    void OnMovement(InputAction.CallbackContext context);
    void OnJump(InputAction.CallbackContext context);
    void OnCrouch(InputAction.CallbackContext context);
    void OnRun(InputAction.CallbackContext context);
}
