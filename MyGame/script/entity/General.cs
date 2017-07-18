using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class General : MonoBehaviour {
	public const int STATE_NONE = 0;
	public const int STATE_COMBAT_IDLE = 1; // 战斗待机
	public const int STATE_MOVE = 2;
	public const int STATE_ATTACK = 3;
	public const int STATE_HIT = 4;
	public const int STATE_DIE = 5;
	public const int STATE_CASUAL_IDLE = 6; // 普通待机
	public int state = 0;
	protected Transform target = null;
	protected int maxHp = 20;
	public int hp = 20;
	protected int atk = 5;
	protected Transform hpBarTf;
	protected int hpHideCount = 0;
	public const int HP_HIDE_FRAME = 150;
	
	// Update is called once per frame
	void Update () {
		if (isDead()) {
			return;
		}
		if (hpHideCount > 0) {
			--hpHideCount;
			if (hpHideCount <= 0) {
				hpBarTf.gameObject.SetActive(false);
			}
		}
		Vector3 hpPoint = transform.position;
		hpPoint.y += 2.3f;
		Vector3 screenPos = Camera.main.WorldToScreenPoint(hpPoint);
		hpBarTf.transform.position = screenPos;
		HpBar hpBar = hpBarTf.GetComponent<HpBar>();
		hpBar.setRate((float)hp / maxHp);
	}

	void FixedUpdate () {
		if (isDead()) {
			return;
		}
		if (target != null) {
			General general = target.GetComponent<General>();
			if (general.isDead()) {
				targetDie();
				target = null;
			}
		}
		switch (state) {
			case STATE_COMBAT_IDLE:
				processCombatIdle();
				break;
			case STATE_MOVE:
				processMove();
				break;
			case STATE_DIE:
				// processDie();
				break;
		}
	}

	protected virtual void processCombatIdle() {
	}

	protected virtual void processMove() {
	}

	protected virtual void processDie() {
	}

	protected virtual void targetDie() {
	}

	public virtual void init() {
		setState(STATE_COMBAT_IDLE);
		//
		GameObject hpBarGo = Instantiate(Resources.Load("ui/hp_bar", typeof(GameObject))) as GameObject;
		GameObject canvasGo = GameObject.Find("Canvas");
		Transform hpContainerTf = Gob.findChildInWide(canvasGo.transform, "hp_container");
		hpBarTf = hpBarGo.transform;
		hpBarTf.SetParent(hpContainerTf, false);
		hpBarTf.gameObject.SetActive(false);
	}

	public void setDieCyc() {
		gameObject.layer = Gob.LAYER_GENERAL_DIE;
		// transform.GetChild(0).GetComponent<SphereCollider>().enabled = false;
		// GameObject.Destroy(hpBarTf.gameObject);
		hpBarTf.gameObject.SetActive(false);
		// GetComponent<BoxCollider>().enabled = false;
	}

	protected Quaternion rotateYToPoint(Vector3 originPos, Vector3 targetPos) {
		Vector3 targetDir = targetPos - originPos;
		targetDir.y = 0f;
		float angle = Vector3.Angle(targetDir, Vector3.forward);
		Vector3 crossValue = Vector3.Cross(targetDir, Vector3.forward);
		if (crossValue.y > 0) {
			angle = -angle;
		}
		return Quaternion.Euler(0, angle, 0);
	}

	protected float calcDist2D(Vector3 curPos, Vector3 targetPos) {
		curPos.y = 0f;
		targetPos.y = 0f;
		return Vector3.Distance(curPos, targetPos);
	}

	public void setAnimatorState(int value) {
		Animator animator = GetComponent<Animator>();
		animator.SetInteger("state", value);
	}

	public void setState(int value) {
		if (state == STATE_DIE) {
			return;
		}
		state = value;
	}

	public void setTarget(Transform value) {
		target = value;
	}

	public void hitTarget() {
		if (target != null) {
			General general = target.GetComponent<General>();
			general.behit(atk);
		}
	}

	public void behit(int damage) {
		if (hp <= 0) {
			return;
		}
		if (hpHideCount <= 0) {
			hpBarTf.gameObject.SetActive(true);
		}
		hpHideCount = HP_HIDE_FRAME;
		if (hp > damage) {
			hp -= damage;
			// setAnimatorState(STATE_HIT);
			// setState(STATE_HIT);
		}
		else {
			hp = 0;
			setAnimatorState(STATE_DIE);
			setState(STATE_DIE);
		}
	}

	public bool isDead() {
		return hp <= 0;
	}

	public bool hasTarget() {
		return target != null;
	}
}
