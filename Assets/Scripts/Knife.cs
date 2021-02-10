using UnityEngine;

public class Knife : MonoBehaviour
{
    [SerializeField] private SetText _moneyText;
    [SerializeField] private ScoreText _scoreText;
    private Rigidbody _rigidbody;
    private BoxCollider _boxCollider;
    private bool _isScoreTaken = false;
    private bool _isKnifeInWood = true;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _boxCollider = GetComponent<BoxCollider>();
        SetBoxCollider(true);
        Vibration.Init();
        _moneyText = GameObject.FindWithTag("Money").GetComponent<SetText>();
        _scoreText = GameObject.FindWithTag("Score").GetComponent<ScoreText>();
    }

    private void AddMoney()
    {
        PlayerPrefs.SetInt("money", PlayerPrefs.GetInt("money") + 1);
        _moneyText.UpdateText();
    }

    public void SetBoxCollider(bool box)
    {
        _boxCollider.enabled = box;
    }
    public void Throw()
    {
        _rigidbody.AddForce(Vector3.up * 30, ForceMode.Impulse);
        Debug.Log("throw");                             
    }

    public void EnableGravity()
    {
        _rigidbody.useGravity = true;
    }

    public void EnableRotation()
    {
        _rigidbody.freezeRotation = false;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
    }

    public void KnifeInWood()
    {
        _isKnifeInWood = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wood") && _isScoreTaken == false)
        {
            gameObject.transform.SetParent(collision.transform);
            var temp = collision.gameObject.GetComponentInParent<Wood>();
            if (!_isKnifeInWood)
            {
                Vibration.Vibrate(100);
                temp.MinusScore();
                _rigidbody.isKinematic = true;
                _isScoreTaken = true;
                ScoreAndStage.AddScore(1);
                _scoreText.UpdateText();
                AddMoney();
            }
            
        }
        if(collision.gameObject.CompareTag("Knife") && _isScoreTaken == false)
        {
            ScoreAndStage.CheckRecords();
            ScoreAndStage.Reset();
            Vibration.Vibrate();
            GameState.GameOver();
            GameState.GameFreeze(true);
            var menu = FindObjectOfType<Wood>();
            menu.Menu.SetActive(true);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Apple"))
        {
            AddMoney();
            ScoreAndStage.AddScore(1);
            Destroy(other.gameObject);
        }
    }
}
