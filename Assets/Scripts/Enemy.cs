using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour {

	[SerializeField] float moveSpeed = 1f;
	[SerializeField] int enemyDamage = 1;
	[SerializeField] PlayerController character;

	[SerializeField] List<Transform> waypoints;
	[SerializeField] int waypointIndex = 0;

	private EnemyHead enemyHead;
	private BoxCollider2D headCollider2D;

	private void Start() {
		transform.position = waypoints[waypointIndex].transform.position;
        enemyHead = FindObjectOfType<EnemyHead>();
        headCollider2D = enemyHead.GetComponent<BoxCollider2D>();
    }

	// Update is called once per frame
	void Update () {

		MoveEnemy();
	}

	private void MoveEnemy() {
		if (waypointIndex <= waypoints.Count - 1) {
			var targetPosition = waypoints[waypointIndex].transform.position;
			var moveFrame = moveSpeed * Time.deltaTime;
			transform.position = Vector2.MoveTowards(
				transform.position,
				targetPosition,
				moveFrame);

			if (transform.position == targetPosition) {
				waypointIndex++;
			}
		} else {
			Destroy(gameObject);
		}
	}

	/// <summary>
	/// function to destroy the object after leave the player scenario
	/// </summary>
	/// <param name="collision"></param>
	private void OnTriggerEnter2D(Collider2D collision) {

		if (collision.gameObject.layer == 13) {

			Destroy(gameObject);

		  /* If has impact on player, disable the head collider to avoid 
		   * kill enemy from bottom to top when hits the head collider */		
		} if (collision.gameObject.layer == 8) {
			
			character.HitCharacter(1);

			var life = FindObjectOfType<Life>();
			if (life.GetLife() < enemyDamage) {
				var sceneController = FindObjectOfType<SceneController>();
				sceneController.GameOver();
			}
		}
	}
}
