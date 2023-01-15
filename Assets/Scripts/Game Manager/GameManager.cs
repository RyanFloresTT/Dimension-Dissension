using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Singleton Setup
    public static GameManager instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }

    // Class Variables
    [SerializeField] private GameObject _player;
    [SerializeField] private Transform _playerSpawnPoint;
    [SerializeField] private QuestManager _questManager;


    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }
    public IEnumerator LoadNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        _player.transform.position = new Vector3(_playerSpawnPoint.position.x, _playerSpawnPoint.position.y, _playerSpawnPoint.position.z);
        _questManager.InitiallizeQuest();
    }
}
