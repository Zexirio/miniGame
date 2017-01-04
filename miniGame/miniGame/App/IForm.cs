namespace miniGame {
    interface IForm {
        void setClientButtonText(string Text);
        void setButtonStatus(string[] controlNames, bool[] status);
        void Chat(string msg);
    }
}
