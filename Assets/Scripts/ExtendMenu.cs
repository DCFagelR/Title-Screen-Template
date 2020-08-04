using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExtendMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject _Background;

    private GameObject myObject;

    // Start is called before the first frame update
    void Update() // Change to awake
    {
        myObject = this.gameObject.gameObject;

        if(Input.GetKey(KeyCode.Space)) {
            myObject.SetActive(false);
        }
    }
}
