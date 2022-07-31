using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool isAction;
    public int talkIndex;
    public Image portraitImg;
    public TalkManager talkManager;
    public GameObject talkPanle;
    public GameObject scanObject;
    public TextMeshProUGUI talkText;
    public QuestManager questManager;

    public void Action(GameObject scanObj) {
        scanObject = scanObj;
        ObjData objData = scanObject.GetComponent<ObjData>();
        Talk(objData.id, objData.isNpc);
		talkPanle.SetActive(isAction);
    }
    void Talk(int id, bool isNpc) {
        int questTalkIndex = questManager.QuestTalkIndex(id);
        string talkData = talkManager.GetTalk(id + questTalkIndex, talkIndex);
        //대화 종료
        if(talkData == null) {
            isAction = false;
            talkIndex = 0; //새로운 오브젝트에 다가갔을때 대화로그를 초기화
            Debug.Log(questManager.CheckQuest(id));
            return;
		}
        //엔피씨가 대상일때
		if(isNpc) {
            talkText.text = talkData.Split(':')[0];
            portraitImg.sprite = talkManager.GetPotrait(id, int.Parse(talkData.Split(':')[1]));
            portraitImg.color = new Color(1, 1, 1, 1);
        }
        //대상이 사물일때
        else {
            talkText.text = talkData;
            portraitImg.color = new Color(1, 1, 1, 0);
        }
        isAction = true;
        talkIndex++;
    }
}
