internal interface IExitableState
{
    void Exit();

    virtual void Update() { }
}
