using UnityEngine;

public class ElevatorButton : MonoBehaviour, IInteractable
{
    [SerializeField] Transform elevator;
    [SerializeField] Transform elevatorDestination;
    [SerializeField] float elevatorSpeed;
    [SerializeField] bool smooth;

    Vector3 startingPoint;
    bool elevatorTurnedOn = false;

    private void Start()
    {
        startingPoint = elevator.position;
    }

    private void Update()
    {
        Vector3 targetPosition;
        if(elevatorTurnedOn)
        {
            targetPosition = elevatorDestination.position;
        }
        else
        {
            targetPosition = startingPoint;
        }

        if (smooth)
        {
            elevator.position = Vector3.Lerp(elevator.position, targetPosition, elevatorSpeed * Time.deltaTime);
        }
        else
        {
            Vector3 direction = (targetPosition - elevator.position).normalized;
            float distance = Mathf.Clamp(elevatorSpeed * Time.deltaTime, 0, Vector3.Distance(elevator.position, targetPosition));
            elevator.position += direction * distance;
        }
    }

    public void Interact(Interactor interactor)
    {
        elevatorTurnedOn = !elevatorTurnedOn;
    }

}
