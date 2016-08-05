using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class QuestionData {
	public int id;
	public string question;
	public int status;
	public List<AnswerData> anwserList;

	public QuestionData(JSONNode json){
		id = json["id"].AsInt;
		question = json["question"];
		status = json["status"].AsInt;
		anwserList = new List<AnswerData> ();
		foreach (JSONNode child in json["anwser"].AsArray) {
			anwserList.Add(new AnswerData(child));
		}
	}
}
