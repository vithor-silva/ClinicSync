using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ClinicSync.Models
{
    public class Consultation
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Name { get; set; }
 
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Email { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Phone { get; set; }

        [Display(Name = "Doutor(a)")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Doctor { get; set; }

        [Display(Name = "Especialidade")]
        public string Speciality { get; set; }

        public Consultation()
        {
            
        }

        public Consultation(int id, string name, string email, string phone, string doctor, string speciality)
        {
            Id = id;
            Name = name;
            Email = email;
            Phone = phone;
            Doctor = doctor;
            Speciality = speciality;
        }
    }
}
