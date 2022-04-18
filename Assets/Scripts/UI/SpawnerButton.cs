using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class SpawnerButton : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Button _button;

    private Image _image;

    private void OnEnable()
    {
        _button.onClick.AddListener(SpawnBlock);
    }

    private void Start()
    {
        _image = GetComponent<Image>();
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(SpawnBlock);
    }

    private void SpawnBlock()
    {
        _spawner.Spawn(_image.color);
    }
}
