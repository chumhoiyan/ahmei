using UnityEngine;
using System.Collections;
using SimpleJSON;

public class AnswerData {
	public int id;
	public int qid;
	public string answer;

	public AnswerData(JSONNode json){
		id = json["id"].AsInt;
		qid = json["qid"].AsInt;
		answer = json["anwser"];
	}
}
