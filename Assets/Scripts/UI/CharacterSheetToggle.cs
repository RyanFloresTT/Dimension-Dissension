using UnityEngine;

public class CharacterSheetToggle : MonoBehaviour
{
    [SerializeField] private GameObject characterSheet;
    private bool _isActive;

    private void Start()
    {
        _isActive = false;
    }
    private void Update()
    {
        if (!Input.GetKeyDown(KeyCode.Tab)) return;
        _isActive = !_isActive;
        characterSheet.SetActive(!_isActive);
        characterSheet.SetActive(_isActive);
    }
}
