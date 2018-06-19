using System;
using System.Windows.Forms;
using System.ComponentModel;
using Winform_Demo.View;
using Winform_Demo.Model;

namespace Winform_Demo.Controller
{
    public class DemoController
    {
        IDemoView View { get; set; }

        private Person _PersonBeignModified;
        private BindingList<Person> _Persons;

        public DemoController(IDemoView demoView)
        {
            _Persons = new BindingList<Person>();

            View = demoView;

            View.AddNewPerson += View_AddNewPerson;
            View.Cancel += View_Cancel;
            View.ExitApplication += View_ExitApplication;
            View.ModifyPerson += View_ModifyPerson;
            View.RemovePerson += View_RemovePerson;
            View.SaveChanges += View_SaveChanges;
            View.ViewIsReady += View_ViewIsReady;

            if (View.ViewReady)
            {
                View.Initialize();
                View.AwaitingMode();
                View.SetPeopleList(_Persons);
            }
        }

        #region View events

        private void View_ViewIsReady(object sender, EventArgs e)
        {
            View.Initialize();
            View.AwaitingMode();
            View.SetPeopleList(_Persons);
        }

        private void View_SaveChanges(object sender, EventArgs e)
        {
            if (ValidatePersonDataAndNotify())
            {
                if (_PersonBeignModified == null)
                {
                    _PersonBeignModified = new Person();
                    _Persons.Add(_PersonBeignModified);
                }

                _PersonBeignModified.Name = View.PersonName;
                _PersonBeignModified.Address = View.PersonAddress;
                _PersonBeignModified.Phone = View.PersonPhone;

                _PersonBeignModified = null;

                View.RefreshPeopleList();
                View.AwaitingMode();
            }
        }

        private void View_RemovePerson(object sender, EventArgs e)
        {
            if (View.GetSelectedPerson() != null)
            {
                _Persons.Remove(View.GetSelectedPerson());
                View.RefreshPeopleList();
            }
            else
            { View.PopMessage("No person selected"); }
        }

        private void View_ModifyPerson(object sender, EventArgs e)
        {
            if (View.GetSelectedPerson() != null)
            {
                _PersonBeignModified = View.GetSelectedPerson();
                View.PersonName = _PersonBeignModified.Name;
                View.PersonAddress = _PersonBeignModified.Address;
                View.PersonPhone = _PersonBeignModified.Phone;
                View.ModifyPersonMode();
            }
            else
            { View.PopMessage("No person selected"); }
        }

        private void View_ExitApplication(object sender, EventArgs e) => Application.Exit();

        private void View_Cancel(object sender, EventArgs e)
        {
            _PersonBeignModified = null;
            View.AwaitingMode();
        }

        private void View_AddNewPerson(object sender, EventArgs e) => View.NewPersonMode();

        #endregion

        private bool ValidatePersonDataAndNotify()
        {
            if (string.IsNullOrWhiteSpace(View.PersonName))
            {
                View.PopMessage("Person's name can't be empty");
                return false;
            }

            if (string.IsNullOrWhiteSpace(View.PersonAddress))
            {
                View.PopMessage("Person's address can't be empty");
                return false;
            }

            if (string.IsNullOrWhiteSpace(View.PersonPhone))
            {
                View.PopMessage("Person's phone can't be empty");
                return false;
            }
            
            return true;
        }

    }
}
