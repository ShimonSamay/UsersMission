using UsersConsoleApp;

List<User> usersList = new List<User>();

void createUser()
{ try
    {
        int counter = 0;
        while (counter < 2)
        {
            User user = new User();
            Console.WriteLine("enter first name");
            user.firstname = Console.ReadLine();
            Console.WriteLine("enter last name");
            user.lastname = Console.ReadLine();
            Console.WriteLine("enter birth year");
            user.birthyaer = int.Parse(Console.ReadLine());
            Console.WriteLine("enter email");
            user.email = Console.ReadLine();
            usersList.Add(user);
            Console.WriteLine(user.firstname);
            saveUserToFile(user);
            counter++;
        }

        saveUsersToFile(usersList);
    }

    catch (FormatException)
    {
        Console.WriteLine("not typed correctly");
    }

    catch (FileNotFoundException)
    {
        Console.WriteLine("file not found");
    }

    catch (NullReferenceException)
    {
        Console.WriteLine("one of the fields is empty");
    }
}

void saveUsersToFile (List<User> anyuserList)
{  try
    {
        foreach (User user in anyuserList)
        {
            FileStream userfs = new FileStream(@$"c:\test\users\users.txt", FileMode.Append);
            using (StreamWriter writer = new StreamWriter(userfs))
            {
                writer.WriteLine($"First Name: {user.firstname} Last Name: {user.lastname} Email:{user.email} Birth Year:{user.birthyaer}");
            }
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("file not found");
    }

    catch (ArgumentException)
    {
        Console.WriteLine("argument error");
    }

    catch (Exception)
    {
        Console.WriteLine("error");
    }
}

void printUsersFromFile (List<User> anyuserList)
{
    try
    {
        FileStream userfs = new FileStream(@$"c:\test\users\users.txt", FileMode.Open);
        using (StreamReader reader = new StreamReader(userfs))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }

    catch(FileNotFoundException)
    {
        Console.WriteLine("file not exist");
    }

    catch (ArgumentException)
    {
        Console.WriteLine("argument error");
    }

    catch (Exception)
    {
        Console.WriteLine("error");
    }
}

void editUser ()
{
    try
    {
        Console.WriteLine("enter user name");
        string userFullName = Console.ReadLine();
        string userlastName = userFullName.Substring(userFullName.IndexOf(" "));
        Console.WriteLine("enter birth year");
        string userBirthYear = Console.ReadLine();
        Console.WriteLine("enter user email");
        string userEmail = Console.ReadLine();

        FileStream userfs = new FileStream(@$"c:\test\{userFullName}.txt", FileMode.Create);
        using (StreamWriter writer = new StreamWriter(userfs))
        {
            writer.WriteLine($"Name:{userFullName} Birth Year:{userBirthYear} Email:{userEmail}");
        }
    }
    catch (ArgumentException)
    {
        Console.WriteLine("argument error");
    }
    catch (NullReferenceException)
    {
        Console.WriteLine("empty field");
    }

    catch (FormatException)
    {
        Console.WriteLine("parametrs not match the fields");
    }

    catch (Exception)
    {
        Console.WriteLine("general error");
    }
    

}

void saveUserToFile (User user)
{
    try
    {
        FileStream userfs = new FileStream(@$"c:\test\{user.firstname} {user.lastname}.txt", FileMode.Append);
        using (StreamWriter writer = new StreamWriter(userfs))
        {
            writer.WriteLine($"First Name:{user.firstname} Last Name:{user.lastname} Email:{user.email} Birth Year:{user.birthyaer}");
        }
    }
    catch (FileNotFoundException)
    {
        Console.WriteLine("file not found");
    }
    catch (ArgumentException)
    {
        Console.WriteLine("argument error");
    }
    catch (Exception)
    {
        Console.WriteLine("error , try again");
    }
}

void printUserFromFile ()
{  
    try
    {
        Console.WriteLine("enter user full name");
        string name = Console.ReadLine();
        FileStream userfs = new FileStream(@$"c:\test\{name}.txt", FileMode.Open);
        using (StreamReader reader = new StreamReader(userfs))
        {
            Console.WriteLine(reader.ReadToEnd());
        }
    }

    catch (FileNotFoundException)
    {
        Console.WriteLine("file not exist");
    }

    catch (FormatException)
    {
        Console.WriteLine("filed not tped correctly");
    }
    catch (Exception)
    {
        Console.WriteLine("error");
    }
}

void deleteUser ()
{
    try
    {
        Console.WriteLine("enter user full name");
        string Name = Console.ReadLine();
        foreach (User user in usersList)
        {
            if (user.firstname == Name) usersList.Remove(user);
        }

        File.Delete(@$"c:\test\{Name}.txt");
    }
    catch(FileNotFoundException)
    {
        Console.WriteLine("file not found");
    }

    catch (FormatException)
    {
        Console.WriteLine("parameters not match field");
    }

    catch (Exception)
    {
        Console.WriteLine("error");
    }
}


void usersMenu ()
{
    Console.WriteLine("1.Add user\n2.Edit user\n3.Delete user\n4.Find user");
    string userChoice = Console.ReadLine();

    switch (userChoice)
    {
        case "1":
        createUser();
        usersMenu();
        break;

        case "2":
        editUser();
        usersMenu();
        break;

        case "3":
        deleteUser();
        usersMenu();
        break;

        case "4":
        printUserFromFile();
        usersMenu();
        break;
    }
}

usersMenu(); 


