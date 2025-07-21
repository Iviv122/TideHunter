using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    InputSystem_Actions inputs;
    public event Action<Vector2> Move;
    public event Action<Vector2> Look;
    public event Action LeftMouse;
    private void Awake()
    {
        inputs = new();
    }
    void OnEnable()
    {
        inputs.Player.Attack.performed += OnAttack;
        inputs.Player.Move.performed += OnMove;
        inputs.Player.Look.performed += OnLook;
        inputs.Player.Restart.performed += OnRestart;

        inputs.Player.Attack.Enable();
        inputs.Player.Move.Enable();
        inputs.Player.Look.Enable();
        inputs.Player.Restart.Enable();
    }
    public void OnLook(InputAction.CallbackContext obj)
    {
        Vector2 dir = obj.ReadValue<Vector2>();
        Look?.Invoke(dir);
    }
    public void OnMove(InputAction.CallbackContext obj)
    {
        Vector2 dir = obj.ReadValue<Vector2>();
        Debug.Log(dir);
        Move?.Invoke(dir);
    }
    public void OnAttack(InputAction.CallbackContext obj)
    {
        Debug.Log("OnAttack");
        LeftMouse?.Invoke();
    }
    public void OnRestart(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}