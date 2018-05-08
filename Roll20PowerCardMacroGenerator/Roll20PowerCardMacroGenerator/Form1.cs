using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Roll20PowerCardMacroGenerator.Factory;
using Roll20PowerCardMacroGenerator.Forms;
using Roll20PowerCardMacroGenerator.Forms.CustomControls;
using System.Text.RegularExpressions;
using System.IO;
using Roll20PowerCardMacroGenerator.Factories;


namespace Roll20PowerCardMacroGenerator
{
    public partial class Form1 : Form
    {
        static List<Power> powers;
        public static List<Power> Powers
        {
            get
            {
                return powers;
            }
        }
        
        //Macros macros;
        //List<Guid> macroOrder;

        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }

        public Form1()
        {
            InitializeComponent();
            LoadDDIPowers();
            LoadScript();
            LoadSystems();
            LoadPreview();
            tabControl1.SelectedTab = tabPageMacro;
            flowLayoutPanelMacros.Resize += flowLayoutPanel1_Resize;
        }

        void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            buttonHeader.Size = new Size(flowLayoutPanelMacros.ClientSize.Width-20, buttonHeader.Height);
        }

        private void LoadPreview()
        {
            string previewPage = Application.StartupPath + @"\Data\Preview.html";
            this.webBrowser1.Navigate("about:blank");
            this.webBrowser1.Navigate(previewPage);
            this.webBrowser1.Update();
            this.Update();
            this.Refresh();
            tabControl1.SelectedTab = tabPageMacro;
        }

        private void LoadSystems()
        {
            //CLEAN UP
            Console.WriteLine(Settings.Instance.GameSystems.Count);
            //comboBoxGameSystems.DataSource = Settings.Instance.GameSystems.Select(o => o.Name).ToList();
            comboBoxGameSystems.DataSource = Settings.Instance.GameSystems.ToList();
            UpdatePredefinedTags(comboBoxGameSystems.SelectedItem as GameSystem);
        }

        private void UpdatePredefinedTags(GameSystem system)
        {
            flowLayoutPanelPredefinedTags.Controls.Clear();
            //GameSystem system = Settings.Instance.GameSystems.First(o => o.Name == comboBoxGameSystems.Text);
            foreach (Tag tag in system.PredefinedTags)
            {
                PredefinedTagButton control = new PredefinedTagButton(tag, toolTip1);
                flowLayoutPanelPredefinedTags.Controls.Add(control);
                control.Click += new EventHandler(AddControl);
            }
            
        }

        private void AddControl(object sender, EventArgs e)
        {
            PredefinedTagButton button = sender as PredefinedTagButton;
            if (button != null)
            {
                Tag tag = button.TagControl;
                AddMacroControl(button.TagControl);
            }
        }

        private void AddMacroControl(Tag tag)
        {
            IMacroControlFactory2 mcf = Settings.Instance.MacroControlFactory;
            // add requested tag
            var control = mcf.CreateMacroControl(tag);
            flowLayoutPanelMacros.Controls.Add(control);
            // set the MoveUp and MoveDown callbacks
            Action<object> moveUp = (o) =>
            {
                Control c = (o as Control).Tag as Control;
                int idx = flowLayoutPanelMacros.Controls.GetChildIndex(c, false);
                if (idx > 1) flowLayoutPanelMacros.Controls.SetChildIndex(c, idx - 1);
            };
            Action<object> moveDown = (o) =>
            {
                Control c = (o as Control).Tag as Control;
                int idx = flowLayoutPanelMacros.Controls.GetChildIndex(c, false);
                if (idx >= 1 && idx <= flowLayoutPanelMacros.Controls.Count - 2) flowLayoutPanelMacros.Controls.SetChildIndex(c, idx + 1);
            };
            control.MoveUp = moveUp;
            control.MoveDown = moveDown;
            foreach (var id in tag.RequiredTagIDs)
            {
                tag = Settings.Instance.SelectedSystem.PredefinedTags.Single(t => t.CustomID == id);
                control = mcf.CreateMacroControl(tag);
                flowLayoutPanelMacros.Controls.Add(control);
                control.MoveUp = moveUp;
                control.MoveDown = moveDown;
            }
        }

        private void LoadScript()
        {
            this.textBoxScript.Text = File.ReadAllText(@".\Data\CPC.js");
        }

        private void LoadDDIPowers()
        {
            DataLoader loader = new DataLoader();
            powers = loader.LoadDDIPowers(textBoxPowers.Text);
            List<string> powerNames = new List<string>();
            foreach (Power power in powers)
            {
                powerNames.Add(power.name);
            }
            var source = new AutoCompleteStringCollection();
            source.AddRange(powerNames.ToArray());
            textBoxAutofill.AutoCompleteCustomSource = source;
            textBoxAutofill.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            textBoxAutofill.AutoCompleteSource = AutoCompleteSource.CustomSource;
        }

        private void buttonAutoFill_Click(object sender, EventArgs e)
        {
            if (powers.Count == 0)
            {
                MessageBox.Show("The powers file selected either does not exist or is empty. Ensure the file selected is a valid ddi_power.dat file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                AutoFill();
                RefreshMacro();
                PreviewRefresh();
            }
        }

        private void AutoFill()
        {
            Power power = powers.Find(x => x.name == textBoxAutofill.Text);
            if (power != null)
            {
                string patternTag = @"\{b\}\D+\{/b\}:|\{i\}\D+:\{/i\}";
                Regex regexTag = new Regex(patternTag);
                string patternContent = @"\{/b\}:.*|:\{/i\}.*";
                Regex regexContent = new Regex(patternContent);

                string[] descriptionArray = power.description.Split(new string[] { "{br}" }, StringSplitOptions.None);

                if (!String.IsNullOrWhiteSpace(power.name))
                {
                    AddMacro("name", power.name);
                }
                if (!String.IsNullOrWhiteSpace(power.usage))
                {
                    AddMacro("usage", power.usage);
                }
                if (!String.IsNullOrWhiteSpace(power.actionType))
                {
                    AddMacro("action", power.actionType);
                }
                if (!String.IsNullOrWhiteSpace(power.target))
                {
                    AddMacro("target", power.target);
                }
                if (!String.IsNullOrWhiteSpace(power.Require))
                {
                    AddMacro("Requirements", power.Require);
                }
                if (!String.IsNullOrWhiteSpace(power.attackAttribute))
                {
                    AddMacro("attack", GetAttack(power.attackAttribute, power.AttackVs));
                }
                if (!String.IsNullOrWhiteSpace(power.Damage))
                {
                    AddMacro("damage", GetDamage(power.Damage, power.DamageAttr, power.DamageType));
                }

                int infoNumber = 0;
                foreach (string str in descriptionArray)
                {
                    if (!String.IsNullOrWhiteSpace(str))
                    {
                        Match matchTag = regexTag.Match(str);
                        if (matchTag.Success)
                        {
                            string tag = matchTag.Value.Substring(3, matchTag.Value.Length - 8).Trim();
                            Match matchContent = regexContent.Match(str);
                            string content = matchContent.Value.Substring(5).Trim();
                            AddMacro(tag, content);
                        }
                        else
                        {
                            AddMacro(String.Format("Info{0}", infoNumber), str);
                            infoNumber++;
                        }
                    }
                }
            }
        }

        #region Obsolete
        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlName>().ToList().Count == 0)
            //{
            //    MacroControlName macroEntry = new MacroControlName();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void buttonCustom_Click(object sender, EventArgs e)
        {
            MacroControlFactory mcf = new MacroControlFactory();
            MacroControlBase macroEntry = mcf.Create(new Tag());
            macroEntry.Tag = 1;
            flowLayoutPanelMacros.Controls.Add(macroEntry);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanelMacros.Controls.OfType<MacroControlAction>().ToList().Count == 0)
            {
                MacroControlAction macroEntry = new MacroControlAction();
                macroEntry.Tag = 1;
                flowLayoutPanelMacros.Controls.Add(macroEntry);
            }
        }

        private void buttonUsage_Click(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlUsage>().ToList().Count == 0)
            //{
            //    MacroControlUsage macroEntry = new MacroControlUsage();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MacroControlTarget macroEntry = new MacroControlTarget();
            macroEntry.Tag = 1;
            flowLayoutPanelMacros.Controls.Add(macroEntry);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (flowLayoutPanelMacros.Controls.OfType<MacroControlKeywords>().ToList().Count == 0)
            {
                MacroControlKeywords macroEntry = new MacroControlKeywords();
                macroEntry.Tag = 1;
                flowLayoutPanelMacros.Controls.Add(macroEntry);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlAttack>().ToList().Count == 0)
            //{
            //    MacroControlAttack macroEntry = new MacroControlAttack();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlDamage>().ToList().Count == 0)
            //{
            //    MacroControlDamage macroEntry = new MacroControlDamage();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlHit>().ToList().Count == 0)
            //{
            //    MacroControlHit macroEntry = new MacroControlHit();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //MacroControlEffect macroEntry = new MacroControlEffect();
            //macroEntry.Tag = 1;
            //flowLayoutPanel1.Controls.Add(macroEntry);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the form?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                flowLayoutPanelMacros.Controls.Clear();
            }
        }

        private string GetAttack(string attackAttribute, string defense)
        {
            string output = "";
            if (!String.IsNullOrWhiteSpace(attackAttribute) && !String.IsNullOrWhiteSpace(defense))
            {
                string attackValue;
                switch (attackAttribute)
                {
                    case "attrStr":
                        attackValue = "Strength";
                        break;
                    case "attrCon":
                        attackValue = "Constitution";
                        break;
                    case "attrDex":
                        attackValue = "Dexterity";
                        break;
                    case "attrInt":
                        attackValue = "Intelligence";
                        break;
                    case "attrWis":
                        attackValue = "Wisdom";
                        break;
                    case "attrCha":
                        attackValue = "Charisma";
                        break;
                    default:
                        attackValue = "ATTACK ATTRIBUTE ERROR!";
                        break;
                }

                string defenseType;
                switch (defense)
                {
                    case "defAC":
                        defenseType = "AC";
                        break;
                    case "defFort":
                        defenseType = "Fortitude";
                        break;
                    case "defRef":
                        defenseType = "Reflex";
                        break;
                    case "defWill":
                        defenseType = "Will";
                        break;
                    default:
                        defenseType = "DEFENSE ERROR!";
                        break;
                }

                output = String.Format("[[1d20+{0}]] vs. {1}", attackValue, defenseType);
            }
            return output;
        }

        private string GetDamage(string damage, string damageAttribute, string damageType)
        {
            List<string> result = new List<string>();
            string output = "";

            if (!String.IsNullOrWhiteSpace(damage))
            {
                string damagePattern = @"Weapon\d";
                Regex regex = new Regex(damagePattern);
                Match match = regex.Match(damage);
                if (match.Success)
                {
                    //result.Add(String.Format("{0}{1}", match.Value.Substring(6, 1), comboBoxWeapon.Text));
                    result.Add(" ");
                }
            }

            if (!String.IsNullOrWhiteSpace(damageAttribute))
            {
                string attributeValue;
                switch (damageAttribute)
                {
                    case "attrStr":
                        attributeValue = "Strength modifier";
                        break;
                    case "attrCon":
                        attributeValue = "Constitution modifier";
                        break;
                    case "attrDex":
                        attributeValue = "Dexterity modifier";
                        break;
                    case "attrInt":
                        attributeValue = "Intelligence modifier";
                        break;
                    case "attrWis":
                        attributeValue = "Wisdom modifier";
                        break;
                    case "attrCha":
                        attributeValue = "Charisma modifier";
                        break;
                    default:
                        attributeValue = "DAMAGE ATTRIBUTE ERROR!";
                        break;
                }
                result.Add(attributeValue);
            }

            if (!String.IsNullOrWhiteSpace(damage) || !String.IsNullOrWhiteSpace(damageAttribute))
            {
                output = @"[[" + String.Join("+", result) + @"]]";
            }

            if (!String.IsNullOrWhiteSpace(damageType))
            {
                output += String.Format(" {0} damage", damageType);
            }
            return output;
        }

        private void RefreshMacro()
        {
            string macroString = "!power ";


            /*
                        List<MacroControlBase> c = flowLayoutPanel1.Controls.OfType<MacroControlBase>().ToList();
                        foreach (MacroControlBase macroControlBase in c)
                        {
                            if (!String.IsNullOrWhiteSpace(macroControlBase.MacroTag.TagValue) &&
                                !String.IsNullOrWhiteSpace(macroControlBase.MacroTag.ContentValue))
                            {
                                macroString += macroControlBase.MacroTag.GetMacroEntryString() + " ";
                            }
                        }
            */
            foreach (Control c in flowLayoutPanelMacros.Controls)
            {
                if (c is IMacroControl)
                    macroString += (c as IMacroControl).GetTagContentString() + " ";
            }
            textBoxTotalMacroString.Text = macroString;
        }

        private void AddMacro(string tag, string content)
        {
            DefaultControlFactory f = new DefaultControlFactory();
            Tag t = new Tag()
            {
                TagValue = tag,
                ContentValue = content,
                ControlType = "TextBoxControl"
            };
            MacroControlBase2 control = f.CreateMacroControl(t);
            flowLayoutPanelMacros.Controls.Add(control);
        }

        #endregion

        private void textBox2_Enter(object sender, EventArgs e)
        {
            RefreshMacro();
            PreviewRefresh();
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                textBoxTotalMacroString.SelectAll();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                textBoxTotalMacroString.DeselectAll();
            }
        }
/*
        private void button1_Click_1(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlName>().ToList().Count == 0)
            //{
            //    MacroControlName macroEntry = new MacroControlName();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void buttonCustom_Click(object sender, EventArgs e)
        {
            MacroControlFactory mcf = new MacroControlFactory();
            MacroControlBase macroEntry = mcf.Create(new Tag());
            macroEntry.Tag = 1;
            flowLayoutPanel1.Controls.Add(macroEntry);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.OfType<MacroControlAction>().ToList().Count == 0)
            {
                MacroControlAction macroEntry = new MacroControlAction();
                macroEntry.Tag = 1;
                flowLayoutPanel1.Controls.Add(macroEntry);
            }
        }

        private void buttonUsage_Click(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlUsage>().ToList().Count == 0)
            //{
            //    MacroControlUsage macroEntry = new MacroControlUsage();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MacroControlTarget macroEntry = new MacroControlTarget();
            macroEntry.Tag = 1;
            flowLayoutPanel1.Controls.Add(macroEntry);
        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            if (flowLayoutPanel1.Controls.OfType<MacroControlKeywords>().ToList().Count == 0)
            {
                MacroControlKeywords macroEntry = new MacroControlKeywords();
                macroEntry.Tag = 1;
                flowLayoutPanel1.Controls.Add(macroEntry);
            }
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlAttack>().ToList().Count == 0)
            //{
            //    MacroControlAttack macroEntry = new MacroControlAttack();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlDamage>().ToList().Count == 0)
            //{
            //    MacroControlDamage macroEntry = new MacroControlDamage();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //if (flowLayoutPanel1.Controls.OfType<MacroControlHit>().ToList().Count == 0)
            //{
            //    MacroControlHit macroEntry = new MacroControlHit();
            //    macroEntry.Tag = 1;
            //    flowLayoutPanel1.Controls.Add(macroEntry);
            //}
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //MacroControlEffect macroEntry = new MacroControlEffect();
            //macroEntry.Tag = 1;
            //flowLayoutPanel1.Controls.Add(macroEntry);
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to clear the form?", "WARNING!", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == System.Windows.Forms.DialogResult.Yes)
            {
                flowLayoutPanel1.Controls.Clear();
            }
        }*/

        private void textBoxAutoFill_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.A)
            {
                textBoxAutofill.SelectAll();
                e.SuppressKeyPress = true;
            }

            if (e.KeyCode == Keys.Escape)
            {
                textBoxAutofill.DeselectAll();
            }

            if (e.KeyCode == Keys.Enter)
            {
                AutoFill();
                RefreshMacro();
                PreviewRefresh();
            }
        }
        /*
        private void numericUpDownStrMod_Enter(object sender, EventArgs e)
        {
            numericUpDownStrMod.Select(0, numericUpDownStrMod.Text.Length);
        }

        private void numericUpDownConMod_Enter(object sender, EventArgs e)
        {
            numericUpDownConMod.Select(0, numericUpDownConMod.Text.Length);
        }

        private void numericUpDownDexMod_Enter(object sender, EventArgs e)
        {
            numericUpDownDexMod.Select(0, numericUpDownDexMod.Text.Length);
        }

        private void numericUpDownIntMod_Enter(object sender, EventArgs e)
        {
            numericUpDownIntMod.Select(0, numericUpDownIntMod.Text.Length);
        }

        private void numericUpDownWisMod_Enter(object sender, EventArgs e)
        {
            numericUpDownWisMod.Select(0, numericUpDownWisMod.Text.Length);
        }

        private void numericUpDownChaMod_Enter(object sender, EventArgs e)
        {
            numericUpDownChaMod.Select(0, numericUpDownChaMod.Text.Length);
        }
        */
        private void buttonOpenPowers_Click(object sender, EventArgs e)
        {
            openFileDialog1.DefaultExt = ".dat";
            openFileDialog1.FileName = "ddi_powers.dat";
            openFileDialog1.InitialDirectory = @"C:\";
            DialogResult fd = openFileDialog1.ShowDialog();
            if (fd == System.Windows.Forms.DialogResult.OK)
            {
                textBoxPowers.Text = openFileDialog1.FileName;
                LoadDDIPowers();
            }
        }

        private void PreviewRefresh()
        {
            webBrowser1.Document.InvokeScript("RunScript", new object[] { new Message(textBoxTotalMacroString.Text) });
        }

        private void comboBoxGameSystems_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cb = sender as ComboBox;
            if(cb != null) UpdatePredefinedTags(cb.SelectedItem as GameSystem);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            GenerateGameSystemForm form = new GenerateGameSystemForm();
            form.Show();
            form.FormClosed += form_FormClosed;
        }

        void form_FormClosed(object sender, FormClosedEventArgs e)
        {
            Settings.Instance.ReloadGameSystems();
            LoadSystems();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            MacroParserForm form = new MacroParserForm();
            if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                form.Tags.ForEach(AddMacroControl);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Will close form after asking for saving.");
        }

        private void flowLayoutPanel1_ControlAdded(object sender, ControlEventArgs e)
        {
            RefreshMacro();
        }

        private void flowLayoutPanel1_ControlRemoved(object sender, ControlEventArgs e)
        {
            RefreshMacro();
        }

        private void savectrlsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFileDialogMacro.RestoreDirectory = true;
            saveFileDialogMacro.InitialDirectory = Environment.CurrentDirectory + @"\Saves";
            saveFileDialogMacro.Filter = "R20CPCMG Macro (*.macro)|*.macro";
            saveFileDialogMacro.DefaultExt = ".macro";
            DialogResult result = saveFileDialogMacro.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Console.WriteLine(saveFileDialogMacro.FileName);
                MacroManager manager = new MacroManager();
                manager.Populate(flowLayoutPanelMacros);
                MacroManager.Save(saveFileDialogMacro.FileName, manager);
            }
        }

        private void loadMacroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialogMacro.RestoreDirectory = true;
            openFileDialogMacro.InitialDirectory = Environment.CurrentDirectory + @"\Saves";
            openFileDialogMacro.Filter = "R20CPCMG Macro (*.macro)|*.macro";
            openFileDialogMacro.DefaultExt = ".macro";
            openFileDialogMacro.FileName = "";
            DialogResult result = openFileDialogMacro.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                Console.WriteLine(openFileDialogMacro.FileName);
                MacroManager manager = MacroManager.Load(openFileDialogMacro.FileName);
                manager.ExtractControls(flowLayoutPanelMacros);
                RefreshMacro();
            }
        }
    }

}
