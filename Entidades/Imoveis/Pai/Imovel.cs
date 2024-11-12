using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entidades.Imoveis.Pai;

public class Imovel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    [BsonElement("tipo"), BsonRepresentation(BsonType.String)]
    public string Tipo { get; set; }
    [BsonElement("area"), BsonRepresentation(BsonType.Double)]
    public double Area { get; set; }
    [BsonElement("preco"), BsonRepresentation(BsonType.Double)]
    public double Preco { get; set; }
    [BsonElement("cep"), BsonRepresentation(BsonType.String)]
    public string CEP { get; set; }
    [BsonElement("rua"), BsonRepresentation(BsonType.String)]
    public string Rua { get; set; }
    [BsonElement("numero"), BsonRepresentation(BsonType.Int32)]
    public int Numero { get; set; }
    [BsonElement("bairro"), BsonRepresentation(BsonType.String)]
    public string Bairro { get; set; }
    [BsonElement("cidade"), BsonRepresentation(BsonType.String)]
    public string Cidade { get; set; }
    [BsonElement("unidade_federativa"), BsonRepresentation(BsonType.String)]
    public string UnidadeFederativa { get; set; }
    [BsonElement("endereco"), BsonRepresentation(BsonType.String)]
    public string Endereco { get; set;}
}