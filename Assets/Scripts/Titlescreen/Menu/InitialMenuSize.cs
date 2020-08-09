using UnityEngine;
using UnityEngine.UI;

public class InitialMenuSize : MonoBehaviour
{

    private float ReferenceResolution => transform.parent.GetComponentInParent<CanvasScaler>().referenceResolution.x;
    private float SideMenuRatio => transform.parent.GetComponent<RectTransform>().anchorMin.x;

    void Start()
    {
        Vector2 mainInitialSize = GetComponent<RectTransform>().offsetMin;

        // Need reference resolution as canvas scales
        mainInitialSize.x = ReferenceResolution * SideMenuRatio;

        GetComponent<RectTransform>().offsetMin = mainInitialSize;
    }
}
