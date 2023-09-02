namespace GraphCalcuculator
{
    partial class GraphCalcMForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.But_Vertex_Add = new System.Windows.Forms.Button();
            this.But_Edge_Add = new System.Windows.Forms.Button();
            this.Box_Vertex_Remove = new System.Windows.Forms.GroupBox();
            this.But_Vertex_Remove = new System.Windows.Forms.Button();
            this.CBox_Vertex_Remove = new System.Windows.Forms.ComboBox();
            this.But_Edge_Remove = new System.Windows.Forms.Button();
            this.Box_Edge_Add = new System.Windows.Forms.GroupBox();
            this.ChBox_Edge_Add_Oriented = new System.Windows.Forms.CheckBox();
            this.TBox_Edge_Add_Length = new System.Windows.Forms.TextBox();
            this.CBox_Edge_Add_To = new System.Windows.Forms.ComboBox();
            this.CBox_Edge_Add_From = new System.Windows.Forms.ComboBox();
            this.Tab_Main = new System.Windows.Forms.TableLayoutPanel();
            this.Box_Edge_Remove = new System.Windows.Forms.GroupBox();
            this.CBox_Edge_Remove_To = new System.Windows.Forms.ComboBox();
            this.CBox_Edge_Remove_From = new System.Windows.Forms.ComboBox();
            this.Box_Print_Control = new System.Windows.Forms.GroupBox();
            this.But_Print_OUForm = new System.Windows.Forms.Button();
            this.But_Print_File = new System.Windows.Forms.Button();
            this.CBox_Print_Mode = new System.Windows.Forms.ComboBox();
            this.Box_Graph_Create = new System.Windows.Forms.GroupBox();
            this.But_Graph_Create = new System.Windows.Forms.Button();
            this.TBox_Graph_NumVer = new System.Windows.Forms.TextBox();
            this.Box_Vertex_Add = new System.Windows.Forms.GroupBox();
            this.TBox_Vertex_Add = new System.Windows.Forms.TextBox();
            this.Box_Edge_Change = new System.Windows.Forms.GroupBox();
            this.ChBox_Edge_Change_Oriented = new System.Windows.Forms.CheckBox();
            this.But_Edge_Change = new System.Windows.Forms.Button();
            this.TBox_Edge_Change_Length = new System.Windows.Forms.TextBox();
            this.CBox_Edge_Change_To = new System.Windows.Forms.ComboBox();
            this.CBox_Edge_Change_From = new System.Windows.Forms.ComboBox();
            this.But_Graph_Load = new System.Windows.Forms.Button();
            this.TabControl_Main = new System.Windows.Forms.TabControl();
            this.TabPage_Main = new System.Windows.Forms.TabPage();
            this.TabPage_Algorithms = new System.Windows.Forms.TabPage();
            this.Tab_Algorithms = new System.Windows.Forms.TableLayoutPanel();
            this.Box_Traversals = new System.Windows.Forms.GroupBox();
            this.But_Traverse = new System.Windows.Forms.Button();
            this.CBox_Traversal_Type = new System.Windows.Forms.ComboBox();
            this.CBox_Traversal_From = new System.Windows.Forms.ComboBox();
            this.Box_SPath = new System.Windows.Forms.GroupBox();
            this.But_SPath_Find = new System.Windows.Forms.Button();
            this.CBox_SPath_To = new System.Windows.Forms.ComboBox();
            this.CBox_SPath_From = new System.Windows.Forms.ComboBox();
            this.Box_Eulerian = new System.Windows.Forms.GroupBox();
            this.But_EuPath_Find = new System.Windows.Forms.Button();
            this.But_EuCycle_Find = new System.Windows.Forms.Button();
            this.Box_Hamiltonian = new System.Windows.Forms.GroupBox();
            this.ToolTip_Main = new System.Windows.Forms.ToolTip(this.components);
            this.Box_Vertex_Remove.SuspendLayout();
            this.Box_Edge_Add.SuspendLayout();
            this.Tab_Main.SuspendLayout();
            this.Box_Edge_Remove.SuspendLayout();
            this.Box_Print_Control.SuspendLayout();
            this.Box_Graph_Create.SuspendLayout();
            this.Box_Vertex_Add.SuspendLayout();
            this.Box_Edge_Change.SuspendLayout();
            this.TabControl_Main.SuspendLayout();
            this.TabPage_Main.SuspendLayout();
            this.TabPage_Algorithms.SuspendLayout();
            this.Tab_Algorithms.SuspendLayout();
            this.Box_Traversals.SuspendLayout();
            this.Box_SPath.SuspendLayout();
            this.Box_Eulerian.SuspendLayout();
            this.SuspendLayout();
            // 
            // But_Vertex_Add
            // 
            this.But_Vertex_Add.Enabled = false;
            this.But_Vertex_Add.Location = new System.Drawing.Point(87, 17);
            this.But_Vertex_Add.Name = "But_Vertex_Add";
            this.But_Vertex_Add.Size = new System.Drawing.Size(271, 24);
            this.But_Vertex_Add.TabIndex = 1;
            this.But_Vertex_Add.Text = "Добавить вершину";
            this.But_Vertex_Add.UseVisualStyleBackColor = true;
            this.But_Vertex_Add.Click += new System.EventHandler(this.But_Vertex_Add_Click);
            // 
            // But_Edge_Add
            // 
            this.But_Edge_Add.Enabled = false;
            this.But_Edge_Add.Location = new System.Drawing.Point(168, 44);
            this.But_Edge_Add.Name = "But_Edge_Add";
            this.But_Edge_Add.Size = new System.Drawing.Size(190, 23);
            this.But_Edge_Add.TabIndex = 3;
            this.But_Edge_Add.Text = "Добавить ребро";
            this.But_Edge_Add.UseVisualStyleBackColor = true;
            this.But_Edge_Add.Click += new System.EventHandler(this.But_Edge_Add_Click);
            // 
            // Box_Vertex_Remove
            // 
            this.Box_Vertex_Remove.Controls.Add(this.But_Vertex_Remove);
            this.Box_Vertex_Remove.Controls.Add(this.CBox_Vertex_Remove);
            this.Box_Vertex_Remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Vertex_Remove.Location = new System.Drawing.Point(3, 63);
            this.Box_Vertex_Remove.Name = "Box_Vertex_Remove";
            this.Box_Vertex_Remove.Size = new System.Drawing.Size(364, 54);
            this.Box_Vertex_Remove.TabIndex = 5;
            this.Box_Vertex_Remove.TabStop = false;
            this.Box_Vertex_Remove.Text = "Удаление вершины";
            // 
            // But_Vertex_Remove
            // 
            this.But_Vertex_Remove.Enabled = false;
            this.But_Vertex_Remove.Location = new System.Drawing.Point(87, 17);
            this.But_Vertex_Remove.Name = "But_Vertex_Remove";
            this.But_Vertex_Remove.Size = new System.Drawing.Size(271, 23);
            this.But_Vertex_Remove.TabIndex = 2;
            this.But_Vertex_Remove.Text = "Удалить вершину";
            this.But_Vertex_Remove.UseVisualStyleBackColor = true;
            this.But_Vertex_Remove.Click += new System.EventHandler(this.But_Vertex_Remove_Click);
            // 
            // CBox_Vertex_Remove
            // 
            this.CBox_Vertex_Remove.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_Vertex_Remove.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_Vertex_Remove.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Vertex_Remove.Enabled = false;
            this.CBox_Vertex_Remove.FormattingEnabled = true;
            this.CBox_Vertex_Remove.Location = new System.Drawing.Point(6, 19);
            this.CBox_Vertex_Remove.Name = "CBox_Vertex_Remove";
            this.CBox_Vertex_Remove.Size = new System.Drawing.Size(75, 21);
            this.CBox_Vertex_Remove.TabIndex = 3;
            this.ToolTip_Main.SetToolTip(this.CBox_Vertex_Remove, "Номер удаляемой вершины");
            // 
            // But_Edge_Remove
            // 
            this.But_Edge_Remove.Enabled = false;
            this.But_Edge_Remove.Location = new System.Drawing.Point(168, 17);
            this.But_Edge_Remove.Name = "But_Edge_Remove";
            this.But_Edge_Remove.Size = new System.Drawing.Size(190, 23);
            this.But_Edge_Remove.TabIndex = 6;
            this.But_Edge_Remove.Text = "Удалить ребро";
            this.But_Edge_Remove.UseVisualStyleBackColor = true;
            this.But_Edge_Remove.Click += new System.EventHandler(this.But_Edge_Remove_Click);
            // 
            // Box_Edge_Add
            // 
            this.Box_Edge_Add.Controls.Add(this.ChBox_Edge_Add_Oriented);
            this.Box_Edge_Add.Controls.Add(this.TBox_Edge_Add_Length);
            this.Box_Edge_Add.Controls.Add(this.CBox_Edge_Add_To);
            this.Box_Edge_Add.Controls.Add(this.CBox_Edge_Add_From);
            this.Box_Edge_Add.Controls.Add(this.But_Edge_Add);
            this.Box_Edge_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Edge_Add.Location = new System.Drawing.Point(3, 123);
            this.Box_Edge_Add.Name = "Box_Edge_Add";
            this.Box_Edge_Add.Size = new System.Drawing.Size(364, 74);
            this.Box_Edge_Add.TabIndex = 7;
            this.Box_Edge_Add.TabStop = false;
            this.Box_Edge_Add.Text = "Добавление ребра";
            // 
            // ChBox_Edge_Add_Oriented
            // 
            this.ChBox_Edge_Add_Oriented.AutoSize = true;
            this.ChBox_Edge_Add_Oriented.Enabled = false;
            this.ChBox_Edge_Add_Oriented.Location = new System.Drawing.Point(168, 21);
            this.ChBox_Edge_Add_Oriented.Name = "ChBox_Edge_Add_Oriented";
            this.ChBox_Edge_Add_Oriented.Size = new System.Drawing.Size(117, 17);
            this.ChBox_Edge_Add_Oriented.TabIndex = 4;
            this.ChBox_Edge_Add_Oriented.Text = "Ориентированное";
            this.ToolTip_Main.SetToolTip(this.ChBox_Edge_Add_Oriented, "Является ли ребро ориентированным");
            this.ChBox_Edge_Add_Oriented.UseVisualStyleBackColor = true;
            // 
            // TBox_Edge_Add_Length
            // 
            this.TBox_Edge_Add_Length.Enabled = false;
            this.TBox_Edge_Add_Length.Location = new System.Drawing.Point(6, 46);
            this.TBox_Edge_Add_Length.Name = "TBox_Edge_Add_Length";
            this.TBox_Edge_Add_Length.Size = new System.Drawing.Size(156, 20);
            this.TBox_Edge_Add_Length.TabIndex = 9;
            this.ToolTip_Main.SetToolTip(this.TBox_Edge_Add_Length, "Длина ребра");
            this.TBox_Edge_Add_Length.TextChanged += new System.EventHandler(this.TBox_Edge_Add_Length_TextChanged);
            // 
            // CBox_Edge_Add_To
            // 
            this.CBox_Edge_Add_To.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_Edge_Add_To.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_Edge_Add_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Edge_Add_To.Enabled = false;
            this.CBox_Edge_Add_To.FormattingEnabled = true;
            this.CBox_Edge_Add_To.Location = new System.Drawing.Point(87, 19);
            this.CBox_Edge_Add_To.Name = "CBox_Edge_Add_To";
            this.CBox_Edge_Add_To.Size = new System.Drawing.Size(75, 21);
            this.CBox_Edge_Add_To.TabIndex = 8;
            this.ToolTip_Main.SetToolTip(this.CBox_Edge_Add_To, "Номер конечной вершины");
            this.CBox_Edge_Add_To.SelectedIndexChanged += new System.EventHandler(this.CBox_Edge_Add_To_SelectedIndexChanged);
            // 
            // CBox_Edge_Add_From
            // 
            this.CBox_Edge_Add_From.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_Edge_Add_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_Edge_Add_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Edge_Add_From.Enabled = false;
            this.CBox_Edge_Add_From.FormattingEnabled = true;
            this.CBox_Edge_Add_From.Location = new System.Drawing.Point(6, 19);
            this.CBox_Edge_Add_From.Name = "CBox_Edge_Add_From";
            this.CBox_Edge_Add_From.Size = new System.Drawing.Size(75, 21);
            this.CBox_Edge_Add_From.TabIndex = 7;
            this.ToolTip_Main.SetToolTip(this.CBox_Edge_Add_From, "Номер исходной вершины");
            this.CBox_Edge_Add_From.SelectedIndexChanged += new System.EventHandler(this.CBox_Edge_Add_From_SelectedIndexChanged);
            // 
            // Tab_Main
            // 
            this.Tab_Main.ColumnCount = 1;
            this.Tab_Main.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tab_Main.Controls.Add(this.Box_Vertex_Remove, 0, 1);
            this.Tab_Main.Controls.Add(this.Box_Edge_Add, 0, 2);
            this.Tab_Main.Controls.Add(this.Box_Edge_Remove, 0, 4);
            this.Tab_Main.Controls.Add(this.Box_Print_Control, 0, 5);
            this.Tab_Main.Controls.Add(this.Box_Graph_Create, 0, 6);
            this.Tab_Main.Controls.Add(this.Box_Vertex_Add, 0, 0);
            this.Tab_Main.Controls.Add(this.Box_Edge_Change, 0, 3);
            this.Tab_Main.Controls.Add(this.But_Graph_Load, 0, 7);
            this.Tab_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_Main.Location = new System.Drawing.Point(3, 3);
            this.Tab_Main.Name = "Tab_Main";
            this.Tab_Main.RowCount = 8;
            this.Tab_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Tab_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Tab_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.Tab_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.Tab_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Tab_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.Tab_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Tab_Main.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tab_Main.Size = new System.Drawing.Size(370, 509);
            this.Tab_Main.TabIndex = 8;
            // 
            // Box_Edge_Remove
            // 
            this.Box_Edge_Remove.Controls.Add(this.CBox_Edge_Remove_To);
            this.Box_Edge_Remove.Controls.Add(this.CBox_Edge_Remove_From);
            this.Box_Edge_Remove.Controls.Add(this.But_Edge_Remove);
            this.Box_Edge_Remove.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Edge_Remove.Location = new System.Drawing.Point(3, 283);
            this.Box_Edge_Remove.Name = "Box_Edge_Remove";
            this.Box_Edge_Remove.Size = new System.Drawing.Size(364, 54);
            this.Box_Edge_Remove.TabIndex = 9;
            this.Box_Edge_Remove.TabStop = false;
            this.Box_Edge_Remove.Text = "Удаление ребра";
            // 
            // CBox_Edge_Remove_To
            // 
            this.CBox_Edge_Remove_To.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_Edge_Remove_To.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_Edge_Remove_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Edge_Remove_To.Enabled = false;
            this.CBox_Edge_Remove_To.FormattingEnabled = true;
            this.CBox_Edge_Remove_To.Location = new System.Drawing.Point(87, 19);
            this.CBox_Edge_Remove_To.Name = "CBox_Edge_Remove_To";
            this.CBox_Edge_Remove_To.Size = new System.Drawing.Size(75, 21);
            this.CBox_Edge_Remove_To.TabIndex = 8;
            this.ToolTip_Main.SetToolTip(this.CBox_Edge_Remove_To, "Номер конечной вершины");
            // 
            // CBox_Edge_Remove_From
            // 
            this.CBox_Edge_Remove_From.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_Edge_Remove_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_Edge_Remove_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Edge_Remove_From.Enabled = false;
            this.CBox_Edge_Remove_From.FormattingEnabled = true;
            this.CBox_Edge_Remove_From.Location = new System.Drawing.Point(6, 19);
            this.CBox_Edge_Remove_From.Name = "CBox_Edge_Remove_From";
            this.CBox_Edge_Remove_From.Size = new System.Drawing.Size(75, 21);
            this.CBox_Edge_Remove_From.TabIndex = 7;
            this.ToolTip_Main.SetToolTip(this.CBox_Edge_Remove_From, "Номер исходной вершины");
            this.CBox_Edge_Remove_From.SelectedIndexChanged += new System.EventHandler(this.CBox_Edge_Remove_From_SelectedIndexChanged);
            // 
            // Box_Print_Control
            // 
            this.Box_Print_Control.Controls.Add(this.But_Print_OUForm);
            this.Box_Print_Control.Controls.Add(this.But_Print_File);
            this.Box_Print_Control.Controls.Add(this.CBox_Print_Mode);
            this.Box_Print_Control.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Print_Control.Location = new System.Drawing.Point(3, 343);
            this.Box_Print_Control.Name = "Box_Print_Control";
            this.Box_Print_Control.Size = new System.Drawing.Size(364, 74);
            this.Box_Print_Control.TabIndex = 10;
            this.Box_Print_Control.TabStop = false;
            this.Box_Print_Control.Text = "Вывод графа";
            // 
            // But_Print_OUForm
            // 
            this.But_Print_OUForm.Location = new System.Drawing.Point(168, 46);
            this.But_Print_OUForm.Name = "But_Print_OUForm";
            this.But_Print_OUForm.Size = new System.Drawing.Size(190, 23);
            this.But_Print_OUForm.TabIndex = 2;
            this.But_Print_OUForm.Text = "Редактирование графа";
            this.But_Print_OUForm.UseVisualStyleBackColor = true;
            this.But_Print_OUForm.Click += new System.EventHandler(this.But_Print_OUForm_Click);
            // 
            // But_Print_File
            // 
            this.But_Print_File.Location = new System.Drawing.Point(6, 46);
            this.But_Print_File.Name = "But_Print_File";
            this.But_Print_File.Size = new System.Drawing.Size(156, 23);
            this.But_Print_File.TabIndex = 1;
            this.But_Print_File.Text = "Вывод в файл";
            this.But_Print_File.UseVisualStyleBackColor = true;
            this.But_Print_File.Click += new System.EventHandler(this.But_Print_File_Click);
            // 
            // CBox_Print_Mode
            // 
            this.CBox_Print_Mode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Print_Mode.FormattingEnabled = true;
            this.CBox_Print_Mode.Items.AddRange(new object[] {
            "Списки вершин и рёбер.",
            "Матрица смежности."});
            this.CBox_Print_Mode.Location = new System.Drawing.Point(6, 19);
            this.CBox_Print_Mode.Name = "CBox_Print_Mode";
            this.CBox_Print_Mode.Size = new System.Drawing.Size(352, 21);
            this.CBox_Print_Mode.TabIndex = 0;
            this.ToolTip_Main.SetToolTip(this.CBox_Print_Mode, "Вид представления графа");
            this.CBox_Print_Mode.SelectedIndexChanged += new System.EventHandler(this.CBox_Print_Mode_SelectedIndexChanged);
            // 
            // Box_Graph_Create
            // 
            this.Box_Graph_Create.Controls.Add(this.But_Graph_Create);
            this.Box_Graph_Create.Controls.Add(this.TBox_Graph_NumVer);
            this.Box_Graph_Create.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Graph_Create.Location = new System.Drawing.Point(3, 423);
            this.Box_Graph_Create.Name = "Box_Graph_Create";
            this.Box_Graph_Create.Size = new System.Drawing.Size(364, 54);
            this.Box_Graph_Create.TabIndex = 11;
            this.Box_Graph_Create.TabStop = false;
            this.Box_Graph_Create.Text = "Создание графа без рёбер";
            // 
            // But_Graph_Create
            // 
            this.But_Graph_Create.Enabled = false;
            this.But_Graph_Create.Location = new System.Drawing.Point(87, 17);
            this.But_Graph_Create.Name = "But_Graph_Create";
            this.But_Graph_Create.Size = new System.Drawing.Size(271, 23);
            this.But_Graph_Create.TabIndex = 2;
            this.But_Graph_Create.Text = "Создать граф";
            this.But_Graph_Create.UseVisualStyleBackColor = true;
            this.But_Graph_Create.Click += new System.EventHandler(this.But_Graph_Create_Click);
            // 
            // TBox_Graph_NumVer
            // 
            this.TBox_Graph_NumVer.Location = new System.Drawing.Point(6, 19);
            this.TBox_Graph_NumVer.Name = "TBox_Graph_NumVer";
            this.TBox_Graph_NumVer.Size = new System.Drawing.Size(75, 20);
            this.TBox_Graph_NumVer.TabIndex = 0;
            this.ToolTip_Main.SetToolTip(this.TBox_Graph_NumVer, "Количество вершин в создаваемом графе");
            this.TBox_Graph_NumVer.TextChanged += new System.EventHandler(this.TBox_Graph_NumVer_TextChanged);
            // 
            // Box_Vertex_Add
            // 
            this.Box_Vertex_Add.Controls.Add(this.TBox_Vertex_Add);
            this.Box_Vertex_Add.Controls.Add(this.But_Vertex_Add);
            this.Box_Vertex_Add.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Vertex_Add.Location = new System.Drawing.Point(3, 3);
            this.Box_Vertex_Add.Name = "Box_Vertex_Add";
            this.Box_Vertex_Add.Size = new System.Drawing.Size(364, 54);
            this.Box_Vertex_Add.TabIndex = 12;
            this.Box_Vertex_Add.TabStop = false;
            this.Box_Vertex_Add.Text = "Добавление вершины";
            // 
            // TBox_Vertex_Add
            // 
            this.TBox_Vertex_Add.Location = new System.Drawing.Point(6, 20);
            this.TBox_Vertex_Add.Name = "TBox_Vertex_Add";
            this.TBox_Vertex_Add.Size = new System.Drawing.Size(75, 20);
            this.TBox_Vertex_Add.TabIndex = 2;
            this.ToolTip_Main.SetToolTip(this.TBox_Vertex_Add, "Номер добавляемой вершины");
            this.TBox_Vertex_Add.TextChanged += new System.EventHandler(this.TBox_Vertex_Add_TextChanged);
            // 
            // Box_Edge_Change
            // 
            this.Box_Edge_Change.Controls.Add(this.ChBox_Edge_Change_Oriented);
            this.Box_Edge_Change.Controls.Add(this.But_Edge_Change);
            this.Box_Edge_Change.Controls.Add(this.TBox_Edge_Change_Length);
            this.Box_Edge_Change.Controls.Add(this.CBox_Edge_Change_To);
            this.Box_Edge_Change.Controls.Add(this.CBox_Edge_Change_From);
            this.Box_Edge_Change.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Edge_Change.Location = new System.Drawing.Point(3, 203);
            this.Box_Edge_Change.Name = "Box_Edge_Change";
            this.Box_Edge_Change.Size = new System.Drawing.Size(364, 74);
            this.Box_Edge_Change.TabIndex = 13;
            this.Box_Edge_Change.TabStop = false;
            this.Box_Edge_Change.Text = "Изменение ребра";
            // 
            // ChBox_Edge_Change_Oriented
            // 
            this.ChBox_Edge_Change_Oriented.AutoSize = true;
            this.ChBox_Edge_Change_Oriented.Enabled = false;
            this.ChBox_Edge_Change_Oriented.Location = new System.Drawing.Point(168, 21);
            this.ChBox_Edge_Change_Oriented.Name = "ChBox_Edge_Change_Oriented";
            this.ChBox_Edge_Change_Oriented.Size = new System.Drawing.Size(117, 17);
            this.ChBox_Edge_Change_Oriented.TabIndex = 4;
            this.ChBox_Edge_Change_Oriented.Text = "Ориентированное";
            this.ToolTip_Main.SetToolTip(this.ChBox_Edge_Change_Oriented, "Является ли ребро ориентированным");
            this.ChBox_Edge_Change_Oriented.UseVisualStyleBackColor = true;
            // 
            // But_Edge_Change
            // 
            this.But_Edge_Change.Enabled = false;
            this.But_Edge_Change.Location = new System.Drawing.Point(168, 46);
            this.But_Edge_Change.Name = "But_Edge_Change";
            this.But_Edge_Change.Size = new System.Drawing.Size(190, 23);
            this.But_Edge_Change.TabIndex = 3;
            this.But_Edge_Change.Text = "Изменить ребро";
            this.But_Edge_Change.UseVisualStyleBackColor = true;
            this.But_Edge_Change.Click += new System.EventHandler(this.But_Edge_Change_Click);
            // 
            // TBox_Edge_Change_Length
            // 
            this.TBox_Edge_Change_Length.Enabled = false;
            this.TBox_Edge_Change_Length.Location = new System.Drawing.Point(6, 48);
            this.TBox_Edge_Change_Length.Name = "TBox_Edge_Change_Length";
            this.TBox_Edge_Change_Length.Size = new System.Drawing.Size(156, 20);
            this.TBox_Edge_Change_Length.TabIndex = 2;
            this.ToolTip_Main.SetToolTip(this.TBox_Edge_Change_Length, "Длина ребра");
            this.TBox_Edge_Change_Length.TextChanged += new System.EventHandler(this.TBox_Edge_Change_Length_TextChanged);
            // 
            // CBox_Edge_Change_To
            // 
            this.CBox_Edge_Change_To.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_Edge_Change_To.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_Edge_Change_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Edge_Change_To.Enabled = false;
            this.CBox_Edge_Change_To.FormattingEnabled = true;
            this.CBox_Edge_Change_To.Location = new System.Drawing.Point(87, 19);
            this.CBox_Edge_Change_To.Name = "CBox_Edge_Change_To";
            this.CBox_Edge_Change_To.Size = new System.Drawing.Size(75, 21);
            this.CBox_Edge_Change_To.TabIndex = 1;
            this.ToolTip_Main.SetToolTip(this.CBox_Edge_Change_To, "Номер конечной вершины");
            this.CBox_Edge_Change_To.SelectedIndexChanged += new System.EventHandler(this.CBox_Edge_Change_To_SelectedIndexChanged);
            // 
            // CBox_Edge_Change_From
            // 
            this.CBox_Edge_Change_From.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_Edge_Change_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_Edge_Change_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Edge_Change_From.Enabled = false;
            this.CBox_Edge_Change_From.FormattingEnabled = true;
            this.CBox_Edge_Change_From.Location = new System.Drawing.Point(6, 19);
            this.CBox_Edge_Change_From.Name = "CBox_Edge_Change_From";
            this.CBox_Edge_Change_From.Size = new System.Drawing.Size(75, 21);
            this.CBox_Edge_Change_From.TabIndex = 0;
            this.ToolTip_Main.SetToolTip(this.CBox_Edge_Change_From, "Номер исходной вершины");
            this.CBox_Edge_Change_From.SelectedIndexChanged += new System.EventHandler(this.CBox_Edge_Change_From_SelectedIndexChanged);
            // 
            // But_Graph_Load
            // 
            this.But_Graph_Load.Dock = System.Windows.Forms.DockStyle.Fill;
            this.But_Graph_Load.Location = new System.Drawing.Point(3, 483);
            this.But_Graph_Load.Name = "But_Graph_Load";
            this.But_Graph_Load.Size = new System.Drawing.Size(364, 23);
            this.But_Graph_Load.TabIndex = 14;
            this.But_Graph_Load.Text = "Загрузить граф из файла";
            this.But_Graph_Load.UseVisualStyleBackColor = true;
            this.But_Graph_Load.Click += new System.EventHandler(this.But_Graph_Load_Click);
            // 
            // TabControl_Main
            // 
            this.TabControl_Main.Controls.Add(this.TabPage_Main);
            this.TabControl_Main.Controls.Add(this.TabPage_Algorithms);
            this.TabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TabControl_Main.Location = new System.Drawing.Point(0, 0);
            this.TabControl_Main.Name = "TabControl_Main";
            this.TabControl_Main.SelectedIndex = 0;
            this.TabControl_Main.Size = new System.Drawing.Size(384, 541);
            this.TabControl_Main.TabIndex = 9;
            // 
            // TabPage_Main
            // 
            this.TabPage_Main.Controls.Add(this.Tab_Main);
            this.TabPage_Main.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Main.Name = "TabPage_Main";
            this.TabPage_Main.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Main.Size = new System.Drawing.Size(376, 515);
            this.TabPage_Main.TabIndex = 0;
            this.TabPage_Main.Text = "Изменение графа";
            this.TabPage_Main.UseVisualStyleBackColor = true;
            // 
            // TabPage_Algorithms
            // 
            this.TabPage_Algorithms.Controls.Add(this.Tab_Algorithms);
            this.TabPage_Algorithms.Location = new System.Drawing.Point(4, 22);
            this.TabPage_Algorithms.Name = "TabPage_Algorithms";
            this.TabPage_Algorithms.Padding = new System.Windows.Forms.Padding(3);
            this.TabPage_Algorithms.Size = new System.Drawing.Size(376, 515);
            this.TabPage_Algorithms.TabIndex = 2;
            this.TabPage_Algorithms.Text = "Алгоритмы на графе";
            this.TabPage_Algorithms.UseVisualStyleBackColor = true;
            // 
            // Tab_Algorithms
            // 
            this.Tab_Algorithms.ColumnCount = 1;
            this.Tab_Algorithms.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tab_Algorithms.Controls.Add(this.Box_Traversals, 0, 0);
            this.Tab_Algorithms.Controls.Add(this.Box_SPath, 0, 1);
            this.Tab_Algorithms.Controls.Add(this.Box_Eulerian, 0, 2);
            this.Tab_Algorithms.Controls.Add(this.Box_Hamiltonian, 0, 3);
            this.Tab_Algorithms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tab_Algorithms.Location = new System.Drawing.Point(3, 3);
            this.Tab_Algorithms.Name = "Tab_Algorithms";
            this.Tab_Algorithms.RowCount = 5;
            this.Tab_Algorithms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Tab_Algorithms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Tab_Algorithms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Tab_Algorithms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.Tab_Algorithms.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.Tab_Algorithms.Size = new System.Drawing.Size(370, 509);
            this.Tab_Algorithms.TabIndex = 0;
            // 
            // Box_Traversals
            // 
            this.Box_Traversals.Controls.Add(this.But_Traverse);
            this.Box_Traversals.Controls.Add(this.CBox_Traversal_Type);
            this.Box_Traversals.Controls.Add(this.CBox_Traversal_From);
            this.Box_Traversals.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Traversals.Location = new System.Drawing.Point(3, 3);
            this.Box_Traversals.Name = "Box_Traversals";
            this.Box_Traversals.Size = new System.Drawing.Size(364, 54);
            this.Box_Traversals.TabIndex = 0;
            this.Box_Traversals.TabStop = false;
            this.Box_Traversals.Text = "Обходы графа";
            // 
            // But_Traverse
            // 
            this.But_Traverse.Enabled = false;
            this.But_Traverse.Location = new System.Drawing.Point(214, 17);
            this.But_Traverse.Name = "But_Traverse";
            this.But_Traverse.Size = new System.Drawing.Size(144, 23);
            this.But_Traverse.TabIndex = 2;
            this.But_Traverse.Text = "Обойти граф";
            this.But_Traverse.UseVisualStyleBackColor = true;
            this.But_Traverse.Click += new System.EventHandler(this.But_Traverse_Click);
            // 
            // CBox_Traversal_Type
            // 
            this.CBox_Traversal_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Traversal_Type.Enabled = false;
            this.CBox_Traversal_Type.FormattingEnabled = true;
            this.CBox_Traversal_Type.Items.AddRange(new object[] {
            "В глубину",
            "В ширину"});
            this.CBox_Traversal_Type.Location = new System.Drawing.Point(87, 19);
            this.CBox_Traversal_Type.Name = "CBox_Traversal_Type";
            this.CBox_Traversal_Type.Size = new System.Drawing.Size(121, 21);
            this.CBox_Traversal_Type.TabIndex = 1;
            this.ToolTip_Main.SetToolTip(this.CBox_Traversal_Type, "Тип обхода графа");
            // 
            // CBox_Traversal_From
            // 
            this.CBox_Traversal_From.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_Traversal_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_Traversal_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_Traversal_From.Enabled = false;
            this.CBox_Traversal_From.FormattingEnabled = true;
            this.CBox_Traversal_From.Location = new System.Drawing.Point(6, 19);
            this.CBox_Traversal_From.Name = "CBox_Traversal_From";
            this.CBox_Traversal_From.Size = new System.Drawing.Size(75, 21);
            this.CBox_Traversal_From.TabIndex = 0;
            this.ToolTip_Main.SetToolTip(this.CBox_Traversal_From, "Номер исходной вершины");
            // 
            // Box_SPath
            // 
            this.Box_SPath.Controls.Add(this.But_SPath_Find);
            this.Box_SPath.Controls.Add(this.CBox_SPath_To);
            this.Box_SPath.Controls.Add(this.CBox_SPath_From);
            this.Box_SPath.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_SPath.Location = new System.Drawing.Point(3, 63);
            this.Box_SPath.Name = "Box_SPath";
            this.Box_SPath.Size = new System.Drawing.Size(364, 54);
            this.Box_SPath.TabIndex = 1;
            this.Box_SPath.TabStop = false;
            this.Box_SPath.Text = "Нахождение кратчайшего пути между вершинами";
            // 
            // But_SPath_Find
            // 
            this.But_SPath_Find.Enabled = false;
            this.But_SPath_Find.Location = new System.Drawing.Point(168, 17);
            this.But_SPath_Find.Name = "But_SPath_Find";
            this.But_SPath_Find.Size = new System.Drawing.Size(190, 23);
            this.But_SPath_Find.TabIndex = 2;
            this.But_SPath_Find.Text = "Найти кратчайший путь";
            this.But_SPath_Find.UseVisualStyleBackColor = true;
            this.But_SPath_Find.Click += new System.EventHandler(this.But_SPath_Find_Click);
            // 
            // CBox_SPath_To
            // 
            this.CBox_SPath_To.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_SPath_To.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_SPath_To.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_SPath_To.Enabled = false;
            this.CBox_SPath_To.FormattingEnabled = true;
            this.CBox_SPath_To.Location = new System.Drawing.Point(87, 19);
            this.CBox_SPath_To.Name = "CBox_SPath_To";
            this.CBox_SPath_To.Size = new System.Drawing.Size(75, 21);
            this.CBox_SPath_To.TabIndex = 1;
            this.ToolTip_Main.SetToolTip(this.CBox_SPath_To, "Номер конечной вершины");
            // 
            // CBox_SPath_From
            // 
            this.CBox_SPath_From.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.CBox_SPath_From.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.CBox_SPath_From.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBox_SPath_From.Enabled = false;
            this.CBox_SPath_From.FormattingEnabled = true;
            this.CBox_SPath_From.Location = new System.Drawing.Point(6, 19);
            this.CBox_SPath_From.Name = "CBox_SPath_From";
            this.CBox_SPath_From.Size = new System.Drawing.Size(75, 21);
            this.CBox_SPath_From.TabIndex = 0;
            this.ToolTip_Main.SetToolTip(this.CBox_SPath_From, "Номер исходной вершины");
            // 
            // Box_Eulerian
            // 
            this.Box_Eulerian.Controls.Add(this.But_EuPath_Find);
            this.Box_Eulerian.Controls.Add(this.But_EuCycle_Find);
            this.Box_Eulerian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Eulerian.Location = new System.Drawing.Point(3, 123);
            this.Box_Eulerian.Name = "Box_Eulerian";
            this.Box_Eulerian.Size = new System.Drawing.Size(364, 54);
            this.Box_Eulerian.TabIndex = 2;
            this.Box_Eulerian.TabStop = false;
            this.Box_Eulerian.Text = "Эйлеровы алгоритмы";
            // 
            // But_EuPath_Find
            // 
            this.But_EuPath_Find.Enabled = false;
            this.But_EuPath_Find.Location = new System.Drawing.Point(185, 19);
            this.But_EuPath_Find.Name = "But_EuPath_Find";
            this.But_EuPath_Find.Size = new System.Drawing.Size(173, 23);
            this.But_EuPath_Find.TabIndex = 1;
            this.But_EuPath_Find.Text = "Найти Эйлеров путь";
            this.But_EuPath_Find.UseVisualStyleBackColor = true;
            this.But_EuPath_Find.Click += new System.EventHandler(this.But_EuPath_Find_Click);
            // 
            // But_EuCycle_Find
            // 
            this.But_EuCycle_Find.Enabled = false;
            this.But_EuCycle_Find.Location = new System.Drawing.Point(6, 19);
            this.But_EuCycle_Find.Name = "But_EuCycle_Find";
            this.But_EuCycle_Find.Size = new System.Drawing.Size(173, 23);
            this.But_EuCycle_Find.TabIndex = 0;
            this.But_EuCycle_Find.Text = "Найти Эйлеров цикл";
            this.But_EuCycle_Find.UseVisualStyleBackColor = true;
            this.But_EuCycle_Find.Click += new System.EventHandler(this.But_EuCycle_Find_Click);
            // 
            // Box_Hamiltonian
            // 
            this.Box_Hamiltonian.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Box_Hamiltonian.Location = new System.Drawing.Point(3, 183);
            this.Box_Hamiltonian.Name = "Box_Hamiltonian";
            this.Box_Hamiltonian.Size = new System.Drawing.Size(364, 54);
            this.Box_Hamiltonian.TabIndex = 3;
            this.Box_Hamiltonian.TabStop = false;
            this.Box_Hamiltonian.Text = "Гамильтоновы алгоритмы";
            // 
            // GraphCalcMForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 541);
            this.Controls.Add(this.TabControl_Main);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "GraphCalcMForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Калькулятор графов";
            this.Box_Vertex_Remove.ResumeLayout(false);
            this.Box_Edge_Add.ResumeLayout(false);
            this.Box_Edge_Add.PerformLayout();
            this.Tab_Main.ResumeLayout(false);
            this.Box_Edge_Remove.ResumeLayout(false);
            this.Box_Print_Control.ResumeLayout(false);
            this.Box_Graph_Create.ResumeLayout(false);
            this.Box_Graph_Create.PerformLayout();
            this.Box_Vertex_Add.ResumeLayout(false);
            this.Box_Vertex_Add.PerformLayout();
            this.Box_Edge_Change.ResumeLayout(false);
            this.Box_Edge_Change.PerformLayout();
            this.TabControl_Main.ResumeLayout(false);
            this.TabPage_Main.ResumeLayout(false);
            this.TabPage_Algorithms.ResumeLayout(false);
            this.Tab_Algorithms.ResumeLayout(false);
            this.Box_Traversals.ResumeLayout(false);
            this.Box_SPath.ResumeLayout(false);
            this.Box_Eulerian.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button But_Vertex_Add;
        private System.Windows.Forms.Button But_Edge_Add;
        private System.Windows.Forms.GroupBox Box_Vertex_Remove;
        private System.Windows.Forms.Button But_Vertex_Remove;
        private System.Windows.Forms.Button But_Edge_Remove;
        private System.Windows.Forms.GroupBox Box_Edge_Add;
        private System.Windows.Forms.TableLayoutPanel Tab_Main;
        private System.Windows.Forms.ComboBox CBox_Vertex_Remove;
        private System.Windows.Forms.ComboBox CBox_Edge_Add_To;
        private System.Windows.Forms.ComboBox CBox_Edge_Add_From;
        private System.Windows.Forms.GroupBox Box_Edge_Remove;
        private System.Windows.Forms.ComboBox CBox_Edge_Remove_To;
        private System.Windows.Forms.ComboBox CBox_Edge_Remove_From;
        private System.Windows.Forms.GroupBox Box_Print_Control;
        private System.Windows.Forms.Button But_Print_OUForm;
        private System.Windows.Forms.GroupBox Box_Graph_Create;
        private System.Windows.Forms.Button But_Graph_Create;
        private System.Windows.Forms.TextBox TBox_Graph_NumVer;
        private System.Windows.Forms.TextBox TBox_Edge_Add_Length;
        private System.Windows.Forms.GroupBox Box_Vertex_Add;
        private System.Windows.Forms.TextBox TBox_Vertex_Add;
        private System.Windows.Forms.GroupBox Box_Edge_Change;
        private System.Windows.Forms.Button But_Edge_Change;
        private System.Windows.Forms.TextBox TBox_Edge_Change_Length;
        private System.Windows.Forms.ComboBox CBox_Edge_Change_To;
        private System.Windows.Forms.ComboBox CBox_Edge_Change_From;
        private System.Windows.Forms.TabControl TabControl_Main;
        private System.Windows.Forms.TabPage TabPage_Main;
        private System.Windows.Forms.Button But_Print_File;
        private System.Windows.Forms.ComboBox CBox_Print_Mode;
        private System.Windows.Forms.Button But_Graph_Load;
        private System.Windows.Forms.TabPage TabPage_Algorithms;
        private System.Windows.Forms.TableLayoutPanel Tab_Algorithms;
        private System.Windows.Forms.GroupBox Box_Traversals;
        private System.Windows.Forms.ComboBox CBox_Traversal_Type;
        private System.Windows.Forms.ComboBox CBox_Traversal_From;
        private System.Windows.Forms.GroupBox Box_SPath;
        private System.Windows.Forms.ComboBox CBox_SPath_To;
        private System.Windows.Forms.ComboBox CBox_SPath_From;
        private System.Windows.Forms.GroupBox Box_Eulerian;
        private System.Windows.Forms.GroupBox Box_Hamiltonian;
        private System.Windows.Forms.Button But_Traverse;
        private System.Windows.Forms.Button But_SPath_Find;
        private System.Windows.Forms.Button But_EuPath_Find;
        private System.Windows.Forms.Button But_EuCycle_Find;
        private System.Windows.Forms.ToolTip ToolTip_Main;
        private System.Windows.Forms.CheckBox ChBox_Edge_Add_Oriented;
        private System.Windows.Forms.CheckBox ChBox_Edge_Change_Oriented;
    }
}

