using System;
using System.ComponentModel;
using Winform_Demo.Model;

namespace Winform_Demo.View
{
    public interface IDemoView
    {
        event EventHandler AddNewPerson;
        event EventHandler ModifyPerson;
        event EventHandler RemovePerson;

        event EventHandler SaveChanges;
        event EventHandler Cancel;

        event EventHandler ExitApplication;
        event EventHandler ViewIsReady;

        void Initialize();
        void SetPeopleList(BindingList<Person> people);
        Person GetSelectedPerson();
        void PopMessage(string message);
        void RefreshPeopleList();

        void NewPersonMode();
        void ModifyPersonMode();
        void AwaitingMode();

        string PersonName { get; set; }
        string PersonAddress { get; set; }
        string PersonPhone { get; set; }
        bool ViewReady { get; }  
        
    }
}
