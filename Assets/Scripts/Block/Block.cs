using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class Block : MonoBehaviour
{
    [SerializeField] private float _lifeTime;

    private MeshRenderer _renderer;
    

    private void Awake()
    {
        _renderer = GetComponent<MeshRenderer>();

        StartCoroutine(Timer());
    }

    public void SetColor(Color color)
    {
        _renderer.sharedMaterial.color = color;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(_lifeTime);

        Destroy(gameObject);
    }
}
