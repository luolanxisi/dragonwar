using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : General {
	private Vector3 originPos;
	private float atkRange = 2f;

	// Use this for initialization
	void Start () {

	}

	protected override void processCombatIdle() {
		if (target != null) {
			if (targetInRange()) {
				Animator animator = GetComponent<Animator>();
				animator.SetInteger("attackType", Random.Range(1, 3));
				setAnimatorState(STATE_ATTACK);
				setState(STATE_ATTACK);
			}
			else {
				setAnimatorState(STATE_MOVE);
			}
		}
		else {
			setAnimatorState(STATE_COMBAT_IDLE);
		}
	}

	protected override void processMove() {
		if (target != null) {
			Rigidbody rb = GetComponent<Rigidbody>();
			Vector3 moveSpeed = rb.rotation * Vector3.forward * 2 * Time.fixedDeltaTime;
			rb.position += moveSpeed;
			rb.rotation = rotateYToPoint(rb.position, target.position);
			if ( targetInRange() ) {
				Animator animator = GetComponent<Animator>();
				animator.SetInteger("attackType", Random.Range(1, 3));
				setAnimatorState(STATE_ATTACK);
				setState(STATE_ATTACK);
			}
		}
	}

	protected override void processDie() {
	}

	public override void init() {
		gameObject.layer = Gob.LAYER_MONSTER;
		Rigidbody rigidbody = gameObject.AddComponent<Rigidbody>();
		rigidbody.angularDrag = 0f;
		rigidbody.constraints = RigidbodyConstraints.FreezeRotation;
		//
		base.init();
	}

	public bool targetInRange() {
		Rigidbody rb = GetComponent<Rigidbody>();
		float dist = calcDist2D(rb.position, target.position);
		if (dist < atkRange) {
			return true;
		}
		return false;
	}
}
