using TMPro;
using UnityEngine;

public class HighlightText : MonoBehaviour
{
    [SerializeField] TMP_Text textComponent;

    public void SetHighlightText(HighlightableObject target)
    {
        textComponent.text = target.name;
    }

    public void ResetHighlightText(HighlightableObject target)
    {
        textComponent.text = "";
    }
}
