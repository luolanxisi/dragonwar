using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FemaleCharacter : MonoBehaviour {
	private GameObject head;
	private GameObject torso;
	private GameObject arms;
	private GameObject hands;
	private GameObject legs;
	private GameObject neck;
	private Color[] bodyColors;
	public Texture2D[] headTextures;
	public GameObject eyes;
	public Texture2D[] eyeTextures;
	private string[] hairNames;
	private GameObject hairGo;
	private Color[] hairColors;
	//
	private string[] helmNames;
	private string[] chestNames;
	private string[] chestFullNames;
	private string[] shouldNames;
	private string[] glovesNames;
	private string[] pantsNames;
	private string[] beltNames;
	private string[] bootsNames;
	//
	public GameObject leftHandPoint;
	public GameObject rightHandPoint;
	public GameObject shieldPoint;

	// Use this for initialization
	void Start () {
		//
		head = Gob.findChildInWide(transform, "Mesh_F_head").gameObject;
		torso = Gob.findChildInWide(transform, "Mesh_F_torso").gameObject;
		arms = Gob.findChildInWide(transform, "Mesh_F_arms").gameObject;
		hands = Gob.findChildInWide(transform, "Mesh_F_hands").gameObject;
		legs = Gob.findChildInWide(transform, "Mesh_F_legs").gameObject;
		neck = Gob.findChildInWide(transform, "Mesh_F_neck").gameObject;
		//
		head.active = true;
		torso.active = true;
		arms.active = false;
		hands.active = true;
		legs.active = true;
		neck.active = false;
		//
		bodyColors = new Color[] {
			Gob.hexToColor("FFFFFF00"),
			Gob.hexToColor("E6E2BA00"),
			Gob.hexToColor("E4CDB300"),
			Gob.hexToColor("C1B48C00"),
			Gob.hexToColor("A1886200"),
			Gob.hexToColor("7B603C00")
		};
		hairColors = new Color[] {
			Gob.hexToColor("FFFFFF00"),
			Gob.hexToColor("FFF0B500"),
			Gob.hexToColor("D0CCA500"),
			Gob.hexToColor("947B5600"),
			Gob.hexToColor("877D5700"),
			Gob.hexToColor("5D482700"),
			Gob.hexToColor("4A2B1300"),
			Gob.hexToColor("B74D0000"),
			Gob.hexToColor("BB0E0200")
		};
		Color bodyColor = bodyColors[Random.Range(0, bodyColors.Length)];
		head.GetComponent<Renderer>().materials[0].SetColor("_Color", bodyColor);
		torso.GetComponent<Renderer>().materials[0].SetColor("_Color", bodyColor);
		arms.GetComponent<Renderer>().materials[0].SetColor("_Color", bodyColor);
		hands.GetComponent<Renderer>().materials[0].SetColor("_Color", bodyColor);
		legs.GetComponent<Renderer>().materials[1].SetColor("_Color", bodyColor);
		neck.GetComponent<Renderer>().materials[0].SetColor("_Color", bodyColor);
		//
		// Texture2D headTexture = headTextures[Random.Range(0, headTextures.Length)];
		// head.GetComponent<Renderer>().materials[0].mainTexture = headTexture;
		//
		// Texture2D eyeTexture = eyeTextures[Random.Range(0, eyeTextures.Length)];
		// eyes.GetComponent<Renderer>().material.mainTexture = eyeTexture;
		//
		hairNames = new string[] {
			"EmtyHair", "Hair01", "Hair02", "Hair03", "Hair04", "Hair05", "Hair06", "Hair07", "Hair08", "Hair09", "Hair10",
			"Hair11", "Hair12", "Hair13", "Hair14", "Hair15", "Hair16", "Hair17", "Hair18", "Hair19"
		};
		hairGo = loadGameObject(hairNames[Random.Range(0, hairNames.Length)], "Hair/");
		Color hairColor = hairColors[Random.Range(0, hairColors.Length)];
		hairGo.GetComponent<Renderer>().material.SetColor("_Color", hairColor);
		////////
		helmNames = new string[] {
			"EMPTYarmor", "Helm_Female_1", "Helm_Female_2", "Helm_Female_3", "Helm_Female_4", "Helm_Female_5", "Helm_Female_6", "Helm_Female_7",
			"Helm_Female_8", "Helm_Female_9", "Helm_Female_10", "Helm_Female_11", "Helm_Female_12", "Helm_Female_13", "Helm_Female_14", "Helm_Female_15",
			"Helm_Female_16", "Helm_Female_17", "Helm_Female_18", "Helm_Female_19", "Helm_Female_20", "Helm_Female_21", "Helm_Female_22", "Helm_Female_23"
		};
		chestNames = new string[] {
			"EMPTYarmor", "Vest_Female_1", "Vest_Female_2", "Vest_Female_3", "Vest_Female_4", "Vest_Female_5", "Vest_Female_6", "Vest_Female_7", "Vest_Female_8",
			 "Vest_Female_9", "Vest_Female_10", "Vest_Female_11", "Vest_Female_12", "Vest_Female_13", "Vest_Female_14", "Vest_Female_15"
		};
		chestFullNames = new string[] {
			"EMPTYarmor", "Chest_Female_1", "Chest_Female_2", "Chest_Female_3", "Chest_Female_4", "Chest_Female_5", "Chest_Female_6", "Chest_Female_7",
			"Chest_Female_8", "Chest_Female_9", "Chest_Female_10", "Chest_Female_11", "Chest_Female_12", "Chest_Female_13", "Chest_Female_14", "Chest_Female_15",
			"Chest_Female_16", "Chest_Female_17", "Chest_Female_18"
		};
		shouldNames = new string[] {
			"EMPTYarmor", "Shoulder_Female_1", "Shoulder_Female_2", "Shoulder_Female_3", "Shoulder_Female_4", "Shoulder_Female_5", "Shoulder_Female_6",
			"Shoulder_Female_7", "Shoulder_Female_8", "Shoulder_Female_9", "Shoulder_Female_10", "Shoulder_Female_11", "Shoulder_Female_12", "Shoulder_Female_13",
			"Shoulder_Female_14", "Shoulder_Female_15", "Shoulder_Female_16", "Shoulder_Female_17"
		};
		glovesNames = new string[] {
			"EMPTYarmor", "Gloves_Female_1", "Gloves_Female_2", "Gloves_Female_3", "Gloves_Female_4", "Gloves_Female_5", "Gloves_Female_6", "Gloves_Female_7",
			"Gloves_Female_8", "Gloves_Female_9", "Gloves_Female_10", "Gloves_Female_11", "Gloves_Female_12", "Gloves_Female_13", "Gloves_Female_14", "Gloves_Female_15",
			"Gloves_Female_16"
		};
		pantsNames = new string[] {
			"EMPTYarmor", "Pants_Female_1",  "Pants_Female_2",  "Pants_Female_3",  "Pants_Female_4"
		};
		beltNames = new string[] {
			"EMPTYarmor", "Belt_Female_1", "Belt_Female_2", "Belt_Female_3", "Belt_Female_4", "Belt_Female_5", "Belt_Female_6", "Belt_Female_7", "Belt_Female_8",
			"Belt_Female_9", "Belt_Female_10", "Belt_Female_11", "Belt_Female_12", "Belt_Female_13", "Belt_Female_14", "Belt_Female_15", "Belt_Female_16", "Belt_Female_17"
		};
		bootsNames = new string[] {
			"EMPTYarmor", "Boots_Female_1", "Boots_Female_2", "Boots_Female_3", "Boots_Female_4", "Boots_Female_5", "Boots_Female_6", "Boots_Female_7", "Boots_Female_8",
			"Boots_Female_9", "Boots_Female_10", "Boots_Female_11", "Boots_Female_12", "Boots_Female_13"
		};
		// loadGameObject(helmNames[Random.Range(1, helmNames.Length)],  "Armor/"); hairGo.active = false;
		// loadGameObject(chestNames[Random.Range(1, chestNames.Length)], "Armor/");
		loadGameObject(chestFullNames[Random.Range(1, chestFullNames.Length)], "Armor/"); torso.active = false; neck.active = true;
		loadGameObject(shouldNames[Random.Range(1, shouldNames.Length)], "Armor/");
		loadGameObject(glovesNames[Random.Range(1, glovesNames.Length)], "Armor/"); hands.active = false;
		loadGameObject(pantsNames[Random.Range(1, pantsNames.Length)], "Armor/"); legs.active = false;
		loadGameObject(beltNames[Random.Range(1, beltNames.Length)], "Armor/");
		loadGameObject(bootsNames[Random.Range(1, bootsNames.Length)],"Armor/");
		////////
		// GameObject rNewWeapon = (GameObject)Instantiate(Resources.Load("Weapons/1h_Axe_1"), rightHandPoint.transform.position, rightHandPoint.transform.rotation );
		// rNewWeapon.transform.parent = rightHandPoint.transform;
		// rNewWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
		// GameObject lNewWeapon = (GameObject)Instantiate(Resources.Load("Weapons/Shield_3"), shieldPoint.transform.position, shieldPoint.transform.rotation );
		// lNewWeapon.transform.parent = shieldPoint.transform;
		// lNewWeapon.transform.localScale = new Vector3(1f, 1f, 1f);
		////////
		// Animator animator = gameObject.GetComponent<Animator>();
		// RuntimeAnimatorController rac = Resources.Load("animation/act_character", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
		// animator.runtimeAnimatorController = rac;
		//
		Transform leftHandTf = Gob.findChildInDepth(transform, "Hand_L");
		Transform rightHandTf = Gob.findChildInDepth(transform, "Hand_R");
		GameObject leftWeaponGo = Instantiate(Resources.Load("weapon/Axe/Axe01")) as GameObject;
		leftWeaponGo.transform.SetParent(leftHandTf, false);
		leftWeaponGo.transform.localPosition = new Vector3(-0.113f, 0f, -0.035f);
		leftWeaponGo.transform.localRotation = Quaternion.Euler(-195.1f, -191.84f, -7.8f);
		GameObject rightWeaponGo = Instantiate(Resources.Load("weapon/Axe/Axe01")) as GameObject;
		rightWeaponGo.transform.SetParent(rightHandTf, false);
		rightWeaponGo.transform.localPosition = new Vector3(-0.1041f, 0f, -0.0379f);
		rightWeaponGo.transform.localRotation = Quaternion.Euler(16.4f, -520.1f, 6.6f);
		//
		GameObject leftWeaponFxGo = Instantiate(Resources.Load("weapon_fx/Weapon 01 Hammer/Enchanted 1.01.1 Hammer Buff tier 1")) as GameObject;
		leftWeaponFxGo.transform.parent = leftWeaponGo.transform;
		leftWeaponFxGo.transform.localPosition = new Vector3(0f, 0f, 0f);
		ParticleSystem lfx = leftWeaponFxGo.transform.GetChild(2).GetComponent<ParticleSystem>();
		ParticleSystem.CollisionModule lcm = lfx.collision;
		lcm.collidesWith = Gob.LAYER_MASK_MONSTER;
		// lfx.collision.collidesWith = Gob.LAYER_MASK_MONSTER;
		GameObject rightWeaponFxGo = Instantiate(Resources.Load("weapon_fx/Weapon 01 Hammer/Enchanted 1.02.1 Hammer Fire additive tier 1")) as GameObject;
		rightWeaponFxGo.transform.parent = rightWeaponGo.transform;
		rightWeaponFxGo.transform.localPosition = new Vector3(0f, 0f, 0f);
		ParticleSystem rfx = rightWeaponFxGo.transform.GetChild(2).GetComponent<ParticleSystem>();
		ParticleSystem.CollisionModule rcm = rfx.collision;
		rcm.collidesWith = Gob.LAYER_MASK_MONSTER;
	}

	// Update is called once per frame
	void Update () {
		
	}

	private GameObject loadGameObject(string name, string path) {
		GameObject go = null;
		GameObject temp = Instantiate(Resources.Load(path + name)) as GameObject;
		go = AddSkinObject(temp);
		Destroy(temp);
		return go;
	}

	private GameObject randomStyle(GameObject[] list, string path) {
		GameObject go = null;
		string name = list[Random.Range(1, list.Length)].name;
		GameObject temp = (GameObject) Instantiate(Resources.Load(path + name));
		go = AddSkinObject(temp);
		Destroy(temp);
		return go;
	}

	private GameObject AddSkinObject(GameObject inst) {
		GameObject go = null;
		SkinnedMeshRenderer bonedObject = inst.GetComponentInChildren<SkinnedMeshRenderer>();
		go = ProcessBonedObject( bonedObject );
		// SkinnedMeshRenderer[] BonedObjects = inst.GetComponentsInChildren<SkinnedMeshRenderer>();
		// foreach( SkinnedMeshRenderer smr in BonedObjects ) {
		// 	go = ProcessBonedObject( smr );
		// }
		return go;
	}

	private GameObject ProcessBonedObject(SkinnedMeshRenderer thisRenderer) {
		// Create the SubObject
		GameObject go = new GameObject(thisRenderer.gameObject.name);
		go.transform.parent = transform;
		// Add the renderer
		SkinnedMeshRenderer newRenderer = go.AddComponent<SkinnedMeshRenderer>();
		// Assemble Bone Structure
		Transform[] myBones = new Transform[thisRenderer.bones.Length];
		// As clips are using bones by their names, we find them that way.
		for( int i = 0; i < thisRenderer.bones.Length; i++ ) {
			myBones[i] = Gob.findChildInDepth(transform, thisRenderer.bones[i].name);
		}
		// Assemble Renderer
		newRenderer.bones = myBones;
		newRenderer.sharedMesh = thisRenderer.sharedMesh;
		newRenderer.materials = thisRenderer.materials;
		return go;
	}
}
