using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

namespace RPG.Units.Player
{
    public class PlayerController : MonoBehaviour
    {
        private StatsAssistant _stats;
        private PlayerControls _controls;
        private Rigidbody _rigidbody;


        private void Awake()
        {
            _controls = new PlayerControls();
            _controls.GameMap.FastAttack.performed += OnFastAttack;
            _controls.GameMap.StrongAttack.performed += OnStrongAttack;
        }

        private void OnEnable()
        {
            _controls.Enable();
        }

        private void Update()
        {
            OnMovement();
        }

        private void OnDisable()
        {
            _controls.Disable();
        }

        private void OnDestroy()
        {
            _controls.Dispose();
        }

        private void OnFastAttack(CallbackContext context)
        {
            // TODO:
            Debug.Log("OnFastAttack");
        }

        private void OnStrongAttack(CallbackContext context)
        {
            // TODO:
            Debug.Log("OnStrongAttack");
        }

        private void OnMovement()
        {
            var direction = _controls.GameMap.Movement.ReadValue<Vector2>();

            var velocity = new Vector3(direction.x, 0, direction.y);
            transform.position += velocity * _stats.GetSpeed() * Time.deltaTime;
        }
    }
}
