namespace PetClinic.DataProcessor
{
    using System;
    using System.Linq;
    using System.Text;
    using PetClinic.Data;

    public class Bonus
    {
        public static string UpdateVetProfession(PetClinicContext context, string phoneNumber, string newProfession)
        {
            var target = context.Vets.FirstOrDefault(x => x.PhoneNumber == phoneNumber);

            StringBuilder sb = new StringBuilder();
            if (target!=null)
            {
                sb.AppendLine($"{target.Name}'s profession updated from {target.Profession} to {newProfession}.");
                target.Profession = newProfession;
                context.SaveChanges();

            }

            else
            {
                 sb.AppendLine($"Vet with phone number {phoneNumber} not found!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
