using System.Collections.Generic;

const string MSJ_ERROR_DNI ="No se encuentra el DNI";
Dictionary<int,Persona> dicPersonas = new Dictionary<int,Persona>();
int opcion;

Console.WriteLine("MENSAJE CON OPCIONES :D");
opcion=IngresarEnteroRango(1,5,"Ingrese la opción: ");
while(opcion!=5){
    switch(opcion){
    case 1:
    break;
    case 2:
    break;
    case 3:
    break;
    case 4:
    break;
}
}

void CargarNuevaPersona(){
    //int id, string ape, string nom, DateTime fN, string mail
    int dni;
    DateTime fechaNacimiento;
    string apellido, nombre, email;
    do{
        dni = IngresarEnteroPos("Ingrese su DNI: ");
    }while(!ValidarDni(dni));
    apellido=IngresarTexto("Ingrese su apellido: ");
    nombre=IngresarTexto("Ingrese su nombre: ");
    //fecha nac
    //email
}

/*string IngresarEmail(string email){

}*/

/*static bool ValidarEmail(string email)
        {
            if (email == null)
            {
                return false;
            }
            if (new EmailAddressAttribute().IsValid(email))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

DateTime IngresarFecha(string mensaje,string mensajeE){
   		 DateTime fecha = new DateTime();
   		 string fechaS;
   		 Console.Write(mensaje);
   		 fechaS = Console.ReadLine();
    
   		 while(!DateTime.TryParse(fechaS,out fecha)){
      			  Console.Write(mensajeE);
      			  fechaS = Console.ReadLine();
   		 }
   		 return fecha;
	}*/ //HAY Q FIJARNOS BIEN ESTO!!!!!

string IngresarTexto(string msj){
    Console.Write(msj);
    return Console.ReadLine();
}

int IngresarEnteroPos(string msj){
    int num;
    do{
        Console.Write(msj);
        num=int.Parse(Console.ReadLine());
    }while(num<=0);
    return num;
}

bool ValidarDni(int dni){
    bool valido = true;
    if(dicPersonas.ContainsKey(dni)){
        valido=false;
    }
    return valido;
}

int IngresarEnteroRango(int desde, int hasta, string msj){
    int num;
    do{
        Console.Write(msj);
        num=int.Parse(Console.ReadLine());
    }while(num<desde || num>hasta);
    return num;
}