using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class UserInfoData{
	public int id;
	public string Log;
	public string password;
	public string Email;
	public string Telephone;
	List<int> questionData;
	public int status;

	public UserInfoData(JSONNode json){
		id = json ["id"].AsInt;
		Log = json ["Log"];
		password = json ["password"];
		Email = json ["Email"];
		Telephone = json ["Telephone"];
		questionData = new List<int>();

		/*
		if (PlayerPrefs.GetInt ("id") == null || PlayerPrefs.GetInt ("id") !=id) {
			PlayerPrefs.SetInt("id",id);
			PlayerPrefs.SetString("questionData", "1,2,3,4,5,6,7,8,9,10,11,12,13,14");
		}

		string questionDataString = "1,2,3,4,5,6,7,8,9,10,11,12,13,14";
		if(PlayerPrefs.GetString("questionData") != null){
			questionDataString = PlayerPrefs.GetString("questionData");
		}
		*/

		string questionDataString = json ["questionData"];
		string[] stringArray = questionDataString.Split(',');

		foreach(string s in stringArray){
			if(s!=""){
				questionData.Add(int.Parse(s));
			}
		}

		status = json ["status"].AsInt;
	}

	public bool isQuestionDone(int questionId){
		if (questionData.Contains (questionId)) {
			return false;
		} else {
			return true;
		}
	}

	
}
