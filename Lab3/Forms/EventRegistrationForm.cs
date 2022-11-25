using BLL.Interfaces;
using BLL.Models;
using BLL.Services;
using System;
using System.Windows.Forms;

namespace Lab3
{
    public partial class EventRegistrationForm : Form
    {
        IEventService eventService;

        public EventRegistrationForm(IEventService eventService) 
        {
            this.eventService = eventService;

            InitializeComponent(); 
        }

        private void acceptButton_Click(object sender, EventArgs e)
        {
            EventModel newEventModel = new EventModel();

            newEventModel.id = Guid.NewGuid();
            newEventModel.name = nameTextBox.Text;
            newEventModel.description = descriptionRichTextBox.Text;
            newEventModel.authorID = (Guid)(authorComboBox.SelectedValue);

            if (!eventService.CreateEvent(newEventModel))
                MessageBox.Show("Проиозошла ошибка.", "Ошибка");
            else
                MessageBox.Show("Новое мероприятие добавлено.", "Успех");

            this.Close();
        }
    }
}
