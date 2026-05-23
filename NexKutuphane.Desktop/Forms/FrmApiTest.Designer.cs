namespace NexKutuphane.Desktop.Forms
{
    partial class FrmApiTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnTestBooks = new Button();
            lstBooks = new ListBox();
            SuspendLayout();
            // 
            // btnTestBooks
            // 
            btnTestBooks.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            btnTestBooks.Location = new Point(192, 12);
            btnTestBooks.Name = "btnTestBooks";
            btnTestBooks.Size = new Size(149, 23);
            btnTestBooks.TabIndex = 0;
            btnTestBooks.Text = "Kitapları Test Et";
            btnTestBooks.UseVisualStyleBackColor = true;
            btnTestBooks.Click += btnTestBooks_Click;
            // 
            // lstBooks
            // 
            lstBooks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lstBooks.FormattingEnabled = true;
            lstBooks.Location = new Point(12, 44);
            lstBooks.Name = "lstBooks";
            lstBooks.Size = new Size(509, 394);
            lstBooks.TabIndex = 1;
            // 
            // FrmApiTest
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(527, 450);
            Controls.Add(lstBooks);
            Controls.Add(btnTestBooks);
            Name = "FrmApiTest";
            Text = "FrmApiTest";
            ResumeLayout(false);
        }

        #endregion

        private Button btnTestBooks;
        private ListBox lstBooks;
    }
}