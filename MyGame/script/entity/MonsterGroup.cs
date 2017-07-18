using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterGroup : MonoBehaviour {
	public GameObject[] perfabs;
	private bool isGen = false;
	private LinkedList<Monster> monsters;

	// Use this for initialization
	void Start () {
		SphereCollider collider = gameObject.AddComponent<SphereCollider>();
		collider.radius = 15f;
		collider.isTrigger = true;
		monsters = new LinkedList<Monster>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void genMonster(Transform characterTf) {
		int size = perfabs.Length;
		for (int i=0; i<size; ++i) {
			GameObject monsterGo = Instantiate(perfabs[i]) as GameObject;
			Monster monster = monsterGo.AddComponent<Monster>();
			monster.init();
			monster.setTarget(characterTf);
			Rigidbody rb = monsterGo.GetComponent<Rigidbody>();
			rb.position = transform.position + new Vector3(i*3, 0, 0);
			monsters.AddLast(monster);
		}
	}

	public Transform getCloestAlive(Vector3 pos) {
		float minDist = float.MaxValue;
		Transform cloestMonster = null;
		foreach (Monster monster in monsters) {
			if (monster.isDead()) {
				continue;
			}
			float dist = Gob.calcDist2D(pos, monster.transform.position);
			if (minDist > dist) {
				minDist = dist;
				cloestMonster = monster.transform;
			}
		}
		return cloestMonster;
	}

	void OnTriggerEnter(Collider collider) {
		if ( ! isGen ) {
			Character character = collider.GetComponent<Character>();
			character.setEnemyGroup(this);
			genMonster(collider.transform);
			isGen = true;
		}
	}
}
