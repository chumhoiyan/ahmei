using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

[RequireComponent(typeof(SimpleAnimation))]
[RequireComponent(typeof(CanvasGroup))]

public class Page : MonoBehaviour {

	public List<int> questionIds;

	protected Transform _subPageContainer;
	protected Dictionary<string, SubPage> subPageDict;
	protected SubPage currentSubPage;

	protected Transform _TSlidingMenu;
	private Transform _TSlider;
	protected Dictionary<string, IconBase> menuBtnDict; 
	//protected Button _indexButton;
	protected float slidingTime = 0.5f;

	protected void Awake(){
		subPageDict = new Dictionary<string, SubPage> ();
	}

	protected void Start () {
		StartCoroutine (LateStartIEnumerator ());
		GetQuesionnaire ();
	}

	public void GetQuesionnaire(){
		if (questionIds != null) {
			if(questionIds.Count>0){
				int questionId = questionIds[0];
				if (!AppData.Instance.userInfoData.isQuestionDone (questionId)) {
					QuestionairePopup popup = PageManager.Instance.OpenPopup ("QuestionairePopup") as QuestionairePopup;
					popup.SetUp (AppData.Instance.questionDict [questionId], GetQuesionnaire);
				}
				questionIds.Remove(questionId);
			}
		}
	}
	
	IEnumerator LateStartIEnumerator(){
		yield return new WaitForEndOfFrame();
		LateStart ();
	}

	protected void Update () {
	}

	public virtual void LateStart(){
	}

	protected void SetUpSlidingMenu(Transform mTSlidingMenu, Transform mTSlider){
		_TSlidingMenu = mTSlidingMenu;
		_TSlider = mTSlider;
		menuBtnDict = new Dictionary<string, IconBase> ();

		bool foundIndexBtn = false;
		IconBase indexBtn = null;

		foreach (IconBase btn in _TSlidingMenu.GetComponentsInChildren<IconBase> ()) {
			if(!foundIndexBtn){
				foundIndexBtn = true;
				indexBtn = btn;
			}

			menuBtnDict.Add(btn.name, btn);
			IconBase tempBtn = btn;
			btn.onClickCallback += OnSlidingMenuBtnClick;
		}

		PreloadSubPage ();
		OnSlidingMenuBtnClick (indexBtn);
	}

	public virtual void OnBtnClick(Button button){
	}

	public virtual void OnSlidingMenuBtnClick(IconBase iconBase){
	}

	public virtual void PreloadSubPage(){
		foreach (IconBase btn in menuBtnDict.Values) {
			Transform btnT = btn.transform;
			OnSlidingMenuBtnClick(btn);
		}
	}

	protected SubPage OpenSubPage(string btnName, string subPageName, bool isSlidingMenu = false){
		SubPage subPage = new SubPage();
		if (_subPageContainer != null) {
			if (subPageDict.ContainsKey (btnName)) {
				subPage = subPageDict [btnName];
			} else {
				GameObject subPageResources = Resources.Load ("Prefabs/SubPage/" + subPageName, typeof(GameObject)) as GameObject;
				if (subPageResources != null) {
					GameObject subPageClone = Instantiate (subPageResources) as GameObject;
					subPage = subPageClone.GetComponent<SubPage> ();

					if (subPage != null) {
						subPageClone.transform.SetParent (_subPageContainer, false);

						if(isSlidingMenu){
							float posX = 0;
							if(currentSubPage!=null){
								posX = currentSubPage.transform.localPosition.x + ((RectTransform)transform).rect.width;
							}
							subPage.transform.localPosition = new Vector3(posX, 0, 0);
						}

						subPageDict.Add (btnName, subPage);
					} else {
						Debug.Log ("Component SubPage not found in" + subPageClone.name);
					}
				} else {
					Debug.Log ("Cannot find subPage:" + subPageName);
				}
			}

			subPage.transform.SetAsLastSibling();
			currentSubPage = subPage;

			if(isSlidingMenu){
				SlideTo(btnName);
			}else{
				SimpleAnimation simpleAnim = subPage.GetComponent<SimpleAnimation> ();
				simpleAnim.pageIn ();
				if(currentSubPage!=null){
					SimpleAnimation currentSimpleAnim = currentSubPage.GetComponent<SimpleAnimation> ();
					currentSimpleAnim.pageOut(null, false);
				}
			}
		}
		return subPage;
	}

	private void SlideTo(string btnName){
		SubPage subPage = subPageDict [btnName];
		float slideDistanceX = -1 * subPage.transform.localPosition.x;
		foreach (SubPage s in subPageDict.Values) {
			s.transform.DOKill();
			s.transform.DOBlendableLocalMoveBy (new Vector3 (slideDistanceX, 0, 0), slidingTime);
		}

		float sliderPosX = menuBtnDict[btnName].transform.localPosition.x;
		_TSlider.DOLocalMoveX (sliderPosX, slidingTime);

	}

	public void PreparePageClose(){

	}

	public virtual void OnPageClose(){
		PageManager.Instance.pageList.Remove (this);
		Destroy (gameObject);
	}

}
