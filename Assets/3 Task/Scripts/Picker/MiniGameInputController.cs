using System;
using UnityEngine;
using Zenject;

public class MiniGameInputController : ITickable
{
    public event Action PressedMouse;

    public bool IsActiv = false;

    public void Tick()
    {
        if (!IsActiv)
            return;

        if (Input.GetKeyDown(KeyCode.Mouse0))
            PressedMouse?.Invoke();
    }
}
