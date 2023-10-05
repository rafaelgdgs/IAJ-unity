using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Animator myAnim;
    private Transform target;
    public Transform homePos;
    [SerializeField] private float speed = 3f;
    [SerializeField] private float maxChaseRange = 7f;
    [SerializeField] private float observeRange = 10f;
    [SerializeField] private float minRange = 1f;

    private enum EnemyState
    {
        Idle,
        FollowPlayer,
        ObservePlayer,
        GoHome
    }

    private EnemyState currentState;

    void Start()
    {
        myAnim = GetComponent<Animator>();
        target = FindObjectOfType<PlayerController>().transform;

        currentState = EnemyState.Idle;
    }

    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                if (Vector3.Distance(target.position, transform.position) <= maxChaseRange && Vector3.Distance(target.position, transform.position) >= minRange)
                {
                    currentState = EnemyState.FollowPlayer;
                }
                else if (Vector3.Distance(target.position, transform.position) > maxChaseRange && Vector3.Distance(target.position, transform.position) <= observeRange)
                {
                    currentState = EnemyState.ObservePlayer;
                }
                else if (Vector3.Distance(target.position, transform.position) > observeRange)
                {
                    currentState = EnemyState.GoHome;
                }
                break;

            case EnemyState.FollowPlayer:
                FollowPlayer();
                if (Vector3.Distance(target.position, transform.position) > maxChaseRange)
                {
                    currentState = EnemyState.ObservePlayer;
                }
                break;

            case EnemyState.ObservePlayer:
                if (Vector3.Distance(target.position, transform.position) > observeRange)
                {
                    currentState = EnemyState.GoHome;
                }
                else if (Vector3.Distance(target.position, transform.position) <= maxChaseRange)
                {
                    currentState = EnemyState.FollowPlayer;
                }
                break;

            case EnemyState.GoHome:
                GoHome();
                if (Vector3.Distance(target.position, transform.position) <= maxChaseRange)
                {
                    currentState = EnemyState.FollowPlayer;
                }
                else if (Vector3.Distance(target.position, transform.position) > observeRange)
                {
                    currentState = EnemyState.Idle;
                }
                break;
        }
    }

    private void FollowPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void GoHome()
    {
        transform.position = Vector3.MoveTowards(transform.position, homePos.position, speed * Time.deltaTime);
    }
}


/*using System.Collections;
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
*/