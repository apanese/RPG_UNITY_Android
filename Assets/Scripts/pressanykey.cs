using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pressanykey : MonoBehaviour
{
    // Start is called before the first frame update
    private bool isAnyKeyDown = false;
    private GameObject ButtonContainer;
    // Start is called before the first frame update
    void Start()
    {
        ButtonContainer = this.transform.parent.Find("Container").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isAnyKeyDown)
        {
            if (Input.anyKey)
            {
                ShowContainerButton();
            }
        }
    }
    void ShowContainerButton()
    {
        this.gameObject.SetActive(false);
        ButtonContainer.SetActive(true);
        isAnyKeyDown = true;

    }
}
