using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
	Dictionary<int, string[]> talkData;
	Dictionary<int, Sprite> protraitDate;
	public Sprite[] portraitArr;

	private void Awake() {
		talkData = new Dictionary<int, string[]>();
		protraitDate = new Dictionary<int, Sprite>();
		GenerateData();
	}
	void GenerateData() {
		talkData.Add(1001, new string[] { "안녕?:0", "넌 누구니?:3" });
		talkData.Add(1002, new string[] { "왜?:1", "넌 저리로가:3", "누구니?:0" });
		talkData.Add(101, new string[] { "평범한 나무상자" });
		talkData.Add(102, new string[] { "평범한 나무책상" });
		talkData.Add(103, new string[] { "흔한 돌벽" });
		protraitDate.Add(1001 + 0, portraitArr[0]);
		protraitDate.Add(1001 + 1, portraitArr[1]);
		protraitDate.Add(1001 + 2, portraitArr[2]);
		protraitDate.Add(1001 + 3, portraitArr[3]);
		protraitDate.Add(1002 + 0, portraitArr[4]);
		protraitDate.Add(1002 + 1, portraitArr[5]);
		protraitDate.Add(1002 + 2, portraitArr[6]);
		protraitDate.Add(1002 + 3, portraitArr[7]);

	}
	public string GetTalk(int id, int talkIndex) {
		if(talkIndex == talkData[id].Length) {
			return null;
		}
		else{
			return talkData[id][talkIndex];
		}
	}
	public Sprite GetPotrait(int id, int portraitIndex) {
		return protraitDate[id + portraitIndex];
	}
}
