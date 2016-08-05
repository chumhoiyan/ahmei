using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UserData : Singleton<UserData> {

	public enum UserType
	{
		buyer,
		shopper
	}

	public UserType userType;
	public List<IconBase> chosenAddClothes;

	protected void Awake(){
		base.Awake ();
		chosenAddClothes = new List<IconBase> ();
	}

}
