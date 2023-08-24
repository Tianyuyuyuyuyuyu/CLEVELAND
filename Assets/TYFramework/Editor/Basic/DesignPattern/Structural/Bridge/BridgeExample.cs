using UnityEngine;

namespace TYFramework.Editor.Basic.DesignPattern.Structural.Bridge
{
    public class BridgeExample : MonoBehaviour
    {
        void Start()
        {
            RemoteControl remoteControl= new ConcreteRemote();
            remoteControl.Implementor = new ChangHong();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
            
            remoteControl.Implementor = new Samsung();
            remoteControl.On();
            remoteControl.SetChannel();
            remoteControl.Off();
        }
    }

    public abstract class TV
    {
        public abstract void On();
        public abstract void Off();
        public abstract void TurnChannel();
    }

    public class Samsung : TV
    {
        public override void On()
        {
            Debug.LogError("三星牌电视打开");
        }

        public override void Off()
        {
            Debug.LogError("三星牌电视关闭");
        }

        public override void TurnChannel()
        {
            Debug.LogError("三星牌电视换频道");
        }
    }
    
    public class ChangHong : TV
    {
        public override void On()
        {
            Debug.LogError("长虹牌电视打开");
        }

        public override void Off()
        {
            Debug.LogError("长虹牌电视关闭");
        }

        public override void TurnChannel()
        {
            Debug.LogError("长虹牌电视换频道");
        }
    }

    public abstract class RemoteControl
    {
        public TV Implementor { get; set; }

        public virtual void On()
        {
            Implementor.On();
        }
        
        public virtual void Off()
        {
            Implementor.Off();
        }
        
        public virtual void SetChannel()
        {
            Implementor.TurnChannel();
        }
    }

    public class ConcreteRemote : RemoteControl
    {
        
    }
}
