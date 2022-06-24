using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Character_Creation : MonoBehaviour
{
    // Start is called before the first frame update
    public UIInput nameInput;//用来得到输入的文本
    public GameObject[] characterPrefabs;
    private GameObject[] characterGameObjects;
    private int selectedIndex = 0;
    private int length;
    void Start()
    {
         length = characterPrefabs.Length;
        characterGameObjects = new GameObject[length];
        for(int i = 0; i < length; i++)
        {
            characterGameObjects[i] = Instantiate(characterPrefabs[i],transform.position,transform.rotation) as GameObject;
        }


    }

    // Update is called once per frame
    void Update()
    {
        UpdateCharacterShow();
    }
    void UpdateCharacterShow()
    {
        characterGameObjects[selectedIndex].SetActive(true);
        for(int i = 0; i < length; i++)
        {
            if (i != selectedIndex)
            {
                characterGameObjects[i].SetActive(false);
            }
        }
    }

    public void OnNextButtonClick()
    {
        selectedIndex++;
        if(selectedIndex >= length)
        {
            selectedIndex = 0;
        }
        UpdateCharacterShow();
    }
    public void OnPrevButtonClick()
    {
        selectedIndex--;
        if (selectedIndex == -1)
        {
            selectedIndex = length-1;
        }
        UpdateCharacterShow();
    }
    public void OnOkButtonClick()
    {
        //加载下一个场景
        PlayerPrefs.SetInt("SelectedCharacterIndex", selectedIndex); //存储选择的角色
        PlayerPrefs.SetString("name", nameInput.value);
        //加载下一个场景
        SceneManager.LoadScene("play2");

    }
}
