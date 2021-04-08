public interface IState
{
    void EnterState();
    void ExitState();
    bool GetActive();
}
