namespace TYFramework.Editor.Basic.DesignPattern.Behavioral.State.Example3
{
    public interface ATMState
    {

        // Different states expected
        // HasCard, NoCard, HasPin, NoCash

        void insertCard();

        void ejectCard();

        void insertPin(int pinEntered);

        void requestCash(int cashToWithdraw);

    }
}