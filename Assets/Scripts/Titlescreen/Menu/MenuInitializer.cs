using UnityEngine;
using UnityEngine.UI;

public class MenuInitializer : MonoBehaviour
{

// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private float ReferenceResolution => transform.parent.GetComponentInParent<CanvasScaler>().referenceResolution.x;

    [Header("Menu Items")]
    [SerializeField]
    private GameObject _sideMenu = null;
    [SerializeField]
    private GameObject _mainMenu = null;

    [Header("Side Menu Size")]
    [SerializeField]
    [Range(0,0.8f)]
    [Tooltip("Side menu size. Based on what percent of screen the menu sits on. 0.1 = on the 10%")]
    private float _sideMenuLeftAnchor = 0.8f;
    
    private Vector2 _closedSize;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    void Start()
    {
        SetSideMenuSize();
        SetMainMenuSize();
    }

// ----------------------------------------------------------------------------

    public Vector2 getClosedSize() => _closedSize;

// ----------------------------------------------------------------------------

    private void SetSideMenuSize()
    {
        _sideMenu.GetComponent<RectTransform>().anchorMin = new Vector2(_sideMenuLeftAnchor, 0);
        _sideMenu.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);

        _sideMenu.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        _sideMenu.GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }

// ----------------------------------------------------------------------------

    private void SetMainMenuSize()
    {
        float sideMinX = _sideMenu.GetComponent<RectTransform>().anchorMin.x;
        float horizontalSize = ReferenceResolution * sideMinX;

        _mainMenu.GetComponent<RectTransform>().anchorMin = Vector2.zero;
        _mainMenu.GetComponent<RectTransform>().anchorMax = new Vector2(sideMinX, 1);

        _mainMenu.GetComponent<RectTransform>().offsetMin = new Vector2(horizontalSize, 0);

        _closedSize = _mainMenu.GetComponent<RectTransform>().sizeDelta;
        
        Debug.Log(_closedSize);
    }
}
