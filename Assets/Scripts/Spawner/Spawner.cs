using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private Block _blockPrefab;

    private Block _block;

    public void Spawn(Color color)
    {
        _block = Instantiate(_blockPrefab, new Vector3(0, 2, 10), Quaternion.identity);
        _block.SetColor(color);
    }

}
