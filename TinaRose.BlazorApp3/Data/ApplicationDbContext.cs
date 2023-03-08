using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using System.Reflection.Emit;

namespace TinaRose.BlazorApp3.Data;

public class ApplicationDbContext : IdentityDbContext
{
    private readonly IWebHostEnvironment _webHostEnvironment;
    

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IWebHostEnvironment webHostEnvironment)
        : base(options)
    {
        _webHostEnvironment = webHostEnvironment;
    }

    public DbSet<Agent> Agents { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<ProductItem> ProductItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // fluent api to ensure identity number is unique
        modelBuilder.Entity<Agent>().HasIndex(a => a.IdentityNumber).IsUnique();

        EnsureProductExists(modelBuilder, id: 1, name: "Full-Coverage Foundation",
            """
            Our full-coverage foundation is the perfect choice for anyone looking for a high-quality, heat-resistant foundation that will provide maximum coverage and leave your skin looking flawless all day long. With a formula that is specially designed to withstand heat and humidity, this foundation will stay in place no matter what the day brings.
            Featuring twenty unique shades to choose from, there is a perfect match for every skin tone. This foundation provides full coverage, helping to cover any imperfections, dark spots or blemishes, while still looking natural and feeling lightweight on the skin.
            Our foundation is formulated with high-quality ingredients that work to nourish and hydrate your skin, leaving it looking and feeling healthy and radiant. So whether you're heading to the office or out for a night on the town, you can trust our full-coverage foundation to keep you looking your best, no matter what.
            """,
            hasColors: true, price: 179.95m, imageName: "Full-Coverage-Foundation.jpg");

        EnsureProductExists(modelBuilder, id: 2, name: "Liquid Matt Foundation",
            """
            The Tina Rose Cosmetics Liquid Foundation is a high-quality, long-lasting foundation that is perfect for achieving a natural, matte finish. This foundation is specially formulated to be heat-resistant, making it an ideal choice for those living in warm climates or for use during outdoor activities. With twenty shades to choose from, there is a perfect match for every skin tone.
            The Tina Rose Cosmetics Liquid Foundation is a lightweight, oil-free formula that provides full coverage without clogging pores or feeling heavy on the skin. It blends seamlessly into the skin, creating a smooth, even finish that lasts all day. Whether you are looking for a natural, everyday look or need a foundation that can stand up to the rigors of an active lifestyle, the Tina Rose Cosmetics Liquid Foundation is the perfect choice.
            In addition to being heat-resistant, this foundation is also transfer-resistant, meaning it won't smudge or rub off on clothing. It is also resistant to sweat and humidity, making it a great choice for outdoor activities and sports. With a matte finish, it helps to control shine throughout the day, leaving your skin looking fresh and flawless.
            Like all Tina Rose Cosmetics products, the Liquid Foundation is made with only the finest ingredients, ensuring that it is gentle on even the most sensitive skin. Whether you are a makeup artist looking for a reliable foundation for your clients, or simply someone who wants to look their best all day long, the Tina Rose Cosmetics Liquid Foundation is the perfect choice.
            """,
            hasColors: true, price: 179.95m, imageName: "Liquid-Foundation.jpg");

        EnsureProductExists(modelBuilder, id: 3, name: "Face Powder",
            """
            Introducing Tina Rose's line of powders, the perfect finish to any makeup routine. Our powders come in a wide range of colors, from the fairest skin tones to the darkest. These powders are perfect for setting makeup, reducing shine, and giving your skin a soft, velvety finish. The powders are made with the same high-quality ingredients as our other products and are heat-resistant, ensuring your makeup stays in place all day. With 20 shades to choose from, you're sure to find the perfect powder to complement your skin tone.
            """,
            hasColors: true, price: 89.95m, imageName: "Face-Powder.jpg");

        EnsureProductExists(modelBuilder, id: 4, name: "Translucent Powder",
            """
            Introducing Tina Rose's line of powders, the perfect finish to any makeup routine. Our powders come in a wide range of colors, from the fairest skin tones to the darkest. These powders are perfect for setting makeup, reducing shine, and giving your skin a soft, velvety finish. The powders are made with the same high-quality ingredients as our other products and are heat-resistant, ensuring your makeup stays in place all day. With 20 shades to choose from, you're sure to find the perfect powder to complement your skin tone.
            """,
            hasColors: false, price: 89.95m, imageName: "Face-Powder.jpg");
    }

    // for seeding the initial product list
    private int productItemId;

    private void EnsureProductExists(ModelBuilder modelBuilder, int id, string name, string description, bool hasColors, decimal price, string imageName)
    {
        // Get the path to the file
        string imagePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products", imageName);

        var imageBytes = File.ReadAllBytes(imagePath);

        var product = new Product
        {
            Id = id,
            Name = name,
            Description = description,
            Price = price,
            IsApproved = true,
            ImageBytes = imageBytes
        };
        EnsureProductExists(modelBuilder, product);

        if (hasColors)
        {
            EnsureProductItemExists(code: "A", name: "Pearl", description: "A very light shade for the fairest skin tones.", color: "FDFDFD");
            EnsureProductItemExists(code: "B", name: "Ivory", description: "A very light shade with a yellow undertone.", color: "F9E3CF");
            EnsureProductItemExists(code: "C", name: "Porcelain", description: "A light shade with a neutral undertone.", color: "F2D1B1");
            EnsureProductItemExists(code: "D", name: "Vanilla", description: "A light shade with a pink undertone.", color: "E8B794");
            EnsureProductItemExists(code: "E", name: "Cream", description: "A light shade with a yellow undertone.", color: "E1A67B");
            EnsureProductItemExists(code: "F", name: "Beige", description: "A light to medium shade with a neutral undertone.", color: "D58E5F");
            EnsureProductItemExists(code: "G", name: "Sand", description: "A medium shade with a yellow undertone.", color: "C97B4D");
            EnsureProductItemExists(code: "H", name: "Honey", description: "A medium shade with a golden undertone.", color: "BD6B3C");
            EnsureProductItemExists(code: "I", name: "Tan", description: "A medium shade with a neutral undertone.", color: "B35F31");
            EnsureProductItemExists(code: "J", name: "Toffee", description: "A medium to dark shade with a golden undertone.", color: "9D4C23");
            EnsureProductItemExists(code: "K", name: "Caramel", description: "A medium to dark shade with a neutral undertone.", color: "8C3F1A");
            EnsureProductItemExists(code: "L", name: "Mocha", description: "A dark shade with a red undertone.", color: "7B3517");
            EnsureProductItemExists(code: "M", name: "Coffee", description: "A dark shade with a neutral undertone.", color: "6A2C13");
            EnsureProductItemExists(code: "N", name: "Chocolate", description: "A dark shade with a warm undertone.", color: "59230F");
            EnsureProductItemExists(code: "O", name: "Espresso", description: "A very dark shade with a red undertone.", color: "481A0C");
            EnsureProductItemExists(code: "P", name: "Ebony", description: "A very dark shade with a neutral undertone.", color: "38140A");
            EnsureProductItemExists(code: "Q", name: "Mahogany", description: "A very dark shade with a cool undertone.", color: "2D0F07");
            EnsureProductItemExists(code: "R", name: "Sable", description: "A very dark shade with a warm undertone.", color: "220B04");
            EnsureProductItemExists(code: "S", name: "Onyx", description: "A very dark shade with a cool undertone.", color: "170702");
            EnsureProductItemExists(code: "T", name: "Midnight", description: "A very dark shade with a cool undertone.", color: "0C0301");
        }

        void EnsureProductItemExists(string code, string name, string description, string color)
        {
            var item = new ProductItem
            {
                Id = ++productItemId,
                ProductId = product.Id,
                Code = code,
                Name = name,
                Description = description,
                Color = color,
            };
            modelBuilder.Entity<ProductItem>()
                .HasData(item);
        }
    }

    private void EnsureProductExists(ModelBuilder modelBuilder, Product product)
    {
        modelBuilder.Entity<Product>()
            .HasData(product);
    }
}

public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public string? Description { get; set; }
    public byte[]? ImageBytes { get; set; }
    public bool IsApproved { get; set; }
    public decimal Price { get; set; }
    public decimal? SalePrice { get; set; }

    public virtual ICollection<ProductItem>? Items { get; set; }
    public virtual ICollection<ProductColor>? Colors { get; set; }

    public string GetImageUrl()
    {
        if (ImageBytes == null || ImageBytes.Length == 0)
        {
            return string.Empty;
        }

        var base64 = Convert.ToBase64String(ImageBytes);
        return $"data:image/png;base64,{base64}";
    }

}

public class ProductColor
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }

    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    public string Description { get;  set; }
    public string Color { get;  set; }
}
public class ProductItem
{
    public int Id { get; set; }
    public required string Code { get; set; }
    public required string Name { get; set; }

    public int? ProductId { get; set; }
    public Product? Product { get; set; }
    public string Description { get;  set; }
    public string Color { get;  set; }
}