using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
	Dictionary<int, string[]> talkData;
	Dictionary<int, Sprite> protraitDate;
	public Sprite[] portraitArr;

	private void Awake() {
		talkData = new Dictionary<int, string[]>(); //딕셔너리 아이디, 문자내용
		protraitDate = new Dictionary<int, Sprite>(); //딕셔너리 아이디, 스프라이트
		GenerateData();
	}
	void GenerateData() {
		talkData.Add(1000, new string[] { "안녕?:0", "넌 누구니?:3" });
		talkData.Add(2000, new string[] { "왜?:1", "넌 저리로가:3", "누구니?:2" });
		talkData.Add(3000, new string[] { "평범한 나무상자" });
		talkData.Add(4000, new string[] { "평범한 나무책상" });
		talkData.Add(103, new string[] { "흔한 돌벽" });
		//퀘스트 이벤트
		talkData.Add(10 + 1000, new string[] { "어서와?:0", "이 마을 왜이럼?:3" });
		talkData.Add(11 + 2000, new string[] { "바쁘니까:0", "저리가라:3", "시르면 말고:2"});
		talkData.Add(20 + 1000, new string[] { "오호호호호:0", "히히히히:3", "하하하:2"});
		talkData.Add(20 + 5000, new string[] { "동전"});
		talkData.Add(21 + 2000, new string[] { "오:0", "오예:3", "땡큐감사:2"});
		protraitDate.Add(1000 + 0, portraitArr[0]);
		protraitDate.Add(1000 + 1, portraitArr[1]);
		protraitDate.Add(1000 + 2, portraitArr[2]);
		protraitDate.Add(1000 + 3, portraitArr[3]);
		protraitDate.Add(2000 + 0, portraitArr[4]);
		protraitDate.Add(2000 + 1, portraitArr[5]);
		protraitDate.Add(2000 + 2, portraitArr[6]);
		protraitDate.Add(2000 + 3, portraitArr[7]);
	}
	public string GetTalk(int id, int talkIndex) {
		if(!talkData.ContainsKey(id)){
			if(!talkData.ContainsKey(id - id % 10)){
			//퀘스트 진행 순서 대사가 없을때 퀘스트 맨처름 대사를 가지고 온다.
				if(talkIndex == talkData[id - id % 100].Length) {
					return null;
				}
				else {
					return talkData[id - id % 100][talkIndex];
				}
			}
			else {
				if(talkIndex == talkData[id - id % 10].Length) {
					return null;
				}
				else {
					return talkData[id - id % 10][talkIndex];
				}
			}
		}
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