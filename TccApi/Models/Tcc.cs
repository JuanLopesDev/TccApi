using System.ComponentModel.DataAnnotations;

namespace TccApi.Models;

public class Tcc
{
    public int Id { get; set; }

    [Required]
    [StringLength(300)]
    public string TituloTCC { get; set; } = string.Empty;

    [Required]
    [StringLength(500)]
    public string Autores { get; set; } = string.Empty;

    [Required]
    [StringLength(200)]
    public string Orientador { get; set; } = string.Empty;

    [Required]
    public DateTime DataDeConclusao { get; set; }
}