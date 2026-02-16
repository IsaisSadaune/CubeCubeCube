using DG.Tweening;
using System.Collections;
using UnityEditor.Timeline;
using UnityEngine;

public class Cucube_Deplacement : MonoBehaviour
{
    [SerializeField] private int numberOfMovesBeforeDeath = 5;
    [SerializeField] private float TimeBetweenMoves = 0.2f;
    [SerializeField] private float TimeToMove = 0.2f;
    [SerializeField] private float TimeToDie = 1f;
    private Rigidbody rb => GetComponent<Rigidbody>();

    private void Awake()
    {
        Physics.IgnoreCollision(
            gameObject.GetComponent<Collider>(), 
            Proto_GameManager.GameManager.player.gameObject.GetComponent<Collider>(), 
            true);
    }

    public IEnumerator StartMovement()
    {
        rb.isKinematic = true;

        for (int i = 0; i < numberOfMovesBeforeDeath; i++)
        {
            yield return new WaitForSeconds(TimeBetweenMoves);

            Vector3 direction = GetClosestOrthogonalDirection(transform, Proto_GameManager.GameManager.player.transform.position);
            Vector3 targetPos = transform.position + direction;

            // Calculer la rotation en espace monde
            Quaternion worldRotation = GetDiceRollRotation(direction);

            // Créer les tweens
            Tween moveTween = transform.DOMove(targetPos, TimeToMove).SetEase(Ease.OutQuint);
            Tween rotateTween = transform.DORotateQuaternion(worldRotation * transform.rotation, TimeToMove).SetEase(Ease.OutQuint);

            // Attendre la fin des tweens
            yield return moveTween.WaitForCompletion();
        }

        transform.DOScale(Vector3.zero, TimeToDie).OnComplete(() => Destroy(gameObject));
    }

    public Vector3 GetClosestOrthogonalDirection(Transform from, Vector3 targetPosition)
    {
        Vector3 directionToTarget = targetPosition - from.position;
        directionToTarget.y = 0;
        directionToTarget.Normalize();

        float absX = Mathf.Abs(directionToTarget.x);
        float absZ = Mathf.Abs(directionToTarget.z);

        if (absX > absZ)
        {
            return directionToTarget.x > 0 ? Vector3.right : Vector3.left;
        }
        else
        {
            return directionToTarget.z > 0 ? Vector3.forward : Vector3.back;
        }
    }

    public Quaternion GetDiceRollRotation(Vector3 direction)
    {
        // Rotation de 90° en espace monde selon la direction
        if (direction == Vector3.forward)
            return Quaternion.Euler(90, 0, 0);
        else if (direction == Vector3.back)
            return Quaternion.Euler(-90, 0, 0);
        else if (direction == Vector3.right)
            return Quaternion.Euler(0, 0, -90);
        else if (direction == Vector3.left)
            return Quaternion.Euler(0, 0, 90);
        else
            return Quaternion.identity;
    }
}