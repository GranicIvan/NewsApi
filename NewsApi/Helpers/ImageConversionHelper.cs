namespace NewsApi.Helpers
{
    public static class ImageConversionHelper
    {

        public static  string ConvertImageToBase64(string imageUrl)
        {
            string result = string.Empty;

            if (imageUrl.EndsWith("png"))
            {
                result = "data:image/png;base64,";
            }
            else
            {
                result = "data:image/jpeg;base64,";
            }

            try {
                result += Convert.ToBase64String(File.ReadAllBytes(imageUrl));
            } 
            catch (Exception e)
            {
                result = string.Empty;
                Console.WriteLine(e.Message);
            }
            return result;

        }

    }
}
