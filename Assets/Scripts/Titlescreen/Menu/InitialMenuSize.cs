using System;
using UnityEngine;
using UnityEngine.UI;

public class InitialMenuSize : MonoBehaviour
{

// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private float ReferenceResolution => transform.parent.GetComponentInParent<CanvasScaler>().referenceResolution.x;

    [SerializeField]
    private GameObject _sideMenu = null;
    [SerializeField]
    private GameObject _mainMenu = null;

    [SerializeField]
    [Range(0,0.8f)]
    private float _sideMenuMinAnchorX = 0.8f;
    
    private Vector2 _closedSize;

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    void Start()
    {
        setSideMenuSize();
        setMainMenuSize();
    }

// ----------------------------------------------------------------------------

    public Vector2 getClosedSize() => _closedSize;

// ----------------------------------------------------------------------------

    private void setSideMenuSize()
    {
        _sideMenu.GetComponent<RectTransform>().anchorMin = new Vector2(_sideMenuMinAnchorX, 0);
        _sideMenu.GetComponent<RectTransform>().anchorMax = new Vector2(1, 1);

        _sideMenu.GetComponent<RectTransform>().offsetMin = Vector2.zero;
        _sideMenu.GetComponent<RectTransform>().offsetMax = Vector2.zero;
    }

// ----------------------------------------------------------------------------

    private void setMainMenuSize()
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
