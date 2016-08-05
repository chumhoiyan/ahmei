using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour{

	private static T _Instance;

	public static T Instance
	{
		get
		{
			if (_Instance == null){
				_Instance = FindObjectOfType(typeof(T)) as T ;
				
				if(_Instance == null){
					GameObject go = new GameObject("_singleton" + (typeof(T)).Name );
					_Instance = go.AddComponent<T>();
					DontDestroyOnLoad(go);
				}
			}
			return _Instance;
		}
	}

	protected void Awake () {
		if (Instance != this) Destroy(this);
	}

}
