using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI ToolTipText = null;
    public GameObject ToolTipUiObject = null;
    public TextMeshProUGUI GoldText = null;
    public TextMeshProUGUI ShurikenText = null;
    public Image Life = null;

    void Start()
    {
        ToolTipText.text = "fsfefs";
        GoldText.text = "0";
        ChangeTooltipVisibility(false);
    }
    
    private void ChangeTooltipVisibility(bool visible)
    {
        if (ToolTipUiObject != null)
        {
            ToolTipUiObject.SetActive(visible);
        }
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
        ChangeTooltipVisibility(false);
    }

    public void SetToolTipText(string text)
    {
        ToolTipText.text = text;
        ChangeTooltipVisibility(true);
    }

    public void UpdateShurikenText(int shuriken)
    {
        ShurikenText.text = shuriken.ToString();
    }
}
