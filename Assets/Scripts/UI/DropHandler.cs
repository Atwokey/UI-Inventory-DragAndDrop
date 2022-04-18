using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DropHandler : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        var otherItemTransform = eventData.pointerDrag.transform;
        var child = GetComponentInChildren<Button>();

        if(child != null)
        {
            child.transform.SetParent(otherItemTransform.parent);
            child.transform.localPosition = Vector3.zero;
        }
        
        otherItemTransform.SetParent(transform);
        otherItemTransform.localPosition = Vector3.zero;
    }
}
