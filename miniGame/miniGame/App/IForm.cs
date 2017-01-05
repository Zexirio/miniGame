namespace miniGame {
    interface IForm {
        void setButtonStatus(string[] controlNames, bool[] status);
        void Chat(string msg);
        void changeLabel(bool status);
    }
}
