using System;
using System.Drawing;
using System.Windows.Forms;

public class CustomMessageBoxForm : Form
{
    private Label lblMessage;
    private Button btnOK;
    private Button btnYes;
    private Button btnNo;

    private const int PaddingSpace = 40;
    private const int MaxTextWidth = 500;
    private readonly Font fixedFont = new Font("Segoe UI", 10);

    public CustomMessageBoxForm(string message, string title, MessageBoxButtons btns)
    {
        // Form settings
        this.Text = title;
        this.StartPosition = FormStartPosition.CenterScreen;
        this.FormBorderStyle = FormBorderStyle.FixedDialog;
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.ShowIcon = false;
        this.ShowInTaskbar = false;

        // Message label
        lblMessage = new Label
        {
            Text = message,
            Font = fixedFont,
            AutoSize = false,
            TextAlign = ContentAlignment.TopLeft,
            Location = new Point(20, 20)
        };
        this.Controls.Add(lblMessage);

        // Handle buttons
        if (btns == MessageBoxButtons.OK)
        {
            btnOK = new Button
            {
                Text = "OK",
                Width = 100,
                Height = 30
            };
            btnOK.Click += (s, e) => { this.DialogResult = DialogResult.OK; this.Close(); };
            this.Controls.Add(btnOK);
        }
        else if (btns == MessageBoxButtons.YesNo)
        {
            btnYes = new Button
            {
                Text = "Yes",
                Width = 100,
                Height = 30
            };
            btnNo = new Button
            {
                Text = "No",
                Width = 100,
                Height = 30
            };

            btnYes.Click += (s, e) => { this.DialogResult = DialogResult.Yes; this.Close(); };
            btnNo.Click += (s, e) => { this.DialogResult = DialogResult.No; this.Close(); };

            this.Controls.Add(btnYes);
            this.Controls.Add(btnNo);
        }

        AdjustLayout(btns);
    }

    private void AdjustLayout(MessageBoxButtons buttons)
    {
        SizeF textSize;
        using (Graphics g = lblMessage.CreateGraphics())
        {
            textSize = g.MeasureString(lblMessage.Text, fixedFont, MaxTextWidth);
        }

        lblMessage.Width = Math.Min(MaxTextWidth, (int)Math.Ceiling(textSize.Width));
        lblMessage.Height = (int)Math.Ceiling(textSize.Height);

        int formWidth = lblMessage.Width + PaddingSpace;
        int formHeight = lblMessage.Height + 80;
        this.ClientSize = new Size(formWidth, formHeight);

        int buttonTop = lblMessage.Bottom + 20;

        if (btnOK != null)
        {
            btnOK.Top = buttonTop;
            btnOK.Left = (this.ClientSize.Width - btnOK.Width) / 2;
        }
        else if (buttons == MessageBoxButtons.YesNo)
        {
            int spacing = 20;
            int totalWidth = btnYes.Width + spacing + btnNo.Width;
            int startX = (this.ClientSize.Width - totalWidth) / 2;

            btnYes.Top = btnNo.Top = buttonTop;
            btnYes.Left = startX;
            btnNo.Left = startX + btnYes.Width + spacing;
        }
    }

    // Static method to mimic MessageBox.Show
    public static bool Show(string message, string title = "Message", MessageBoxButtons btns = MessageBoxButtons.OK)
    {
        using (var form = new CustomMessageBoxForm(message, title, btns))
        {
            return form.ShowDialog() == DialogResult.Yes;
        }
    }
}
