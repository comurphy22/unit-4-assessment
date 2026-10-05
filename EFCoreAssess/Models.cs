using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

[Table("animals")]
public class Animal
{
    [Key]
    [Column("animal_id")]
    public int AnimalId { get; set; }

    [Required]
    [MaxLength(50)]
    [Column("name")]
    public string Name { get; set; } = null!;

    [Required]
    [MaxLength(25)]
    [Column("animal_species")]
    public string Species { get; set; } = null!;

    [Column("birth_year")]
    public int? BirthYear { get; set; }

    [Column("human_id")]
    public int HumanId { get; set; }

    [ForeignKey(nameof(HumanId))]
    public Human Human { get; set; } = null!;

    public override string ToString()
    {
        return $"<Animal AnimalId={AnimalId} Name={Name} Species={Species}>";
    }
}

[Table("humans")]
public class Human
{
    [Key]
    [Column("human_id")]
    public int HumanId { get; set; }

    [Required]
    [MaxLength(25)]
    [Column("fname")]
    public string FirstName { get; set; } = null!;

    [Required]
    [MaxLength(25)]
    [Column("lname")]
    public string LastName { get; set; } = null!;

    [Required]
    [MaxLength(100)]
    [Column("email")]
    public string Email { get; set; } = null!;

    public List<Animal> Animals { get; set; } = new();

    public override string ToString()
    {
        return $"<Human HumanId={HumanId} FirstName={FirstName}>";
    }
}
