using System.Collections;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject MovementText;
    [SerializeField] private GameObject AttackText;
    [SerializeField] private GameObject WeaponText;
    [SerializeField] private GameObject HealthText;
    [SerializeField] private GameObject CounterText;
    [SerializeField] private GameObject MarketText;

    [SerializeField] private GameObject Icon;
    [SerializeField] private GameObject Health;
    [SerializeField] private GameObject Counters;
    [SerializeField] private GameObject Market;

    private Transform PlayerPosition;
    private Animator _animatorText;
    private Animator _animatorPanel;
    private float WaitCompleteTime = 0.5f;
    private void Start() {
        PlayerPosition = GameObject.FindGameObjectWithTag("Player").transform;
        StartCoroutine(nameof(CompleteMovement));
    }

    private IEnumerator CompleteMovement() {
        if (!(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))) {
            yield return new WaitForSeconds(0.014f);
            StopCoroutine(nameof(CompleteMovement));
            StartCoroutine(nameof(CompleteMovement));
        }

        yield return new WaitForSeconds(WaitCompleteTime);

        _animatorText = MovementText.GetComponent<Animator>();
        _animatorText.SetBool("IsComplete", true);
        yield return new WaitForSeconds(1.05f);

        MovementText.SetActive(false);
        AttackText.SetActive(true);

        StopCoroutine(nameof(CompleteMovement));
        StartCoroutine(nameof(CompleteAttack));
    }

    private IEnumerator CompleteAttack() {
        if (!Input.GetKey(KeyCode.W)) {
            yield return new WaitForSeconds(0.014f);
            StopCoroutine(nameof(CompleteAttack));
            StartCoroutine(nameof(CompleteAttack));
        }

        yield return new WaitForSeconds(WaitCompleteTime);

        _animatorText = AttackText.GetComponent<Animator>();
        _animatorText.SetBool("IsComplete", true);
        yield return new WaitForSeconds(1.05f);

        AttackText.SetActive(false);
        WeaponText.SetActive(true);

        StopCoroutine(nameof(CompleteAttack));
        StartCoroutine(nameof(CompleteWeapon));
    }

    private IEnumerator CompleteWeapon() {
        StartCoroutine(nameof(DoAnimation), Icon);
        if (!(Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Alpha3) || Input.GetKeyDown(KeyCode.Alpha4) || Input.GetKeyDown(KeyCode.Alpha5))) {
            yield return new WaitForSeconds(0.014f);
            StopCoroutine(nameof(CompleteWeapon));
            StartCoroutine(nameof(CompleteWeapon));
        }

        yield return new WaitForSeconds(WaitCompleteTime);

        _animatorText = WeaponText.GetComponent<Animator>();
        _animatorText.SetBool("IsComplete", true);
        yield return new WaitForSeconds(1.05f);

        WeaponText.SetActive(false);
        HealthText.SetActive(true);

        StopCoroutine(nameof(CompleteWeapon));
        StartCoroutine(nameof(CompleteHealth));
    }

    private IEnumerator DoAnimation(GameObject panel) {
        _animatorPanel = panel.GetComponent<Animator>();
        _animatorPanel.SetBool("IsStarting", true);
        yield return new WaitForSeconds(0.67f);
        StopCoroutine(nameof(DoAnimation));
    }

    private IEnumerator CompleteHealth() {
        StartCoroutine(nameof(DoAnimation), Health);

        yield return new WaitForSeconds(8f);

        _animatorText = HealthText.GetComponent<Animator>();
        _animatorText.SetBool("IsComplete", true);
        yield return new WaitForSeconds(1.05f);

        HealthText.SetActive(false);
        CounterText.SetActive(true);

        StopCoroutine(nameof(CompleteHealth));
        StartCoroutine(nameof(CompleteCounters));
    }

    private IEnumerator CompleteCounters() {
        StartCoroutine(nameof(DoAnimation), Counters);

        yield return new WaitForSeconds(10f);

        _animatorText = CounterText.GetComponent<Animator>();
        _animatorText.SetBool("IsComplete", true);
        yield return new WaitForSeconds(1.05f);

        CounterText.SetActive(false);

        StopCoroutine(nameof(CompleteHealth));
        //StartCoroutine(nameof());
    }
}