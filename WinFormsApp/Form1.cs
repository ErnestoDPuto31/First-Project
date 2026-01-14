using System;
using System.ComponentModel;
using System.Windows.Forms;
using ClassLibrary;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        // Use BindingList so DataGridView updates automatically
        private BindingList<Class1> classlist = new BindingList<Class1>
        {
            new Class1 { Id = 1, Name = "Ernest" },
            new Class1 { Id = 2, Name = "Alice" },
            new Class1 { Id = 3, Name = "Bob" },
            new Class1 { Id = 4, Name = "Diana" },
            new Class1 { Id = 5, Name = "Frank" }
        };

        public Form1()
        {
            InitializeComponent();
            LoadClassList();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Any startup code here
            MessageBox.Show("Form Loaded!");
        }


        private void LoadClassList()
        {
            dataGridView1.AutoGenerateColumns = true;
            dataGridView1.DataSource = classlist;
        }

        private void showButton_Click(object sender, EventArgs e)
        {
            // Validate ID
            if (!int.TryParse(textBox1.Text.Trim(), out int id))
            {
                MessageBox.Show("Please enter a valid numeric ID.");
                return;
            }

            // Validate Name
            string name = textBox2.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show("Name cannot be empty.");
                return;
            }

            // Add to the bound list
            classlist.Add(new Class1
            {
                Id = id,
                Name = name
            });

            // Clear inputs
            textBox1.Clear();
            textBox2.Clear();
            textBox1.Focus();
        }
    }
}
