using System;
using System.Collections.Generic;

class Contact
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string City { get; set; }
    public DateTime AddedDate { get; set; }
    public string PhoneNumber { get; set; }
    public Email Email { get; set; }
    public Address Address { get; set; }
}

class Email
{
    public string EmailAddress { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
}

class Address
{
    public string Place { get; set; }
    public string Type { get; set; }
    public string Description { get; set; }
}

class ContactsManager
{
    public List<Contact> contacts;

    public ContactsManager()
    {
        contacts = new List<Contact>();
    }

    public void AddContact(Contact contact)
    {
        contacts.Add(contact);
    }

    public void EditContact(int id, Contact newContact)
    {
        Contact existingContact = contacts.Find(c => c.Id == id);
        if (existingContact != null)
        {
            existingContact.FirstName = newContact.FirstName;
            existingContact.LastName = newContact.LastName;
            existingContact.Gender = newContact.Gender;
            existingContact.City = newContact.City;
            existingContact.AddedDate = newContact.AddedDate;
            existingContact.PhoneNumber = newContact.PhoneNumber;
            existingContact.Email = newContact.Email;
            existingContact.Address = newContact.Address;
        }
    }

    public void DeleteContact(int id)
    {
        Contact contact = contacts.Find(c => c.Id == id);
        if (contact != null)
        {
            contacts.Remove(contact);
        }
    }

    public List<Contact> SearchContacts(string searchTerm)
    {
        List<Contact> matchedContacts = contacts.FindAll(c =>
            c.FirstName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.LastName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Gender.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.City.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.PhoneNumber.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Email.EmailAddress.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Email.Type.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Email.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Address.Place.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Address.Type.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
            c.Address.Description.Contains(searchTerm, StringComparison.OrdinalIgnoreCase));

        return matchedContacts;
    }

    public void ShowAllContacts()
    {
        foreach (Contact contact in contacts)
        {
            Console.WriteLine("ID: " + contact.Id);
            Console.WriteLine("Name: " + contact.FirstName + contact.LastName);
            Console.WriteLine("Gender: " + contact.Gender);
            Console.WriteLine("City: " + contact.City);

            Console.WriteLine("Phone Number: " + contact.PhoneNumber);
            Console.WriteLine("Email: " + contact.Email.EmailAddress);
            Console.WriteLine("Email Type: " + contact.Email.Type);
            Console.WriteLine("Email Description: " + contact.Email.Description);
            Console.WriteLine("Address: " + contact.Address.Place);
            Console.WriteLine("Address Type: " + contact.Address.Type);
            Console.WriteLine("Address Description: " + contact.Address.Description);
            Console.WriteLine();
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        ContactsManager manager = new ContactsManager();

        while (true)
        {
            Console.WriteLine("----Phone Contacts Manager----");
            Console.WriteLine();
            Console.WriteLine("Made by: Ahmed Elkholy");
            Console.WriteLine();
            Console.WriteLine("Choose an operation from the following list:");
            Console.WriteLine();
            Console.WriteLine("1. Add Contact");
            Console.WriteLine("2. Edit Contact");
            Console.WriteLine("3. Delete Contact");
            Console.WriteLine("4. Search Contacts");
            Console.WriteLine("5. Show All Contacts");
            Console.WriteLine("6. Exit");
            Console.WriteLine();
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Contact newContact = CreateContact();
                    manager.AddContact(newContact);
                    Console.WriteLine("Contact added successfully");
                    Console.WriteLine();
                    break;

                case 2:
                    Console.Write("Enter the ID of the contact to edit: ");
                    int idToEdit = Convert.ToInt32(Console.ReadLine());
                    Contact editedContact = CreateContact();
                    manager.EditContact(idToEdit, editedContact);
                    Console.WriteLine("Contact edited successfully");
                    Console.WriteLine();
                    break;

                case 3:
                    Console.Write("Enter the ID of the contact to delete: ");
                    int idToDelete = Convert.ToInt32(Console.ReadLine());
                    manager.DeleteContact(idToDelete);
                    Console.WriteLine("Contact deleted successfully");
                    Console.WriteLine();
                    break;

                case 4:
                    Console.Write("Enter any key word to search with: ");
                    string searchTerm = Console.ReadLine();
                    List<Contact> matchedContacts = manager.SearchContacts(searchTerm);
                    Console.WriteLine("Matched contacts:");
                    Console.WriteLine();
                    foreach (Contact contact in matchedContacts)
                    {
                        Console.WriteLine("ID: " + contact.Id);
                        Console.WriteLine("Name: " + contact.FirstName + contact.LastName);
                        Console.WriteLine("Gender: " + contact.Gender);
                        Console.WriteLine("City: " + contact.City);

                        Console.WriteLine("Phone Number: " + contact.PhoneNumber);
                        Console.WriteLine("Email: " + contact.Email.EmailAddress);
                        Console.WriteLine("Email Type: " + contact.Email.Type);
                        Console.WriteLine("Email Description: " + contact.Email.Description);
                        Console.WriteLine("Address: " + contact.Address.Place);
                        Console.WriteLine("Address Type: " + contact.Address.Type);
                        Console.WriteLine("Address Description: " + contact.Address.Description);
                        Console.WriteLine(contact.AddedDate = DateTime.Now);
                        Console.WriteLine();
                    }
                    break;

                case 5:
                    manager.ShowAllContacts();
                    break;

                default:
                    Console.WriteLine("Invalid");
                    break;
            }
        }
    }

    static Contact CreateContact()
    {
        Contact contact = new Contact();

        Console.Write("Enter ID: ");
        contact.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter First Name: ");
        contact.FirstName = Console.ReadLine();

        Console.Write("Enter Last Name: ");
        contact.LastName = Console.ReadLine();

        Console.Write("Enter Gender: ");
        contact.Gender = Console.ReadLine();

        Console.Write("Enter City: ");
        contact.City = Console.ReadLine();

        Console.Write("Enter Phone Number: ");
        contact.PhoneNumber = Console.ReadLine();

        Console.Write("Enter Email Address: ");
        string emailAddress = Console.ReadLine();

        Console.Write("Enter Email Type: ");
        string emailType = Console.ReadLine();

        Console.Write("Enter Email Description: ");
        string emailDescription = Console.ReadLine();

        contact.Email = new Email
        {
            EmailAddress = emailAddress,
            Type = emailType,
            Description = emailDescription
        };

        Console.Write("Enter Address Place: ");
        string addressPlace = Console.ReadLine();

        Console.Write("Enter Address Type: ");
        string addressType = Console.ReadLine();

        Console.Write("Enter Address Description: ");
        string addressDescription = Console.ReadLine();

        contact.Address = new Address
        {
            Place = addressPlace,
            Type = addressType,
            Description = addressDescription
        };

        return contact;
    }
}