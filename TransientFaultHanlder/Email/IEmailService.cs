namespace TransientFaultHanlder
{
    internal interface IEmailService
    {
        Result<string> Send();
        Result<string> Send(Email email);
        RestResult<string> SendMocky();
        RestResult<string> SendMocky(Email email);
    }
}
