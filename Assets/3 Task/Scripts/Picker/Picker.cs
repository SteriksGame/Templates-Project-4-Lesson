using UnityEngine;
using Zenject;

public class Picker : MonoBehaviour
{
    private Camera _camera => Camera.main;

    private MiniGameInputController _miniGameInputController;

    private bool _isInit = false;

    [Inject]
    public void Constructor(MiniGameInputController miniGameInputController)
    {
        _miniGameInputController = miniGameInputController;

        _isInit = true;

        OnEnable();
    }

    private void OnEnable()
    {
        if (!_isInit)
            return;

        _miniGameInputController.PressedMouse += TakeBall;
    }

    private void OnDisable()
    {
        _miniGameInputController.PressedMouse -= TakeBall;
    }

    private void TakeBall()
    {
        RaycastHit hit;
        Ray ray = _camera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider.TryGetComponent(out Ball ball))
            {
                ball.DestroyBall();
            }
        }
    }
}
