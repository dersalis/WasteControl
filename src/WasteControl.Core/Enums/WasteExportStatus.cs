using System.ComponentModel;

namespace WasteControl.Core.Enums
{
    public enum WasteExportStatus : int
    {
        [Description("Waiting")]
        Waiting = 0,

        [Description("Loaded")]
        Loaded = 1,

        [Description("Finished")]
        Finished = 2
    }
}