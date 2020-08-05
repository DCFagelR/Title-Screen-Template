using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuExtender : MonoBehaviour
{
// ++Variables+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    private GameObject _myObject;

    [Range(1,10)]
    [SerializeField]
    private int _fadeSpeed = 1;

    // Start is called before the first frame update
    void Start() {
        _myObject = this.gameObject;
    }

// ++Methods+++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++++

    public void ExtendMenu()
    {
        DeactivateMenuObjects();
    }

// ----------------------------------------------------------------------------

    private void DeactivateMenuObjects()
    {
        GameObject myChild = _myObject.transform.GetChild(0).gameObject;
        GameObject childButtons = myChild.transform.GetChild(0).gameObject;
        int currChild = 0;

        // while(childButtons != null) {
        //     Debug.Log("EXISTS");
        //     childButtons.GetComponentInChildren<TextFader>().TextFadeContoller(true);
        //     currChild++;
        // }

        // while(true) {
            
        //     break;
        // }

        // myChild.SetActive(false);
    }
}
