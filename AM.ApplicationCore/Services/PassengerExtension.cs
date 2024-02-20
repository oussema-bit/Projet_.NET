using AM.ApplicationCore.Domain;

namespace AM.ApplicationCore.Services;


// 1.Classe doit etre static
// 2.Methode a extendre doit etre static
// 3.On doit passer un parametre de type de la classe mére ou source (Passenger)
public static class PassengerExtension
{
    public static void UpperFullName(this Passenger p)
    {
        p.FirstName = p.FirstName.Substring(0,1).ToUpper() + p.FirstName.Substring(1);
        p.LastName = p.LastName.Substring(0,1).ToUpper() + p.LastName.Substring(1);
    }
}