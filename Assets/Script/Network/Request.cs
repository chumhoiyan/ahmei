using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using SimpleJSON;

public class Request : Singleton<Request> {

	private Popup _loadingPopup = null;
	private GameObject _errorPopupPrefab = null;
	private string _lastUrl;
	private Dictionary<string, string> _lastParameters;
	private Action<JSONNode> _lastCallback;
	private bool _lastShowLoading;
	private bool _lastAutoCloseLoading;
	private bool _lastShowErrorPopup;
	private WWW _wwwAsset = null;

	public void CallAPI (string url, Dictionary<string, string> parameters, Action<JSONNode> callback, bool showLoading = true, bool showErrorPopup = true, bool autoCloseLoading = true, float delayTime = 0f)
	{
		_lastUrl = url;
		_lastParameters = parameters;
		_lastCallback = callback;
		_lastShowLoading = showLoading;
		_lastAutoCloseLoading = autoCloseLoading;
		_lastShowErrorPopup = showErrorPopup;
		
		if (showLoading) {
			_loadingPopup = PageManager.Instance.OpenPopup ("LoadingPopup");
		}
		WWWForm form = new WWWForm ();
		if (parameters != null) {
			foreach (string keyOfParam in GetBaseParam.Keys) {
				if (!parameters.ContainsKey (keyOfParam)) {
					parameters.Add (keyOfParam, GetBaseParam [keyOfParam]);
				}
			}
		} else {
			parameters = new Dictionary<string, string> ();
			foreach (string keyOfParam in GetBaseParam.Keys) {
				parameters.Add (keyOfParam, GetBaseParam [keyOfParam]);
			}
		}
		
		if (parameters != null) {
			foreach (string key in parameters.Keys) {
				form.AddField (key, parameters [key]);
			}
		}
		WWW www = new WWW (url, form);
		StartCoroutine (WaitForRequest (www, callback, showErrorPopup, delayTime));
	}

	protected IEnumerator WaitForRequest (WWW www, Action<JSONNode> callback, bool showErrorPopup, float delayTime)
	{
		if(delayTime > 0f){
			yield return new WaitForSeconds(delayTime);
		}
		yield return www;
		// check for errors
		string errorStringTitle = "";
		string errorString = "";
		bool isPwInvalid = false;

		if(_lastAutoCloseLoading){
			if(_loadingPopup!=null){
				PageManager.Instance.ClosePopup(_loadingPopup);
				_loadingPopup = null;
			}
		}

		if (www.error == null) {
			JSONNode json = JSON.Parse (www.text);

			int code = json ["code"].AsInt;
			if (code != 2) {
				string errorMessage = (string)json ["message"];
				ErrorPopup popup = PageManager.Instance.OpenPopup("ErrorPopUp") as ErrorPopup;
				popup.SetUp(errorMessage);
			} else {
				UpdateAppData (json);
				if(callback!=null){
					callback (json);
				}
			}
		}

			/*
			if (errorCode > 0) {
				switch(errorCode)
				{
				case 7:
					errorStringTitle = "Old Version";
					errorString = "";
					break;
				case 8:
					errorStringTitle = "Maintainence";
					errorString = "";
					break;
				case 9:
					isPwInvalid = true;
					break;
				default:
					errorStringTitle = "Request Error";
					errorString = "error : " + errorCode;
					break;
				}
				
				if(Debug.isDebugBuild)
					errorString += "(" + errorCode + "): " + jsonNode ["error_description"];
			} else {
				
				UpdateGameData (jsonNode ["data"]);
				callback (jsonNode);
			}
		} else {
			errorStringTitle = "Request Error";
			
			if(Debug.isDebugBuild)
				errorString += "(" + www.error.ToString () + ")";
		}
		*/

		
		//Debug.Log(errorString);
		/*if(isPwInvalid){
			PopupConfirm popupConfirm = PageManager.Instance.OpenPopup("PopupConfirm") as PopupConfirm;
			popupConfirm.title = errorStringTitle;
			popupConfirm.message = errorString;
		} else if (errorStringTitle != "" && showErrorPopup) {
			PopupConfirm popupConfirm = PageManager.Instance.OpenPopup("PopupConfirm") as PopupConfirm;
			popupConfirm.title = errorStringTitle;
			popupConfirm.message = errorString;
			popupConfirm.popupFadeOutResultButton = OnCloseErrorPopupAniFinish;
			if(Debug.isDebugBuild)
				Debug.Log("CallAPI " + errorStringTitle + "/  errorString:" + errorString);
		} else 
		*/
	}

	private Dictionary<string,string> GetBaseParam {
		get {
			Dictionary<string,string> loginDict = new Dictionary<string, string> ();

			if(AppData.Instance.userInfoData!=null){
				loginDict.Add ("Log", AppData.Instance.userInfoData.Log); 
				loginDict.Add ("password", AppData.Instance.userInfoData.password);
			}
			return loginDict;
		}
	}

	public void UpdateAppData (JSONNode jsonData)
	{
		Debug.Log (jsonData);
		if (jsonData ["userInfo"] != null) {
			AppData.Instance.userInfoData = new UserInfoData(jsonData ["userInfo"]);
			/*
			if (GameObject.Find ("IndexPage")) {
				GameObject.Find ("IndexPage").GetComponent<IndexPage> ().UpdateContent ();
			}
			*/
		}

		if (jsonData ["question"] != null || jsonData ["question"].AsBool != false) {
			AppData.Instance.SetQuestion(jsonData ["question"]);
			/*
			if (GameObject.Find ("IndexPage")) {
				GameObject.Find ("IndexPage").GetComponent<IndexPage> ().UpdateContent ();
			}
			*/
		}

	}

}
