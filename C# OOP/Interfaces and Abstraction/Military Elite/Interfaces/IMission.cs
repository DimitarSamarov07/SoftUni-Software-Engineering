using _08MilitaryElite.Enumerations;

namespace _08MilitaryElite.Interfaces
{
    public interface IMission
    {
        string CodeName { get; }

        State State { get; }

        void CompleteMission();
    }
}
