using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour {
    [SerializeField] private Transform SpawnPoint;
    [SerializeField] private GameObject MovementText;
    [SerializeField] private GameObject AttackText;
    [SerializeField] private GameObject WeaponText;
    [SerializeField] private GameObject HealthText;
    [SerializeField] private GameObject CounterText;
    [SerializeField] private GameObject MarketText;
    [SerializeField] private GameObject EnemyText;
    [SerializeField] private GameObject FinishText;

    [SerializeField] private GameObject Icon;
    [SerializeField] private GameObject Health;
    [SerializeField] private GameObject Counters;
    [SerializeField] private GameObject Market;
    [SerializeField] private GameObject EnemyPrefab;
    [SerializeField] private Transform EnemyPosition;

    private Transform PlayerPosition;
    private PlayerHealth PlayerHealth;
    private GameObject Enemy;
    private Animator _animatorText;
    private Animator _animatorPanel;
    private float WaitCompleteTime = 0.5f;
    private void Start() {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        PlayerPosition = Player.transform;
        PlayerHealth = Player.GetComponent<PlayerHealth>();
        Money.MoneyAmount = 3;
        Money.UpdateUI();
        StartCoroutine(nameof(CompleteMovement));
    }

    private IEnumerator CompleteMovement() {
        if (!(Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.UpArrow))) {
            yield return new WaitForEndOfFrame();
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
            yield return new WaitForEndOfFrame();
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
        if (!(Input.GetKey(KeyCode.Alpha1) || Input.GetKey(KeyCode.Alpha2) || Input.GetKey(KeyCode.Alpha3) || Input.GetKey(KeyCode.Alpha4) || Input.GetKey(KeyCode.Alpha5))) {
            yield return new WaitForEndOfFrame();
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
        MarketText.SetActive(true);

        StopCoroutine(nameof(CompleteHealth));
        StartCoroutine(nameof(DoAnimation), Market);
        StartCoroutine(nameof(CompleteMarket));
    }

    private IEnumerator CompleteMarket() {
        if (Money.MoneyAmount == 3) {
            yield return new WaitForEndOfFrame();
            StopCoroutine(nameof(CompleteMarket));
            StartCoroutine(nameof(CompleteMarket));
        }

        yield return new WaitForSeconds(WaitCompleteTime);

        _animatorText = MarketText.GetComponent<Animator>();
        _animatorText.SetBool("IsComplete", true);
        yield return new WaitForSeconds(1.05f);

        _animatorPanel = Market.GetComponent<Animator>();
        _animatorPanel.SetBool("IsStarting", false);

        MarketText.SetActive(false);
        EnemyText.SetActive(true);
        Enemy = Instantiate(EnemyPrefab, EnemyPosition);

        StopCoroutine(nameof(CompleteMarket));
        StartCoroutine(nameof(CompleteKilling));
    }

    public void TurnOnSlot(GameObject button) {
        Money.MoneyAmount -= int.Parse(button.GetComponentInChildren<Text>().text);
        Money.UpdateUI();
        button.SetActive(false);
    }

    private IEnumerator CompleteKilling() {
        if (Enemy != null) {
            PlayerHealth.LivesAmount = PlayerHealth.LivesAmount <= 0 ? 3 : PlayerHealth.LivesAmount;

            yield return new WaitForEndOfFrame();
            StopCoroutine(nameof(CompleteKilling));
            StartCoroutine(nameof(CompleteKilling));
        }

        yield return new WaitForSeconds(WaitCompleteTime);

        _animatorText = EnemyText.GetComponent<Animator>();
        _animatorText.SetBool("IsComplete", true);
        yield return new WaitForSeconds(1.05f);

        EnemyText.SetActive(false);
        FinishText.SetActive(true);

        StopCoroutine(nameof(CompleteKilling));
        StartCoroutine(nameof(CompleteTutorial));
    }

    private IEnumerator CompleteTutorial() {
        yield return new WaitForSeconds(1f);

        _animatorText = FinishText.GetComponent<Animator>();
        _animatorText.SetBool("IsComplete", true);
        yield return new WaitForSeconds(1.05f);

        StopCoroutine(nameof(CompleteTutorial));
        SceneManager.LoadScene("Arena");
    }
}