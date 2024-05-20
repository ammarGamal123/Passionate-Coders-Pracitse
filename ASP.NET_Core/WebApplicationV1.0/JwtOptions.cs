namespace WebApplicationV1._0
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }
        
        public int LifeTime { get; set; }
        
        public string SigningKey { get; set; }
    }

}
