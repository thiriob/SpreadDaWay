using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QueenController : MonoBehaviour
{

    public float Life;
    float LifeMax = 100f;

    public SceneLoader Map;
    public Image LifeBar;
    float _sizeMapDiv2X;
    float _sizeMapDiv2Y;
    public float Speed = 2.0f;
    public Vector2 MovementVector;
    public float soundTimer = 3f;
    public AudioClip[] audios;
    private AudioSource audio;
    private Animator _anim;

    void Start()
    {
        _sizeMapDiv2X = Map.Size.x / 2.0f;
        _sizeMapDiv2Y = Map.Size.y / 2.0f;
        _anim = GetComponent<Animator>();
        Life = LifeMax;
        audio = GetComponent<AudioSource>();
    }

    void playRandomAudio()
    {
        audio.PlayOneShot(audios[Random.Range(0, audios.Length)]);
    }

    void Update()
    {
        if (Life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
        /*else if (Life < LifeMax)
            Life += Time.deltaTime;*/
        if (soundTimer > 0f)
            soundTimer -= Time.deltaTime;
        else
        {
            soundTimer += Random.Range(1f, 4f);
            playRandomAudio();
        }
        LifeBar.fillAmount = Life / LifeMax;
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("mob"))
        {
            Life -= Time.deltaTime * 25;
        }
    }

    void FixedUpdate()
    {
        MovementVector = Vector2.zero;

        MovementVector += Vector2.right * Input.GetAxisRaw("Horizontal");
        MovementVector += Vector2.up * Input.GetAxisRaw("Vertical");
        if (MovementVector.x == 0 || MovementVector.y == 0)
            MovementVector *= 1.41f;
        MovementVector *= Speed * Time.deltaTime;
        float queenXPos = transform.position.x + MovementVector.x;
        float queenYPos = transform.position.y + MovementVector.y;
        if (queenXPos > Map.Center.x + _sizeMapDiv2X || queenXPos < Map.Center.x - _sizeMapDiv2X)
        {
            MovementVector.x = 0;
        }
        if (queenYPos > Map.Center.y + _sizeMapDiv2Y || queenYPos < Map.Center.y - _sizeMapDiv2Y)
        {
            MovementVector.y = 0;
        }
        transform.Translate(MovementVector);

        /* Mouse related movements */
        var renderer = GetComponent<SpriteRenderer>();
        if (MovementVector.x > 0) renderer.flipX = true;
        if (MovementVector.x < 0) renderer.flipX = false;
        _anim.SetInteger("moving", (int)((MovementVector.x + MovementVector.y) * 1000));
    }
}
