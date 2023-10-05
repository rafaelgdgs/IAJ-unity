using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField]
    private float speed = 3f;
    [SerializeField]
    private float maxRange = 7f;
    [SerializeField]
    private float minRange = 1f;

    // Start is called before the first frame update
    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(target.position, transform.position) <= maxRange && Vector3.Distance(target.position, transform.position) >= minRange) {
            FollowPlayer();
        }
        else if (Vector3.Distance(target.position, transform.position) > maxRange) {
            GoHome();
        }
    }

    public void FollowPlayer() {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    public void GoHome() {
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
    }
}
