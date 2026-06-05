using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UISelectableHighlighted : MonoBehaviour, IPointerEnterHandler
{
    private Selectable selectableUIElement; 

    public void OnPointerEnter(PointerEventData eventData)
    {
        selectableUIElement.Select();
    }

    private void Awake()
    {
        selectableUIElement = this.gameObject.GetComponent<Selectable>();
    }
}
