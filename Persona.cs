class Persona{
    private const int EDAD_MIN=16;
    public int dni{get;set;}
    public string apellido{get;set;}
    public string nombre{get;set;}
    public DateTime fechaNacimiento{get;set;}
    public string email{get;set;}
    public int edad{get;set;}

    Persona(int id, string ape, string nom, DateTime fN, string mail){
        dni = id;
        apellido = ape;
        nombre = nom;
        fechaNacimiento = fN;
        email = mail;
    }

    public int ObtenerEdad(){
        DateTime hoy = DateTime.Today;
        DateTime cumpleaños = new DateTime(hoy.Year, fechaNacimiento.Month, fechaNacimiento.Day);

        edad = hoy.Year - fechaNacimiento.Year;
        if(cumpleaños>hoy)
            edad--;

        return edad;
    }

    public bool PuedeVotar(){
        bool puede=false;
        if(edad>=EDAD_MIN)
            puede=true;
        return puede;
    }

}