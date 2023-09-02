using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphClasses;

namespace GraphCalcuculator
{
    public partial class GraphCalcMForm : Form
    {

        #region Form class fields and properties

        internal Graph curGraph;

        #endregion

        #region Form layout methods

        public GraphCalcMForm()
        {
            InitializeComponent();
            curGraph = new Graph();
            string vertexNumToolTip = ToolTip_Main.GetToolTip(TBox_Vertex_Add) + Environment.NewLine +
                                      $"Должен быть целым числом между 1 и {ushort.MaxValue:N0}.";
            string edgeLenToolTip = ToolTip_Main.GetToolTip(TBox_Edge_Add_Length) + Environment.NewLine +
                                    $"Должна быть целым числом от 1 до {Graph.MaxEdgeLen:N0}";
            ToolTip_Main.SetToolTip(TBox_Vertex_Add, vertexNumToolTip);
            ToolTip_Main.SetToolTip(TBox_Edge_Add_Length, edgeLenToolTip);
            ToolTip_Main.SetToolTip(TBox_Edge_Change_Length, edgeLenToolTip);
            CBox_Print_Mode.SelectedIndex = 0;
            CBox_Traversal_Type.SelectedIndex = 0;
        }

        internal void Refresh_Vertices()
        {
            List<ushort> verLst = curGraph.VerticesId.ToList();
            if (verLst.Any())
            {
                TBox_Vertex_Add.Enabled = curGraph.VertexCount < Graph.MaxVertexNum;

                CBox_Vertex_Remove.DataSource = verLst.ToList();
                CBox_Vertex_Remove.Enabled = true;
                But_Vertex_Remove.Enabled = true;

                CBox_Edge_Add_From.DataSource = verLst.ToList();
                CBox_Edge_Add_From.Enabled = true;

                CBox_Edge_Change_From.DataSource = verLst.ToList();
                CBox_Edge_Change_From.Enabled = true;

                CBox_Edge_Remove_From.DataSource = verLst.ToList();
                CBox_Edge_Remove_From.Enabled = true;

                CBox_Traversal_From.DataSource = verLst.ToList();
                CBox_Traversal_From.Enabled = true;
                CBox_Traversal_Type.Enabled = true;
                But_Traverse.Enabled = true;

                CBox_SPath_From.DataSource = verLst.ToList();
                CBox_SPath_From.Enabled = true;
                CBox_SPath_To.DataSource = verLst.ToList();
                CBox_SPath_To.Enabled = true;
                But_SPath_Find.Enabled = true;

                But_EuCycle_Find.Enabled = true;
                But_EuPath_Find.Enabled = true;
            }
            else
            {
                CBox_Vertex_Remove.DataSource = null;
                CBox_Vertex_Remove.Enabled = false;
                But_Vertex_Remove.Enabled = false;

                CBox_Edge_Add_From.DataSource = null;
                CBox_Edge_Add_From.Enabled = false;
                CBox_Edge_Add_To.DataSource = null;
                CBox_Edge_Add_To.Enabled = false;
                TBox_Edge_Add_Length.Text = string.Empty;
                TBox_Edge_Add_Length.Enabled = false;
                ChBox_Edge_Add_Oriented.Checked = false;
                ChBox_Edge_Add_Oriented.Enabled = false;
                But_Edge_Add.Enabled = false;

                CBox_Edge_Change_From.DataSource = null;
                CBox_Edge_Change_From.Enabled = false;
                CBox_Edge_Change_To.DataSource = null;
                CBox_Edge_Change_To.Enabled = false;
                TBox_Edge_Change_Length.Text = string.Empty;
                TBox_Edge_Change_Length.Enabled = false;
                ChBox_Edge_Change_Oriented.Checked = false;
                ChBox_Edge_Change_Oriented.Enabled = false;
                But_Edge_Change.Enabled = false;

                CBox_Edge_Remove_From.DataSource = null;
                CBox_Edge_Remove_From.Enabled = false;
                CBox_Edge_Remove_To.DataSource = null;
                CBox_Edge_Remove_To.Enabled = false;
                But_Edge_Remove.Enabled = false;

                CBox_Traversal_From.DataSource = null;
                CBox_Traversal_From.Enabled = false;
                CBox_Traversal_Type.Enabled = false;
                But_Traverse.Enabled = false;

                CBox_SPath_From.DataSource = null;
                CBox_SPath_From.Enabled = false;
                CBox_SPath_To.DataSource = null;
                CBox_SPath_To.Enabled = false;
                But_SPath_Find.Enabled = false;

                But_EuCycle_Find.Enabled = false;
                But_EuPath_Find.Enabled = false;
            }
        }

        private void Refresh_Edges()
        {
            CBox_Edge_Add_From_SelectedIndexChanged(null, null);
            CBox_Edge_Change_From_SelectedIndexChanged(null, null);
            CBox_Edge_Remove_From_SelectedIndexChanged(null, null);
        }

        #endregion

        #region Auxiliary methods

        private bool TBox_Empty(TextBox TBox) => string.IsNullOrEmpty(TBox.Text);

        private void IncorEdgeLen() => StaticElements.MBoxError($"Длина ребра должна быть целым числом от 1 до {Graph.MaxEdgeLen:N0}!");

        private void RetrieveFailed(string cause)
        {
            StaticElements.MBoxError("Ошибка извлечения данных графа!" + Environment.NewLine +
                                     $"{cause}" + Environment.NewLine +
                                     "Данные перезагружены.");
            Refresh_Vertices();
        }

        #endregion

        #region Graph change methods

        #region Add vertex methods

        private void TBox_Vertex_Add_TextChanged(object sender, EventArgs e) => But_Vertex_Add.Enabled = !TBox_Empty(TBox_Vertex_Add);

        private void But_Vertex_Add_Click(object sender, EventArgs e)
        {
            if (!ushort.TryParse(TBox_Vertex_Add.Text, out ushort ver) || ver == 0)
            {
                StaticElements.MBoxError($"Номер вершины должен быть целым числом от 1 до {Graph.MaxVertexNum:N0}!");
                return;
            }
            else if (!curGraph.AddVertex(ver)) StaticElements.MBoxError($"Вершина {ver} уже существует.");
            TBox_Vertex_Add.Text = string.Empty;
            Refresh_Vertices();
        }

        #endregion

        #region Remove vertex methods

        private void But_Vertex_Remove_Click(object sender, EventArgs e)
        {
            ushort ver = (ushort)CBox_Vertex_Remove.SelectedItem;
            if (StaticElements.MBoxAttentionRefuse($"Вы уверены, что хотите удалить вершину {ver}?")) return;
            if (!curGraph.RemoveVertex(ver)) StaticElements.MBoxError($"Вершина {ver} не существует.");
            Refresh_Vertices();
        }

        #endregion

        #region Add edge methods

        private void CBox_Edge_Add_From_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBox_Edge_Add_From.DataSource is null) return;
            try
            {
                List<ushort> verLst = curGraph.GetAvailOutEdges((ushort)CBox_Edge_Add_From.SelectedValue).ToList();
                TBox_Edge_Add_Length.Text = string.Empty;
                if (verLst.Any())
                {
                    CBox_Edge_Add_To.DataSource = verLst;
                    CBox_Edge_Add_To.Enabled = true;
                    TBox_Edge_Add_Length.Enabled = true;
                }
                else
                {
                    CBox_Edge_Add_To.DataSource = null;
                    CBox_Edge_Add_To.Enabled = false;
                    TBox_Edge_Add_Length.Enabled = false;
                }
            }
            catch (Exception ex) { RetrieveFailed(ex.Message); }
        }

        private void CBox_Edge_Add_To_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBox_Edge_Add_To.DataSource is null) return;
            ushort from = (ushort)CBox_Edge_Add_From.SelectedItem,
                   to = (ushort)CBox_Edge_Add_To.SelectedItem;
            bool isLoop = from == to;
            ChBox_Edge_Add_Oriented.Enabled = !isLoop;
            if (isLoop) ChBox_Edge_Add_Oriented.Checked = false;
        }

        private void TBox_Edge_Add_Length_TextChanged(object sender, EventArgs e) => But_Edge_Add.Enabled = !TBox_Empty(TBox_Edge_Add_Length);

        private void But_Edge_Add_Click(object sender, EventArgs e)
        {
            if (!uint.TryParse(TBox_Edge_Add_Length.Text, out uint len) ||
                len == 0 || len > Graph.MaxEdgeLen)
            {
                IncorEdgeLen();
                return;
            }
            ushort from = (ushort)CBox_Edge_Add_From.SelectedItem,
                   to = (ushort)CBox_Edge_Add_To.SelectedItem;
            bool isDir = ChBox_Edge_Add_Oriented.Checked;
            EdgeData revEdge = curGraph.GetEdgeState(to, from);
            if (!isDir && revEdge.Exists && revEdge.IsDir &&
                    StaticElements.MBoxAttentionRefuse($"Существует ориентированное ребро {to}-{from}, при продолжении оно будет удалено!" + Environment.NewLine +
                                                       "Продолжить?")) return;
            if (!curGraph.AddEdge(from, to, len, isDir))
            {
                StaticElements.MBoxError($"Ребро {from} - {to} уже существует.");
                Refresh_Vertices();
            }
            else
            {
                Refresh_Edges();
                TBox_Edge_Add_Length.Text = string.Empty;
                ChBox_Edge_Add_Oriented.Checked = false;
            }
        }

        #endregion

        #region Change edge methods

        private void CBox_Edge_Change_From_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBox_Edge_Change_From.DataSource is null) return;
            try
            {
                List<ushort> verlst = curGraph.GetExistOutEdges((ushort)CBox_Edge_Change_From.SelectedItem).ToList();
                if (verlst.Any())
                {
                    CBox_Edge_Change_To.DataSource = verlst;
                    CBox_Edge_Change_To.Enabled = true;
                    TBox_Edge_Change_Length.Enabled = true;
                }
                else
                {
                    CBox_Edge_Change_To.DataSource = null;
                    CBox_Edge_Change_To.Enabled = false;
                    TBox_Edge_Change_Length.Text = string.Empty;
                    TBox_Edge_Change_Length.Enabled = false;
                }
            }
            catch (Exception ex) { RetrieveFailed(ex.Message); }
        }

        private void CBox_Edge_Change_To_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBox_Edge_Change_To.DataSource is null) return;
            ushort from = (ushort)CBox_Edge_Change_From.SelectedItem,
                   to = (ushort)CBox_Edge_Change_To.SelectedItem;
            try
            {
                EdgeData curEdge = curGraph.GetEdgeState(from, to);
                TBox_Edge_Change_Length.Text = curEdge.Length.ToString();
                ChBox_Edge_Change_Oriented.Checked = curEdge.IsDir;
                ChBox_Edge_Change_Oriented.Enabled = from != to;
            }
            catch (Exception ex) { RetrieveFailed(ex.Message); }
        }

        private void TBox_Edge_Change_Length_TextChanged(object sender, EventArgs e) =>
            But_Edge_Change.Enabled = !TBox_Empty(TBox_Edge_Change_Length);

        private void But_Edge_Change_Click(object sender, EventArgs e)
        {
            if (!uint.TryParse(TBox_Edge_Change_Length.Text, out uint len) ||
                len == 0 || len > Graph.MaxEdgeLen)
            {
                IncorEdgeLen();
                return;
            }
            ushort from = (ushort)CBox_Edge_Change_From.SelectedItem,
                   to = (ushort)CBox_Edge_Change_To.SelectedItem;
            bool isDir = ChBox_Edge_Add_Oriented.Checked;
            EdgeData revEdge = curGraph.GetEdgeState(to, from);
            if (!isDir && revEdge.Exists && revEdge.IsDir &&
                    StaticElements.MBoxAttentionRefuse($"Существует ориентированное ребро {to}-{from}, при продолжении оно будет удалено!" + Environment.NewLine +
                                                       "Продолжить?")) return;
            if (!curGraph.ChangeEdge(from, to, len, isDir))
            {
                StaticElements.MBoxError($"Ребро {from} - {to} не существует.");
                Refresh_Vertices();
            }
            else Refresh_Edges();
        }

        #endregion

        #region Remove edge methods

        private void CBox_Edge_Remove_From_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CBox_Edge_Remove_From.DataSource is null) return;
            try
            {
                List<ushort> verlst = curGraph.GetExistOutEdges((ushort)CBox_Edge_Remove_From.SelectedItem).ToList();
                if (verlst.Any())
                {
                    CBox_Edge_Remove_To.DataSource = verlst;
                    CBox_Edge_Remove_To.Enabled = true;
                    But_Edge_Remove.Enabled = true;
                }
                else
                {
                    CBox_Edge_Remove_To.DataSource = null;
                    CBox_Edge_Remove_To.Enabled = false;
                    But_Edge_Remove.Enabled = false;
                }
            }
            catch(Exception ex)
            {
                RetrieveFailed(ex.Message);
            }
        }

        private void But_Edge_Remove_Click(object sender, EventArgs e)
        {
            ushort from = (ushort)CBox_Edge_Change_From.SelectedItem,
                   to = (ushort)CBox_Edge_Change_To.SelectedItem;
            if (!curGraph.RemoveEdge(from, to))
            {
                StaticElements.MBoxError($"Ребро {from} - {to} не существует.");
                Refresh_Vertices();
            }
            else Refresh_Edges();
        }

        #endregion

        #endregion

        #region Output control methods

        private void CBox_Print_Mode_SelectedIndexChanged(object sender, EventArgs e) =>
            But_Print_OUForm.Enabled = CBox_Print_Mode.SelectedIndex == 0;

        private string GetOutStr()
        {
            switch(CBox_Print_Mode.SelectedIndex)
            {
                case 0: return curGraph.ToVerEdgSets();
                default: return curGraph.ToAdjMtx();
            }
        }

        private void But_Print_File_Click(object sender, EventArgs e)
        {
            string oupfile;
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                sfd.Filter = CBox_Print_Mode.SelectedIndex == 0 ?
                             "Файл графа (*.gra)|*.gra" :
                             "Файл CSV (*.csv)|*.csv";
                if (sfd.ShowDialog() != DialogResult.OK) return;
                oupfile = sfd.FileName;
            }
            try
            {
                File.WriteAllText(oupfile, GetOutStr());
                StaticElements.MBoxInfo("Сохранение завершено!");
            }
            catch(Exception ex)
            {
                StaticElements.MBoxError("Не удалось сохранить граф!" + Environment.NewLine +
                                          $"{ex.Message}");
            }
        }

        private void But_Print_OUForm_Click(object sender, EventArgs e)
        {
            string outStr = GetOutStr();
            GraphCalcOForm oform = new GraphCalcOForm(this, "Представление графа", outStr, true);
            oform.ShowDialog();
        }

        #endregion

        #region Graph initialization methods

        #region Create graph methods

        private void TBox_Graph_NumVer_TextChanged(object sender, EventArgs e) => But_Graph_Create.Enabled = !TBox_Empty(TBox_Graph_NumVer);

        private void But_Graph_Create_Click(object sender, EventArgs e)
        {
            string strnumver = TBox_Graph_NumVer.Text;
            if (!ushort.TryParse(strnumver, out ushort numver))
            {
                StaticElements.MBoxError($"Количество вершин должно быть неотрицательным целым числом, не превышающим {Graph.MaxVertexNum:N0}!");
                return;
            }
            if (StaticElements.MBoxNewGraphRefuse()) return;
            try { curGraph = new Graph(numver); }
            catch (Exception ex)
            { StaticElements.MBoxGraphCreationFailed(ex.Message); }
            Refresh_Vertices();
            TBox_Graph_NumVer.Text = string.Empty;
        }

        #endregion

        #region Load graph methods

        private void But_Graph_Load_Click(object sender, EventArgs e)
        {
            string inpfile;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                ofd.Filter = "Файлы графов (*.gra, *.csv)|*.gra;*.csv";
                if (ofd.ShowDialog() != DialogResult.OK) return;
                inpfile = ofd.FileName;
            }
            try
            {
                Graph newGraph = new Graph(File.ReadAllLines(inpfile));
                if (StaticElements.MBoxNewGraphRefuse()) return;
                curGraph = newGraph;
                Refresh_Vertices();
            }
            catch (Exception ex) { StaticElements.MBoxGraphCreationFailed(ex.Message); }
        }

        #endregion

        #endregion

        #region Graph algorithms
        private void But_Traverse_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDft = CBox_Traversal_Type.SelectedIndex == 0;
                ushort start = (ushort)CBox_Traversal_From.SelectedItem;
                string output = $"Обход в {(isDft ? "глубину" : "ширину")} из вершины {start}:" + Environment.NewLine +
                                curGraph.GetTraversal(start, isDft);
                GraphCalcOForm oform = new GraphCalcOForm(this, "Обход графа", output, false);
                oform.ShowDialog();
            }
            catch (Exception ex)
            {
                StaticElements.MBoxError(ex.Message);
                Refresh_Vertices();
            }
        }

        private void But_SPath_Find_Click(object sender, EventArgs e)
        {
            try
            {
                ushort from = (ushort)CBox_SPath_From.SelectedItem,
                       to = (ushort)CBox_SPath_To.SelectedItem;
                GraphClasses.Path result = curGraph.FindShortestPath(from, to);
                if (result is null)
                {
                    StaticElements.MBoxInfo($"Путь из {from} в {to} не существует.");
                    return;
                }
                GraphCalcOForm oform = new GraphCalcOForm(this,
                                                                  $"Кратчайший путь из {from} в {to}",
                                                                  result.FullInfo(),
                                                                  false);
                oform.ShowDialog();
            }
            catch (Exception ex)
            {
                StaticElements.MBoxError(ex.Message);
                Refresh_Vertices();
            }
        }

        private void EulerianAlgorithmGeneral(bool needCycle)
        {
            GraphClasses.Path result = curGraph.FindEulerianPath();
            if (result is null)
            {
                StaticElements.MBoxInfo($"Эйлеров {(needCycle ? "цикл" : "путь")} не существует.");
                return;
            }
            bool isCycle = result.IsCycle;
            string type = $"Эйлеров {(isCycle && needCycle ? "цикл" : "путь")}",
                   output = $"{type}:" + Environment.NewLine +
                            result;
            GraphCalcOForm oform = new GraphCalcOForm(this, type, output, false);
            if (!needCycle ||
                isCycle ||
                StaticElements.MBoxAttentionAccept("Эйлеров цикл не найден, но найден эйлеров путь." + Environment.NewLine +
                                                   "Показать его?"))
                oform.ShowDialog();
        }

        private void But_EuCycle_Find_Click(object sender, EventArgs e) => EulerianAlgorithmGeneral(true);

        private void But_EuPath_Find_Click(object sender, EventArgs e) => EulerianAlgorithmGeneral(false);
        #endregion
    }
}
