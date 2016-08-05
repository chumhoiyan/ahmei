using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using SimpleJSON;

public class AppData : Singleton<AppData> {

	public enum UserType
	{
		buyer,
		shopper
	}

	public UserType userType;
	public List<IconBase> chosenAddClothes;

	public UserInfoData userInfoData;
	public Dictionary<int, QuestionData> questionDict;

	protected void Awake(){
		base.Awake ();
		chosenAddClothes = new List<IconBase> ();
		questionDict = new Dictionary<int, QuestionData>();
	}

	public void SetQuestion(JSONNode questionJSON){
		questionDict = new Dictionary<int, QuestionData> ();
		if (questionJSON.AsArray != null) {
			foreach (JSONNode child in questionJSON.AsArray) {
				QuestionData questionData = new QuestionData (child);
				questionDict.Add (questionData.id, questionData);
			}
		}
	}

}
