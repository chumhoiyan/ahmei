using UnityEngine;
using System.Collections;
using DG.Tweening;
using System;

public class SimpleAnimation : MonoBehaviour {

	public enum AnimationType{
		MoveIn,
		MoveOut,
		Popup,
		Popout,
		Sliding,
		None,
	}

	public AnimationType pageInAnim = AnimationType.MoveIn;
	public AnimationType pageOutAnim = AnimationType.MoveOut;
	public float animtionTime = 0.5f;

	public void pageIn(System.Action callback = null){
		Sequence seq = DOTween.Sequence();
		if (pageInAnim == AnimationType.MoveIn) {
			seq = moveIn();
		}else if (pageInAnim == AnimationType.MoveOut) {
			seq = moveOut();
		}else if (pageInAnim == AnimationType.None) {
		}else if (pageInAnim == AnimationType.Popup) {
			seq = popUp();
		}else if (pageInAnim == AnimationType.Popout) {
			seq = popOut();
		}

		if(callback!=null){
			seq.AppendCallback (new TweenCallback(callback));
		}
	}

	public void pageOut(Action[] callbacks = null, bool isClosePage = false){
		Sequence seq = DOTween.Sequence();

		if (pageOutAnim == AnimationType.MoveIn) {
			seq = moveIn();
		}else if (pageOutAnim == AnimationType.MoveOut) {
			seq = moveOut(isClosePage);
		}else if (pageOutAnim == AnimationType.None) {
		}else if (pageOutAnim == AnimationType.Popup) {
			seq = popUp();
		}else if (pageOutAnim == AnimationType.Popout) {
			seq = popOut();
		}

		if(callbacks!=null){
			foreach(Action callback in callbacks){
				seq.AppendCallback (new TweenCallback(callback));
			}
		}
	}

	public Sequence popUp(){
		Transform _TContent = transform.FindChild("Content");
		Transform poppingTransform = (_TContent == null) ? transform : _TContent;

		poppingTransform.localScale = Vector3.zero;
		Sequence seq = DOTween.Sequence ();
		seq.Append (poppingTransform.DOScale (Vector3.one, animtionTime));

		return seq;
	}

	public Sequence popOut(){
		Transform _TContent = transform.FindChild("Content");
		Transform poppingTransform = (_TContent == null) ? transform : _TContent;

		Sequence seq = DOTween.Sequence ();
		seq.Append (poppingTransform.DOScale (Vector3.zero, animtionTime));

		return seq;
	}

	Sequence moveIn(){
		transform.localPosition = new Vector3 (((RectTransform)transform).rect.width, 0, 0);

		Sequence seq = DOTween.Sequence ();

		foreach (Page p in PageManager.Instance.pageList) {
			seq.Insert(0,p.transform.DOBlendableLocalMoveBy (new Vector3(-1 * (((RectTransform)p.transform).rect.width),0,0),animtionTime));
		}
		return seq;
	}

	Sequence moveOut(bool isClosePage = false){
		Sequence seq = DOTween.Sequence();

		foreach (Page p in PageManager.Instance.pageList) {
			seq.Insert (0, p.transform.DOBlendableLocalMoveBy (new Vector3 (((RectTransform)p.transform).rect.width, 0, 0),animtionTime));
		}

		return seq;
	}


}
