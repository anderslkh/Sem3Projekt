namespace DesktopConsumer.GUI.MenuPanels
{
    public abstract partial class SubBaseMenu : Form
    {
        public Panel MnuPanel;
        public Panel ContentPanel;

        public void ContentPanel_Resize(object sender, System.EventArgs e)
        {
            foreach (Control item in ContentPanel.Controls)
            {
                var frm = (Form)item;
                frm.Width = ContentPanel.Width;
                frm.Height = ContentPanel.Height;
            }
        }
        public void NavigateTo(Form form, Panel panel)
        {
            form.TopLevel = false;
            form.Size = panel.Size; // for responsive size
            panel.Controls.Clear();
            panel.Tag = form;
            panel.Resize += ContentPanel_Resize;
            panel.Controls.Add(form);
            form.BringToFront();
            form.Show();
        }

        public virtual void InitializeLayout(List<Button> buttonList)
        {
            this.MnuPanel = new System.Windows.Forms.Panel();
            this.ContentPanel = new System.Windows.Forms.Panel();
            this.FormBorderStyle = FormBorderStyle.None;
            this.SuspendLayout();
            // 
            // MnuPanel
            // 
            this.MnuPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.MnuPanel.Location = new System.Drawing.Point(0, 0);
            this.MnuPanel.Name = "MnuPanel";
            this.MnuPanel.Size = new System.Drawing.Size(189, 435);
            this.MnuPanel.TabIndex = 0;
            this.MnuPanel.BorderStyle = BorderStyle.FixedSingle;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(189, 0);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(589, 435);
            this.ContentPanel.TabIndex = 1;
            // 
            // BaseSubMenu
            // 
            this.ClientSize = new System.Drawing.Size(778, 435);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.MnuPanel);
            this.Name = "BaseSubMenu";
            this.ResumeLayout(false);

            AddElements(buttonList);
        }
        public virtual void AddElements(List<Button> buttons)
        {
            foreach (Button btn in buttons)
            {
                btn.Dock = DockStyle.Top;
                btn.Size = new System.Drawing.Size(173, 29);
                MnuPanel.Controls.Add(btn);
            }
        }
    }
}