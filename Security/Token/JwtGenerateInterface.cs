namespace BE_TALENTO.Security.token
{
    public interface JwtGenerateInterface
    {
        string CreateToken(int prmNumUserId, string prmVarUserEmail, string prmVarFullName);
    }
}