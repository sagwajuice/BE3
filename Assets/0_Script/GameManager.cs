using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI talkText;
    public GameObject scanObject;

    public void Acttion(GameObject scanObj) {
        scanObject = scanObj;
        talkText.text = "이것의 이름은 " + scanObject.name + "이라고 한다.";

    }
}
