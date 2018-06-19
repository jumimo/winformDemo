using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.ComponentModel;
using Winform_Demo.Model;

namespace Winform_Demo.View
{
    public partial class DemoForm : Form, IDemoView
    {
        public DemoForm()
        {
            InitializeComponent();
            OnViewIsReady();
        }

        #region Properties

        public string PersonName { get => tbName.Text; set => tbName.Text = value; }
        public string PersonAddress { get => tbAddress.Text; set => tbAddress.Text = value; }
        public string PersonPhone { get => tbPhone.Text; set => tbPhone.Text = value; }
        public bool ViewReady { get => true; }

        #endregion

        #region Events

        public event EventHandler AddNewPerson;
        protected void OnAddNewPerson() => AddNewPerson?.Invoke(this, new EventArgs());

        public event EventHandler ModifyPerson;
        protected void OnModifyPerson() => ModifyPerson?.Invoke(this, new EventArgs());

        public event EventHandler RemovePerson;
        protected void OnRemovePerson() => RemovePerson?.Invoke(this, new EventArgs());

        public event EventHandler SaveChanges;
        protected void OnSaveChanges() => SaveChanges?.Invoke(this, new EventArgs());

        public event EventHandler Cancel;
        protected void OnCancel() => Cancel?.Invoke(this, new EventArgs());

        public event EventHandler ExitApplication;
        protected void OnExitApplication() => ExitApplication?.Invoke(this, new EventArgs());

        public event EventHandler ViewIsReady;
        protected void OnViewIsReady() => ViewIsReady?.Invoke(this, new EventArgs());

        #endregion

        public void AwaitingMode()
        {
            tbName.Text = "";
            tbName.Enabled = false;
            tbAddress.Enabled = false;
            tbAddress.Text = "";
            tbPhone.Enabled = false;
            tbPhone.Text = "";
            btnSaveChanges.Enabled = false;
            btnCancel.Enabled = false;
            btnAddNew.Enabled = true;
            btnModify.Enabled = true;
            btnRemove.Enabled = true;
        }

        public void Initialize()
        {
            dgvPersons.DataSource = null;
            tbName.Text = "";
            tbName.Enabled = false;
            tbAddress.Text = "";
            tbAddress.Enabled = false;
            tbPhone.Text = "";
            tbPhone.Enabled = false;
            btnSaveChanges.Enabled = false;
            btnCancel.Enabled = false;
            btnExit.Enabled = true;
            btnAddNew.Enabled = true;
            btnModify.Enabled = true;
            btnRemove.Enabled = true;
        }

        public void ModifyPersonMode()
        {
            tbName.Enabled = true;
            tbAddress.Enabled = true;
            tbPhone.Enabled = true;
            btnSaveChanges.Enabled = true;
            btnCancel.Enabled = true;
            btnAddNew.Enabled = false;
            btnModify.Enabled = false;
            btnRemove.Enabled = false;
        }

        public void NewPersonMode()
        {
            tbName.Enabled = true;
            tbAddress.Enabled = true;
            tbPhone.Enabled = true;
            btnSaveChanges.Enabled = true;
            btnCancel.Enabled = true;
            btnAddNew.Enabled = false;
            btnModify.Enabled = false;
            btnRemove.Enabled = false;
        }

        public void PopMessage(string message) => MessageBox.Show(message);

        public void SetPeopleList(BindingList<Person> people) => dgvPersons.DataSource = people;

        public Person GetSelectedPerson() => dgvPersons.CurrentRow == null ? null : (dgvPersons.DataSource as IList<Person>)[dgvPersons.Rows.IndexOf(dgvPersons.CurrentRow)];

        public void RefreshPeopleList() => dgvPersons.Refresh();

        #region Controls events

        private void btnAddNew_Click(object sender, EventArgs e) => OnAddNewPerson();

        private void btnModify_Click(object sender, EventArgs e) => OnModifyPerson();

        private void btnRemove_Click(object sender, EventArgs e) => OnRemovePerson();

        private void btnSaveChanges_Click(object sender, EventArgs e) => OnSaveChanges();

        private void btnCancel_Click(object sender, EventArgs e) => OnCancel();

        private void btnExit_Click(object sender, EventArgs e) => OnExitApplication();

        #endregion
    }
}
