using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Singleton Setup
    public static GameManager Instance { get; private set; }
    private void OnEnable() { Instance = this; }
    private void OnDisable() { Instance = null; }
    
    private float _musicTimer;
    private AudioSource _audioSource;
    [SerializeField] private AudioClip inGameMusic;
    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerSpawnPoint;
    [SerializeField] private QuestManager questManager;

    private void Awake()
    {
        Instance = this;
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
        questManager.InitializeQuest();
    }
}
