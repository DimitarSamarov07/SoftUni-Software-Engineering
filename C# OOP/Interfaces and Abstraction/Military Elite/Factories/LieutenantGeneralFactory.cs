using _08MilitaryElite.Models;

namespace _08MilitaryElite.Factories
{
    public class LieutenantGeneralFactory
    {
        public LieutenantGeneral CreateLieutenantGeneral(string id, string firstName, string lastName, decimal salary)
        {
            LieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

            return lieutenantGeneral;
        }
    }
}
