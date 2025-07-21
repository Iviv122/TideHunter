using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    public event Action<Vector2> Move;
    public event Action<Vector2> Look;
    public event Action LeftMouse;
    public void OnLook(InputValue ctx)
    {
        Vector2 dir = ctx.Get<Vector2>();
        Look?.Invoke(dir);
    }
    public void OnMove(InputValue ctx)
    {
        Vector2 dir = ctx.Get<Vector2>();
        Move?.Invoke(dir);
    }
    public void OnAttack()
    {
        Debug.Log("OnAttack");
        LeftMouse?.Invoke();
    }
    public void OnRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}