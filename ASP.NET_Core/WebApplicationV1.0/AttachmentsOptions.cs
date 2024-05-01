namespace WebApplicationV1._0
{
    public class AttachmentsOptions
    {
        /*
{
    "AllowedExtensions": "jpg;jpeg;bmp;png",
    "MaxSizeInMegaBytes": 1,
    "EnableCompression": true
  }

         */
        public string AllowedExtensions { get; set; }

        public int MaxSizeInMegaBytes { get; set; }

        public bool EnableComperession { get; set; }

    }
}
