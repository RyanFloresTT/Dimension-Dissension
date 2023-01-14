using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSheetToggle : MonoBehaviour
{
    [SerializeField] private GameObject _characterSheet;
    private bool _isActive;

    private void Start()
    {
        _isActive = false;
    }

    // Update is called once per framevate void Update()
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            //Swithces the boolean from true to false each button press;
            _isActive = !_isActive;

            //Enable the white platform when the boolean is false, disable when true
            _characterSheet.SetActive(!_isActive);
            //Enable the black platform when the boolean is true, disable when false
            _characterSheet.SetActive(_isActive);
        }
    }
}
