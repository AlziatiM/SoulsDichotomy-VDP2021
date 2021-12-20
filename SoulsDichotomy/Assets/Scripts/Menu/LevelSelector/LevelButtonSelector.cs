using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class LevelButtonSelector : MonoBehaviour
{
    [Header("Level the Door will open")]
    [SerializeField] private int level;
    [Header("Sprites")]
    [SerializeField] private Sprite locked;
    [SerializeField] private Sprite unlocked;
    [Header("UI components")]
    [SerializeField] private TextMeshProUGUI textMeshPro;
    [SerializeField] private Image imageUI;
    private Button button;
    private void Awake()
    {
        button = gameObject.GetComponent<Button>();
    }

    // Start is called before the first frame update
    void Start()
    {
        SetUp();
    }

    private void OnEnable()
    {
        SetUp();
    }

    private void SetUp()
    {
        //Levelx has 1 if is already be completed 0 otherwise, so you can re-choose it
        //Level1 must have 1 from the beginning
        if (PlayerPrefs.HasKey("Level" + level))
        {
            if (PlayerPrefs.GetInt("Level" + level) == 1)
            {
                imageUI.sprite = unlocked;
                button.interactable = true;
            }
            else
            {
                imageUI.sprite = locked;
                button.interactable = false;
            }
        }
        else
        {
            PlayerPrefs.SetInt("Level" + level, level==1?1:0);
            SetUp();
        }
        textMeshPro.text = level.ToString();
    }
}
