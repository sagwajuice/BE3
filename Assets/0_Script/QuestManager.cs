using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    public int questId;
    public int questActionIndex;
    Dictionary<int, QuestData> questList;
    public GameObject [] questObject;

    private void Awake() {
        questList = new Dictionary<int, QuestData>();
        GenerateData();
    }
    void GenerateData() {
        questList.Add(10, new QuestData("첫 마을 임무", new int[] {1001, 2002}));
        questList.Add(20, new QuestData("짜증내는 임무", new int[] {3001, 2002}));
    }
    public int QuestTalkIndex(int id){
        return questId + questActionIndex;
    }
    public string CheckQuest(int id) {
        if(id == questList[questId].npcId[questActionIndex]){
            questActionIndex++;
        }
        ControlObject();
        if(questActionIndex == questList[questId].npcId.Length){
            NextQuest();
        }
        return questList[questId].questname;
    }
    void NextQuest(){
        questId += 10;
        questActionIndex = 0;
    }
    void ControlObject(){
        switch(questId){
            case 10:
                if(questActionIndex == 2)
                    questObject[0].SetActive(true);
                break;
            case 20:
                if(questActionIndex == 1)
                    questObject[0].SetActive(false);
                break;
        }
    }
}