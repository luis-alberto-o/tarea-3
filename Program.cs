using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a mi lista de Contactos");

        bool runing = true;
        List<int> ids = new List<int>();
        Dictionary<int, string> names = new Dictionary<int, string>();
        Dictionary<int, string> lastnames = new Dictionary<int, string>();
        Dictionary<int, string> addresses = new Dictionary<int, string>();
        Dictionary<int, string> telephones = new Dictionary<int, string>();
        Dictionary<int, string> emails = new Dictionary<int, string>();
        Dictionary<int, int> ages = new Dictionary<int, int>();
        Dictionary<int, bool> bestFriends = new Dictionary<int, bool>();

        while (runing)
        {
            Console.WriteLine(@"
1. Agregar Contacto     
2. Ver Contactos    
3. Buscar Contactos     
4. Modificar Contacto   
5. Eliminar Contacto    
6. Salir");
            Console.WriteLine("Digite el número de la opción deseada");

            int typeOption = Convert.ToInt32(Console.ReadLine());

            switch (typeOption)
            {
                case 1:
                    AddContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 2:
                    ViewContacts(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 3:
                    SearchContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 4:
                    ModifyContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 5:
                    DeleteContact(ids, names, lastnames, addresses, telephones, emails, ages, bestFriends);
                    break;

                case 6:
                    runing = false;
                    Console.WriteLine("Saliendo...");
                    break;

                default:
                    Console.WriteLine("Opción no válida, intenta de nuevo");
                    break;
            }
        }
    }

    // ✅ AGREGAR CONTACTO
    static void AddContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el nombre de la persona");
        string name = Console.ReadLine();
        Console.WriteLine("Digite el apellido de la persona");
        string lastname = Console.ReadLine();
        Console.WriteLine("Digite la dirección");
        string address = Console.ReadLine();
        Console.WriteLine("Digite el telefono de la persona");
        string phone = Console.ReadLine();
        Console.WriteLine("Digite el email de la persona");
        string email = Console.ReadLine();
        Console.WriteLine("Digite la edad de la persona en números");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Especifique si es mejor amigo: 1. Si, 2. No");
        bool isBestFriend = Convert.ToInt32(Console.ReadLine()) == 1;

        var id = ids.Count + 1;
        ids.Add(id);
        names.Add(id, name);
        lastnames.Add(id, lastname);
        addresses.Add(id, address);
        telephones.Add(id, phone);
        emails.Add(id, email);
        ages.Add(id, age);
        bestFriends.Add(id, isBestFriend);

        Console.WriteLine("✅ Contacto agregado correctamente!");
    }

    // ✅ VER CONTACTOS
    static void ViewContacts(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine($"ID   Nombre      Apellido        Dirección       Telefono        Email         Edad   Mejor Amigo?");
        Console.WriteLine("___________________________________________________________________________________________________");

        foreach (var id in ids)
        {
            string isBestFriendStr = bestFriends[id] ? "Si" : "No";
            Console.WriteLine($"{id}    {names[id]}      {lastnames[id]}      {addresses[id]}      {telephones[id]}      {emails[id]}      {ages[id]}      {isBestFriendStr}");
        }
    }

    // ✅ BUSCAR CONTACTO (por nombre o apellido)
    static void SearchContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el nombre o apellido del contacto que desea buscar:");
        string search = Console.ReadLine().ToLower();

        bool found = false;
        foreach (var id in ids)
        {
            if (names[id].ToLower().Contains(search) || lastnames[id].ToLower().Contains(search))
            {
                string isBestFriendStr = bestFriends[id] ? "Si" : "No";
                Console.WriteLine($"✅ Encontrado: {names[id]} {lastnames[id]} - Tel: {telephones[id]} - Email: {emails[id]} - Mejor Amigo: {isBestFriendStr}");
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("❌ No se encontró ningún contacto con ese nombre o apellido.");
        }
    }

    // ✅ MODIFICAR CONTACTO
    static void ModifyContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el ID del contacto que desea modificar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("❌ No existe un contacto con ese ID.");
            return;
        }

        Console.WriteLine("Digite el nuevo nombre (o presione Enter para no cambiar):");
        string name = Console.ReadLine();
        if (!string.IsNullOrEmpty(name)) names[id] = name;

        Console.WriteLine("Digite el nuevo apellido:");
        string lastname = Console.ReadLine();
        if (!string.IsNullOrEmpty(lastname)) lastnames[id] = lastname;

        Console.WriteLine("Digite la nueva dirección:");
        string address = Console.ReadLine();
        if (!string.IsNullOrEmpty(address)) addresses[id] = address;

        Console.WriteLine("Digite el nuevo teléfono:");
        string phone = Console.ReadLine();
        if (!string.IsNullOrEmpty(phone)) telephones[id] = phone;

        Console.WriteLine("Digite el nuevo email:");
        string email = Console.ReadLine();
        if (!string.IsNullOrEmpty(email)) emails[id] = email;

        Console.WriteLine("Digite la nueva edad (o 0 para no cambiar):");
        int age = Convert.ToInt32(Console.ReadLine());
        if (age > 0) ages[id] = age;

        Console.WriteLine("Es mejor amigo? 1. Si, 2. No, 0. No cambiar:");
        int best = Convert.ToInt32(Console.ReadLine());
        if (best == 1) bestFriends[id] = true;
        else if (best == 2) bestFriends[id] = false;

        Console.WriteLine("✅ Contacto modificado correctamente!");
    }

    // ✅ ELIMINAR CONTACTO
    static void DeleteContact(List<int> ids, Dictionary<int, string> names, Dictionary<int, string> lastnames,
        Dictionary<int, string> addresses, Dictionary<int, string> telephones, Dictionary<int, string> emails,
        Dictionary<int, int> ages, Dictionary<int, bool> bestFriends)
    {
        Console.WriteLine("Digite el ID del contacto que desea eliminar:");
        int id = Convert.ToInt32(Console.ReadLine());

        if (!ids.Contains(id))
        {
            Console.WriteLine("❌ No existe un contacto con ese ID.");
            return;
        }

        ids.Remove(id);
        names.Remove(id);
        lastnames.Remove(id);
        addresses.Remove(id);
        telephones.Remove(id);
        emails.Remove(id);
        ages.Remove(id);
        bestFriends.Remove(id);

        Console.WriteLine("✅ Contacto eliminado correctamente!");
    }
}

