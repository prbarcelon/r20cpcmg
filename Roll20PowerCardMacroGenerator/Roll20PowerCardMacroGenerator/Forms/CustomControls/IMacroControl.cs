namespace Roll20PowerCardMacroGenerator.Forms.CustomControls
{
    public interface IMacroControl
    {
        void Init(Tag tag);
        Tag TagSettings { get; }
        string GetTagContentString();
    }
}