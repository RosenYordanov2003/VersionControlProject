namespace VersionControlProject.Responses
{
    public class LoginResponseModel : AuthResponseModel
    {
        public LoginResponseModel(bool success, params string[] errors) : base(success, errors)
        {
        }
        public string? Token { get; set; }
    }
}
