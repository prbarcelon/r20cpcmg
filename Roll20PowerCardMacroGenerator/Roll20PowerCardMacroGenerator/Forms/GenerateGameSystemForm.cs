using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Roll20PowerCardMacroGenerator.Forms
{
    public partial class GenerateGameSystemForm : Form
    {
        public GenerateGameSystemForm()
        {
            InitializeComponent();
        }

        private void GenerateGameSystemForm_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = new Tag();
        }

        #region Tab Generate Game System

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Tag tag = listBox1.SelectedItem as Tag;
            if(tag != null)
                propertyGrid1.SelectedObject = (listBox1.SelectedItem as Tag).Clone();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(propertyGrid1.SelectedObject);
            propertyGrid1.SelectedObject = new Tag();
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            int idx = listBox1.SelectedIndex;
            if (idx >= 0)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                listBox1.SelectedIndex = idx - 1;
            }
        }

        private void buttonClear_Click_1(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            propertyGrid1.SelectedObject = new Tag();
        }
        #endregion

        private void buttonSave_Click(object sender, EventArgs e)
        {
            var name = textBoxName.Text;
            var tags = listBox1.Items;
            if (string.IsNullOrEmpty(name))
            {
                MessageBox.Show("A Game System name must be entered.", "No Name");
                return;
            }
            if (tags.Count == 0)
            {
                MessageBox.Show("No tags defined.  At least 1 tag must be defined", "No Tags");
                return;
            }

            GameSystem gs = new GameSystem();
            gs.Name = name;
            gs.PredefinedTags = new List<Tag>();
            foreach (Tag tag in tags)
                gs.PredefinedTags.Add(tag);
            SaveGameSystem(gs);
        }

        private void SaveGameSystem(GameSystem gs)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.FileName = gs.Name + ".xml";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    GameSystem.Write(gs, sfd.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Failed to create GameSystem\n" + e.Message, "Error");
                }
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            GameSystem gs = LoadGameSystem();
            if (gs != null)
            {
                listBox1.Items.Clear();
                gs.PredefinedTags.ForEach(t => listBox1.Items.Add(t));
                textBoxName.Text = gs.Name;
            }
        }

        private GameSystem LoadGameSystem()
        {
            OpenFileDialog sfd = new OpenFileDialog();
            sfd.Filter = "(xml files)|*.xml|(All)|*.*";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    return GameSystem.Read(sfd.FileName);
                }
                catch (Exception e)
                {
                    MessageBox.Show("Failed to load GameSystem\n" + e.Message, "Error");
                }
            }
            return null;
        }

        private void buttonReplace_Click(object sender, EventArgs e)
        {
            Tag tag = propertyGrid1.SelectedObject as Tag;
            if (listBox1.SelectedItem == null) buttonAdd_Click(sender, e);
            else
            {
                int idx = listBox1.SelectedIndex;
                listBox1.Items.RemoveAt(idx);
                listBox1.Items.Insert(idx, tag);
                propertyGrid1.SelectedObject = new Tag();
            }
        }

    }
}
