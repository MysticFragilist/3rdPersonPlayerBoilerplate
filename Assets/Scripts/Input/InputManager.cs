using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour, IPlayerMovement
{
    public static InputManager Instance;

    private IPlayerMovement _iPlayerMovement;
    [HideInInspector] public IPlayerMovement PlayerMovement
    {
        set => _iPlayerMovement = value;
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Debug.Log($"Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    #region IPlayerMovement
    public void OnMovement(InputAction.CallbackContext context) => _iPlayerMovement?.OnMovement(context);

    public void OnJump(InputAction.CallbackContext context) =>_iPlayerMovement?.OnJump(context);

    public void OnCrouch(InputAction.CallbackContext context) => _iPlayerMovement?.OnCrouch(context);

    public void OnRun(InputAction.CallbackContext context) => _iPlayerMovement?.OnRun(context);
    #endregion
}
