namespace CommonCMS.Model.System
{
    public class JsonResponseModel
    {
        public bool isError { get; set; } = true;
        public string strMessage { get; set; } = "";
        public string type { get; set; } = PopupMessageType.error.ToString();
        public dynamic result { get; set; }
    }

}