using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerGameObject;
    [SerializeField] private Transform _playerSpawnPoint;

    // Spawn Player In
    void Start()
    {
        Instantiate(_playerGameObject, _playerSpawnPoint);
    }
}
