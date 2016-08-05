using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class QuestionairePopup : Popup {
	public GameObject answerBtnResources;
	QuestionData _questionData;

	Transform _TContent;
	Text _questionText;
	System.Action _callback;
	//bool _isCallback = false;

	protected void Awake(){
		base.Awake ();
		_TContent = transform.FindChild ("Content");
		_questionText = _TContent.FindChild ("Question").GetComponent<Text>();
	}
	
	// Use this for initialization
	protected void Start () {
		base.Start ();
	}
	
	// Update is called once per frame
	protected void Update () {
		base.Update ();
	}

	public void SetUp(QuestionData mQuestionData, System.Action callback = null ){
		_callback = callback;
		_questionData = mQuestionData;
		_questionText.text = _questionData.question;

		foreach (AnswerData answerData in _questionData.anwserList) {
			AnswerData temp = answerData;
			GameObject answerBtnClone = Instantiate(answerBtnResources) as GameObject;
			answerBtnClone.GetComponentInChildren<Text>().text = temp.answer;
			answerBtnClone.GetComponentInChildren<Button>().onClick.AddListener(()=>{
				OnAnswerClick(answerData);
			});
			answerBtnClone.transform.SetParent(_TContent,false);
			answerBtnClone.GetComponentInChildren<Text>().text = answerData.answer;
		}
	}	

	public void OnAnswerClick(AnswerData answerData){
		PageManager.Instance.ClosePopup (this);
		Dictionary<string, string> parma = new Dictionary<string, string>();
		parma.Add("user_id", AppData.Instance.userInfoData.id.ToString());
		parma.Add("question_id", _questionData.id.ToString());
		parma.Add("anwser id", answerData.id.ToString());
		Request.Instance.CallAPI(RequestUrlConfig.API_SAVE_QUESTION, parma, null);
		//AppData.Instance.userInfoData.RemoveQuestionId (_questionData.id);
		//if(answerData.qid)
	}

	public override void OnBtnClick(Button button){
		base.OnBtnClick (button);
		if (button.name == "DimBG") {
			PageManager.Instance.ClosePopup (this);
		}
	}
	
	public override void OnPageClose(){
		base.OnPageClose ();

		_callback ();
	}
}
