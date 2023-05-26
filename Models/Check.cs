namespace Assignment2.Models
{
    public static class Check
    {

            public static string IDExists(productdbContext ctx,
            string productid)
            {
                string msg = "";
                if (!string.IsNullOrEmpty(productid))
                {
                    var product = ctx.Products.FirstOrDefault(
                        s => s.ProductId.ToLower() == productid.ToLower());
                    if (product != null)
                        msg = $"Product ID {productid} already in use.";
                }
                return msg;
            }
        
    }
}
