using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entidades.Imoveis.Pai;

public class Imovel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Tipo { get; set; }
    public double Area { get; set; }
    public double Preco { get; set; }
    public int Anos { get; set; }
    public string CEP { get; set; }
    public string Rua { get; set; }
    public int? Numero { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string UnidadeFederativa { get; set; }
    public string Endereco { get; set;}
    public List<string> URLsImagens { get; set; }
    public string Descricao { get; set; }
    public List<string> AreasComuns { get; set; }
}