using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField]
    int level;
    void Start()
    {
        if (level > PlayerPrefs.GetInt("level", 1)) //jeżeli pod kluczem tu "level" nic nie jest zapisaen metod bierze pod uwage drugie przeciazeniu tu 1
        { 
            transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().color = Color.grey;
            GetComponent<Button>().interactable = false;
        }
    }

    
}
