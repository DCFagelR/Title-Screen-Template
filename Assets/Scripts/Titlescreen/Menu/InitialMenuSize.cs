using UnityEngine;
using UnityEngine.UI;

public class InitialMenuSize : MonoBehaviour
{

    private float ReferenceResolution => transform.parent.GetComponentInParent<CanvasScaler>().referenceResolution.x;
    private float SideMenuAnchorX => transform.parent.GetComponent<RectTransform>().anchorMin.x;

    void Start()
    {
        Vector2 mainInitialSize = GetComponent<RectTransform>().offsetMin;
        float SideMenuRatio = 1 - SideMenuAnchorX;

        // Need reference resolution as canvas scales
        mainInitialSize.x = ReferenceResolution * SideMenuAnchorX;

        GetComponent<RectTransform>().offsetMin = mainInitialSize;
        GetComponent<RectTransform>().anchorMin = new Vector2(-SideMenuAnchorX/SideMenuRatio, 0);
    }
}
