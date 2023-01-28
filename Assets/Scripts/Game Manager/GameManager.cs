using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class GameManager : MonoBehaviour
{
    // Singleton Setup
    public static GameManager instance { get; private set; }
    void OnEnable() { instance = this; }
    void OnDisable() { instance = null; }
    
    private float _musicTimer;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip inGameMusic;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private QuestManager questManager;

    private void Awake()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
        _audioSource = FindObjectOfType<AudioSource>();
    }

    private void Start()
    {
        _audioSource.PlayOneShot(inGameMusic);
    }

    private void Update()
    {
        PlayMusic();
    }

    private void PlayMusic()
    {
        _musicTimer += Time.deltaTime;
        if (!(_musicTimer > inGameMusic.length)) return;
        _audioSource.PlayOneShot(inGameMusic);
        _musicTimer = 0;
    }

    public IEnumerator LoadNextLevel(float delay)
    {
        yield return new WaitForSeconds(delay);
        player.transform.position = playerSpawnPoint.position;
        questManager.InitiallizeQuest();
    }
}
