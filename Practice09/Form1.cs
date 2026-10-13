using System.Text.Json;

namespace _09_practice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Text = "Notepad";
            button1.Text = "Save";
            label2.Text = "Name";
            label3.Text = "Surname";
            label4.Text = "Id";

            string fileName = "note.json";
            if (!File.Exists(fileName))
            {
                MessageBox.Show("File not found");
                return;
            }

            string json = File.ReadAllText(fileName);
            note = JsonSerializer.Deserialize<Note>(json);

            label1.Text = "Save Time: " + note.CreatedAt;
            textBox1.Text = note.Name;
            textBox2.Text = note.Surname;
            textBox3.Text = note.Id.ToString();
        }
        Note note = new Note
        {
            Id = 1,
            Name = "Test",
            Surname = "Test",
            CreatedAt = DateTime.Now,
        };

        private void button1_Click(object sender, EventArgs e)
        {
            note.CreatedAt = DateTime.Now;
            note.Name = textBox1.Text;
            note.Surname = textBox2.Text;
            note.Id = int.Parse(textBox3.Text);
            string json = JsonSerializer.Serialize(note);
            File.WriteAllText("note.json", json);
        }
    }

    public class Note
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime CreatedAt { get; set; }
    }

}
