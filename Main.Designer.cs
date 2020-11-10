namespace _2048
{
    partial class Main
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.메뉴ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.무한모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.크기모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x4모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x5모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x6모드ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x7ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.x8ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.종료ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("MV Boli", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(351, 126);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 45);
            this.button1.TabIndex = 0;
            this.button1.Text = "New Game";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.메뉴ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(450, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 메뉴ToolStripMenuItem
            // 
            this.메뉴ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.무한모드ToolStripMenuItem,
            this.크기모드ToolStripMenuItem,
            this.종료ToolStripMenuItem});
            this.메뉴ToolStripMenuItem.Name = "메뉴ToolStripMenuItem";
            this.메뉴ToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.메뉴ToolStripMenuItem.Text = "메뉴";
            // 
            // 무한모드ToolStripMenuItem
            // 
            this.무한모드ToolStripMenuItem.Name = "무한모드ToolStripMenuItem";
            this.무한모드ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.무한모드ToolStripMenuItem.Text = "무한모드";
            this.무한모드ToolStripMenuItem.Click += new System.EventHandler(this.무한모드ToolStripMenuItem_Click);
            // 
            // 크기모드ToolStripMenuItem
            // 
            this.크기모드ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.x4모드ToolStripMenuItem,
            this.x5모드ToolStripMenuItem,
            this.x6모드ToolStripMenuItem,
            this.x7ToolStripMenuItem,
            this.x8ToolStripMenuItem});
            this.크기모드ToolStripMenuItem.Name = "크기모드ToolStripMenuItem";
            this.크기모드ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.크기모드ToolStripMenuItem.Text = "게임설정";
            // 
            // x4모드ToolStripMenuItem
            // 
            this.x4모드ToolStripMenuItem.Name = "x4모드ToolStripMenuItem";
            this.x4모드ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.x4모드ToolStripMenuItem.Text = "4x4";
            this.x4모드ToolStripMenuItem.Click += new System.EventHandler(this.x4모드ToolStripMenuItem_Click);
            // 
            // x5모드ToolStripMenuItem
            // 
            this.x5모드ToolStripMenuItem.Name = "x5모드ToolStripMenuItem";
            this.x5모드ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.x5모드ToolStripMenuItem.Text = "5x5";
            this.x5모드ToolStripMenuItem.Click += new System.EventHandler(this.x5모드ToolStripMenuItem_Click);
            // 
            // x6모드ToolStripMenuItem
            // 
            this.x6모드ToolStripMenuItem.Name = "x6모드ToolStripMenuItem";
            this.x6모드ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.x6모드ToolStripMenuItem.Text = "6x6";
            this.x6모드ToolStripMenuItem.Click += new System.EventHandler(this.x6모드ToolStripMenuItem_Click);
            // 
            // x7ToolStripMenuItem
            // 
            this.x7ToolStripMenuItem.Name = "x7ToolStripMenuItem";
            this.x7ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.x7ToolStripMenuItem.Text = "7x7";
            this.x7ToolStripMenuItem.Click += new System.EventHandler(this.x7ToolStripMenuItem_Click);
            // 
            // x8ToolStripMenuItem
            // 
            this.x8ToolStripMenuItem.Name = "x8ToolStripMenuItem";
            this.x8ToolStripMenuItem.Size = new System.Drawing.Size(94, 22);
            this.x8ToolStripMenuItem.Text = "8x8";
            this.x8ToolStripMenuItem.Click += new System.EventHandler(this.x8ToolStripMenuItem_Click);
            // 
            // 종료ToolStripMenuItem
            // 
            this.종료ToolStripMenuItem.Name = "종료ToolStripMenuItem";
            this.종료ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.종료ToolStripMenuItem.Text = "종료";
            this.종료ToolStripMenuItem.Click += new System.EventHandler(this.종료ToolStripMenuItem_Click);
            // 
            // panel1
            // 
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(450, 620);
            this.panel1.TabIndex = 2;
            this.panel1.Visible = false;
            // 
            // button2
            // 
            this.button2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("휴먼옛체", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button2.Location = new System.Drawing.Point(177, 298);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 61);
            this.button2.TabIndex = 1;
            this.button2.Text = "Retry";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("휴먼둥근헤드라인", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(95, 223);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(282, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Game Over!";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(185)))), ((int)(((byte)(173)))), ((int)(((byte)(162)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(450, 620);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2048!";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Main_KeyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 메뉴ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 무한모드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 종료ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 크기모드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x4모드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x5모드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x6모드ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x7ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem x8ToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
    }
}

