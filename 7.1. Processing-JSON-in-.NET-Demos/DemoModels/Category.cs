namespace DemoModels
{
    using System.Collections.Generic;

    public class Category
    {
        private static int lastCategoryId;
        private static Dictionary<string, Category> categories;

        static Category()
        {
            lastCategoryId = 0;
            categories = new Dictionary<string, Category>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public static Category Get(string categoryName)
        {
            var categoryNameToLower = categoryName.ToLower();
            if (!categories.ContainsKey(categoryNameToLower))
            {
                categories[categoryNameToLower] = new Category
                {
                    Id = ++lastCategoryId,
                    Name = categoryName
                };
            }
            return categories[categoryNameToLower];
        }

        public override string ToString()
        {
            return string.Format("Id: {0}, Name: {1}", this.Id, this.Name);
        }
    }
}
