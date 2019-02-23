namespace ShoppingCart
{
    internal class APIContext
    {
        private object accessToken;

        public APIContext(object accessToken)
        {
            this.accessToken = accessToken;
        }
    }
}