using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(PlayerInput))]
public class InputManager : MonoBehaviour
{
    public event Action<Vector2> Move;
    public event Action<Vector2> Look;
    public event Action Jump;
    public event Action LeftMouse;
    public event Action<Vector2> Scroll;
    public void Awake()
    {
    }
    public void OnScrollWheel(InputValue ctx)
    {
        Debug.Log(ctx.Get<Vector2>().normalized);
        Scroll?.Invoke(ctx.Get<Vector2>().normalized);
    }
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
    public void OnJump()
    {
        Jump?.Invoke();
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