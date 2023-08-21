namespace TYFramework.Editor.Basic.DesignPattern.Behavioral.State.Example4
{
    public class Heroine
    {
        HeroineBaseState _state;

        public Heroine()
        {
            _state = new StandingState(this);

        }

        public void SetHeroineState(HeroineBaseState newState)
        {
            _state = newState;
        }

        public void HandleInput()
        {

        }



        public void Update()
        {
            _state.HandleInput();
        }

    }
}
