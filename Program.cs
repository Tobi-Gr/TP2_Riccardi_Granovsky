using System.Collections.Generic;
using System.Text.RegularExpressions;

const string MSJ_ERROR_DNI ="No se encuentra el DNI";
const string opciones = "1. Cargar nueva persona.\n2. Obtener estadisticas del censo.\n3. Buscar persona.\n4. Modificar mail de una persona.\n5. Salir.";
Dictionary<int,Persona> dicPersonas = new Dictionary<int,Persona>();
int opcion;

Console.WriteLine(opciones);
opcion=IngresarEnteroRango(1,5,"Ingrese la opción: ");
while(opcion!=5){
    switch(opcion){
    case 1:
        CargarNuevaPersona();
    break;
    case 2: 
        if(ContarElementosDic()==0)
        {
            Console.WriteLine("Aún no se ingresaron personas en la lista.");
        }
        else
        {
            Console.WriteLine("Estadísticas del censo:");
            Console.WriteLine("Cantidad de personas: " + ContarElementosDic());
            Console.WriteLine("Cantidad de personas habilitadas a votar: " + CantVotantes());
            Console.WriteLine("Promedio de edad: " + CalcularPromedioEdad());
        }
    break;
    case 3:
        BuscarPersona();
    break;
    case 4:
        ModificarEmail();
    break;
    }
    Console.ReadKey();
    Console.Clear();
    Console.WriteLine(opciones);
    opcion=IngresarEnteroRango(1,5,"Ingrese la opción: ");
}

void ModificarEmail()
{
    string nuevoEmail;
    Console.Write("Ingrese el DNI de la persona: ");
    int dni = int.Parse(Console.ReadLine());

    if(!ContieneDni(dni))
    {
        Console.WriteLine(MSJ_ERROR_DNI);
    }
    else
    {
        nuevoEmail = IngresarEmail("Ingrese el nuevo email: ");
        dicPersonas[dni].email = nuevoEmail;
    }
}

void BuscarPersona()
{
    Console.Write("Ingrese el DNI de la persona a buscar: ");
    int dni = int.Parse(Console.ReadLine());

    if(!ContieneDni(dni))
    {
        Console.WriteLine(MSJ_ERROR_DNI);
    }
    else
    {
        Console.WriteLine("Apellido: " + dicPersonas[dni].apellido);
        Console.WriteLine("Nombre: " + dicPersonas[dni].nombre);
        Console.WriteLine("Email: " + dicPersonas[dni].email);
        Console.WriteLine("Fecha de nacimiento: " + dicPersonas[dni].fechaNacimiento.ToShortDateString());
        Console.WriteLine("Edad: " + dicPersonas[dni].ObtenerEdad());
        Console.Write("Puede votar: ");
        if(dicPersonas[dni].PuedeVotar())
            Console.WriteLine("Sí");
        else
            Console.WriteLine("No");
    }
}

double CalcularPromedioEdad()
{
    int suma = 0, cont = 0;

    foreach(Persona usuario in dicPersonas.Values)
    {
        suma+= usuario.ObtenerEdad();
        cont++;
    }
    return suma/cont;
}

int CantVotantes()
{
    int cont=0;
    foreach(Persona usuario in dicPersonas.Values)
    {
        usuario.ObtenerEdad();
        if(usuario.PuedeVotar()){
            cont++;
        }
    }
    return cont;
}

int ContarElementosDic()
{
    int contador=0;
    foreach (int clave in dicPersonas.Keys)
    {
        contador++;
    } 
    return contador;
}

void CargarNuevaPersona(){
    int dni;
    DateTime fechaNacimiento;
    string apellido, nombre, email;
    do
    {
        dni = IngresarEnteroPos("Ingrese su DNI: ");
    }
    while(ContieneDni(dni));
    apellido = IngresarTexto("Ingrese su apellido: ");
    nombre = IngresarTexto("Ingrese su nombre: ");
    fechaNacimiento = IngresarFecha("Ingrese su fecha de nacimiento siguiendo el siguiente formato DD/MM/XXXX: ");
    email = IngresarEmail("Ingrese su email: ");
    Persona usuario = new Persona(dni,apellido,nombre,fechaNacimiento,email);
    dicPersonas.Add(dni,usuario);
}

string IngresarEmail(string mensaje)
{
    string input;
    do
    {
        Console.Write(mensaje);
        input = Console.ReadLine();
    }
    while(!ValidarEmail(input));
    return input;
}

bool ValidarEmail(string emailAComprobar)
{ 
    String sFormato; 
    sFormato = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";
    if (Regex.IsMatch(emailAComprobar, sFormato)) 
    {
        if (Regex.Replace(emailAComprobar, sFormato, String.Empty).Length == 0) 
        { 
            return true; 
        } 
        else
        { 
            return false; 
        } 
    } 
    else
    { 
        return false;
    }
}

DateTime IngresarFecha(string mensaje)
{
   		 DateTime fecha = new DateTime();
   		 string fechaS;    
   		 do
         {
      		Console.Write(mensaje);
      		fechaS = Console.ReadLine();
   		 }
         while(!DateTime.TryParse(fechaS,out fecha));
   		 return fecha;
}

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

bool ContieneDni(int dni){
    bool contiene = false;
    if(dicPersonas.ContainsKey(dni)){
        contiene=true;
    }
    return contiene;
}

int IngresarEnteroRango(int desde, int hasta, string msj){
    int num;
    do{
        Console.Write(msj);
        num=int.Parse(Console.ReadLine());
    }while(num<desde || num>hasta);
    return num;
}