using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using System.Collections.Generic;

public class CustomMouseCursor : MonoBehaviour
{
    [Header("Cursor Settings")]
    [SerializeField] private RectTransform cursorTransform;
    [SerializeField] private Canvas canvas;

    private PointerEventData pointerData;
    private List<RaycastResult> uiResults = new List<RaycastResult>();

    void Awake()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;

        if (canvas == null)
            canvas = GetComponentInParent<Canvas>();

        pointerData = new PointerEventData(EventSystem.current);
    }

    void Update()
    {
        UpdateCursorPosition();

        if (Mouse.current.leftButton.wasPressedThisFrame)
            HandleClick();
    }

    void UpdateCursorPosition()
    {
        if (!cursorTransform) return;

        Vector2 mousePosition = Mouse.current.position.ReadValue();

        if (canvas.renderMode == RenderMode.ScreenSpaceOverlay)
        {
            cursorTransform.position = mousePosition;
        }
        else
        {
            Vector2 pos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(
                canvas.transform as RectTransform,
                mousePosition,
                canvas.worldCamera,
                out pos
            );

            cursorTransform.position = canvas.transform.TransformPoint(pos);
        }
    }

    void HandleClick()
    {
        GameObject hit = GetObjectUnderMouse();
        if (hit == null) return;

        IClickable clickable = hit.GetComponent<IClickable>();
        if (clickable != null)
        {
            clickable.OnClick();
        }
    }

    GameObject GetObjectUnderMouse()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue();

        pointerData.position = mousePosition;
        uiResults.Clear();
        EventSystem.current.RaycastAll(pointerData, uiResults);

        if (uiResults.Count > 0)
            return uiResults[0].gameObject;

        return null;
    }

    void OnDestroy()
    {
        Cursor.visible = true;
    }
}

public interface IClickable
{
    void OnClick();
}