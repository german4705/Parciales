using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour,IDamageable
{

    Controller _controller;
    Movement _movement;
    Jump _jump;
    Reload _reload;

    //transform del checkpoint
    [SerializeField]
    Transform checkPointSaver;

    [SerializeField] float _speed;
    [SerializeField] float _force;


    [SerializeField] Animator _playerAnimator;


    [SerializeField]
    public float healt;
    [SerializeField]
    private float maxHealt;


    [SerializeField]
    private Image HealtBar;


    private void Awake()
    {
        healt = maxHealt;
    }

    void Start()
    {
        _playerAnimator = GetComponent<Animator>();

        _movement = new Movement(transform, _speed,GetComponent<Rigidbody>(),_force,this,_playerAnimator);

        _controller = new Controller(_movement);

        
        
    }

    
    void Update()
    {
        _controller.ArtificialUpDate(); // Llamo constantemente a la funcion para que sea como un update en controller.

        if(Input.GetKeyDown(KeyCode.L))
        {
            
            healt--;
            HealtBarManager();
        }

      
    }

    public void HealtBarManager()
    {
        HealtBar.fillAmount = healt / maxHealt;
    }
    public struct Memento
    {
        private float currentHealt;
        private Transform checkpointPosition;

        public Memento(Player player, Transform checkpoint)
        {
            currentHealt = player.healt;
            checkpointPosition = player.checkPointSaver;
        }

        public void Set(Player player)
        {
            player.healt = currentHealt;
            player.transform.position = checkpointPosition.position;
        }



    }

    public Memento CreateMemento()
    {
        return new Memento(this, checkPointSaver);
    }

    public void RestoreMemento(Memento Memento)
    {
        Memento.Set(this);
    }

    public void GetDamage()
    {
        healt--;
        HealtBarManager();
    }
}


