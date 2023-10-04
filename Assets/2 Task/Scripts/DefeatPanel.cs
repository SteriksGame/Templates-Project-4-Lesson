using System;
using UnityEngine;
using UnityEngine.UI;

public class DefeatPanel : MonoBehaviour
{
    public event Action Restarted;

    [SerializeField] private Button _restart;

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void OnEnable() => _restart.onClick.AddListener(OnRestartClick);

    private void OnDisable() => _restart.onClick.RemoveListener(OnRestartClick);

    private void OnRestartClick() => Restarted?.Invoke();
}
