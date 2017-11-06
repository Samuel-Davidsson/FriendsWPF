namespace FriendOrganizer.UI.View.Services
{
    public interface IMessageDialogService
    {
        MessageDialogResult ShowOkCancelDialoga(string text, string title);

        void ShowInfoDialog(string text);
    }
}