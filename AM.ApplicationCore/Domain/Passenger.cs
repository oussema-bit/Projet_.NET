using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.ApplicationCore.Domain
{
    public class Passenger //sealed ==> Block la classe ne peut pas etre héritée
    {
        [Key]
        [StringLength(7)] //Contraint
        public string PassportNumber { get; set; }
        
        [MinLength(3,ErrorMessage = "Minimum 3 characteres")]
        [MaxLength(25,ErrorMessage = "Maximum 25 characteres")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        [DataType(DataType.Date)]//Dans le HTML Form ce sera un calendrier
        [Display(Name = "Date of birth")] //label dans le form 
        public DateTime BirthDate { get; set; }
        
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        [RegularExpression("^[0-9]{8}$")]
        public string PhoneNumber { get; set; }
        public bool CheckProfile(string prenom, string nom,string email=null)
        {
            if(email!=null)
                return FirstName.Equals(prenom) && LastName.Equals(nom)&&EmailAdress.Equals(email);
            else
                return FirstName.Equals(prenom) && LastName.Equals(nom);

        }
        public virtual void PassengerType()
        {
            Console.WriteLine("I am a passenger");
        }
        public ICollection<Flight> Flights { get; set; }
    }
}
