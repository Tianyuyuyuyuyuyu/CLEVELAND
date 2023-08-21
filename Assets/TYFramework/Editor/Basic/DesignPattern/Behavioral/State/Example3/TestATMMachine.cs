using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Behavioral.State.Example3
{
    public class TestATMMachine: MonoBehaviour
    {

        void Start()
        {
            ATMMachine atmMachine = new ATMMachine();

            atmMachine.insertCard();

            atmMachine.ejectCard();

            atmMachine.insertCard();

            atmMachine.insertPin(1234);

            atmMachine.requestCash(2000);

            atmMachine.insertCard();

            atmMachine.insertPin(1234);

        }
    }
}