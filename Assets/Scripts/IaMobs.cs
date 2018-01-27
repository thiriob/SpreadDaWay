using System;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class IaMobs : MonoBehaviour
{
    public Transform Queen;
    public Vector2 Speed = new Vector2(1, 4);
    public Vector2 SpeedInterval = new Vector2(1, 10);
    public float DirectionInterval = 2;
    public float Tolerance = 0.1f;
    public float Venere = 50;

    public float LifeMax = 500f;
    public float Life;

    public GameObject NamePrefab;
    private Vector3 _nameOffset = new Vector3(0, 0.2f, 0);

    private Vector2 _tmpTarg = Vector2.zero;
    private Vector2 _x;
    private Vector2 _y;
    private float _speed = 0;
    private SceneLoader _loader;
    private GameObject _name;
    private bool _attack = false;

    void ChangeSpeed()
    {
        _speed = Random.Range(Speed.x, Speed.y);
        Invoke("ChangeSpeed", Random.Range(SpeedInterval.x, SpeedInterval.y));
    }

    void ChangeDirection()
    {
        if (_attack)
            return;
        if (Random.Range(0, 100) <= Venere)
        {
            _tmpTarg = new Vector2(Queen.position.x, Queen.position.y);
            _speed = Speed.y;
            _attack = true;
        }
        else
            _tmpTarg = new Vector2(Random.Range(_x.x, _x.y), Random.Range(_y.x, _y.y));
    }

    void Start()
    {
        transform.localScale = new Vector3(0.1f + Life / 4000, 0.1f + Life / 4000);
        Queen = GameObject.Find("Queen").transform;
        _loader = GameObject.Find("loader").GetComponent<SceneLoader>();
        _x = new Vector2(_loader.Center.x - (_loader.Size.x / 2), _loader.Center.x + (_loader.Size.x / 2) + 1);
        _y = new Vector2(_loader.Center.y - (_loader.Size.y / 2), _loader.Center.y + (_loader.Size.y / 2) + 1);
        ChangeSpeed();
        InvokeRepeating("ChangeDirection", 0, DirectionInterval);
        _name = Instantiate(NamePrefab, GameObject.Find("NAMECONTAINER").transform);
        _name.name = name;
        _name.GetComponent<Text>().text = name;
        _nameOffset = new Vector3(0, 0.2f + Life / 2000, 0);

        Life = LifeMax;
    }

    void Update()
    {
        _name.transform.position = transform.position + _nameOffset;
        if (Math.Abs(transform.position.x - _tmpTarg.x) > Tolerance || Math.Abs(transform.position.y - _tmpTarg.y) > Tolerance)
            transform.position = Vector2.MoveTowards(transform.position, _tmpTarg, _speed * Time.deltaTime);
        else
        {
            _attack = false;
            ChangeDirection();
        }

        if (Life <= 0)
        {
            GameObject.Find("ugandaManager").GetComponent<ugandaManager>().SendMessage("SpawnUganda", transform.position);
            Destroy(this.gameObject);
        }
        else if (Life < LifeMax)
        {
            Life += 10 * Time.deltaTime;
        }
    }

    void OnDestroy()
    {
        Destroy(_name);
    }

    void OnCollisionStay2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("uganda"))
            Life--;
        //Life -= coll.gameObject.SendMessage("AskDamage");
    }
}
