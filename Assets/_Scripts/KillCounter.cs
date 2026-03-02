using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class KillCounter : MonoBehaviour {
    public static KillCounter instance;
    [SerializeField] public TextMeshProUGUI killText; 
    [SerializeField] public TextMeshProUGUI recordText;
    private int kills = 0;
    private int record = 0;

    void Awake() 
    {
        if(instance == null)
        instance = this;
        else Destroy(gameObject);
    }

    void Start() 
    {
        record =  PlayerPrefs.GetInt("Record", 0);
        UpdateUI();
    }

    // method plus kills
    public void AddKill()
    {
        kills ++;
        if(kills > record)
        {
            record = kills;
            PlayerPrefs.SetInt("Record", record);
        }
        UpdateUI();
        DifficultyManager.instance.CheckDifficultyLevel(kills);
    }

    // method update text Score
    void UpdateUI()
    {
        if(killText != null) {
        killText.text = kills.ToString();
        }
        if(recordText != null) {
        recordText.text = record.ToString();
        }

    }

    public void ResetRecord()
    {
        // reset record
        record = 0;
        PlayerPrefs.SetInt("Record ", 0);
        UpdateUI();

        //reset botton to inactive
        EventSystem.current.SetSelectedGameObject(null);
    }
    

} 