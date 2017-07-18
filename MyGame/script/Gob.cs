using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gob {
	public const int LAYER_CHARACTER = 8;
	public const int LAYER_MONSTER_GEN = 9;
	public const int LAYER_SCENE_ITEM = 10;
	public const int LAYER_TERRIAN = 11;
	public const int LAYER_MONSTER = 12;
	public const int LAYER_MONSTER_WEAPON = 13;
	public const int LAYER_CHARACTER_WEAPON = 14;
	public const int LAYER_GENERAL_DIE = 15;
	public const int LAYER_CHEST = 16;
	public static LayerMask LAYER_MASK_MONSTER = 1 << LAYER_MONSTER;
	public static LayerMask LAYER_MASK_CHEST = 1 << LAYER_CHEST;
	// public static int LAYER_TERRIAN_MASK = 1 << LAYER_TERRIAN;
	// public static int LAYER_CHARACTER_DIE_MASK = 1 << LAYER_CHARACTER_DIE;
	// public static int LAYER_CAMP1_CHARACTER_MASK = 1 << LAYER_CAMP1_CHARACTER;
	// public static int LAYER_CAMP2_CHARACTER_MASK = 1 << LAYER_CAMP2_CHARACTER;
	// public static int LAYER_CAMP1_AOI_MASK = 1 << LAYER_CAMP1_AOI;
	// public static int LAYER_CAMP2_AOI_MASK = 1 << LAYER_CAMP2_AOI;
	// public static int LAYER_CAMP1_WEAPON_MASK = 1 << LAYER_CAMP1_WEAPON;
	// public static int LAYER_CAMP2_WEAPON_MASK = 1 << LAYER_CAMP2_WEAPON;
	// public static int LAYER_SCENE_ITEM_MASK = 1 << LAYER_SCENE_ITEM;
	// public static int arrowLayerMask = Gob.LAYER_TERRIAN_MASK | Gob.LAYER_CAMP1_CHARACTER_MASK | Gob.LAYER_CAMP2_CHARACTER_MASK | Gob.LAYER_CAMP1_WEAPON_MASK | Gob.LAYER_CAMP2_WEAPON_MASK | Gob.LAYER_SCENE_ITEM_MASK;
	// public static int eyeLayerMask = Gob.LAYER_TERRIAN_MASK | Gob.LAYER_SCENE_ITEM_MASK;

	public static Transform findChildInDepth(Transform parent, string childName)
	{
		if(parent.name == childName)
		{
			return parent;
		}
		if(parent.childCount < 1)
		{
			return null;
		}
		Transform result = null;
		foreach (Transform child in parent) {
			result = findChildInDepth(child, childName);
			if(result != null)
			{
				break;
			}
		}
		return result;
	}

	public static Transform findChildInWide(Transform parent, string childName)
	{
		LinkedList<Transform> list = new LinkedList<Transform>();
		list.AddLast(parent);
		while (list.Count > 0) {
			parent = list.First.Value;
			list.RemoveFirst();
			foreach (Transform child in parent) {
				if (child.name == childName) {
					return child;
				}
				if (child.childCount > 0) {
					list.AddLast(child);
				}
			}
		}
		return null;
	}

	public static Color hexToColor(string hex) {
		int r = Convert.ToInt32(hex.Substring(0, 2), 16);
		int g = Convert.ToInt32(hex.Substring(2, 2), 16);
		int b = Convert.ToInt32(hex.Substring(4, 2), 16);
		int a = Convert.ToInt32(hex.Substring(6, 2), 16);
		Color color = new Color((float)r/255, (float)g/255, (float)b/255, (float)a/255);
		return color;
	}

	public static float calcDist2D(Vector3 curPos, Vector3 targetPos) {
		curPos.y = 0f;
		targetPos.y = 0f;
		return Vector3.Distance(curPos, targetPos);
	}
}
