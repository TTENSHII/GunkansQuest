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
}
