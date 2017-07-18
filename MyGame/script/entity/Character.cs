using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Character : General {
	private GameObject pathGo;
	private int curNodeIdx = 0;
	private Transform curNodeTf;
	private int incIdx = 1;
	private LinkedList<Transform> rangeTargets = new LinkedList<Transform>();
	private MonsterGroup enemyGroup = null;
	private Transform cloestEnemy = null;

	// Use this for initialization
	void Start () {
		maxHp = 500;
		hp = maxHp;
		pathGo = GameObject.Find("Path");
		curNodeTf = pathGo.transform.GetChild(curNodeIdx);
		//
		init();
	}

	protected override void processCombatIdle() {
		if ( target != null ) {
			Animator animator = GetComponent<Animator>();
			animator.SetInteger("attackType", Random.Range(1, 3));
			setAnimatorState(STATE_ATTACK);
			setState(STATE_ATTACK);
		}
		else {
			if (rangeTargets.Count > 0) {
				target = rangeTargets.First.Value;
			}
			else {
				if (enemyGroup != null) {
					cloestEnemy = enemyGroup.getCloestAlive(transform.position);
				}
				setAnimatorState(STATE_MOVE);
			}
		}
	}

	protected override void processMove() {
		if (cloestEnemy == null) {
			moveToPoint();
		}
		else {
			moveToCloest();
		}
	}

	protected override void processDie() {

	}

	void OnTriggerEnter(Collider collider) {
		if (collider.gameObject.layer == Gob.LAYER_MONSTER) {
			if (target == null) {
				setTarget(collider.transform);
				setAnimatorState(STATE_ATTACK);
				setState(STATE_ATTACK);
			}
			rangeTargets.AddLast(collider.transform);
		}
	}

	void OnTriggerExit(Collider collider) {
		if (collider.gameObject.layer == Gob.LAYER_MONSTER) {
			rangeTargets.Remove(collider.transform);
			if (target == collider.transform) {
				target = null;
			}
		}
	}

	protected override void targetDie() {
		rangeTargets.Remove(target);
		setAnimatorState(STATE_COMBAT_IDLE);
		setState(STATE_COMBAT_IDLE);
	}

	private void moveToPoint() {
		Rigidbody rb = GetComponent<Rigidbody>();
		Vector3 moveSpeed = rb.rotation * Vector3.forward * 2 * Time.fixedDeltaTime;
		rb.position += moveSpeed;
		rb.rotation = rotateYToPoint(rb.position, curNodeTf.position);
		//
		if (calcDist2D(rb.position, curNodeTf.position) < 0.1f) {
			if (curNodeIdx >= pathGo.transform.childCount - 1) {
				incIdx = -1;
			}
			else if (curNodeIdx <= 0) {
				incIdx = 1;
			}
			curNodeIdx += incIdx;
			Transform tempTf = curNodeTf;
			curNodeTf = pathGo.transform.GetChild(curNodeIdx);
			AttachCamera attachCamera = Camera.main.GetComponent<AttachCamera>();
			attachCamera.setDir(tempTf.position, curNodeTf.position);
		}
	}

	private void moveToCloest() {
		Rigidbody rb = GetComponent<Rigidbody>();
		Vector3 moveSpeed = rb.rotation * Vector3.forward * 2 * Time.fixedDeltaTime;
		rb.position += moveSpeed;
		rb.rotation = rotateYToPoint(rb.position, cloestEnemy.position);
	}

	// void OnCollisionEnter(Collision collision) {
	// 	Debug.LogError("OnCollisionEnter");
	// }

	public override void init() {
		gameObject.layer = Gob.LAYER_CHARACTER;
		Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
		rigidbody.angularDrag = 0f;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		//
		GameObject childGo = transform.GetChild(0).gameObject;
		childGo.layer = Gob.LAYER_CHARACTER_WEAPON;
		SphereCollider weaponCollider = childGo.AddComponent<SphereCollider>();
		weaponCollider.center = new Vector3(0, 0, 0);
		weaponCollider.radius = 1f;
		weaponCollider.isTrigger = true;
		//
		// Animator animator = gameObject.GetComponent<Animator>();
		// RuntimeAnimatorController rac = Resources.Load("act_character", typeof(RuntimeAnimatorController)) as RuntimeAnimatorController;
		// animator.runtimeAnimatorController = rac;
		//
		base.init();
	}

	public void setEnemyGroup(MonsterGroup value) {
		enemyGroup = value;
	}
}




