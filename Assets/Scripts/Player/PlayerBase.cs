using UnityEngine;

[RequireComponent(typeof(PlayerInputReader))]
[RequireComponent(typeof(PlayerSurfaceChecker))]
[RequireComponent(typeof(PlayerMover))]
[RequireComponent(typeof(PlayerJumper))]
[RequireComponent(typeof(PlayerAnimationsController))]
[RequireComponent(typeof(PlayerCollisionDetector))]
[RequireComponent(typeof(PlayerCombat))]
[RequireComponent(typeof(PlayerHealth))]
[RequireComponent(typeof(PlayerBag))]
public class PlayerBase : MonoBehaviour
{

}