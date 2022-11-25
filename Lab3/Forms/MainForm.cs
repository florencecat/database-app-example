using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BLL;
using BLL.Models;
using BLL.Interfaces;

namespace Lab3
{
    public partial class MainForm : Form
    {
        IDataBaseCRUD dataBaseOperation;
        IEventService eventService;
        IReportService reportService;

        List<EventModel> allEvents;
        List<ManagerModel> allManagers;
        List<OrganizationModel> allOrganizations;

        public MainForm(IDataBaseCRUD dataBaseOperaton, IEventService eventService, IReportService reportService)
        {
            this.dataBaseOperation = dataBaseOperaton;
            this.eventService = eventService;
            this.reportService = reportService;

            InitializeComponent();
            Initialize();
        }

        void Initialize()
        {
            allEvents = dataBaseOperation.GetAllEvents();
            bindingSourceEvents.DataSource = allEvents;

            allManagers = dataBaseOperation.GetAllManagers();
            bindingSourceManagers.DataSource = allManagers;

            allOrganizations = dataBaseOperation.GetAllOrganizations();
            dataGridViewOrganizations.DataSource = allOrganizations;

            comboBoxOrganizations.DataSource = allOrganizations;
            comboBoxOrganizations.DisplayMember = "name";
            comboBoxOrganizations.ValueMember = "id";
        }

        private void createEventButton_Click(object sender, EventArgs e)
        {
            EventRegistrationForm form = new EventRegistrationForm(eventService);

            form.authorComboBox.DataSource = allManagers;
            form.authorComboBox.DisplayMember = "name";
            form.authorComboBox.ValueMember = "userID";

            form.ShowDialog(this);

            Initialize();
        }

        private void dataGridViewEvents_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3) { MessageBox.Show(allEvents[e.RowIndex].description, "Описание события"); }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            DialogResult question = MessageBox.Show("Вы уверены?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dataGridViewEvents.SelectedRows.Count > 0 && question == DialogResult.Yes)
                dataBaseOperation.DeleteEvent(allEvents[dataGridViewEvents.SelectedRows[0].Index].id);

            Initialize();
        }

        private void buttonReport_Click(object sender, EventArgs e)
        {
            dataGridViewReport.DataSource = reportService.ManagersOfOrganization((Guid)comboBoxOrganizations.SelectedValue);
        }
    }
}

