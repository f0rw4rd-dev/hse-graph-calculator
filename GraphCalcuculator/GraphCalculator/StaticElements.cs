using System;
using System.Windows.Forms;

namespace GraphCalcuculator
{
    internal static class StaticElements
    {

        #region Fields

        internal const string attStr = "Внимание!";
        internal const string errStr = "Ошибка!";
        internal const string infStr = "Информация.";

        #endregion

        #region Message box methods

        internal static DialogResult MBoxAttention(string message) => MessageBox.Show(message, attStr, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
        internal static bool MBoxAttentionAccept(string message) => MBoxAttention(message) == DialogResult.Yes;
        internal static bool MBoxAttentionRefuse(string message) => MBoxAttention(message) == DialogResult.No;
        internal static void MBoxError(string message) => MessageBox.Show(message, errStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
        internal static void MBoxInfo(string message)=> MessageBox.Show(message, infStr, MessageBoxButtons.OK, MessageBoxIcon.Information);
        internal static bool MBoxNewGraphRefuse() => MBoxAttentionRefuse("Предыдущий граф будет удалён!" + Environment.NewLine +
                                                                                        "Продолжить?");
        internal static void MBoxGraphCreationFailed(string error) => MBoxError(error + Environment.NewLine +
                                                                                               "Граф не изменён.");

        #endregion

    }
}
