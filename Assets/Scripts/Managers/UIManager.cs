using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ToolTipText;
    public RawImage ToolTipBackground;
    public TextMeshProUGUI GoldText;
    public TextMeshProUGUI ShurikenText;
    public Image Life;

    void Start()
    {
        ToolTipText.text = "";
        GoldText.text = "0";
        ToolTipBackground.enabled = false;
    }

    public void UpdateGoldText(int gold)
    {
        GoldText.text = gold.ToString();
    }

    public void UpdateLife(int life)
    {
        Life.rectTransform.sizeDelta = new Vector2(life * 100, Life.rectTransform.sizeDelta.y);
    }

    public void StopToolTip()
    {
        ToolTipText.text = "";
        ToolTipBackground.enabled = false;
    }

    public void SetToolTipText(string text)
    {
        ToolTipText.text = text;
        ToolTipBackground.enabled = true;
    }

    public void UpdateShurikenText(int shuriken)
    {
        ShurikenText.text = shuriken.ToString();
    }
}
