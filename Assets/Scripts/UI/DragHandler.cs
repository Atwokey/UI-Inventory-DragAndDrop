using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform), typeof(SpawnerButton), typeof(CanvasGroup))]
public class DragHandler : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    [SerializeField] Canvas _canvas;
    [SerializeField] RectTransform _parentTransform;

    private RectTransform _rectTransform;
    private SpawnerButton _spawnerButton;
    private CanvasGroup _canvasGroup;
    private float _deltaPosition;

    private void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        _spawnerButton = GetComponent<SpawnerButton>();
        _canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        var slotTransform = _rectTransform.parent;
        slotTransform.SetAsLastSibling();

        _spawnerButton.enabled = false;
        _canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _rectTransform.anchoredPosition += eventData.delta / _canvas.scaleFactor;
        _deltaPosition = _rectTransform.anchoredPosition.y - _parentTransform.anchoredPosition.y;
        Debug.Log(_rectTransform.anchoredPosition.y - _parentTransform.anchoredPosition.y);
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (_deltaPosition > 60)
            gameObject.SetActive(false);

        transform.localPosition = Vector3.zero;
        _spawnerButton.enabled = true;
        _canvasGroup.blocksRaycasts = true;
    }
}
