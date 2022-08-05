using Assets.Scripts;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable
{
    private OldMan _oldMan;

    [SerializeField] private Transform BulletStartPosition;

    public Health Health;
    public Armour Armour;
    public Money Money;
    public IController Controller;
    public IInterfaceManager InterfaceManager;
    public IItemManager ItemManager;

    private ManagerWindow _managerWindow;
    private ITakeDamage _damage;
    private ILookAround _lookAround;
    private IMovement _movement;
    private IGunsList _gunsList;

    public GameObject _camera;
    public Restart Restart;
    private Riffle _riffle;
    private AudioSource _audioSource;
    public Animate _animate;
    private PlayerAttack _playerAttack;
    private CounterItems _counterItems;
    private CharacterController _characterController;

    public CurePlayer _curePlayer;
    public bool IsAlive { get; private set; } = true;
    public bool key = false;
    public bool Acting = false;
    public float Speed = 10;
    private float Sensevity = 9;

    public Transform enemy;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _animate = GetComponent<Animate>();
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Start()
    {
        Initialeze();
    }

    private void Initialeze()
    {
        Camera camera = GetComponentInChildren<Camera>();
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        _characterController = GetComponent<CharacterController>();

        _counterItems = new CounterItems();
        Health = new Health(100f,25f);
        Armour = new Armour(100f, 100f);
        Money = new Money();
        _riffle = GetComponentInChildren<Riffle>();
        _riffle.SetStartPositionAndCenterScreen(BulletStartPosition);
        _damage = new Damage(Health, Armour);
        Controller = new Controller(); 
        _lookAround = new LookAround(camera, rigidbody, Sensevity, this);
        _movement = new Movement(Controller, Speed, this, _characterController, _lookAround, _animate);
        _gunsList = new GunsList(Controller, _riffle);
        InterfaceManager = new InterfaceManager(Health, Armour, (GunsList)_gunsList, Money, _counterItems);
        ItemManager = new ItemManager(Health, Armour, (GunsList)_gunsList,
            new PropertyOfRampage(Health, Armour, (GunsList)_gunsList, (Movement)_movement), Money,
                FindObjectOfType<TriggerBase>(), _counterItems);
        _oldMan = new OldMan(_damage, _movement, _gunsList, _managerWindow);
        _playerAttack = FindObjectOfType<PlayerAttack>();
        _curePlayer = new CurePlayer(Health, Armour, _animate);
    }

    void Update()
    {
        if (IsAlive)
        {
            _oldMan.Fire(_playerAttack.GetNearEnemy(), 
                _playerAttack.AttackOrNot());
            _oldMan.LookAround();
            _oldMan.Move();
/*            _soldier.Reloading();*/
/*            _soldier.Paused();*/
        }
    }

    public void KeyUp()
    {
        key = true;
    }

    public void MakeDamage(float damage)
    {
        _oldMan.TakeDamage(damage);
        IsAlive = _damage.CheckLiveStatus();
        DeathOrLive();
    }

    private void DeathOrLive()
    {
        if (!IsAlive)
        {
            _animate.SetAnimationDeath(IsAlive); 
            gameObject.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Restart.gameObject.SetActive(true);   
        }
    }
}


